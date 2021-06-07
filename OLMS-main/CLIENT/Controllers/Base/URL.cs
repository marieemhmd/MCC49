using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLIENT.Controllers.Base
{
    public class URL
    {
        public string GetDevelopment()
        {
            return "https://localhost:44358/api/";
        }
        public string GetProduction()
        {
            return "https://localhost:44358/api/";
        }
    }
}
