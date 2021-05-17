using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vueling.Test.Client.ClientBuilder;
using Vueling.Test.Entities;
using Vueling.Test.Entities.Models;

namespace Vueling.Test.Services.Domain
{
    public interface IRatesDomain
    {
        Task<IList<Exchange>> getExchanges(IHttpClient _client);
        IList<RateEntity> completeRates(IList<Exchange> exchanges);
    }
}
