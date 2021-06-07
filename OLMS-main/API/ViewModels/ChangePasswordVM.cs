using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class ChangePasswordVM
    {
        [Required(ErrorMessage = "Required")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "Required")]
        public string NewPassword { get; set; }

        [Compare("NewPassword"), Required(ErrorMessage = "Required")]
        public string ConfirmPassword { get; set; }
    }
}