using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactsApi.Models
{
    public class Person
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MyProperty { get; set; }
        public string PhoneNumber { get; set; }
        public long OrganizationId { get; set; }
        [JsonIgnore]
        public Organization Organization { get; set; }
        public List<Address> Adresses { get; set; }
    }
}