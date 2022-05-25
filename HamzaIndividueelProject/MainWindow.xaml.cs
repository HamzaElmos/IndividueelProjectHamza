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

        private void btnEmployees_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string ConnectionString = @"Data Source = LAPTOP-GUFE3U9Q\SQLEXPRESS;Database=LoginData;Trusted_Connection=True;";

            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(" Select * from Employees", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            DatagridXML.Items.Add(dt);
        }
    }
}
