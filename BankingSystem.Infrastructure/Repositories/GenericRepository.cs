using BankingSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        protected GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public T? GetById(int? id)
        {
            Logger.Info("GetById for " + typeof(T).Name + " with id=" + id);

            return _context.Set<T>().Find(id);
        }


        public IEnumerable<T> GetAll()
        {
            Logger.Info("GetAll for " + typeof(T).Name);

            return _context.Set<T>().ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            Logger.Info("Find for " + typeof(T).Name);

            return _context.Set<T>().Where(expression);
        }


        public void Add(T entity)
        {
            Logger.Info("Add for " + typeof(T).Name);
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            Logger.Info("Delete for " + typeof(T).Name);

            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            Logger.Info("Update for " + typeof(T).Name);

            _context.Set<T>().Update(entity);
        }
    }
}
