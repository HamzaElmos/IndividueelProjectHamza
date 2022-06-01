﻿using HamzaIndividueelProject.Magazijnier;
using HamzaIndividueelProject.Verkoper;
using System.Linq;
using System.Windows;

namespace HamzaIndividueelProject
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

           /* var username = txtUsername.Text;
            var password = txtPassword.Password;

            using (Context context = new Context())
            {

                bool userfound = context.Users.Any(user => user.Username == username && user.PasswordHash == password);

                if (userfound)
                {
                    GrantAccess();

                }
                else
                {
                    MessageBox.Show("Wrong Username or Password");
                }

            }

            */
             using (Context ctx = new Context())
            {
                if(cbProfile.Text != null && txtPassword.Password != null && txtUsername.Text != null)
                {
                    ctx.LoginData.Add(new LoginData()
                    {
                        Profile = cbProfile.Text,
                        Username = txtUsername.Text,
                        Password = txtPassword.Password

                    }
                    );

                    ctx.SaveChanges();
                }               
            switch (cbProfile.Text)
            {
                case "Administrator":
                    MainWindow hoofd = new MainWindow();
                    hoofd.Show();
                    this.Close();
                    break;

                case "Verkoper":
                    Verkoop verkoper = new Verkoop();
                    verkoper.Show();
                    this.Close();
                    break;
                case "Magazijnier":
                    MagazijnierProducts magazijn = new MagazijnierProducts();
                    magazijn.Show();
                    this.Close();
                    break;
            }
            }
            txtUsername.Clear();
            txtPassword.Clear();




        }

        public void GrantAccess()
        {
            switch (cbProfile.Text)
            {
                case "Administrator":
                    MainWindow hoofd = new MainWindow();
                    hoofd.Show();
                    this.Close();
                    break;

                case "Verkoper":
                    Verkoop verkoper = new Verkoop();
                    verkoper.Show();
                    this.Close();
                    break;
                case "Magazijnier":
                    MagazijnierProducts magazijn = new MagazijnierProducts();
                    magazijn.Show();
                    this.Close();
                    break;
            }
        }
        
    }
}
