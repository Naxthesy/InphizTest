using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Services
{
    public class GenerateSeedService
    {
        private readonly RandomService _random;
        private readonly ApplicationContext _db;
        private readonly IMapper _mapper;
        public GenerateSeedService(RandomService random, ApplicationContext db, IMapper mapper)
        {
            _random = random;
            _db = db;
            _mapper = mapper;
        }
        private IEnumerable<User> GenerateUsers(int length)
        {
            List<User> users = new List<User>();
            for(int i = 0; i<length; i++)
            {
                users.Add(new User { Name = _random.RandomString(), Email = _random.RandomEmail(), SurName = _random.RandomString(), userLoginAttempts = new List<Models.UserLoginAttempt>() });
            }
            return users;
        }
        public async Task<IEnumerable<User>> SeedData(int usersCount, int maxAttemptsPerUser)
        {
            _db.UserLoginAttempts.RemoveRange(_db.UserLoginAttempts.ToList());
            _db.Users.RemoveRange(_db.Users.ToList());
            var users = GenerateUsers(usersCount);
            foreach(var user in users)
            {
                int maxAttempts = _random.RandomInt(maxAttemptsPerUser);
                var attempts = new List<UserLoginAttempt>();
                for(var i = 0; i< maxAttempts; i++)
                {
                    attempts.Add(new UserLoginAttempt { AttemptTime = _random.RandomDay(), IsSuccess = _random.RandomBool() });
                }
                user.userLoginAttempts = attempts;
            }
            await _db.Users.AddRangeAsync(users);
            await _db.SaveChangesAsync();
            return users;
        }
    }
}
