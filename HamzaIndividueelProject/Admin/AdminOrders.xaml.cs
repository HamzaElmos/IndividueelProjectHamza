using HamzaIndividueelProject.Classes;
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
    /// Interaction logic for AdminOrders.xaml
    /// </summary>
    public partial class AdminOrders : Window
    {
        public List<Orders> DatabaseOrders { get; private set; }

        public AdminOrders()
        {
            InitializeComponent();
            Read();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int quantity = Convert.ToInt32(tbQuantity.Text);
            double unitprice = Convert.ToDouble(tbUnitPrice.Text);

            double subtotal = quantity * unitprice;
            subtotal= Math.Round(subtotal, 2);

            tbTotal.Text = subtotal.ToString();
        }

        public void Create()
        {
           
                using (Context ctx = new Context())
                {
                    string brandname = cbBrandName.Text;
                    string garagename = tbGarageName.Text;
                    string contactname = tbContactNameOrder.Text;
                    string modelname = tbModelName.Text;
                    int quantity = Convert.ToInt32(tbQuantity.Text);
                    double unitprice = Convert.ToDouble(tbUnitPrice.Text);
                    double taxdue = Convert.ToDouble(tbTax);
                    double totalallin = Convert.ToDouble(tbTotalIncl.Text);
                    double total = Convert.ToDouble(tbTotal.Text);

                    if (brandname != null && garagename != null && contactname != null && modelname != null)
                    {
                        ctx.Orders.Add(new Orders() { TotalAllIn = totalallin, TaxDue = taxdue, BrandName = brandname, GarageName = garagename, ContactNameOrder = contactname, ModelName = modelname, Quantity = quantity, UnitPrice = unitprice, Total = total });
                        ctx.SaveChanges();
                    }
                    tbGarageName.Clear();
                    tbContactNameOrder.Clear();
                    tbModelName.Clear();
                    tbQuantity.Clear();
                    tbUnitPrice.Clear();
                    tbTotal.Clear();
                    tbTotalIncl.Clear();
                    tbTax.Clear();
                }
            
           
        }

        public void Read()
        {
            using (Context ctx = new Context())
            {
                DatabaseOrders = ctx.Orders.ToList();
                ItemList.ItemsSource = DatabaseOrders;

            }
        }

        public void Update()
        {
            using (Context ctx = new Context())
            {
                Orders selectedOrder = ItemList.SelectedItem as Orders;

                if(selectedOrder == null)
                {
                    MessageBox.Show("Niets aangeduid","Fout");
                }
                else
                {
                    string brandname = cbBrandName.Text;
                    string garagename = tbGarageName.Text;
                    string contactname = tbContactNameOrder.Text;
                    string modelname = tbModelName.Text;
                    int quantity = Convert.ToInt32(tbQuantity.Text);
                    double unitprice = Convert.ToDouble(tbUnitPrice.Text);
                    double taxdue = Convert.ToDouble(tbTax.Text);
                    double total = Convert.ToDouble(tbTotal.Text);
                    double totalallin = Convert.ToDouble(tbTotalIncl.Text);

                    if (brandname != null && modelname != null && garagename != null && contactname != null)
                    {
                        Orders order = ctx.Orders.Find(selectedOrder.OrderID);
                        order.BrandName = brandname;
                        order.GarageName = garagename;
                        order.ContactNameOrder = contactname;
                        order.ModelName = modelname;
                        order.UnitPrice = unitprice;
                        order.Quantity = quantity;
                        order.TaxDue = taxdue;
                        order.Total = total;
                        order.TotalAllIn = totalallin;


                        ctx.SaveChanges();
                    }
                    
                    MessageBox.Show($"Order is updated");
                    tbGarageName.Clear();
                    tbContactNameOrder.Clear();
                    tbModelName.Clear();
                    tbQuantity.Clear();
                    tbUnitPrice.Clear();
                    tbTotal.Clear();
                    tbTotalIncl.Clear();
                    tbTax.Clear();

                }
                


            }

        }

        public void Delete()
        {

            using (Context ctx = new Context())
            {
                Orders selectedOrder = ItemList.SelectedItem as Orders;


                if (selectedOrder != null)
                {

                    Orders order = ctx.Orders.Single(x => x.OrderID == selectedOrder.OrderID);

                    ctx.Remove(order);
                    ctx.SaveChanges();
                }
                MessageBox.Show($"Too bad");
            }
        }


        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
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
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int quantity = Convert.ToInt32(tbQuantity.Text);
            double unitprice = Convert.ToDouble(tbUnitPrice.Text);
            double tax = 0.21;
            double subtotal = (quantity * unitprice)*tax;
            subtotal = Math.Round(subtotal, 2);
            tbTax.Text = subtotal.ToString();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int quantity = Convert.ToInt32(tbQuantity.Text);
            double unitprice = Convert.ToDouble(tbUnitPrice.Text);
            double tax = 1.21;
            double subtotal = (quantity * unitprice) * tax;
            subtotal = Math.Round(subtotal, 2);
            tbTotalIncl.Text = subtotal.ToString();
           
        }
    }
}

