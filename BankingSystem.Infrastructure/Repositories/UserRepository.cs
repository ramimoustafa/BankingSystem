using BankingSystem.Domain.Interfaces;
using BankingSystem.Domain.Models.DTO;
using BankingSystem.Domain.Models.Response;
using BankingSystem.Infrastructure.Common;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<UserResponse> GetActiveAccountsUsers(string connectionString)
        {
            List<UserResponse> users = new List<UserResponse>();

             using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetActiveAccountsUsers", connection)
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
    }
}
