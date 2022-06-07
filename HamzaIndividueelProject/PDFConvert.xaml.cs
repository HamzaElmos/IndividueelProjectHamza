using OfficeOpenXml;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows;
using Syncfusion.XlsIO;
namespace HamzaIndividueelProject
{
    /// <summary>
    /// Interaction logic for PDFConvert.xaml
    /// </summary>
    public partial class PDFConvert : Window
    {
        public PDFConvert()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using(ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2016;

                //create a workbook
                IWorkbook workbook = application.Workbooks.Create(1); //getal toont aan hoeveel sheets er in excel zullen zijn.. als er geen getal is, standaard 3
                IWorksheet worksheet = workbook.Worksheets[0];

                //save the excel workbook as Output.xlsx
                workbook.SaveAs("Output.xlsx");
                this.Close();
                System.Diagnostics.Process.Start("Output.xlsx");
            }
        }
    }
}
