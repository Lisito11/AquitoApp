using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquitoWebApp.Authentication
{
    public class UserAuth
    {
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
        public Dictionary<string, string> ExposedClaims { get; set; }
    }
}
