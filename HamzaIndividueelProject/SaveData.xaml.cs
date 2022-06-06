using HamzaIndividueelProject.Verkoper;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for SaveData.xaml
    /// </summary>
    public partial class SaveData : Window
    {
        public SaveData()
        {
            InitializeComponent(); 
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.InitialDirectory = @"C:\Deze pc\Downloads";
            var result = dlg.ShowDialog();
            tbUploadFile.Text = dlg.FileName;
            DG.ItemsSource = Products.GetData(dlg.FileName);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

       
    }
}
