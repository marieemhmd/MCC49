using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models;
using UserManagement.View_Model;

namespace UserManagement.Repository.Interface
{
    interface IPersonRepository
    {
        IEnumerable<Person> Get(); //get all
        Person Get(string NIK); //get by ID
        Person Insert(Person person); 
        Person Update(Person person);
        Person Delete(string NIK);

        PersonVM GetFirstName(string NIK);

        IEnumerable<PersonVM> GetAllFirstName();
    }
}
