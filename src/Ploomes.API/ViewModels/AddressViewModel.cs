using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ploomes.API.ViewModels
{
    public class AddressViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(100, ErrorMessage = "The field must be between {2} and {1} characters long.", MinimumLength = 5)]
        public string Street { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(100, ErrorMessage = "The field must be between {2} and {1} characters long.", MinimumLength = 1)]
        public string Number { get; set; }

        public string Additional { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(8, ErrorMessage = "The field must be {1} characters long.", MinimumLength = 8)]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(100, ErrorMessage = "The field must be between {2} and {1} characters long.", MinimumLength = 5)]
        public string Neighborhood { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(100, ErrorMessage = "The field must be between {2} and {1} characters long.", MinimumLength = 5)]
        public string City { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(100, ErrorMessage = "The field must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string State { get; set; }

        public Guid ProviderId { get; set; }

    }
}
