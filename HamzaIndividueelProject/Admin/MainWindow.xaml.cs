using HamzaIndividueelProject.Admin;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HamzaIndividueelProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdminEmployee_Click(object sender, RoutedEventArgs e)
        {
            AdministratorScherm employee = new AdministratorScherm();
            employee.Show();
            this.Close();
        }

        private void btnAdminCustomer_Click(object sender, RoutedEventArgs e)
        {
            AdminCustomers customer = new AdminCustomers();
            customer.Show();
            this.Close();
        }

        private void btnAdminProduct_Click(object sender, RoutedEventArgs e)
        {
            AdminProduct product = new AdminProduct();
            product.Show();
            this.Close();
        }

        private void btnSupplier_Click(object sender, RoutedEventArgs e)
        {
            AdminSuppliers suppliers = new AdminSuppliers();
            suppliers.Show();
            this.Close ();
        }

        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            AdminOrders orders = new AdminOrders();
            orders.Show();
            this.Close();
        }

        /* private void sidebar_SelectionChanged(object sender, SelectionChangedEventArgs e)
         {

             var selected = sidebar.SelectedItem as NavButton;

             navframe.Navigate(selected.Navlink);

         }*/


    }
}
