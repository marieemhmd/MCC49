using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models;

namespace UserManagement.Repository.Interface
{
    interface IPersonRepository
    {
        IEnumerable<Person> Get(); //get all
        Person Get(string NIK); //get by ID
        int Insert(Person person); 
        int Update(Person person);
        int Delete(string NIK);
        
    }
}
