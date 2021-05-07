using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
//using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace UserManagement.Models
{
    [Table("tb_t_profilings")]
    public class Profiling
    {
        [Key]
        public string NIK { get; set; }
        [JsonIgnore]
        public virtual Account Account { get; set; }
        public int EducationId { get; set; }
        //[JsonIgnore]
        public virtual Education Education { get; set; }

    }
}
