using Microsoft.AspNetCore.Mvc;
using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Controllers
{
    public class MccDayOneController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DaftarParticipant()
        {
            List<Participant> participants = new List<Participant>();
            participants.Add(new Participant("Agus", "Setiawan"));
            participants.Add(new Participant("Bernadus", "Rangga"));
            participants.Add(new Participant("Helda", "Triyanti"));
            participants.Add(new Participant("Mar'ie", "Muhammad"));
            participants.Add(new Participant("Muhammad", "Zulfikar"));
            participants.Add(new Participant("Mulia Abror", "Khairul"));
            return View(participants);
        }
    }
}
