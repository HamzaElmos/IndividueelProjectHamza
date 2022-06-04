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

namespace HamzaIndividueelProject
{
    /// <summary>
    /// Interaction logic for AdminCustomers.xaml
    /// </summary>
    public partial class AdminCustomers : Window
    {
        public AdminCustomers()
        {
            InitializeComponent();
        }

        public List<Customers> DatabaseCustomers { get; private set; }

        public void Create()
        {
            using (Context ctx = new Context())
            {
                var garagename = tbGarageName.Text;
                var contactname = tbContactName.Text;
                var address = tbAddress.Text;
                var country = tbCountry.Text;
                var city = tbCity.Text;
                var postcode = tbPostcode.Text;


                if (garagename != null && contactname != null && address != null && country != null && city != null && postcode != null)
                {
                    ctx.Customers.Add(new Customers() { CustomerName = garagename, ContactName = contactname, Country = country, Address = address, City = city, PostalCode = postcode });
                    ctx.SaveChanges();
                }
                tbGarageName.Clear();
                tbContactName.Clear();
                tbAddress.Clear();
                tbCountry.Clear();
                tbCity.Clear();
                tbPostcode.Clear();




            }
        }
        public void Read()
        {
            using (Context ctx = new Context())
            {
                DatabaseCustomers = ctx.Customers.ToList();
                ItemList.ItemsSource = DatabaseCustomers;

            }
        }

        public void Update()
        {
            using (Context ctx = new Context())
            {
                Customers selectedCustomer = ItemList.SelectedItem as Customers;

                if(selectedCustomer == null)
                {
                    MessageBox.Show("Nothing is selected", "Error");
                }
                else
                {
                    var garagename = tbGarageName.Text;
                    var contactname = tbContactName.Text;
                    var address = tbAddress.Text;
                    var country = tbCountry.Text;
                    var city = tbCity.Text;
                    var postcode = tbPostcode.Text;

                    if (garagename != null && contactname != null && address != null && country != null && city != null && postcode != null)
                    {
                        Customers customer = ctx.Customers.Find(selectedCustomer.ID);
                        customer.CustomerName = garagename;
                        customer.ContactName = contactname;
                        customer.Address = address;
                        customer.City = city;
                        customer.PostalCode = postcode;
                        customer.Country = country;

                        ctx.SaveChanges();
                    }
                    MessageBox.Show($"{tbGarageName.Text} is updated");
                }
               


            }

        }

        public void Delete()
        {

            using (Context ctx = new Context())
            {
                Customers selectedCustomer = ItemList.SelectedItem as Customers;


                if (selectedCustomer != null)
                {

                    Customers customer = ctx.Customers.Single(x => x.ID == selectedCustomer.ID);

                    ctx.Remove(customer);
                    ctx.SaveChanges();
                }
                MessageBox.Show($"bye bye");
            }
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
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
    }
}
