using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Test.Client.ClientBuilder;
using Vueling.Test.Entities;
using Vueling.Test.Entities.Models;

namespace Vueling.Test.Services.Domain
{
    public class TransactionDomain : ITransactionsDomain
    {
        public async Task<IList<Operations>> getOperations(IHttpClient _client)
        {
            string json = await _client.getTransactions();
            return JsonConvert.DeserializeObject<IList<Operations>>(json);
        }

        public IList<TransactionEntity> mapTransactions(IList<Operations> operations)
        {
            return (from op in operations select new TransactionEntity() { Amount = op.amount, Currency = op.currency, Sku = op.sku }).ToList();
        }

        public IList<TransactionEntity> transactionsToEur(IList<RateEntity> rates, IList<TransactionEntity> transactions)
        {
            rates = rates.Where(r => r.To == "EUR").ToList();
            foreach (TransactionEntity transaction in transactions)
            {
                if (transaction.Currency != "EUR")
                {
                    double val = transaction.Amount * rates.Where(r => r.From == transaction.Currency).FirstOrDefault().Rate;
                    transaction.Amount = Math.Round(val, 2, MidpointRounding.ToEven);
                    transaction.Currency = "EUR";
                }
            }
            return transactions;
        }

        public TransactionEntity transactionsToEurSumTotal(IList<RateEntity> rates, IList<TransactionEntity> transactions)
        {
            transactions = transactionsToEur(rates, transactions);
            double suma = transactions.Sum(t => t.Amount);
            TransactionEntity transaction = transactions.FirstOrDefault();
            transaction.Amount = Math.Round(suma, 2, MidpointRounding.ToEven);
            transaction.IdTransaction = 0;
            return transaction;
        }

    }
}
