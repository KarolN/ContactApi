using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactsApi.Models
{
    public class Address
    {
        public long Id { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public List<Person> People { get; set; }
    }
}