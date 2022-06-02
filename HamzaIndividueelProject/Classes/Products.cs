using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamzaIndividueelProject
{
    public class Products
    {
        [Key]
        public int OrderID { get; set; }

        public string BrandName { get; set; }

        public string ModelName { get; set; }

        public int Quantity { get; set; }

        public string Supplier { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal PurchasePrice { get; set; }
        public decimal Margin { get; set; }

    }
    
}
