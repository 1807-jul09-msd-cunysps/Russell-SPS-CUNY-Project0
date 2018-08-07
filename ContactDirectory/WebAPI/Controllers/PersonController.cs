using System;
using System.Collections.Generic;
using System.Web.Http;
using ContactDal;
using ContactLibrary;
using System.Web.Http.Cors;

namespace ContactAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class PersonController : ApiController
    {
        PersonCRUD crud = new PersonCRUD();
       // [Route("/api/Person")]
        //READ
        [HttpGet]
        [Route("api/Person")]
        public IEnumerable<Person> Get()
        {
            var person = crud.GetPerson();
            return person;
        }
        //ADD Person
        [HttpPost]
        [Route("api/Person")]
        public IHttpActionResult Post([FromBody]Person p)
        {
            try
            {   
                // Make a call to CRUD Method to insert in to DB
                crud.Add(p);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + e.StackTrace);
            }
        }

        [Route("api/Message")]
        [HttpPost]
        public IHttpActionResult PostMessage([FromBody]Message m)
        {
            try
            {
                crud.Add(m);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }
    }
}