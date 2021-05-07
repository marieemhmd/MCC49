using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Models
{
    [Table("tb_t_accountRoles")]
    public class AccountRole
    {
        public int RoleId { get; set; }
        [JsonIgnore]
        public virtual Role Role { get; set; }
        public string AccountId { get; set; }
        [JsonIgnore]
        public virtual Account Account { get; set; }
    }
}
