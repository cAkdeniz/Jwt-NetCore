using JwtProje.DataAccess.Interfaces;
using JwtProje.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtProje.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfProductRepository: EfGenericRepository<Product>, IProductDal
    {
    }
}
