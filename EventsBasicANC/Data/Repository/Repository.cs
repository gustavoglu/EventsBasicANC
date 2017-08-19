using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using EventsBasicANC.Data.Repository.Interfaces;
using EventsBasicANC.Models;

namespace EventsBasicANC.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected SQLSContext Db;

        protected DbSet<T> DbSet;

        public Repository(SQLSContext sqlsContext )
        {
            Db = sqlsContext;
            DbSet = Db.Set<T>();
        }

        public virtual void Atualizar(T entity)
        {
            DbSet.Update(entity);
        }

        public virtual void Criar(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual T TrazerAtivoPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual T TrazerDeletadoPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual T TrazerPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> Pesquisar(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> PesquisarAtivos(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> PesquisarDeletados(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> TrazerTodos()
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> TrazerTodosAtivos()
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> TrazerTodosDeletados()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
