using System;
using System.Collections.Generic;
using System.Text;
using Vueling.Test.Entities.Models;

namespace Vuelin.Test.UnitTest.Stubs
{
    public class ExchangeStub
    {
        public static Exchange rate_1 = new Exchange()
        {
            from = "EUR",
            to = "USD",
            rate = 1.359
        };

        public static Exchange rate_2 = new Exchange()
        {
            from = "CAD",
            to = "EUR",
            rate = 0.732,
        };

        public static Exchange rate_3 = new Exchange()
        {
            from = "USD",
            to = "EUR",
            rate = 0.736,
        };

        public static Exchange rate_4 = new Exchange()
        {
            from = "EUR",
            to = "CAD",
            rate = 1.366,
        };

        public static IList<Exchange> rates = new List<Exchange>(new Exchange[] { rate_1, rate_2, rate_3, rate_4 });
    }
}
