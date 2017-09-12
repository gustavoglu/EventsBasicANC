using EventsBasicANC.Data.Repository.Interfaces;
using EventsBasicANC.Models;
using EventsBasicANC.Util;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;
using EventsBasicANC.Interfaces;
using System.Linq;

namespace EventsBasicANC.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        private bool IsPrivate() => _easyClaims.isPrivate("Produtos").Result;
        private bool IsPrincipal() => _easyClaims.isPrincipal("Produtos").Result;
        private bool IsAdmin() => _easyClaims.isAdmin().Result;
        private readonly IContratoRepository _contratoRepository;
        private readonly IConta_FuncionarioRepository _conta_FuncionarioRepository;
        private readonly IUser _user;
        private readonly EasyClaims _easyClaims;

        public ProdutoRepository(SQLSContext sqlsContext, IConta_FuncionarioRepository conta_FuncionarioRepository, IContratoRepository contratoRepository, IUser user, EasyClaims easyClaims) : base(sqlsContext)
        {
            _contratoRepository = contratoRepository;
            _conta_FuncionarioRepository = conta_FuncionarioRepository;
            _user = user;
            _easyClaims = easyClaims;
        }

        public override IEnumerable<Produto> TrazerTodos()
        {

            if (_user.IsAuthenticated())
            {
                var id_user = _user.GetUserId();

                if (IsPrincipal())
                {
                    var contratos = _contratoRepository.PesquisarAtivos(c => c.Id_organizador == id_user);
                    if (!contratos.Any()) return new List<Produto>();

                    var produtos = from contrato in contratos
                                   from produto in this.Pesquisar(p => p.Id_loja == contrato.Id_loja).ToList()
                                   select produto;

                    return produtos;
                }

                if (IsPrivate())
                {
                    var conta_funcionario = _conta_FuncionarioRepository.PesquisarAtivos(cf => cf.Id_funcionario == id_user).FirstOrDefault();
                    if (conta_funcionario != null) return this.Pesquisar(p => p.Id_loja == conta_funcionario.Id_conta);
                    this.Pesquisar(p => p.Id_loja == id_user);
                }

                if (IsAdmin())
                {
                    return base.TrazerTodos();
                }
            }

            return null;
        }

        public override IEnumerable<Produto> TrazerTodosAtivos()
        {
            if (_user.IsAuthenticated())
            {
                var id_user = _user.GetUserId();

                if (IsPrincipal())
                {
                    var contratos = _contratoRepository.PesquisarAtivos(c => c.Id_organizador == id_user);

                    if (!contratos.Any()) return new List<Produto>();

                    var produtos = from contrato in contratos
                                   from produto in this.PesquisarAtivos(p => p.Id_loja == contrato.Id_loja)
                                   select produto;

                    return produtos;
                }

                if (IsPrivate())
                {
                    var conta_funcionario = _conta_FuncionarioRepository.PesquisarAtivos(cf => cf.Id_funcionario == id_user).FirstOrDefault();
                    if (conta_funcionario != null) return this.PesquisarAtivos(p => p.Id_loja == conta_funcionario.Id_conta);
                    this.PesquisarAtivos(p => p.Id_loja == id_user);
                }
            }
            return base.TrazerTodos();
        }

        public override IEnumerable<Produto> TrazerTodosDeletados()
        {
            if (_user.IsAuthenticated())
            {
                var id_user = _user.GetUserId();

                if (IsPrincipal())
                {
                    var contratos = _contratoRepository.PesquisarAtivos(c => c.Id_organizador == id_user);
                    if (!contratos.Any()) return new List<Produto>(); ;

                    var produtos = from contrato in contratos
                                   from produto in this.PesquisarDeletados(p => p.Id_loja == contrato.Id_loja)
                                   select produto;

                    return produtos;
                }

                if (IsPrivate())
                {
                    var conta_funcionario = _conta_FuncionarioRepository.PesquisarAtivos(cf => cf.Id_funcionario == id_user).FirstOrDefault();
                    if (conta_funcionario != null) return this.PesquisarDeletados(p => p.Id_loja == conta_funcionario.Id_conta);
                    this.PesquisarDeletados(p => p.Id_loja == id_user);
                }

                if (IsAdmin())
                {
                    return base.TrazerTodos();
                }
            }

            return null;
        }

        public override Produto TrazerPorId(Guid id)
        {
            if (_user.IsAuthenticated())
            {
                var id_user = _user.GetUserId();

                if (IsPrincipal())
                {
                    var contratos = _contratoRepository.PesquisarAtivos(c => c.Id_organizador == id_user);
                    if (!contratos.Any()) return null;

                    var produtos = from contrato in contratos
                                   from produto in this.Pesquisar(p => p.Id_loja == contrato.Id_loja)
                                   where produto.Id == id
                                   select produto;

                    return produtos.FirstOrDefault();
                }

                if (IsPrivate())
                {
                    var conta_funcionario = _conta_FuncionarioRepository.PesquisarAtivos(cf => cf.Id_funcionario == id_user).FirstOrDefault();
                    if (conta_funcionario != null) return this.Pesquisar(p => p.Id_loja == conta_funcionario.Id_conta && p.Id == id).FirstOrDefault();
                    this.Pesquisar(p => p.Id_loja == id_user && p.Id == id).FirstOrDefault();
                }

                if (IsAdmin())
                {
                    return base.TrazerPorId(id);
                }
            }

            return null;
        }

        public override Produto TrazerDeletadoPorId(Guid id)
        {
            if (_user.IsAuthenticated())
            {
                var id_user = _user.GetUserId();

                if (IsPrincipal())
                {
                    var contratos = _contratoRepository.PesquisarAtivos(c => c.Id_organizador == id_user);
                    if (!contratos.Any()) return null;

                    var produtos = from contrato in contratos
                                   from produto in this.PesquisarDeletados(p => p.Id_loja == contrato.Id_loja)
                                   where produto.Id == id
                                   select produto;

                    return produtos.FirstOrDefault();
                }

                if (IsPrivate())
                {
                    var conta_funcionario = _conta_FuncionarioRepository.PesquisarAtivos(cf => cf.Id_funcionario == id_user).FirstOrDefault();
                    if (conta_funcionario != null) return this.PesquisarDeletados(p => p.Id_loja == conta_funcionario.Id_conta && p.Id == id).FirstOrDefault();
                    this.PesquisarDeletados(p => p.Id_loja == id_user && p.Id == id).FirstOrDefault();
                }

                if (IsAdmin())
                {
                    return base.TrazerDeletadoPorId(id);
                }
            }

            return null;
        }

        public override Produto TrazerAtivoPorId(Guid id)
        {
            if (_user.IsAuthenticated())
            {
                var id_user = _user.GetUserId();

                if (IsPrincipal())
                {
                    var contratos = _contratoRepository.PesquisarAtivos(c => c.Id_organizador == id_user);
                    if (!contratos.Any()) return null;

                    var produtos = from contrato in contratos
                                   from produto in this.PesquisarAtivos(p => p.Id_loja == contrato.Id_loja).ToList()
                                   where produto.Id == id
                                   select produto;

                    return produtos.FirstOrDefault();
                }

                if (IsPrivate())
                {
                    var conta_funcionario = _conta_FuncionarioRepository.PesquisarAtivos(cf => cf.Id_funcionario == id_user).FirstOrDefault();
                    if (conta_funcionario != null) return this.PesquisarAtivos(p => p.Id_loja == conta_funcionario.Id_conta && p.Id == id).FirstOrDefault();
                    this.PesquisarAtivos(p => p.Id_loja == id_user && p.Id == id).FirstOrDefault();
                }

                if (IsAdmin())
                {
                    return base.TrazerAtivoPorId(id);
                }
            }

            return null;
        }

        public override IEnumerable<Produto> Pesquisar(Expression<Func<Produto, bool>> predicate)
        {
            if (_user.IsAuthenticated())
            {
                var id_user = _user.GetUserId();

                if (IsPrincipal())
                {
                    var contratos = _contratoRepository.PesquisarAtivos(c => c.Id_organizador == id_user);
                    if (!contratos.Any()) return new List<Produto>();

                    var produtos = from contrato in contratos
                                   from produto in this.DbSet.Where(p => p.Id_loja == contrato.Id_loja).Where(predicate).ToList()
                                   select produto;

                    return produtos;
                }

                if (IsPrivate())
                {
                    var conta_funcionario = _conta_FuncionarioRepository.PesquisarAtivos(cf => cf.Id_funcionario == id_user).FirstOrDefault();
                    if (conta_funcionario != null) return this.DbSet.Where(p => p.Id_loja == conta_funcionario.Id_conta).Where(predicate);
                    this.DbSet.Where(p => p.Id_loja == id_user).Where(predicate);
                }
            }

            return base.Pesquisar(predicate);
        }

        public override IEnumerable<Produto> PesquisarAtivos(Expression<Func<Produto, bool>> predicate)
        {
            if (_user.IsAuthenticated())
            {
                var id_user = _user.GetUserId();

                if (IsPrincipal())
                {
                    var contratos = _contratoRepository.PesquisarAtivos(c => c.Id_organizador == id_user);
                    if (!contratos.Any()) return new List<Produto>();

                    var produtos = from contrato in contratos
                                   from produto in this.DbSet.Where(p => p.Id_loja == contrato.Id_loja).AsQueryable().Where(predicate)
                                   where produto.Deletado == false
                                   select produto;

                    return produtos;
                }

                if (IsPrivate())
                {
                    var conta_funcionario = _conta_FuncionarioRepository.PesquisarAtivos(cf => cf.Id_funcionario == id_user).FirstOrDefault();
                    if (conta_funcionario != null) return this.DbSet.Where(p => p.Id_loja == conta_funcionario.Id_conta && p.Deletado == false).Where(predicate);
                    this.DbSet.Where(p => p.Id_loja == id_user && p.Deletado == false).Where(predicate);
                }
            }

            return base.PesquisarAtivos(predicate);
        }

        public override IEnumerable<Produto> PesquisarDeletados(Expression<Func<Produto, bool>> predicate)
        {
            if (_user.IsAuthenticated())
            {
                var id_user = _user.GetUserId();

                if (IsPrincipal())
                {
                    var contratos = _contratoRepository.PesquisarAtivos(c => c.Id_organizador == id_user);

                    if (!contratos.Any()) return new List<Produto>();

                    var produtos = from contrato in contratos
                                   from produto in this.DbSet.Where(p => p.Id_loja == contrato.Id_loja).Where(predicate).ToList()
                                   where produto.Deletado == true
                                   select produto;

                    return produtos;
                }

                if (IsPrivate())
                {
                    var conta_funcionario = _conta_FuncionarioRepository.PesquisarAtivos(cf => cf.Id_funcionario == id_user).FirstOrDefault();
                    if (conta_funcionario != null) return this.DbSet.Where(p => p.Id_loja == conta_funcionario.Id_conta && p.Deletado == true).Where(predicate);
                    this.DbSet.Where(p => p.Id_loja == id_user && p.Deletado == true).Where(predicate);
                }
            }

            return base.PesquisarDeletados(predicate);
        }
    }
}
