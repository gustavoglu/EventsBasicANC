using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using EventsBasicANC.Data.Repository.Interfaces;
using EventsBasicANC.Models;
using EventsBasicANC.Util;
using EventsBasicANC.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EventsBasicANC.Data.Repository
{
    public class VendaRepository : Repository<Venda>, IVendaRepository
    {
        private bool IsPrivate() => _easyClaims.isPrivate("Vendas").Result;
        private bool IsPrincipal() => _easyClaims.isPrincipal("Vendas").Result;
        private bool IsAdmin() => _easyClaims.isAdmin().Result;
        private readonly EasyClaims _easyClaims;
        private readonly IUser _user;
        private readonly IEventoRepository _eventoRepository;


        public VendaRepository(SQLSContext sqlsContext, EasyClaims easyClaims, IUser user, IEventoRepository eventoRepository) : base(sqlsContext)
        {
            _user = user;
            _easyClaims = easyClaims;
            _eventoRepository = eventoRepository;

        }


        public override IEnumerable<Venda> TrazerTodos()
        {
            if (_user.IsAuthenticated())
            {
                var id_user = _user.GetUserId();

                if (IsPrincipal())
                {

                    var eventos = _eventoRepository.Pesquisar(e => e.Id_organizador == id_user);
                    if (!eventos.Any()) return null;

                    var vendas = DbSet.Include(v => v.Evento)
                                    .Where(v => v.Evento.Id_organizador == id_user);

                    return vendas;
                }

                if (IsPrivate())
                {
                    var vendas = DbSet.Include(v => v.Conta)
                                 .Where(v => v.Conta.Id == id_user);


                    return vendas;
                }
            }

            return base.TrazerTodos();
        }

        public override IEnumerable<Venda> TrazerTodosAtivos()
        {
            if (_user.IsAuthenticated())
            {
                var id_user = _user.GetUserId();

                if (IsPrincipal())
                {

                    var eventos = _eventoRepository.Pesquisar(e => e.Id_organizador == id_user);
                    if (!eventos.Any()) return null;

                    var vendas = DbSet.Include(v => v.Evento)
                                    .Where(v => v.Evento.Id_organizador == id_user && v.Deletado == false);

                    return vendas;
                }

                if (IsPrivate())
                {
                    var vendas = DbSet.Include(v => v.Conta)
                                 .Where(v => v.Conta.Id == id_user && v.Deletado == false);


                    return vendas;
                }
            }

            return base.TrazerTodosAtivos();
        }

        public override IEnumerable<Venda> TrazerTodosDeletados()
        {
            if (_user.IsAuthenticated())
            {
                var id_user = _user.GetUserId();

                if (IsPrincipal())
                {

                    var eventos = _eventoRepository.Pesquisar(e => e.Id_organizador == id_user);
                    if (!eventos.Any()) return null;

                    var vendas = DbSet.Include(v => v.Evento)
                                    .Where(v => v.Evento.Id_organizador == id_user && v.Deletado == true);

                    return vendas;
                }

                if (IsPrivate())
                {
                    var vendas = DbSet.Include(v => v.Conta)
                                 .Where(v => v.Conta.Id == id_user && v.Deletado == true);


                    return vendas;
                }
            }
            return base.TrazerTodosDeletados();
        }

        public override Venda TrazerAtivoPorId(Guid id)
        {
            if (_user.IsAuthenticated())
            {
                var id_user = _user.GetUserId();

                if (IsPrincipal())
                {

                    var eventos = _eventoRepository.Pesquisar(e => e.Id_organizador == id_user);
                    if (!eventos.Any()) return null;

                    var venda = DbSet.Include(v => v.Evento)
                                    .FirstOrDefault(v => v.Evento.Id_organizador == id_user && v.Id == id && v.Deletado == false);

                    return venda;
                }

                if (IsPrivate())
                {
                    var venda = DbSet.Include(v => v.Conta)
                                 .FirstOrDefault(v => v.Conta.Id == id_user && v.Deletado == false && v.Id == id);
                               

                    return venda;
                }
            }

            return base.TrazerAtivoPorId(id);
        }

        public override Venda TrazerDeletadoPorId(Guid id)
        {
            if (_user.IsAuthenticated())
            {
                var id_user = _user.GetUserId();

                if (IsPrincipal())
                {

                    var eventos = _eventoRepository.Pesquisar(e => e.Id_organizador == id_user);
                    if (!eventos.Any()) return null;

                    var venda = DbSet.Include(v => v.Evento)
                                    .FirstOrDefault(v => v.Evento.Id_organizador == id_user && v.Id == id && v.Deletado == true);

                    return venda;
                }

                if (IsPrivate())
                {
                    var venda = DbSet.Include(v => v.Conta)
                                 .FirstOrDefault(v => v.Conta.Id == id_user && v.Deletado == true && v.Id == id);


                    return venda;
                }
            }

            return base.TrazerDeletadoPorId(id);
        }

        public override Venda TrazerPorId(Guid id)
        {
            if (_user.IsAuthenticated())
            {
                var id_user = _user.GetUserId();

                if (IsPrincipal())
                {

                    var eventos = _eventoRepository.Pesquisar(e => e.Id_organizador == id_user);
                    if (!eventos.Any()) return null;

                    var venda = DbSet.Include(v => v.Evento)
                                    .FirstOrDefault(v => v.Evento.Id_organizador == id_user && v.Id == id);

                    return venda;
                }

                if (IsPrivate())
                {
                    var venda = DbSet.Include(v => v.Conta)
                                 .FirstOrDefault(v => v.Conta.Id == id_user && v.Id == id);


                    return venda;
                }
            }

            return base.TrazerPorId(id);
        }


        public override IEnumerable<Venda> Pesquisar(Expression<Func<Venda, bool>> predicate)
        {
            if (_user.IsAuthenticated())
            {
                var id_user = _user.GetUserId();

                if (IsPrincipal())
                {

                    var eventos = _eventoRepository.Pesquisar(e => e.Id_organizador == id_user);
                    if (!eventos.Any()) return default(IEnumerable<Venda>);

                    var vendas = DbSet.Include(v => v.Evento)
                                    .Where(v => v.Evento.Id_organizador == id_user)
                                    .Where(predicate);

                    return vendas;
                }

                if (IsPrivate())
                {
                    var vendas = DbSet.Include(v => v.Conta)
                                 .Where(v => v.Conta.Id == id_user)
                                 .Where(predicate);

                    return vendas;
                }
            }

            return base.Pesquisar(predicate);
        }

        public override IEnumerable<Venda> PesquisarAtivos(Expression<Func<Venda, bool>> predicate)
        {
            if (_user.IsAuthenticated())
            {
                var id_user = _user.GetUserId();

                if (IsPrincipal())
                {

                    var eventos = _eventoRepository.Pesquisar(e => e.Id_organizador == id_user);
                    if (!eventos.Any()) return default(IEnumerable<Venda>);

                    var vendas = DbSet.Include(v => v.Evento)
                                    .Where(v => v.Evento.Id_organizador == id_user && v.Deletado == false)
                                    .Where(predicate);

                    return vendas;
                }

                if (IsPrivate())
                {
                    var vendas = DbSet.Include(v => v.Conta)
                                 .Where(v => v.Conta.Id == id_user && v.Deletado == false)
                                 .Where(predicate);

                    return vendas;
                }
            }

            return base.PesquisarAtivos(predicate);
        }

        public override IEnumerable<Venda> PesquisarDeletados(Expression<Func<Venda, bool>> predicate)
        {
            if (_user.IsAuthenticated())
            {
                var id_user = _user.GetUserId();

                if (IsPrincipal())
                {

                    var eventos = _eventoRepository.Pesquisar(e => e.Id_organizador == id_user);
                    if (!eventos.Any()) return default(IEnumerable<Venda>);

                    var vendas = DbSet.Include(v => v.Evento)
                                    .Where(v => v.Evento.Id_organizador == id_user && v.Deletado == true)
                                    .Where(predicate);

                    return vendas;
                }

                if (IsPrivate())
                {
                    var vendas = DbSet.Include(v => v.Conta)
                                 .Where(v => v.Conta.Id == id_user && v.Deletado == true)
                                 .Where(predicate);

                    return vendas;
                }
            }

            return base.PesquisarDeletados(predicate);
        }
    }
}
