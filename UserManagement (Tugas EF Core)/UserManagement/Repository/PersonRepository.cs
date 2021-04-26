using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Context;
using UserManagement.Models;
using UserManagement.Repository.Interface;

namespace UserManagement.Repository
{
    public class PersonRepository : IPersonRepository
    {
        MyContext conn;
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

        public Person Get(string NIK)
        {
            var result = conn.Persons.Find(NIK);
            return result;
        }

        public int Insert(Person person)
        {
            conn.Persons.Add(person); //menambah ke db
            var result = conn.SaveChanges(); //menyimpan ke db
            return result;
        }

        public int Update(Person person)
        {
            conn.Persons.Update(person);
            var result = conn.SaveChanges();
            return result;
        }
        public int Delete(string NIK)
        {
            var deletePerson = conn.Persons.Find(NIK);
            conn.Persons.Remove(deletePerson);
            var result = conn.SaveChanges();
            return result;

        }
    }
}
