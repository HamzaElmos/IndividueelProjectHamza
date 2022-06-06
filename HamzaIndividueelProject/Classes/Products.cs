using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
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
        public double DeductableTax {get; set; }
        public double TotalExcl { get; set; }
        public double Total { get; set; }
        public decimal Margin { get; set; }


        public static List<Products> GetData(string path)
        {

            
            var file = path;
            var lines = File.ReadAllLines(file);
            var list = new List<Products>();

            for (int i = 2; i < lines.Length; i++)
            {
                var line = lines[i].Split(';');
                var productupdate = new Products()
                {
                    Supplier = line[0],
                    BrandName = line[1],
                    ModelName = line[2],
                    PurchasePrice = Convert.ToDecimal(line[3]),
                    Quantity = Convert.ToInt32(line[4])
                };
                list.Add(productupdate);
            }
            return list;
        }

    }
    
}
