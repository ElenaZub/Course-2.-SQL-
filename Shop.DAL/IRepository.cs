﻿using ShopDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.DAL
{
    public interface IRepository<TEntity> : IDisposable
    {
        IEnumerable<TEntity> Get();

        TEntity GetById(int carId);

        void Delete(TEntity entity);

        void DeleteById(int entityId);

        void Update(TEntity entity);

        void Add(TEntity entity);

        void Save();
        IEnumerable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null, Func<System.Linq.IQueryable<TEntity>, System.Linq.IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
    }
}
