using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Study.JWT.API.Config
{
    public class TokenConfiguracao
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
    }
}
