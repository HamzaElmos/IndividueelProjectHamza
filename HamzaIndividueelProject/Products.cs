using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamzaIndividueelProject
{
    public class Products
    {
        public int ID { get; set; }

        public string BrandName { get; set; }

        public string ModelName { get; set; }

        public bool InStock { get; set; }

        public string Supplier { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal PurchasePrice { get; set; }
    }
}
