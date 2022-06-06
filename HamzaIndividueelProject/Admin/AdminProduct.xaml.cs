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
            Read();

        }
        public List<Products> DatabaseProducts { get; private set; }

        public void Create()
        {
            using (Context ctx = new Context())
            {
                string brandname = cbBrandName.Text;
                string modelname = tbModelName.Text;
                string supplier = tbSupplier.Text;
                decimal unitprice = Convert.ToDecimal( tbUnitPrice.Text);
                decimal purchaseprice = Convert.ToDecimal( tbPurchasePrice.Text);
                double deductabletax = Convert.ToDouble(tbTax.Text);
                double total = Convert.ToDouble(tbTotalIncl.Text);
                double totalexcl = Convert.ToDouble(tbTotalExcl.Text);
                decimal margin = Convert.ToDecimal( tbMargin.Text);
                int quantity = Convert.ToInt32( tbQuantity.Text);



                if (brandname != null && modelname != null && supplier != null)
                {
                    ctx.Products.Add(new Products() { BrandName = brandname, ModelName = modelname, Supplier = supplier, UnitPrice = unitprice, PurchasePrice = purchaseprice, Quantity = quantity, Margin = margin});
                    ctx.SaveChanges();
                }
                tbModelName.Clear();
                tbSupplier.Clear();
                tbUnitPrice.Clear();
                tbPurchasePrice.Clear();
                tbQuantity.Clear();
                tbMargin.Clear();
                tbTax.Clear();
                tbTotalIncl.Clear();
                tbTotalExcl.Clear();




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

                if(selectedProduct == null)
                {
                    MessageBox.Show("Nothing is selected", "Error");
                }
                else
                {
                    string brandname = cbBrandName.Text;
                    string modelname = tbModelName.Text;
                    string supplier = tbSupplier.Text;
                    decimal unitprice = Convert.ToDecimal(tbUnitPrice.Text);
                    decimal purchaseprice = Convert.ToDecimal(tbPurchasePrice.Text);
                    decimal margin = Convert.ToDecimal(tbMargin.Text);
                    double tax = Convert.ToDouble(tbTax.Text);
                    double totalIncl = Convert.ToDouble(tbTotalIncl.Text);
                    double totalexcl = Convert.ToDouble(tbTotalExcl.Text);
                    int quantity = Convert.ToInt32(tbQuantity.Text);

                    if (brandname != null && modelname != null && supplier != null)
                    {
                        Products product = ctx.Products.Find(selectedProduct.OrderID);
                        product.BrandName = brandname;
                        product.ModelName = modelname;
                        product.Supplier = supplier;
                        product.UnitPrice = unitprice;
                        product.PurchasePrice = purchaseprice;
                        product.DeductableTax = tax;
                        product.Total = totalIncl;
                        product.TotalExcl = totalexcl;
                        product.Margin = margin;
                        product.Quantity = quantity;

                        ctx.SaveChanges();
                    }
                    tbModelName.Clear();
                    tbSupplier.Clear();
                    tbUnitPrice.Clear();
                    tbPurchasePrice.Clear();
                    tbQuantity.Clear();
                    tbMargin.Clear();
                    tbTax.Clear();
                    tbTotalIncl.Clear();
                    tbTotalExcl.Clear();
                    MessageBox.Show($"{cbBrandName.Text} {tbModelName.Text} is updated");
                }
                


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

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow hoofd = new MainWindow();
            hoofd.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            decimal purchase = Convert.ToDecimal(tbPurchasePrice.Text);
            decimal unit = Convert.ToDecimal(tbUnitPrice.Text);
            int quantity = Convert.ToInt32(tbQuantity.Text);

            decimal margin = (decimal)((unit - purchase) * quantity);
            margin = Math.Round(margin, 2);

            tbMargin.Text= margin.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //exclusief
            decimal purchase = Convert.ToDecimal(tbPurchasePrice.Text);
            int quantity = Convert.ToInt32(tbQuantity.Text);
            double totalexcl = (double)(purchase * quantity);
            tbTotalExcl.Text= totalexcl.ToString();

            //tax
            double tax = 0.21;
            double total = totalexcl * tax;
            total = Math.Round(total, 2);
            tbTax.Text = total.ToString();

            //inclusief
            double taxincl = 1.21;
            double totalincl = totalexcl * taxincl;
            totalincl = Math.Round(total, 2);
            tbTotalIncl.Text = totalincl.ToString();

        }

       /* private void Tax_Click(object sender, RoutedEventArgs e)
        {
            decimal purchase = Convert.ToDecimal(tbPurchasePrice.Text);
            int quantity = Convert.ToInt32(tbQuantity.Text);
            double totalexcl = (double)(purchase * quantity);
            double tax = 0.21;
            double total = totalexcl * tax;
            total = Math.Round(total, 2);
            tbTax.Text= total.ToString();

        }

        private void btnTotal_Click(object sender, RoutedEventArgs e)
        {
            decimal purchase = Convert.ToDecimal(tbPurchasePrice.Text);
            int quantity = Convert.ToInt32(tbQuantity.Text);
            double totalexcl = (double)(purchase * quantity);
            double tax = 1.21;
            double total = totalexcl * tax;
            total = Math.Round(total, 2);
            tbTotalIncl.Text = total.ToString();
        } */
    }
}
