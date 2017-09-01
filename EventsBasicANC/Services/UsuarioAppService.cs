using AutoMapper;
using EventsBasicANC.Authorization;
using EventsBasicANC.Data.Repository.Interfaces;
using EventsBasicANC.Domain.Models.Enums;
using EventsBasicANC.Models;
using EventsBasicANC.Services.Interfaces;
using EventsBasicANC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EventsBasicANC.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signManager;
        private readonly JwtTokenOptions _jwtTokenOptions;
        private readonly IContaRepository _contaRepository;
        private readonly IConta_FuncionarioRepository _conta_funcionarioRepository;
        private readonly IMapper _mapper;

        public UsuarioAppService(IOptions<JwtTokenOptions> jwtTokenOptions, UserManager<Usuario> userManager, SignInManager<Usuario> signManager, IContaRepository contaRepository, IConta_FuncionarioRepository conta_funcionarioRepository, IMapper mapper)
        {
            _userManager = userManager;
            _signManager = signManager;
            _jwtTokenOptions = jwtTokenOptions.Value;
            _contaRepository = contaRepository;
            _conta_funcionarioRepository = conta_funcionarioRepository;
            _mapper = mapper;

            ThrowIfInvalidOptions(_jwtTokenOptions);
        }

        private static long ToUnixEpochDate(DateTime date) =>
         (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        public async Task<object> ObterTokenUsuario(UsuarioLoginViewModel loginViewModel)
        {
            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
            var userClaims = await _userManager.GetClaimsAsync(user);

            userClaims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, await _jwtTokenOptions.JtiGenerator()));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtTokenOptions.IssueAt).ToString(), ClaimValueTypes.Integer64));

            var jwt = new JwtSecurityToken(
                issuer: _jwtTokenOptions.Issuer,
                audience: _jwtTokenOptions.Audience,
                claims: userClaims,
                notBefore: _jwtTokenOptions.NotBefore,
                expires: _jwtTokenOptions.Expiration,
                signingCredentials: _jwtTokenOptions.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                expirese_in = (int)_jwtTokenOptions.ValidFor.TotalSeconds,
            };

            return response;
        }

        private static void ThrowIfInvalidOptions(JwtTokenOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(JwtTokenOptions));

            if (options.ValidFor <= TimeSpan.Zero)
            {
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(JwtTokenOptions.ValidFor));
            }
            if (options.SigningCredentials == null)
            {
                throw new ArgumentNullException(nameof(JwtTokenOptions.SigningCredentials));
            }
            if (options.JtiGenerator == null)
            {
                throw new ArgumentNullException(nameof(JwtTokenOptions.SigningCredentials));
            }
        }

        public async Task<UsuarioViewModel> CriarLojaPorOrganizador(NovaLojaViewModel novaLojaViewModel)
        {
            Usuario usuario = new Usuario { UserName = novaLojaViewModel.Login , Email = novaLojaViewModel.Login};

            Guid id_usuarioGuid = Guid.Parse(usuario.Id);

            var result = await _signManager.UserManager.CreateAsync(usuario, novaLojaViewModel.Senha);
            if (!result.Succeeded) return null;

            Contrato contrato = new Contrato
            {
                Id_evento = novaLojaViewModel.Id_evento,
                Id_loja = id_usuarioGuid,
                Id_organizador = novaLojaViewModel.Id_conta_organizador
            };

            Conta conta_loja = new Conta
            {
                Id = id_usuarioGuid,
                NomeFantasia = novaLojaViewModel.NomeFantasia,
                RazaoSocial = novaLojaViewModel.RazaoSocial,
                Tipo = ContaTipo.Loja,
                Endereco = new Endereco { Id = id_usuarioGuid, Bairro = novaLojaViewModel.Endereco.Bairro, Cidade = novaLojaViewModel.Endereco.Cidade, Estado = novaLojaViewModel.Endereco.Estado, Rua = novaLojaViewModel.Endereco.Rua },
                Contato = new Contato { Id = id_usuarioGuid, Documento = novaLojaViewModel.Contato.Documento, DocumentoTipo = novaLojaViewModel.Contato.DocumentoTipo.Value, NomeCompleto = novaLojaViewModel.Contato.NomeCompleto, Email = novaLojaViewModel.Contato.Email, EmailAdicional = novaLojaViewModel.Contato.EmailAdicional, Telefone = novaLojaViewModel.Contato.Telefone, Telefone2 = novaLojaViewModel.Contato.Telefone2 },
            };

            conta_loja.Organizador_Contratos = new List<Contrato>() { contrato };

            try
            {
                var contaCriada = _contaRepository.Criar(conta_loja);
            }
            catch (Exception e)
            {
                var usuarioParaDeletar = await _signManager.UserManager.FindByIdAsync(usuario.Id);
                await _signManager.UserManager.DeleteAsync(usuarioParaDeletar);
            }

            return _mapper.Map<UsuarioViewModel>(usuario);
        }

        public async Task<UsuarioViewModel> CriarFuncionario(NovoFuncionarioViewModel novoFuncionarioViewModel)
        {
            Usuario usuario = new Usuario { UserName = novoFuncionarioViewModel.Login ,Email = novoFuncionarioViewModel.Login };

            Guid id_usuarioGuid = Guid.Parse(usuario.Id);

            var result = await _signManager.UserManager.CreateAsync(usuario, novoFuncionarioViewModel.Senha);
            if (!result.Succeeded) return null;

            var conta = _contaRepository.TrazerPorId(novoFuncionarioViewModel.Id_conta);

            Conta funcionario = new Conta
            {
                Id = id_usuarioGuid,
                Tipo = ContaTipo.Funcionario,
                Contato = new Contato { Id = id_usuarioGuid, NomeCompleto = novoFuncionarioViewModel.NomeCompleto },
                Endereco = new Endereco { Id = id_usuarioGuid },
            };

            try
            {
                var contaCriada = _contaRepository.Criar(funcionario);
                Conta_Funcionario contaFuncionario = new Conta_Funcionario { Id_conta = novoFuncionarioViewModel.Id_conta, Id_funcionario = funcionario.Id };
                _conta_funcionarioRepository.Criar(contaFuncionario);
            }
            catch (Exception e)
            {
                var usuarioParaDeletar = await _signManager.UserManager.FindByIdAsync(usuario.Id);
                await _signManager.UserManager.DeleteAsync(usuarioParaDeletar);
            }

            return _mapper.Map<UsuarioViewModel>(usuario);
        }

    }
}
