using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class RequestVM
    {
        public int Id { get; set; }
        public string NIK { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public string Notes { get; set; }
        public string ReasonRequest { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string UploadFile { get; set; }
        public int RoleId { get; set; }
        public int RemainingQuota { get; set; }
        public string EmailManager { get; set; }
        public int RequestStatus { get; set; }
        //note reject
        public string RejectedNotes { get; set; }
        //daterequest
        public DateTime DateRequest { get; set; }

        public IFormFile UploadDoc { get; set; }
    }
}
