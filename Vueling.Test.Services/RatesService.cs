using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Test.Client.ClientBuilder;
using Vueling.Test.Entities;
using Vueling.Test.Entities.Models;
using Vueling.Test.Repository.Repository;
using Vueling.Test.Services.Domain;

namespace Vueling.Test.Services
{
    public class RatesService : IRatesService
    {
        private readonly IRatesRepository _repository;
        private readonly IRatesDomain _domain;
        private readonly Client.ClientBuilder.IHttpClient _client;

        public RatesService(IRatesRepository repository, IRatesDomain domain, Client.ClientBuilder.IHttpClient client)
        {
            _repository = repository;
            _client = client;
            _domain = domain;
        }

        public async Task<IList<RateEntity>> getRates()
        {
            IList<Exchange> exchanges = await _domain.getExchanges(_client);
            IList<RateEntity> rates = _domain.completeRates(exchanges);
            return await _repository.read(rates);
        }
       
    }
}
