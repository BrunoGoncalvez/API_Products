using FluentValidation;
using Ploomes.Business.Models;
using Ploomes.Business.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using static Ploomes.Business.Validations.Identification.ValidateIdentification;

namespace Ploomes.Business.Validations
{
    public class ProviderValidation : AbstractValidator<Provider>
    {

        public ProviderValidation()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} required")
                                .Length(2, 100).WithMessage("The field must be between {MinLength} and {MaxLength} characters long.");
            When(p => p.ProviderType == ProviderType.Individual, () => 
            {
                RuleFor(p => p.Identification.Length).Equal(CpfValidacao.TamanhoCpf)
                    .WithMessage("Invalid CPF");
                RuleFor(p => CpfValidacao.Validar(p.Identification)).Equal(true)
                    .WithMessage("Invalid CPF");
            });
            When(p => p.ProviderType == ProviderType.Company, () => 
            {
                RuleFor(p => p.Identification.Length).Equal(CnpjValidacao.TamanhoCnpj)
                    .WithMessage("CNPJ Invalid");
                RuleFor(p => CnpjValidacao.Validar(p.Identification)).Equal(true)
                    .WithMessage("CNPJ Invalid");
            });
        }

    }
}
