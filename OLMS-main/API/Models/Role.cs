using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_M_Role")]
    public class Role
    {
        [Key]
        [Required(ErrorMessage = "Required")]
        public int RoleID { get; set; }
        [Required(ErrorMessage = "Required")]
        public string RoleName { get; set; }
        [JsonIgnore]
        public virtual ICollection<AccountRole> AccountRoles { get; set; }
    }
}
