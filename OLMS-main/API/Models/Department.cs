using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_M_Department")]
    public class Department
    {
        [Key]
        [Required(ErrorMessage = "Required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        public string DeptName { get; set; }
        //[JsonIgnore]
        public virtual ICollection<Position> Positions { get; set; }
    }
}
