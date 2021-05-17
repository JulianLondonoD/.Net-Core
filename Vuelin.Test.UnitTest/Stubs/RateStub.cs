using System;
using System.Collections.Generic;
using System.Text;
using Vueling.Test.Entities;

namespace Vuelin.Test.UnitTest.Stubs
{
    public static class RateStub
    {
        public static RateEntity rate_1 = new RateEntity() 
        { 
            From = "EUR",
            To = "USD",
            Rate = 1.359,
            IdRate = 1
        };

        public static RateEntity rate_3 = new RateEntity()
        {
            From = "USD",
            To = "EUR",
            Rate = 0.736,
            IdRate = 2
        };

        public static RateEntity rate_2 = new RateEntity()
        {
            From = "CAD",
            To = "EUR",
            Rate = 0.732,
            IdRate = 3
        };

        public static RateEntity rate_4 = new RateEntity()
        {
            From = "EUR",
            To = "CAD",
            Rate = 1.366,
            IdRate = 4
        };

        public static RateEntity rate_5 = new RateEntity()
        {
            From = "USD",
            To = "CAD",
            Rate = Math.Round(rate_3.Rate * rate_4.Rate, 2, MidpointRounding.ToEven),
            IdRate = 5
        };

        public static RateEntity rate_6 = new RateEntity()
        {
            From = "CAD",
            To = "USD",
            Rate = Math.Round(rate_2.Rate * rate_1.Rate, 2, MidpointRounding.ToEven),
            IdRate = 6
        };

        public static IList<RateEntity> rates = new List<RateEntity>(new RateEntity[] { rate_1, rate_2, rate_3, rate_4, rate_5, rate_6 });
    }
}
