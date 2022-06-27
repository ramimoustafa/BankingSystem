using BankingSystem.Domain.Interfaces;
using BankingSystem.Domain.Models.DTO;
using BankingSystem.Domain.Models.Request;
using BankingSystem.Domain.Models.Response;
using BankingSystem.Infrastructure.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Infrastructure.Repositories
{
    public class LimitRepository : GenericRepository<Limit>, ILimitRepository
    {
        private readonly IMemoryCache _memoryCache;

        public LimitRepository(ApplicationDbContext context, IMemoryCache memoryCache) : base(context)
        {
            _memoryCache = memoryCache;
        }


        public List<Limit> GetLimits()
        {
            List<Limit> limits = null;

            limits = _context.Limit
            .Include(l => l.ObjectType)
            .Include(l => l.CurrencyType)
            .Include(l => l.LocationType)
            .Include(l => l.LimitTransferTypes)
            .Include(l => l.LimitAccountTypes)
            .ToList();

             

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromDays(30));

            _memoryCache.Set("CachedLimits", limits, cacheEntryOptions);

            return limits;

        }

        public ResponseModel IsEligible(TransferRequest transferRequest, HttpContext context)
        {
            List<Limit> limits = new List<Limit>();
            User? sourceUser = GetUser(transferRequest.SourceAccountNumber);
            User? destinationUser = GetUser(transferRequest.SourceAccountNumber);
            bool isSourceEligible = true;
            bool isDestinationEligible = true;
            double sourceAmount = 0;
            double destinationAmount = 0;
            ResponseModel responseModel = new ResponseModel();


            Account? sourceAccount = _context.Account.Where(a => a.Number == transferRequest.SourceAccountNumber).FirstOrDefault();
            Account? destinationAccount = _context.Account.Where(a => a.Number == transferRequest.DestinationAccountNumber).FirstOrDefault();

            CurrencyTypeEnum currencyType = CheckTransferCurrencyType(transferRequest.SourceAccountNumber, transferRequest.DestinationAccountNumber);
            int transfertypeid = 1;



            limits = _memoryCache.Get<List<Limit>?>("CachedLimits");
            if (limits==null)
                limits = GetLimits();

            List<Limit> sourceRequiredLimits = limits
                                                    .Where(x => x.ObjectTypeId == (int)ObjectTypEnum.User && x.ObjectId == sourceUser.Id
                                                    || x.ObjectTypeId == (int)ObjectTypEnum.UserType && x.ObjectId == sourceUser.UserTypeId
                                                    || (x.ObjectTypeId == null && x.IsTransferTypeRule && x.LimitTransferTypes.Select(lt => lt.TransferTypeId).ToList().Contains(transferRequest.TransferTypeId))
                                                    || (x.ObjectTypeId == null && x.IsAccountTypeRule && x.LimitAccountTypes.Select(la => la.AccountTypeId).ToList().Contains(sourceAccount.AccountTypeId))
                                                    || (x.ObjectTypeId == null && x.CurrencyTypeId == (int)currencyType)).ToList();

            List<Limit> destinationRequiredLimits = limits
                                                    .Where(x => x.ObjectTypeId == (int)ObjectTypEnum.User && x.ObjectId == destinationUser.Id
                                                    || x.ObjectTypeId == (int)ObjectTypEnum.UserType && x.ObjectId == destinationUser.UserTypeId
                                                    || (x.ObjectTypeId == null && x.IsTransferTypeRule && x.LimitTransferTypes.Select(lt => lt.TransferTypeId).ToList().Contains(transferRequest.TransferTypeId))
                                                    || (x.ObjectTypeId == null && x.IsAccountTypeRule && x.LimitAccountTypes.Select(la => la.AccountTypeId).ToList().Contains(destinationAccount.AccountTypeId))
                                                    || (x.ObjectTypeId == null && x.CurrencyTypeId == (int)currencyType)).ToList();

            foreach (Limit limit in sourceRequiredLimits)
            {
                sourceAmount = GetTotalAmount(transferRequest.SourceAccountNumber, limit.MaxAmountPeriodTypeId, limit.MaxAmounPeriodValue) + transferRequest.Amount;
                if (sourceAmount > limit.MaxAmount)
                {
                    isSourceEligible = false;
                    break;
                }

            }
            foreach (Limit limit in destinationRequiredLimits)
            {
                destinationAmount = GetTotalAmount(transferRequest.DestinationAccountNumber, limit.MaxAmountPeriodTypeId, limit.MaxAmounPeriodValue) + transferRequest.Amount;
                if (destinationAmount > limit.MaxAmount)
                {
                    isDestinationEligible = false;
                    break;
                }

            }
            if (isSourceEligible && isDestinationEligible)
                responseModel = Helper.ReturnResponse(500, "Eligible", null, context);
            else 
                responseModel = Helper.ReturnResponse(400, "You cannot proceed with this transaction", null, context);

            return responseModel;
        }


        public User? GetUser(int accountNumber)
        {
            int userId = _context.Account.Where(a => a.Number == accountNumber).Select(a => a.UserId).FirstOrDefault();

            User? user = _context.User.Where(u => u.Id == userId).FirstOrDefault();

            return user;
        }



        public double GetTotalAmount(int accountNumber, int PeriodType, int PeriodValue)
        {
            DateTime to = DateTime.Now;
            DateTime from = new DateTime();
            double amount = 0;

            switch (PeriodType)
            {
                case (int)PeriodTypeEnum.Minutes:
                    from = to.AddMinutes(-PeriodValue);
                    break;
                case (int)PeriodTypeEnum.Hourly:
                    from = to.AddHours(-PeriodValue);
                    break;
                case (int)PeriodTypeEnum.Daily:
                    from = to.AddDays(-PeriodValue);
                    break;
                case (int)PeriodTypeEnum.Weekly:
                    from = to.AddDays(-7 * PeriodValue);
                    break;
                case (int)PeriodTypeEnum.Monthly:
                    from = to.AddMonths(-PeriodValue);
                    break;
                case (int)PeriodTypeEnum.Yearly:
                    from = to.AddMonths(-PeriodValue);
                    break;

            }
            amount = _context.Transaction
                      .Where(t => (t.SourceAccountNumber == accountNumber ||
                              t.DestinationAccountNumber == accountNumber)
                              && t.Created >= from && t.Created <= to)
                              .Select(t => t.Amount).Sum();
            return amount;

        }
 


        public CurrencyTypeEnum CheckTransferCurrencyType(int sourceAccountNumber, int destinationAccountNumber)
        {
            string? sourceCurrencyCode = _context.Account.Include(a => a.Currency)
                .Where(a => a.Id == sourceAccountNumber).Select(a => a.Currency.Code).FirstOrDefault();
            string? destinationCurrencyCode = _context.Account.Include(a => a.Currency)
                .Where(a => a.Id == destinationAccountNumber).Select(a => a.Currency.Code).FirstOrDefault();

            if (sourceCurrencyCode == destinationCurrencyCode)
                return CurrencyTypeEnum.Same;

            return CurrencyTypeEnum.Different;

        }



        #region not used

        public TransferEnum CheckTransferType(int sourceAccountNumber, int destinationAccountNumber)
        {
            int sourceUserId = _context.Account.Where(a => a.Id == sourceAccountNumber).Select(a => a.UserId).FirstOrDefault();
            int destinationUserId = _context.Account.Where(a => a.Id == destinationAccountNumber).Select(a => a.UserId).FirstOrDefault();
            if (sourceUserId == destinationUserId)
            {
                return TransferEnum.Own;
            }
            return TransferEnum.Other;

        }

        public AccountEnum CheckAccountType(int sourceAccountNumber, int destinationAccountNumber)
        {
            int accounttype = _context.Account.Where(a => a.Id == sourceAccountNumber).Select(a => a.AccountTypeId).FirstOrDefault();

            return (AccountEnum)accounttype;

        }


        public Account? GetAccount(int accountNumber)
        {
            Account? account = null;
            if (accountNumber > 0)
                account = _context.Account
                    .Include(x => x.Currency)
                    .Include(x => x.AccountType)
                    .Include(x => x.User)
                    .Include(x => x.SourceTransactions)
                    .Include(x => x.DestinationTransactions)
                    .Where(x => x.Number == accountNumber)
                    .FirstOrDefault();


            return account;
        }
        #endregion
    }

}