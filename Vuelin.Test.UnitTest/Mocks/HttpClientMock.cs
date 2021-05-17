using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Vuelin.Test.UnitTest.Stubs;
using Vueling.Test.Client.ClientBuilder;

namespace Vuelin.Test.UnitTest.Mocks
{
    public class HttpClientMock
    {
        public Mock<IHttpClient> _client { get; set; }

        public HttpClientMock()
        {
            _client = new Mock<IHttpClient>();
            Setup();
        }

        private void Setup()
        {
            _client.Setup(x => x.getExchanges()).ReturnsAsync(RatesJsonStub.json);
        }
    }
}
