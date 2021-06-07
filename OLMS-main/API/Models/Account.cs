using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_M_Account")]
    public class Account
    {
        [Key]
        [Required(ErrorMessage = "Required")]
        public string NIK { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Password)]
        public string AccountPassword { get; set; }
        //[JsonIgnore]
        public virtual Employee Employee { get; set; }
        //[JsonIgnore]
        public virtual ICollection<AccountRole> AccountRoles { get; set; }
    }
}
