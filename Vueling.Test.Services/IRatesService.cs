using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vueling.Test.Entities;

namespace Vueling.Test.Services
{
    public interface IRatesService
    {
        Task<IList<RateEntity>> getRates();
    }
}
