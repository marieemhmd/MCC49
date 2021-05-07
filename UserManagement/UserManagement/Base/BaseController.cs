using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UserManagement.Repository.Interface;

namespace UserManagement.Base
{
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [ApiController]
    public class BaseController<Entity, Repository, Key> : ControllerBase
        where Entity : class
        where Repository : IRepository<Entity, Key>
    {
        private readonly Repository repo;
        public BaseController(Repository repository)
        {
            this.repo = repository;
        }

        //get post put delete
        // GET api/values    
        /// <summary>    
        /// Get method    
        /// </summary>    
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get()
        {
            IEnumerable<Entity> entities = repo.Get();
            if (entities != null)
            {
                return Ok(entities);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/values    
        /// <summary>    
        /// Post method    
        /// </summary>    
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post(Entity entity)
        {
            try
            {
                repo.Insert(entity);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(405, new { status = HttpStatusCode.MethodNotAllowed, message = "Data gagal dimasukkan" });
            }
        }

        // PUT api/values    
        /// <summary>    
        /// Put method    
        /// </summary>    
        /// <returns></returns>
        [HttpPut]
        public ActionResult Update(Entity entity)
        {
            try
            {
                repo.Update(entity);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(405, new { status = HttpStatusCode.MethodNotAllowed, message = "NIK tidak ditemukan. Data gagal diperbaharui" });
            }
        }

        // DELETE api/values    
        /// <summary>    
        /// Delete method    
        /// </summary>    
        /// <returns></returns>
        [HttpDelete("{key}")]
        public ActionResult Delete(Key key)
        {
            if (repo.Get(key) != null)
            {
                repo.Delete(key);
                return Ok();
            }
            else
            {
                return NotFound("Data tidak ditemukan");
            }
        }

    }
}
