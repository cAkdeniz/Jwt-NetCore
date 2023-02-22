using JwtProje.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtProje.Entities.DTOs.ProductDtos
{
    public class ProductAddDto: IDto
    {
        public string Name { get; set; }
    }
}
