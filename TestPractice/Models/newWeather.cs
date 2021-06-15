using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestPractice.Models
{
    public class newWeather
    {
        public class desciption
        {
            public int cityId { get; set; }
            public string cityName { get; set; }
            public string weatherMain { get; set; }
            public string weatherDescription { get; set; }
            public string weatherIcon { get; set; }
            public int mainTemp { get; set; }
            public int mainHumidity { get; set; }

        }
        public string  message { get; set; }
        public int statusCode { get; set; }
    }
}
