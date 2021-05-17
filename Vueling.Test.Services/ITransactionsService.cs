using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vueling.Test.Entities;

namespace Vueling.Test.Services
{
    public interface ITransactionsService
    {
        Task<IList<TransactionEntity>> getTransactions();
        Task<IList<TransactionEntity>> getTransactions(string sku);
        Task<TransactionEntity> getSumaTotal(string sku);
    }
}
