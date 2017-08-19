using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using EventsBasicANC.Data.Repository.Interfaces;
using EventsBasicANC.Models;
using System.Linq;

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

        public virtual T Atualizar(T entity)
        {
            var a = DbSet.Update(entity);
            SaveChanges();
            return DbSet.Find(entity);
        }

        public virtual T Criar(T entity)
        {
            DbSet.Add(entity);
            SaveChanges();
            return DbSet.Find(entity);
        }

        public virtual T Criar(ICollection<T> entitys)
        {
            foreach (var entity in entitys) DbSet.Add(entity);
            
            SaveChanges();
            return DbSet.Find(entitys);
        }

        public virtual T Deletar(Guid id)
        {
            var entityDeleted = DbSet.FirstOrDefault(e => e.Id == id);
            DbSet.Remove(entityDeleted);
            return entityDeleted;
        }

        public virtual T TrazerAtivoPorId(Guid id)
        {
            return DbSet.FirstOrDefault(e => e.Id == id && e.Deletado == false);
        }

        public virtual T TrazerDeletadoPorId(Guid id)
        {
            return DbSet.FirstOrDefault(e => e.Id == id && e.Deletado == true);
        }

        public virtual T TrazerPorId(Guid id)
        {
            return DbSet.FirstOrDefault(e => e.Id == id);
        }

        public virtual IEnumerable<T> Pesquisar(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual IEnumerable<T> PesquisarAtivos(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate).Where(e => e.Deletado == false);
        }

        public virtual IEnumerable<T> PesquisarDeletados(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate).Where(e => e.Deletado == true);
        }

        public virtual IEnumerable<T> TrazerTodos()
        {
            return DbSet;
        }

        public virtual IEnumerable<T> TrazerTodosAtivos()
        {
            return DbSet.Where(e => e.Deletado == false);
        }

        public virtual IEnumerable<T> TrazerTodosDeletados()
        {
            return DbSet.Where(e => e.Deletado == true);
        }

        protected int SaveChanges()
        {
            return this.Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
