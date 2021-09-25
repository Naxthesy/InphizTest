using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Attributes;
using Test.Services;

namespace Test.Controllers
{
    [ApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly StatisticService _service;
        public StatisticController(StatisticService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetStatistic(string metric, DateTime? startDate=null, DateTime? endDate=null, bool? isSuccess=null)
        {
            return Ok(_service.GetStatistic(startDate, endDate, metric, isSuccess));
        }
    }
}
