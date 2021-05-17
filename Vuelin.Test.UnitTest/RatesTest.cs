using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vuelin.Test.UnitTest.Mocks;
using Vueling.Test.Api.Controllers;
using Vueling.Test.Client.ClientBuilder;
using Vueling.Test.Entities;
using Vueling.Test.Repository.Repository;
using Vueling.Test.Services;
using Vueling.Test.Services.Domain;

namespace Vuelin.Test.UnitTest
{
    [TestClass]
    public class RatesTest
    {
        private static IRatesService _service;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Mock<IRatesRepository> _repository = new RatesRepositoryMock()._repository;
            Mock<IHttpClient> _client = new HttpClientMock()._client;
            Mock<IRatesDomain> _domain = new RatesDomainMock(_client)._domain;
            _service = new RatesService(_repository.Object, _domain.Object, _client.Object);
        }

        [TestMethod]
        public async Task lista_de_rates_no_debe_ser_vacia()
        {
            IList<RateEntity> result = await _service.getRates();
            result.Should().NotBeEmpty();
        }

        [TestMethod]
        public async Task lista_de_rates_completa()
        {
            IList<RateEntity> result = await _service.getRates();
            result.Where(r => r.From == "USD" && r.To == "CAD").FirstOrDefault().Should().NotBeNull();
            result.Where(r => r.From == "CAD" && r.To == "USD").FirstOrDefault().Should().NotBeNull();
        }
    }
}
