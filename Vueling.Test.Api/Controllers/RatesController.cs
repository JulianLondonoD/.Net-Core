using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Vueling.Test.Client.ClientBuilder;
using Vueling.Test.Data;
using Vueling.Test.Entities;
using Vueling.Test.Services;

namespace Vueling.Test.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RatesController : ControllerBase
    {
        
        private readonly IRatesService _service;
        public RatesController(IRatesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IList<RateEntity> rates = await _service.getRates();
            return Ok(rates);
        }
    }
}
