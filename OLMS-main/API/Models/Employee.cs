using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_M_Employee")]
    public class Employee
    {
        [Key, ForeignKey(nameof(Manager))]
        public string NIK { get; set; }

        [Required(ErrorMessage = "Required"), MaxLength(50, ErrorMessage = "Maximum 50 characters"), RegularExpression(@"^\D+$", ErrorMessage = "Cannot enter number")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Required"), RegularExpression(@"^08[0-9]{10,11}$", ErrorMessage = "Must be a number starting with 08"), MinLength(10, ErrorMessage = "Minimum 11 characters"), MaxLength(14, ErrorMessage = "Maximum 14 characters")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Required"), EmailAddress(ErrorMessage = "Invalid email input"), MaxLength(255, ErrorMessage = "Maximum 255 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required"), DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }

        public string MaritalStatus { get; set; }

        [MaxLength(255, ErrorMessage = "Maximum 255 character")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Required")]
        public int RemainingQuota { get; set; }
        #nullable enable
        public string? NIK_Manager { get; set; }
        #nullable restore
        public int PositionId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? JoinDate { get; set; }

        public virtual Employee Manager { get; set; }
        public virtual Position Position { get; set; }
        public virtual Account Account { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
