using BankingSystem.Domain.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Transaction>()
            //    .HasOne(x => x.SourceAccount)
            //    .WithMany(x => x.SourceTransactions)
            //    .HasForeignKey(x => x.SourceAccountId)
            //    .OnDelete(DeleteBehavior.ClientSetNull);

            //modelBuilder.Entity<Transaction>()
            //    .HasOne(x => x.DestinationAccount)
            //    .WithMany(x => x.DestinationTransactions)
            //    .HasForeignKey(x => x.DestinationAccountId)
            //    .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Transaction>()
          .HasOne(x => x.SourceAccount)
          .WithMany(x => x.SourceTransactions)
          .HasForeignKey(x => x.SourceAccountNumber)
          .HasPrincipalKey(x => x.Number);

            modelBuilder.Entity<Transaction>()
        .HasOne(x => x.DestinationAccount)
        .WithMany(x => x.DestinationTransactions)
        .HasForeignKey(x => x.DestinationAccountNumber)
        .HasPrincipalKey(x => x.Number);

        }
        public DbSet<Account> Account { get; set; }
        public DbSet<AccountType> AccountType { get; set; }
        public DbSet<Branch> Branch { get; set; }

        public DbSet<Currency> Currency { get; set; }

        public DbSet<CurrencyType> CurrencyType { get; set; }
        public DbSet<Gender> Gender { get; set; }

        public DbSet<Limit> Limit { get; set; }
        public DbSet<LimitAccountType> LimitAccountType { get; set; }
        public DbSet<LimitTransferType> LimitTransferType { get; set; }
        public DbSet<LocationType> LocationType { get; set; }
        public DbSet<ObjectType> ObjectType { get; set; }
        public DbSet<PeriodType> PeriodType { get; set; }

        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<TransferType> TransferType { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserType> UserType { get; set; }




    }
}