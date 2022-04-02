using System.Collections.Generic;
using Ploomes.Business.Models.Enums;

namespace Ploomes.Business.Models
{
    public class Provider : Entity
    {

        public string Name { get; set; }
        public string Identification { get; set; }
        public ProviderType ProviderType { get; set; }
        public Address Address { get; set; }
        public bool Active { get; set; }


        public IEnumerable<Product> Products { get; set; } // EF

    }
}
