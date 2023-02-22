using JwtProje.Business.Interfaces;
using JwtProje.DataAccess.Interfaces;
using JwtProje.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtProje.Business.Concrete
{
    public class ProductManager: GenericManager<Product>, IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IGenericDal<Product> genericDal, IProductDal productDal) :base(genericDal)
        {
            _productDal = productDal;
        }
    }
}
