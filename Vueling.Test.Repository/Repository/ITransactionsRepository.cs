using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vueling.Test.Entities;

namespace Vueling.Test.Repository.Repository
{
    public interface ITransactionsRepository
    {
        Task<IList<TransactionEntity>> read(IList<TransactionEntity> transactions);
        Task<IList<TransactionEntity>> read(string sku);
    }
}
