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
        public IEnumerable<Person> Get()
        {
            var person = crud.GetPerson();
            return person;
        }
        //ADD Person
        [HttpPost]
        //[Route("/api/Post/Person")]
        public IHttpActionResult Post([FromBody]Person p)
        {
            if (p != null)
            {
                // Make a call to CRUD Method to insert in to DB
                crud.Add(p);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        // to do  Put

        // to do Delete

    }
}