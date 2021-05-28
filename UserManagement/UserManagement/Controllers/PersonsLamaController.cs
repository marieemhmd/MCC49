using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UserManagement.Models;
using UserManagement.Repository;
using UserManagement.View_Model;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsLamaController : ControllerBase
    {
        private readonly PersonRepository personRepository;
        public PersonsLamaController(PersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        //mendapatkan data dari db menggunakan get
        //memasukkan data ke db menggunakan post
        //[HttpPost]
        //[Route("Insert")]
        //public ActionResult Insert(Person person)
        //{
        //    //personRepository.Insert(person);
        //    return Ok(personRepository.Insert(person)); //mengembalikan data di body postman
        //}

        //[HttpPost("{Insert2}")]
        ////[Route("Insert2")]
        //public ActionResult Insert2(Person person)
        //{
        //    personRepository.Insert(person);
        //    return Ok();
        //}

        [HttpPost]
        public ActionResult Post(Person person)
        {
            try
            {
                return Ok(personRepository.Insert(person));
            }
            catch (Exception)
            {

                return StatusCode(405, new { status = HttpStatusCode.MethodNotAllowed, message = "Data gagal dimasukkan" });
            }
            //status code 405
        }

        [HttpGet]
        public ActionResult Get()
        {
            IEnumerable<Person> persons = personRepository.Get();
            if (persons != null)
            {
                return Ok(persons);
            }
            else
            {
                return NotFound();
            } 
        }

        [HttpGet("{NIK}")]
        public ActionResult Get(string NIK)
        {
            var person = personRepository.Get(NIK);
            if (person != null)
            {
                return Ok(person);
            }
            else 
            { 
                return NotFound("Data tidak ditemukan");
            }

        }

        [HttpGet("GetAllFirstName")]
        public ActionResult GetAllFirstName()
        {
            IEnumerable<PersonVM> persons = personRepository.GetAllFirstName();
            if (persons != null)
            {
                return Ok(persons);
            } else
            {
                return NotFound();
            } 
        }

        [HttpGet("GetFirstName/{NIK}")]
        public ActionResult GetFirstName(string NIK)
        {
            if (personRepository.Get(NIK) != null)
            {
                PersonVM person = personRepository.GetFirstName(NIK);
                return Ok(person);
            } else
            {
                return NotFound("Data tidak ditemukan");
            } 
        }

        [HttpDelete("{NIK}")]
        public ActionResult Delete(string NIK)
        {
            //var person = personRepository.Get(NIK);
            if (personRepository.Get(NIK) != null)
            {
                return Ok(personRepository.Delete(NIK));
            } else
            {
                return NotFound("Data tidak ditemukan");
            } 
            //personRepository.Delete(NIK);
            //return "Not Found"
        }

        [HttpPut]
        public ActionResult Update(Person person)
        {
            //personRepository.Update(person);
            try
            {
                return Ok(personRepository.Update(person));

            }
            catch (Exception)
            {

                return StatusCode(405, new { status = HttpStatusCode.MethodNotAllowed, message = "Data gagal diperbaharui"});
            }
        }
    }
}
