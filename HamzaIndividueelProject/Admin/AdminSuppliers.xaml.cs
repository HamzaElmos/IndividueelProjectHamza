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
    /// Interaction logic for AdminSuppliers.xaml
    /// </summary>
    public partial class AdminSuppliers : Window
    {
        public List<Suppliers> DatabaseSuppliers { get; private set; }

        public AdminSuppliers()
        {
            InitializeComponent();
            Read();
        }

        public void Create()
        {
            using (Context ctx = new Context())
            {
                string suppliername = tbSupplierName.Text;
                string contactname = tbContactName.Text;
                string address = tbAddress.Text;
                string country = tbCountry.Text;
                string city = tbCity.Text;
                string postcode = tbPostcode.Text;
                string phone = tbPhone.Text;


                if (suppliername != null && contactname != null && address != null && country != null && city != null && postcode != null && phone != null)
                {
                    ctx.Suppliers.Add(new Suppliers() { SupplierName = suppliername, ContactName = contactname, Country = country, Address = address, City = city, PostalCode = postcode, Phone = phone });
                    ctx.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Niet alle velden zijn ingevuld");
                }
                tbSupplierName.Clear();
                tbContactName.Clear();
                tbAddress.Clear();
                tbCountry.Clear();
                tbCity.Clear();
                tbPostcode.Clear();
                tbPhone.Clear();




            }
        }

        public void Read()
        {
            using (Context ctx = new Context())
            {
                DatabaseSuppliers = ctx.Suppliers.ToList();
                ItemList.ItemsSource = DatabaseSuppliers;

            }
        }

        public void Update()
        {
            using (Context ctx = new Context())
            {
                Suppliers selectedSuppliers= ItemList.SelectedItem as Suppliers;
                if(selectedSuppliers == null)
                {
                    MessageBox.Show("Nothing is selected", "Error");
                }
                else
                {
                    string suppliername = tbSupplierName.Text;
                    string contactname = tbContactName.Text;
                    string address = tbAddress.Text;
                    string country = tbCountry.Text;
                    string city = tbCity.Text;
                    string postcode = tbPostcode.Text;
                    string phone = tbPhone.Text;

                    if (suppliername != null && contactname != null && address != null && country != null && city != null && postcode != null && phone != null)
                    {
                        Suppliers supplier = ctx.Suppliers.Find(selectedSuppliers.ID);
                        supplier.SupplierName = suppliername;
                        supplier.ContactName = contactname;
                        supplier.Address = address;
                        supplier.City = city;
                        supplier.PostalCode = postcode;
                        supplier.Country = country;
                        supplier.Phone = phone;

                        ctx.SaveChanges();
                    }
                    MessageBox.Show($"{tbSupplierName.Text} is updated");

                    tbSupplierName.Clear();
                    tbContactName.Clear();
                    tbContactName.Clear();
                    tbAddress.Clear();
                    tbCity.Clear();
                    tbPostcode.Clear();
                    tbCountry.Clear();
                    tbPhone.Clear();
                }
                
            }

        }

        public void Delete()
        {

            using (Context ctx = new Context())
            {
                Suppliers selectedSupplier = ItemList.SelectedItem as Suppliers;


                if (selectedSupplier != null)
                {

                    Suppliers supplier = ctx.Suppliers.Single(x => x.ID == selectedSupplier.ID);

                    ctx.Remove(supplier);
                    ctx.SaveChanges();
                }
                MessageBox.Show($"bye bye");
            }
        }

        private void btnAddSupplier_Click(object sender, RoutedEventArgs e)
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
    }
}
