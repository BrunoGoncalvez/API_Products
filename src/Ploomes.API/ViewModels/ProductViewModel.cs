using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ploomes.API.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public Guid ProviderId { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(100, ErrorMessage = "The field must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(1000, ErrorMessage = "The field must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public decimal Price { get; set; }

        public string ImageUpload { get; set; }

        public string Image { get; set; }

        [ScaffoldColumn(false)]
        public DateTime RegistrationDate { get; set; }

        public bool Active { get; set; }
        
        [ScaffoldColumn(false)]
        public string ProviderName { get; set; }

    }
}
