using JwtProje.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtProje.Entities
{
    public class Product: ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
