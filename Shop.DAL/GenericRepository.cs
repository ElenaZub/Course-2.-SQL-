using System;
using System.Collections.Generic;
using ShopDAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Shop.DAL
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private CarDBContext context;
        private DbSet<TEntity> dbSet;
        private bool disposed = false;

        public GenericRepository(CarDBContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()
        {
            IQueryable<TEntity> query = this.dbSet;

            return query.ToList();
        }

        public void Add(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            if (this.context.Entry(entity).State == EntityState.Detached)
                this.dbSet.Attach(entity);

            this.dbSet.Remove(entity);
        }

        public void DeleteById(int entityId)
        {
            TEntity entityToDelete = this.dbSet.Find(entityId);
            this.Delete(entityToDelete);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                    this.context.Dispose();

            this.disposed = true;
        }

        public TEntity GetById(int entityId)
        {
            return this.dbSet.Find(entityId);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            this.dbSet.Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
        }
    }
}
