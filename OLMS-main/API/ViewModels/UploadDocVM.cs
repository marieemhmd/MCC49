using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class UploadDocVM
    {
        //public string FileName { get; set; }
        public IFormFile UploadDoc { get; set; }
    }
}
