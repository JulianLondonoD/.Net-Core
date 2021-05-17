using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Test.Client.ClientBuilder
{
    public class HttpClient : IHttpClient
    {
        private readonly IConfiguration _configuration;
        public HttpClient(IConfiguration configuration) 
        {
            _configuration = configuration;
        }
        public async Task<string> getExchanges()
        {
            using (var httpClient = new System.Net.Http.HttpClient())
            {

                try
                {
                    return await httpClient.GetStringAsync(_configuration["ExchangeURL"]);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public async Task<string> getTransactions()
        {
            using (var httpClient = new System.Net.Http.HttpClient())
            {
                try
                {
                    return await httpClient.GetStringAsync(_configuration["TransactionsURL"]);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
