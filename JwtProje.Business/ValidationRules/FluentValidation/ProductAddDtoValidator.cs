using FluentValidation;
using JwtProje.Entities.DTOs.ProductDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtProje.Business.ValidationRules.FluentValidation
{
    public class ProductAddDtoValidator: AbstractValidator<ProductAddDto>
    {
        public ProductAddDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez.");
        }
    }
}
