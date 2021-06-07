using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_M_Parameter")]
    public class Parameter
    {
        [Key, Required(ErrorMessage = "Required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Required"), MaxLength(20, ErrorMessage = "Maximum of 20 characters"), RegularExpression(@"^\D+$", ErrorMessage = "This field cannot be a number")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required")]
        public int Value { get; set; }
    }
}
