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

            using (Context ctx = new Context())
            {
                if(cbProfile.Text != null && txtPassword.Text != null && txtUsername.Text != null)
                {
                    ctx.LoginData.Add(new LoginData()
                    {
                        Profile = cbProfile.Text,
                        Username = txtUsername.Text,
                        Password = txtPassword.Text

                    }
                    );

                    ctx.SaveChanges();
                }  
                

            }



            //MessageBox.Show($"{txtUsername.Text} is added to list");
            txtUsername.Clear();
            txtPassword.Clear();

            switch (cbProfile.Text)
            {
                case "Administrator":
                    MainWindow hoofd = new MainWindow();
                    hoofd.Show();
                    this.Close();
                    break;

                case "Verkoper":
                    Verkoper verkoper = new Verkoper();
                    verkoper.Show();
                    this.Close();
                    break;
                case "Magazijnier":
                    MainWindow main = new MainWindow();
                    main.Show();
                    this.Close();
                    break;
            }

            // MainWindow dashboard = new MainWindow();
            //dashboard.Show();
            //this.Close(); 
        }
    }
}
