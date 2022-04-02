using System;
using System.Collections.Generic;
using System.Text;

namespace Ploomes.Business.Models
{
    public abstract class Entity
    {

        public Guid Id { get; set; }

        protected Entity()
        {
            Id = new Guid();
        }

    }
}
