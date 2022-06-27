using BankingSystem.Domain.Interfaces;
using BankingSystem.Infrastructure;
using System;

namespace BankingSystem.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ILimitRepository Limits { get; }
        public ITransactionRepository Transactions { get; }
        public IUserRepository Users { get; }


        public UnitOfWork(ApplicationDbContext bankingDbContext,
            ILimitRepository limitRepository,
            ITransactionRepository transactionRepository,
            IUserRepository userRepository
            )
        {
            _context = bankingDbContext;
            Limits = limitRepository;
            Transactions = transactionRepository;
            Users = userRepository;


        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
