using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactsApi.Models
{
    public class Organization
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public List<Person> People { get; set; }
    }
}