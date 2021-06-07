using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_M_Request")]
    public class Request
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        public string ReasonRequest { get; set; }

        [Required(ErrorMessage = "Required")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Required"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Required")]
        public RequestStatus RequestStatus { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Notes { get; set; }

        [DataType(DataType.Date)]
        public DateTime? RequestDate { get; set; }        

        public string ApprovedHRD { get; set; }
        public string ApprovedManager { get; set; }
#nullable enable
        public string? NIK_Employee { get; set; }
        public string? UploadDoc { get; set; }
#nullable restore
        public virtual Employee Employee { get; set; }

        public virtual ICollection<NationalHoliday> Holidays { get; set; }
    }
    public enum RequestStatus
    {
        OnProcess,
        ApprovedByHRD,
        RejectByHRD,
        ApprovedByManager,
        RejectByManager
    }
}
