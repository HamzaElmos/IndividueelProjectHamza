using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamzaIndividueelProject.Classes
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }
        public string GarageName { get; set; }
        public string ContactNameOrder { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
    }
}
