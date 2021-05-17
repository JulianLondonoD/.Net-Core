using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Test.Client.ClientBuilder;
using Vueling.Test.Entities;
using Vueling.Test.Entities.Models;

namespace Vueling.Test.Services.Domain
{
    public class RatesDomain : IRatesDomain
    {

        public async Task<IList<Exchange>> getExchanges(IHttpClient _client)
        {
            string json = await _client.getExchanges();
            return JsonConvert.DeserializeObject<IList<Exchange>>(json);
        }

        public IList<RateEntity> completeRates(IList<Exchange> exchanges)
        {
            IList<RateEntity> rates = (from e in exchanges select new RateEntity() { From = e.@from, To = e.to, Rate = e.rate }).ToList();
            IList<string> monedas = exchanges.Select(e => e.from).Distinct().ToList();
            for (int i = 0; i < monedas.Count; i++)
            {
                for (int j = 0; j < monedas.Count; j++)
                {
                    if (monedas[i] != monedas[j])
                    {
                        double _rate = exchanges.Where(e => e.from == monedas[i] && e.to == monedas[j]).Select(e => e.rate).FirstOrDefault();
                        if (_rate == 0)
                        {
                            try
                            {
                                RateEntity rate = new RateEntity();
                                rate.From = monedas[i];
                                rate.To = monedas[j];
                                IList<RateEntity> rateFrom = rates.Where(e => e.From == rate.From).ToList();
                                IList<RateEntity> rateTo = rates.Where(e => e.To == rate.To).ToList();

                                RateEntity rateBase = (from rf in rateFrom
                                                       join rt in rateTo on rf.To equals rt.From
                                                       select rf).FirstOrDefault();
                                if (rateBase != null)
                                {

                                    RateEntity rateAux = rates.Where(e => e.From == rateBase.To && e.To == monedas[j]).FirstOrDefault();
                                    rate.Rate = Math.Round(rateBase.Rate * rateAux.Rate, 2, MidpointRounding.ToEven);
                                    rates.Add(rate);
                                }
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                }
            }

            return rates;
        }
    }
}
