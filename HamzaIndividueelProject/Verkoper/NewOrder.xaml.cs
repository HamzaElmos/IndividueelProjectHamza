using HamzaIndividueelProject.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using SpreadsheetLight;
using Microsoft.Win32; 



namespace HamzaIndividueelProject.Verkoper
{
    /// <summary>
    /// Interaction logic for NewOrder.xaml
    /// </summary>
    public partial class NewOrder : Window 
    {
        public List<Orders> DatabaseOrders { get; private set; }

        public NewOrder() 
        {
            InitializeComponent();
            Read();
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
                double taxdue = Convert.ToDouble(tbTax.Text) ;
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

                if (selectedOrder == null)
                {
                    MessageBox.Show("Niets aangeduid", "Fout");
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
            Verkoop verkoop = new Verkoop();
            verkoop.Show();
            this.Close();
        }

        private void lblName_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?", "Loggin Off", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Login login = new Login();
                login.Show();
                this.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbQuantity.Text == string.Empty && tbUnitPrice.Text == String.Empty)
            {
                MessageBox.Show("No valid entry");
            }
            else
            {

                int quantity = Convert.ToInt32(tbQuantity.Text);
                double unitprice = Convert.ToDouble(tbUnitPrice.Text);

                double subtotal = quantity * unitprice;
                subtotal = Math.Round(subtotal, 2);

                tbTotal.Text = subtotal.ToString();

                //tax
                double tax = 0.21;
                double taxexcl = subtotal * tax;
                taxexcl = Math.Round(subtotal, 2);
                tbTax.Text = taxexcl.ToString();

                //tax incl
                double taxincl = 1.21;
                double total = subtotal * taxincl;
                subtotal = Math.Round(subtotal, 2);
                tbTotalIncl.Text = subtotal.ToString();
                
            }
            


        }

        public void CreateFile(string path)
        {
            if (path != String.Empty)
            {
                using (SLDocument Doc = new SLDocument())
                {
                    
                    Doc.AutoFitColumn(20);
                    Doc.SetCellValue("C1", tbGarageName.Text);
                    Doc.SetCellValue("D1", tbContactNameOrder.Text);
                    Doc.SetCellValue("A3", cbBrandName.Text);
                    Doc.SetCellValue("B3", tbModelName.Text);
                    Doc.SetCellValue("D3", tbUnitPrice.Text);
                    Doc.SetCellValue("E3", tbQuantity.Text);
                    Doc.SetCellValue("D6", tbTotal.Text);
                    Doc.SetCellValue("D7", tbTax.Text);
                    Doc.SetCellValue("D10", tbTotalIncl.Text);
                    Doc.SaveAs(path);

                }
            }


        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = "xlsx";

            if (saveFile.ShowDialog() == true)
            {
                CreateFile(saveFile.FileName);

            }


        }

       
    }
}
