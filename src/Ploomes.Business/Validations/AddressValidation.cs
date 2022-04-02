using FluentValidation;
using Ploomes.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ploomes.Business.Validations
{
    public class AddressValidation : AbstractValidator<Address>
    {

        public AddressValidation()
        {
            RuleFor(c => c.Street)
                .NotEmpty().WithMessage("{PropertyName} required")
                .Length(2, 200).WithMessage("The field must be between {MinLength} and {MaxLength} characters long.");

            RuleFor(c => c.Neighborhood)
                .NotEmpty().WithMessage("{PropertyName} required")
                .Length(2, 100).WithMessage("The field must be between {MinLength} and {MaxLength} characters long.");

            RuleFor(c => c.ZipCode)
                .NotEmpty().WithMessage("{PropertyName} required")
                .Length(8).WithMessage("The field must be between {MinLength} and {MaxLength} characters long.");

            RuleFor(c => c.City)
                .NotEmpty().WithMessage("{PropertyName} required")
                .Length(2, 100).WithMessage("The field must be between {MinLength} and {MaxLength} characters long.");

            RuleFor(c => c.State)
                .NotEmpty().WithMessage("{PropertyName} required")
                .Length(2, 50).WithMessage("The field must be between {MinLength} and {MaxLength} characters long.");

            RuleFor(c => c.Number)
                .NotEmpty().WithMessage("{PropertyName} required")
                .Length(1, 50).WithMessage("The field must be between {MinLength} and {MaxLength} characters long.");
        }

    }
}
