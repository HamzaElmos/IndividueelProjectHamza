using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HamzaIndividueelProject.Admin
{
    /// <summary>
    /// Interaction logic for AdminProduct.xaml
    /// </summary>
    public partial class AdminProduct : Window
    {
        public AdminProduct()
        {
            InitializeComponent();
        }
        public List<Customers> DatabaseCustomers { get; private set; }

        public void Create()
        {
            using (Context ctx = new Context())
            {
                var brandname = cbBrandName.Text;
                var modelname = tbModelName.Text;
                var supplier = tbSupplier.Text;
                var unitprice = tbUnitPrice.Text;
                var purchaseprice = tbPurchasePrice.Text;
                var quantity = tbQuantity.Text;


                if (brandname != null && modelname != null && supplier != null && unitprice != null && purchaseprice != null && quantity != null)
                {
                    ctx.Products.Add(new Products() { BrandName = brandname, ModelName = modelname, Supplier = supplier, UnitPrice = unitprice.Length, PurchasePrice = purchaseprice.Length, PostalCode = postcode });
                    ctx.SaveChanges();
                }
                




            }
        }
    }
}
