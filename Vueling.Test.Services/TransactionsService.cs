using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vueling.Test.Client.ClientBuilder;
using Vueling.Test.Entities;
using Vueling.Test.Entities.Models;
using Vueling.Test.Repository.Repository;
using System.Linq;
using Vueling.Test.Services.Domain;

namespace Vueling.Test.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly ITransactionsRepository _repository;
        private readonly IRatesRepository _ratesRepository;
        private readonly ITransactionsDomain _domain;
        private readonly Client.ClientBuilder.IHttpClient _client;
        public TransactionsService(ITransactionsRepository repository, IRatesRepository ratesRepository, ITransactionsDomain domain, Client.ClientBuilder.IHttpClient client)
        {
            _repository = repository;
            _ratesRepository = ratesRepository;
            _domain = domain;
            _client = client;
        }
        public async Task<IList<TransactionEntity>> getTransactions()
        {
            IList<Operations> operations = await _domain.getOperations(_client);
            IList<TransactionEntity> transactions = _domain.mapTransactions(operations);
            return await _repository.read(transactions);
        }

        public async Task<IList<TransactionEntity>> getTransactions(string sku)
        {
            IList<RateEntity> rates = await _ratesRepository.read();
            IList<TransactionEntity> transactions = await _repository.read(sku);
            transactions = _domain.transactionsToEur(rates, transactions);
            return transactions;
        }

        public async Task<TransactionEntity> getSumaTotal(string sku)
        {
            IList<RateEntity> rates = await _ratesRepository.read();
            IList<TransactionEntity> transactions = await _repository.read(sku);
            return _domain.transactionsToEurSumTotal(rates, transactions);
        }




    }
}
