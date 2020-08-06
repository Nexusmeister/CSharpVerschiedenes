using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //VPE
        public short QuantityInPackage { get; set; }

        //Messeinheit
        public UnitOfMeasurement UnitOfMeasurement { get; set; }

        //Relation auf Category
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
