using EventsBasicANC.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EventsBasicANC.Data.Repository.Interfaces
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        void Criar(T entity);

        void Atualizar(T entity);

        T TrazerPorId(Guid id);

        T TrazerAtivoPorId(Guid id);

        T TrazerDeletadoPorId(Guid id);

        IEnumerable<T> TrazerTodos();

        IEnumerable<T> TrazerTodosAtivos();

        IEnumerable<T> TrazerTodosDeletados();

        IEnumerable<T> Pesquisar(Expression<Func<T,bool>> predicate);

        IEnumerable<T> PesquisarAtivos(Expression<Func<T, bool>> predicate);

        IEnumerable<T> PesquisarDeletados(Expression<Func<T, bool>> predicate);
    }
}
