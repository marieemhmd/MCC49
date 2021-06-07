using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Entity, Repository, Key> : ControllerBase
        where Entity : class
        where Repository : IRepository<Entity, Key>
    {
        private readonly Repository repository;
        public BaseController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<Entity> Get()
        {
            var data = repository.Get();

            if (data != null)
            {
                return Ok(new { status = HttpStatusCode.OK, data, message = "Data Found" });
            }
            else
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, data, message = "Data Not Found" }); ;
            }
        }

        [HttpGet("{key}")]
        public ActionResult<Entity> Get(Key key)
        {
            var data = repository.Get(key);
            if (data != null)
            {
                return Ok(new { status = HttpStatusCode.OK, data, message = "Data Found" });
            }
            else
            {
                return NotFound(new { status = HttpStatusCode.NotFound, message = "Data Not Found" });
            }
        }

        [HttpPost]
        public ActionResult Post(Entity entity)
        {
            var data = repository.Insert(entity);
            if (data > 0)
            {
                return Ok(new { status = HttpStatusCode.OK, data = "", message = "Successfully Creating New Data" });
            }
            else
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = "Failed to Create New Data" });
            }
        }

        [HttpDelete("{key}")]
        public ActionResult Delete(Key key)
        {
            var data = repository.Delete(key);
            if (data > 0)
            {
                return Ok(new { status = HttpStatusCode.OK, data = "", message = "Successfully Deleting Data" });
            }
            else
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = "Failed to Delete Data" });
            }
        }

        [HttpPut]
        public ActionResult Put(Entity entity)
        {
            if (entity == null)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "The Data Entered is Incorrect / Incomplete" });
            }

            var data = repository.Update(entity);

            if (data > 0)
            {
                return Ok(new { status = HttpStatusCode.OK, data = "", message = "Successfully Update Data" });
            }
            else
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = "Failed to Update Data" });
            }
        }
    }
}