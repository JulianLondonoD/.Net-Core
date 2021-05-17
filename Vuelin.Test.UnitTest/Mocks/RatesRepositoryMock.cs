using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Vuelin.Test.UnitTest.Stubs;
using Vueling.Test.Entities;
using Vueling.Test.Repository.Repository;

namespace Vuelin.Test.UnitTest.Mocks
{
    public class RatesRepositoryMock
    {
        public Mock<IRatesRepository> _repository { get; set; }

        public RatesRepositoryMock()
        {
            _repository = new Mock<IRatesRepository>();
            Setup();
        }

        private void Setup()
        {
            _repository.Setup(x => x.read(It.IsAny<IList<RateEntity>>())).ReturnsAsync(RateStub.rates);
            _repository.Setup(x => x.read()).ReturnsAsync(RateStub.rates);
        }
    }
}
