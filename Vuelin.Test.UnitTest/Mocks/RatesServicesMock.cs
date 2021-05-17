using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Vuelin.Test.UnitTest.Stubs;
using Vueling.Test.Entities;
using Vueling.Test.Services;

namespace Vuelin.Test.UnitTest.Mocks
{
    public class RatesServicesMock
    {
        public Mock<IRatesService> _ratesServices { get; set; }

        public RatesServicesMock()
        {
            _ratesServices = new Mock<IRatesService>();
            Setup();
        }

        private void Setup()
        {
            _ratesServices.Setup(x => x.getRates()).ReturnsAsync(RateStub.rates);
        }
    }

}
