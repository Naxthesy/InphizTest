using AutoMapper;
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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly ApplicationContext _db;
        private readonly GenerateSeedService _service;
        public SeedController( ApplicationContext db, GenerateSeedService service)
        {
            _service = service;
            _db = db;
        }

        [HttpGet]
        public async  Task<IActionResult> Init(int usersCount, int maxAttemptsPerUser)
        {
            return Ok(await _service.SeedData(usersCount, maxAttemptsPerUser));
        }
    }
}
