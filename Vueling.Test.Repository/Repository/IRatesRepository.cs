using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vueling.Test.Data;
using Vueling.Test.Entities;

namespace Vueling.Test.Repository.Repository
{
    public interface IRatesRepository
    {
        Task<IList<RateEntity>> read(IList<RateEntity> rates);
        Task<IList<RateEntity>> read();

    }
}
