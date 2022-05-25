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
    /// Interaction logic for AdministratorScherm.xaml
    /// </summary>
    public partial class AdministratorScherm : Window
    {
        public List<Employees> DatabaseEmployees { get; private set; }

        public AdministratorScherm()
        {
            InitializeComponent();
        }
        public void Create()
        {
            using (Context ctx = new Context())
            {
                var name = tbFirstNameEmployee.Text;
                var lastname = tbLastNameEmployee.Text;
                var address = tbAddress.Text;
                var departement = cbDepartement.Text;
                var city = tbCity.Text;
                var postcode = tbPostcode.Text;


                if (name != null && lastname != null && address != null && departement != null)
                {
                    ctx.Employees.Add(new Employees() { FirstName = name, LastName = lastname, Departement = departement, Address= address, City=city, Postcode=postcode });
                    ctx.SaveChanges();
                }
                


            }
        }
        public void Read()
        {
            using (Context ctx = new Context())
            {
                DatabaseEmployees = ctx.Employees.ToList();
                ItemList.ItemsSource = DatabaseEmployees;

            }

        }
        public void Update()
        {
            using (Context ctx = new Context())
            {
                Employees selectedEmployee = ItemList.SelectedItem as Employees;

                var name = tbFirstNameEmployee.Text;
                var lastname = tbLastNameEmployee.Text;
                var address = tbAddress.Text;
                var departement = cbDepartement.Text;
                var city = tbCity.Text;
                var postcode = tbPostcode.Text;

                if (name != null && lastname != null && address != null && departement != null && city != null && postcode != null)
                {
                    Employees employee = ctx.Employees.Find(selectedEmployee.FirstName);
                    employee.FirstName = name;
                    employee.LastName = lastname;
                    employee.Departement = departement;
                    employee.Address = address;

                    ctx.SaveChanges();

                }


            }

        }
        public void Delete()
        {

            using (Context ctx = new Context())
            {
                Employees selectedEmployee = ItemList.SelectedItem as Employees;


                if(selectedEmployee != null)
                {

                    Employees employee = ctx.Employees.Single(x=> x.FirstName == selectedEmployee.FirstName);

                    ctx.Remove(employee);
                    ctx.SaveChanges();
                }
                
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ItemList.Items.Clear();
        }
    }
}