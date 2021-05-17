using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Vuelin.Test.UnitTest.Stubs;
using Vueling.Test.Client.ClientBuilder;
using Vueling.Test.Entities.Models;
using Vueling.Test.Services.Domain;

namespace Vuelin.Test.UnitTest.Mocks
{
    public class RatesDomainMock
    {
        public Mock<IRatesDomain> _domain { get; set; }
        Mock<IHttpClient> _client;
        public RatesDomainMock(Mock<IHttpClient> client)
        {
            _domain = new Mock<IRatesDomain>();
            _client = client;
            Setup();
        }

        private void Setup()
        {
            _domain.Setup(x => x.getExchanges(_client.Object)).ReturnsAsync(ExchangeStub.rates);
            _domain.Setup(x => x.completeRates(It.IsAny<IList<Exchange>>())).Returns(RateStub.rates);
        }
    }
}
