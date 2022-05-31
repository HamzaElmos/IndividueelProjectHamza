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

namespace HamzaIndividueelProject.Magazijnier
{
    /// <summary>
    /// Interaction logic for MagazijnierProducts.xaml
    /// </summary>
    public partial class MagazijnierProducts : Window
    {
        public MagazijnierProducts()
        {
            InitializeComponent();
        }

        public List<Products> DatabaseProducts { get; private set; }

        public void Create()
        {
            using (Context ctx = new Context())
            {
                string brandname = cbBrandName.Text;
                string modelname = tbModelName.Text;
                string supplier = tbSupplier.Text;
                decimal unitprice = Convert.ToDecimal(tbUnitPrice.Text);
                decimal purchaseprice = Convert.ToDecimal(tbPurchasePrice.Text);
                int quantity = Convert.ToInt32(tbQuantity.Text);


                if (brandname != null && modelname != null && supplier != null)
                {
                    ctx.Products.Add(new Products() { BrandName = brandname, ModelName = modelname, Supplier = supplier, UnitPrice = unitprice, PurchasePrice = purchaseprice, Quantity = quantity });
                    ctx.SaveChanges();
                }
                tbModelName.Clear();
                tbSupplier.Clear();
                tbUnitPrice.Clear();
                tbPurchasePrice.Clear();
                tbQuantity.Clear();




            }
        }


        public void Read()
        {
            using (Context ctx = new Context())
            {
                DatabaseProducts = ctx.Products.ToList();
                ItemList.ItemsSource = DatabaseProducts;

            }
        }

        public void Update()
        {
            using (Context ctx = new Context())
            {
                Products selectedProduct = ItemList.SelectedItem as Products;

                string brandname = cbBrandName.Text;
                string modelname = tbModelName.Text;
                string supplier = tbSupplier.Text;
                decimal unitprice = Convert.ToDecimal(tbUnitPrice.Text);
                decimal purchaseprice = Convert.ToDecimal(tbPurchasePrice.Text);
                int quantity = Convert.ToInt32(tbQuantity.Text);

                if (brandname != null && modelname != null && supplier != null)
                {
                    Products product = ctx.Products.Find(selectedProduct.OrderID);
                    product.BrandName = brandname;
                    product.ModelName = modelname;
                    product.Supplier = supplier;
                    product.UnitPrice = unitprice;
                    product.PurchasePrice = purchaseprice;
                    product.Quantity = quantity;

                    ctx.SaveChanges();
                }
                MessageBox.Show($"{cbBrandName.Text} {tbModelName.Text} is updated");


            }

        }

        public void Delete()
        {

            using (Context ctx = new Context())
            {
                Products selectedProduct = ItemList.SelectedItem as Products;


                if (selectedProduct != null)
                {

                    Products products = ctx.Products.Single(x => x.OrderID == selectedProduct.OrderID);

                    ctx.Remove(products);
                    ctx.SaveChanges();
                }
                MessageBox.Show($"bye bye");
            }
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            Create();
        }

        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            Read();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Delete();
        }

       
    }
}

