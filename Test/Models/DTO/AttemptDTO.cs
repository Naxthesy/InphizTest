using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models.DTO
{
    public class AttemptDTO
    {
        public Guid Id { get; set; }
        public string AttemptTime { get; set; }
        public bool IsSuccess { get; set; }
    }
}
