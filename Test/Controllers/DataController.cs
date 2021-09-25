using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Test.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test.Attributes;

namespace Test.Controllers
{
    [ApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly ApplicationContext _db;
        public DataController(ApplicationContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult GetUserByEmail(string email)
        {
            return Ok(_db.Users.Where(x => x.Email == email).Include(x => x.userLoginAttempts));
        }
    }
}
