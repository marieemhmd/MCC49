using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Models
{
    public class Participant
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Participant(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
