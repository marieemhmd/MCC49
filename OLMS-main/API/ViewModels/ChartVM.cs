using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class ChartVM
    {
        public string PositionName { get; set; }
        public int Total { get; set; }

        public string DeptName { get; set; }
        public int TotalQoutaDept { get; set; }

        public int totalReason { get; set; }

        public int totalStatus { get; set; }
        public string ReasonRequest { get; set; }

        public string leaveQuota { get; set; }
        public int totalLeaveQuota { get; set; }
        public string Reason { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int TotalRequest { get; set; }
    }




}