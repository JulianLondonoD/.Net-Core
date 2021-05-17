using System;
using System.Collections.Generic;
using System.Text;

namespace Vuelin.Test.UnitTest.Stubs
{
    public static class RatesJsonStub
    {
        public static string json = "[{ 'from': 'EUR', 'to': 'USD', 'rate': '1.359' }," +
                                    "{ 'from': 'CAD','to': 'EUR', 'rate': '0.732' }," +
                                    "{ 'from': 'USD', 'to': 'EUR', 'rate': '0.736' }," +
                                    "{ 'from': 'EUR', 'to': 'CAD', 'rate': '1.366' }]";
       
    }
}
