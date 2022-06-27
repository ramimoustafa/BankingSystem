using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.Domain.Interfaces;
using BankingSystem.Domain.Models.DTO;
using BankingSystem.Domain.Models.Request;
using BankingSystem.Domain.Models.Response;
using BankingSystem.Infrastructure.Common;
using Microsoft.Data.SqlClient;

namespace BankingSystem.Infrastructure.Repositories
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<TransactionResponse> GetTransactions(TransactionRequest transactionRequest, string connectionString)
        {
            List<TransactionResponse> transactionResponseList = new List<TransactionResponse>();
             using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetTransactions", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@From", transactionRequest.From);
                cmd.Parameters.AddWithValue("@To", transactionRequest.To);
                cmd.Parameters.AddWithValue("@PageNumber", transactionRequest.PageNumber);
                cmd.Parameters.AddWithValue("@PageSize", transactionRequest.PageSize);
                connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                    transactionResponseList = Helper.DataReaderMapToList<TransactionResponse>(sdr);
                connection.Close();
            }

            return transactionResponseList;
        }
    }
}
