using FluentValidation;
using JwtProje.Entities.DTOs.ProductDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtProje.Business.ValidationRules.FluentValidation
{
    public class ProductUpdateDtoValidator: AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez.");
        }
    }
}
