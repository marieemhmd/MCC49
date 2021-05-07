using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Context;
using UserManagement.Models;
using UserManagement.Repository.Interface;
using UserManagement.View_Model;

namespace UserManagement.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MyContext conn;
        public PersonRepository(MyContext conn)
        {
            this.conn = conn;
        }

        public IEnumerable<Person> Get()
        {
            IEnumerable<Person> persons = new List<Person>();
            persons = conn.Persons.ToList();
            return persons;
        }
        public IEnumerable<PersonVM> GetAllFirstName()
        {
            IEnumerable<Person> persons = new List<Person>();
            List<PersonVM> personList = new List<PersonVM>();
            persons = conn.Persons.ToList();
            foreach(var item in persons)
            {
                PersonVM personVM = new PersonVM();
                personVM.NIK = item.NIK;
                personVM.FirstName = item.FirstName;
                personList.Add(personVM);
            }
            return personList;
        }

        public Person Get(string NIK)
        {
            var result = conn.Persons.Find(NIK);
            return result;
        }

        public Person Insert(Person person)
        {
            conn.Persons.Add(person); //menambah ke db
            var result = conn.SaveChanges(); //menyimpan ke db
            return person;
            //nik yang sudah digunakan
            //nik 
        }

        public Person Update(Person person)
        {
            conn.Persons.Update(person);
            var result = conn.SaveChanges();
            return person;
            //nik yang sudah digunakan
            //nik yang 
        }
        // entitystate.modified
        public Person Delete(string NIK)
        {
            var deletePerson = conn.Persons.Find(NIK);
            conn.Persons.Remove(deletePerson);
            var result = conn.SaveChanges(); //result bernilai int
            return deletePerson;
        }

        public PersonVM GetFirstName(string NIK)
        {
            var result = conn.Persons.Find(NIK);
            PersonVM person = new PersonVM();
            person.FirstName = result.FirstName;
            person.NIK = result.NIK;
            return person;
        }

    }
}
