using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vueling.Test.Client.ClientBuilder;
using Vueling.Test.Entities;
using Vueling.Test.Entities.Models;

namespace Vueling.Test.Services.Domain
{
    public interface ITransactionsDomain
    {
        Task<IList<Operations>> getOperations(IHttpClient _client);
        IList<TransactionEntity> mapTransactions(IList<Operations> operations);
        IList<TransactionEntity> transactionsToEur(IList<RateEntity> rates, IList<TransactionEntity> transactions);
        TransactionEntity transactionsToEurSumTotal(IList<RateEntity> rates, IList<TransactionEntity> transactions);
    }
}
