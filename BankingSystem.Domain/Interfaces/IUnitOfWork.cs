﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Domain.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        ILimitRepository Limits { get; }
        ITransactionRepository Transactions { get; }
        IUserRepository Users { get; }

        int Complete();
    }
}
