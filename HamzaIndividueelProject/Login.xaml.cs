using HamzaIndividueelProject.Classes;
using HamzaIndividueelProject.Magazijnier;
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

        public void LoginData()
        {
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
            }
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

        private static string Encryptor (string password)
        {
            string encrypyted = string.Empty;

            for (int i = 0; i < password.Length; i++)
            {
                encrypyted += 255 - password[i];
            }
            return encrypyted;
        }
       
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            
            var username = txtUsername.Text;
             string password = Cryptography.Encrypt( txtPassword.Password);
             var departement = cbProfile.Text;
            



            using (Context context = new Context())
             {

                
                bool userfound = context.NewUsers.Any(user => user.Username == username && user.Password == password && user.Departement == departement);

                 if (userfound)
                 {
                    
                    LoginData(); 
                    GrantAccess();

                 }
                 else
                 {
                     MessageBox.Show("Wrong Username or Password");
                 }
             }
           }
        }
    }
