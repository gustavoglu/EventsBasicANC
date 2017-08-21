using AutoMapper;
using EventsBasicANC.Authorization;
using EventsBasicANC.Data.Repository.Interfaces;
using EventsBasicANC.Models;
using EventsBasicANC.Services.Interfaces;
using EventsBasicANC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
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
        private readonly IMapper _mapper;

        public UsuarioAppService(IOptions<JwtTokenOptions> jwtTokenOptions, UserManager<Usuario> userManager,SignInManager<Usuario> signManager, IContaRepository contaRepository, IMapper mapper)
        {
            _userManager = userManager;
            _signManager = signManager;
            _jwtTokenOptions = jwtTokenOptions.Value;
            _contaRepository = contaRepository;
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
    }
}
