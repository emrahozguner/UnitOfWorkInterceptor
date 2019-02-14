﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace WebApi.Repository.Base
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);

        IQueryable<T> SelectAll();

        T GetBy(Expression<Func<T, bool>> expression);

        IQueryable<T> SelectBy(Expression<Func<T, bool>> expression);

        int Insert(T entity);

        void Update(T entity);
    }
}