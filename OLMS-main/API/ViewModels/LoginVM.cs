using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class LoginVM
    {
        public string NIK { get; }

        public string Email { set; get; }

        public string Password { set; get; }

        public string FullName { get; }

        public IEnumerable<string> Roles { get; }

        public string RoleName { get; }
    }
}
