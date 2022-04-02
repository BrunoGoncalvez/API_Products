using System;
using System.Collections.Generic;
using System.Text;

namespace Ploomes.Business.Models
{
    public class Address : Entity
    {

        public Guid ProviderId { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Additional { get; set; }
        public string ZipCode { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }


        public Provider Provider { get; set; } // EF


    }
}
