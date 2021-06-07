using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class StatusRequestVM
    {
        public int Id { get; set; }
        public string Email { get; }
        public Boolean ApproveOrRejected { get; set; }
        public string RejectedNotes { get; set; }
    }
}
