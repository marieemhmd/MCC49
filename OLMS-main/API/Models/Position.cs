using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_M_Position")]
    public class Position
    {
        [Key]
        [Required(ErrorMessage = "Required")]
        public int Id { get; set; }
        public string PositionName { get; set; }
        public int DepartmentId { get; set; }
        
        public virtual Department Department { get; set; }
        //[JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
