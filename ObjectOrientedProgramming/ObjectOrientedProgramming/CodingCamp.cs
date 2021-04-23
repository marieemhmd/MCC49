using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming
{
    class CodingCamp
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Participant> Participants { get; set; }
        public CodingCamp(string id, string name)
        {
            Id = id;
            Name = name;
            Participants = new List<Participant>();
        }
        public void TampilPeserta()
        {
            Console.WriteLine("Daftar paricipant");
            foreach (Participant p in Participants)
            {
                Console.WriteLine($"NAMA : {p.nama}");
            }
        }

    }
}
