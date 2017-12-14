using ContactsApi.DataAccess;
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
        public IEnumerable<Organization> Get()
        {
            using(var ctx = new ContactDbContext())
            {
                var orgs = ctx.Organizations.Include("People").ToList();
                return orgs;
            }
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
            using (var ctx = new ContactDbContext())
            {
                ctx.Organizations.Add(organization);
                ctx.SaveChanges();
            }
            
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
        public IHttpActionResult AddPerson([FromUri]int orgId, [FromBody]Person person)
        {
            using(var ctx = new ContactDbContext())
            {
                var organization = ctx.Organizations.Single(x => x.Id == orgId);
                person.Organization = organization;
                ctx.People.Add(person);
                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}