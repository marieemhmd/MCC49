using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.View_Model
{
    public class UpdatePassVM
    {
        public string Email { get; set; }
        public string OldPass { get; set; }
        public string NewPass { get; set; }
    }
}
