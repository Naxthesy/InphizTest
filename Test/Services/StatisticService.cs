using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models.DTO;
using Test.Services.ExtensionServices;

namespace Test.Services
{
    public class StatisticService
    {
        private readonly ApplicationContext _db;
        private readonly IMapper _mapper;
        public StatisticService(ApplicationContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public IEnumerable<StatisticDTO> GetStatistic(DateTime? startDate, DateTime? endDate, string metric, bool? isSuccess)
        {
            startDate = startDate ?? new DateTime(1990, 1, 1);
            endDate = endDate ?? DateTime.Now;
            if(isSuccess == null)
            {
                var dtos = _db.UserLoginAttempts.Where(x => x.AttemptTime > startDate && x.AttemptTime <= endDate)
                    .Select(x => new AttemptDTO { AttemptTime = x.AttemptTime.GetDateByMetrics(metric), Id = x.Id, IsSuccess = x.IsSuccess }).ToList();

                var attempts =  dtos
                    .GroupBy(x=>x.AttemptTime)
                    .Select(x=> new StatisticDTO { Period = x.Key, Value = x.Count() })
                    .OrderBy(x=>x.Period)
                    .ToList();
                return attempts;
            }
            else
            {
                var dtos = _db.UserLoginAttempts.Where(x => x.AttemptTime > startDate && x.AttemptTime <= endDate && x.IsSuccess == isSuccess)
                    .Select(x => new AttemptDTO { AttemptTime = x.AttemptTime.GetDateByMetrics(metric), Id = x.Id, IsSuccess = x.IsSuccess }).ToList();

                var attempts = dtos
                    .GroupBy(x => x.AttemptTime)
                    .Select(x => new StatisticDTO { Period = x.Key, Value = x.Count() })
                    .OrderBy(x => x.Period)
                    .ToList();
                return attempts;
            }
        }
    }
}
