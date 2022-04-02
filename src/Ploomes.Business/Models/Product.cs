using System;
using System.Collections.Generic;
using System.Text;

namespace Ploomes.Business.Models
{
    public class Product : Entity
    {

        public Guid ProviderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Active { get; set; }


        public Provider Provider { get; set; } // EF

    }
}
