using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Services
{
    public class RandomService
    {
        private Random random = new Random();
        public string RandomString(int length = 0)
        {
            if(length <= 0)
            {
                length = random.Next(30);
            }
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public string RandomEmail()
        {
            int length = random.Next(21);
            string[] emails = new string[3]{"@gmail.com", "@mail.ru", "@ukr.net"};
            var emailStart = this.RandomString(length);
            emailStart = emailStart + emails[random.Next(emails.Length)];
            return emailStart;
        }
        public DateTime RandomDay()
        {
            var year = random.Next(2010, 2021);
            var month = random.Next(1, 13);
            var days = random.Next(1, DateTime.DaysInMonth(year, month) + 1);
            return new DateTime(year, month, days,
                random.Next(0, 24), random.Next(0, 60), random.Next(0, 60), random.Next(0, 1000));
        }
        public int RandomInt(int maxValue)
        {
            return random.Next(maxValue);
        }
        public bool RandomBool()
        {
            return Convert.ToBoolean(random.Next(-1, 1));
        }
    }
}
