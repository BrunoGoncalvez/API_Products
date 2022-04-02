using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ploomes.API.ViewModels
{
    public class ProviderViewModel
    {

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(100, ErrorMessage = "The field must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(14, ErrorMessage = "The field must be between {2} and {1} characters long.", MinimumLength = 11)]
        public string Identification { get; set; }

        public int ProviderType { get; set; }

        public AddressViewModel Address { get; set; }

        public bool Active { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }

    }
}
