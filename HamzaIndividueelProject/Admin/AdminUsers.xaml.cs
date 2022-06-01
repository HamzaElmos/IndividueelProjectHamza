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
    /// Interaction logic for AdminUsers.xaml
    /// </summary>
    public partial class AdminUsers : Window
    {
        public AdminUsers()
        {
            InitializeComponent();
        }

        public List<User> DatabaseUsers { get; private set; }

        public void Create()
        {
            using (Context ctx = new Context())
            {
                string name = tbFirstName.Text;
                string lastname = tbLastName.Text;
                string username = tbUsername.Text;
                string password = tbPassword.Text;
                DateTime dateTime = tbJoined.DisplayDate;



                if (name != null && lastname != null && username != null && password != null && dateTime != null)
                {
                    ctx.Users.Add(new User() { Name = name, LastName = lastname, Username = username, PasswordHash = password, DatedJoined = dateTime });
                    ctx.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Niet alle velden zijn ingevuld");
                }
                //clear boxes
                tbFirstName.Clear();
                tbLastName.Clear();
                tbUsername.Clear();
                tbPassword.Clear();





            }
        }
       

        public void Read()
        {
            using (Context ctx = new Context())
            {
                DatabaseUsers = ctx.Users.ToList();
                ItemList.ItemsSource = DatabaseUsers;

            }
        }

        public void Update()
        {
            using (Context ctx = new Context())
            {
                User selectedUser = ItemList.SelectedItem as User;
                string name = tbFirstName.Text;
                string lastname = tbLastName.Text;
                string username = tbUsername.Text;
                string password = tbPassword.Text;
                DateTime dateTime = tbJoined.DisplayDate;


                if (name != null && lastname != null && username != null && password != null && dateTime != null)
                {
                    User user = ctx.Users.Find(selectedUser.ID);
                    user.Name = name;
                    user.Username = username;
                    user.LastName = lastname;
                    user.PasswordHash = password;
                    user.DatedJoined = dateTime;
                    ctx.SaveChanges();
                }
                MessageBox.Show($"{tbUsername.Text} is updated");
            }
        }

        public void Delete()
        {

            using (Context ctx = new Context())
            {
                User selectedUser = ItemList.SelectedItem as User;


                if (selectedUser != null)
                {

                    User user = ctx.Users.Single(x => x.ID == selectedUser.ID);

                    ctx.Remove(user);
                    ctx.SaveChanges();
                }
                MessageBox.Show($"bye bye");
            }
        }



        private void btnAddUser_Click(object sender, RoutedEventArgs e)
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
