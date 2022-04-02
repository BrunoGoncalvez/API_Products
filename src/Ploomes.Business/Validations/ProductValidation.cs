using FluentValidation;
using Ploomes.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ploomes.Business.Validations
{
    public class ProductValidation : AbstractValidator<Product>
    {

        public ProductValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} required")
                .Length(2, 200).WithMessage("The field must be between {MinLength} and {MaxLength} characters long.");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("{PropertyName} required")
                .Length(2, 1000).WithMessage("The field must be between {MinLength} and {MaxLength} characters long.");

            RuleFor(c => c.Price)
                .GreaterThan(0).WithMessage("The field must be greater than {ComparisonValue}.");
        }

    }
}
