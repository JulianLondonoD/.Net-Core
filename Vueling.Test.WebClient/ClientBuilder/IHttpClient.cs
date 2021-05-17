using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Test.Client.ClientBuilder
{
    public interface IHttpClient
    {
        Task<string> getExchanges();
        Task<string> getTransactions();
    }
}
