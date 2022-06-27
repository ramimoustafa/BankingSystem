﻿using BankingSystem.Domain.Models.DTO;
using BankingSystem.Domain.Models.Request;
using BankingSystem.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Domain.Interfaces
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        List<TransactionResponse> GetTransactions(TransactionRequest transactionRequest, string connectionString);
 
    }
}
