using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamzaIndividueelProject
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ModelName { get; set; }
        public double RetailPrice { get; set; }
        public int Quantity { get; set; }
    }
}
