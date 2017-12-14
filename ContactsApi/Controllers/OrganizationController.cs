using ContactsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContactsApi.Controllers
{
    [Route("organization")]
    public class OrganizationController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
        [HttpGet]
        [Route("organization/{id}")]
        public Organization Get(int id)
        {
            return new Organization();
        }

        [HttpPost]
        [Route("organization")]
        public IHttpActionResult Post([FromBody]Organization organization)
        {
            return Ok();
        }

        [HttpGet]
        [Route("organization/{orgId}/people")]
        public List<Person> GetPeople([FromUri]long orgId)
        {
            return new List<Person>();
        }

        [HttpPost]
        [Route("organization/{orgId}/people")]
        public IHttpActionResult AddPerson([FromBody]Person person)
        {
            return Ok();
        }
    }
}