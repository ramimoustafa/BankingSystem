using BankingSystem.API.Service.Models.Request;
using BankingSystem.API.Service.Models.Response;
using BankingSystem.Domain.Models.DTO;
using BankingSystem.Infrastructure;
using BankingSystem.Infrastructure.Common;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;


namespace BankingSystem.API.Service
{
    public class SoapService : ISoapService
    {
        public readonly ApplicationDbContext _context;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private IConfiguration _configuration;

        public SoapService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }
        public LimitRequest InsertOrUpdateLimits(LimitRequest limit)
        {
            int? id = null;
            List<LimitTransferType> limitTransferTypes = new List<LimitTransferType>();
            List<LimitAccountType> limitAccountTypes = new List<LimitAccountType>();

            if (limit.Id != null)
            {
                id = limit.Id;
            }
            Limit limitDTO = new Limit
            {
                Id = id,
                MinAmount = limit.MinAmount,
                MaxAmount = limit.MaxAmount,
                MaxAmountPeriodTypeId = limit.MaxAmountPeriodTypeId,
                MaxAmounPeriodValue = limit.MaxAmounPeriodValue,
                ObjectTypeId = limit.ObjectTypeId,
                ObjectId = limit.ObjectId,
                IsTransferTypeRule = limit.IsTransferTypeRule,
                IsAccountTypeRule = limit.IsAccountTypeRule,
                CurrencyTypeId = limit.CurrencyTypeId,
                LocationTypeId = limit.LocationTypeId,
                IsActive = limit.IsActive

            };

            if (limit.IsTransferTypeRule && limit.LimitTransferTypes.Count > 0)
            {
                foreach (LimitTransferTypeRequest limitTransferTypeRequest in limit.LimitTransferTypes)
                {
                    LimitTransferType limitTransferType = new LimitTransferType
                    {
                        LimitId = limitTransferTypeRequest.LimitId,
                        TransferTypeId = limitTransferTypeRequest.TransferTypeId
                    };
                    limitTransferTypes.Add(limitTransferType);

                }
            }

            if (limit.IsAccountTypeRule && limit.LimitAccountTypes.Count > 0)
            {
                foreach (LimitAccountTypeRequest limitAccountTypeRequest in limit.LimitAccountTypes)
                {
                    LimitAccountType limitAccountType = new LimitAccountType
                    {
                        LimitId = limitAccountTypeRequest.LimitId,
                        AccountTypeId = limitAccountTypeRequest.AccountTypeId
                    };
                    limitAccountTypes.Add(limitAccountType);

                }
            }

            if (id == null) // Add
            {
                _context.Limit.Add(limitDTO);

                if (limit.IsTransferTypeRule && limit.LimitTransferTypes.Count > 0)
                    _context.LimitTransferType.AddRange(limitTransferTypes);

                if (limit.IsAccountTypeRule && limit.LimitAccountTypes.Count > 0)
                    _context.LimitAccountType.AddRange(limitAccountTypes);

            }
            else //Update
            {
                _context.Limit.Update(limitDTO);

                if (limit.IsTransferTypeRule && limit.LimitTransferTypes.Count > 0)
                {
                    List<LimitTransferType> toBeDeleteLimitTransferTypes = _context.LimitTransferType.Where(x => x.LimitId == id).ToList();

                    _context.LimitTransferType.RemoveRange(toBeDeleteLimitTransferTypes); // Remove Old Records
                    _context.LimitTransferType.AddRange(limitTransferTypes); // Add New Records

                }

                if (limit.IsAccountTypeRule && limit.LimitAccountTypes.Count > 0)
                {
                    List<LimitAccountType> toBeDeleteLimitAccountTypes = _context.LimitAccountType.Where(x => x.LimitId == id).ToList();

                    _context.LimitAccountType.RemoveRange(toBeDeleteLimitAccountTypes); // Remove Old Records
                    _context.LimitAccountType.AddRange(limitAccountTypes); // Add New Records
                }


            }

            _context.SaveChanges();
            return limit;

        }
        public List<UserResponse> GetInactiveAccountsUsers()
        {
            List<UserResponse> users = new List<UserResponse>();
            string ConnectionString = _configuration.GetConnectionString("BankingSystem");
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetInActiveAccountsUsers", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                    users = Helper.DataReaderMapToList<UserResponse>(sdr);
                connection.Close();
            }
            return users;
        }


        public List<UserResponse> GetReachedUsers(int limitId)
        {
            Limit limit = _context.Limit.Where(l => l.Id == limitId).FirstOrDefault();
            List<Account> accounts = _context.Account.Where(a => a.IsActive).ToList();

            List<User> users = _context.User
                .Include(u => u.Gender)
                .Include(u => u.UserType)
                .Include(u => u.Branch)
                .Include(u => u.Accounts).ToList();

            List<UserResponse> reachedMaxAmountUsers = new List<UserResponse>();
            double usertotalamount = 0;
            double transactionsamount = 0;
            foreach (User user in users)
            {

                foreach (Account account in user.Accounts)
                {
                    if (account.IsActive)
                    {
                        transactionsamount = GetTotalAmount(account.Number, limit.MaxAmountPeriodTypeId, limit.MaxAmounPeriodValue);
                        usertotalamount += transactionsamount;
                    }
                }
                if (usertotalamount > limit.MaxAmount)
                {
                    UserResponse u = new UserResponse
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        MiddleName = user.MiddleName,
                        DOB = user.DOB,
                        Gender = user.Gender.Name,
                        UserType = user.UserType.Name,
                        Branch = user.Branch.Name,
                        Created = user.Created

                    };
                    reachedMaxAmountUsers.Add(u);
                }
                usertotalamount = 0;
            }

            return reachedMaxAmountUsers;


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
    }
}
