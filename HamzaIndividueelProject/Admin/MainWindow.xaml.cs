using HamzaIndividueelProject.Admin;
using System.Windows;

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

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            AdminUsers users = new AdminUsers();
            users.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?","Loggin Off", MessageBoxButton.YesNo, MessageBoxImage.Question); 
            if(result == MessageBoxResult.Yes)
            {
                Login login = new Login();
                login.Show();
                this.Close();
            }
            
        
            
        }

        private void btnViewData_Click(object sender, RoutedEventArgs e)
        {
            SaveData saveData = new SaveData();
            saveData.Show();
            this.Close();
        }

        /* private void sidebar_SelectionChanged(object sender, SelectionChangedEventArgs e)
         {

             var selected = sidebar.SelectedItem as NavButton;

             navframe.Navigate(selected.Navlink);

         }*/


    }
}
