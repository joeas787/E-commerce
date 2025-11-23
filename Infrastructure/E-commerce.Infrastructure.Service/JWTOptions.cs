using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Infrastructure.Service
{
    public class JWTOptions
    {
        public static string SectionName { get; set; } = "JWTOptions";
        public string Key { get; set; }
        public string issuer { get; set; }

        public string audience { get; set; }

        public int DurationInHours { get; set; }

    }
}
