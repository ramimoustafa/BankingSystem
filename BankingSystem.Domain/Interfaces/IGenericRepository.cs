﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class

    {
        T? GetById(int? id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

    }
}
