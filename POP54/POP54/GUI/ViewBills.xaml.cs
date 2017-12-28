using POP54.Model;
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

namespace POP54.GUI
{
    /// <summary>
    /// Interaction logic for ViewBills.xaml
    /// </summary>
    public partial class ViewBills : Window
    {
        public ViewBills(Bill bill)
        {
            InitializeComponent();
            DataContext = this;
            var store = Project.Instance.Store;
            tbBill.Text = "============================" + "\n\t" + store.Name.ToUpper() + "\n\t   " + store.Address + "\n\t   " + store.Website + "\n\t      Tel:" + store.Phone + "\n";
            tbBill.Text += "PIB:" + store.Pib +"\n" + "Company No.:" + store.CompanyNo + "\n";
            tbBill.Text += "----------------------------------------------" + "\n";

            tbBill.Text += "Furniture:";
            foreach (var f in bill.FurnitureForSaleList)
            {
                tbBill.Text += "\n" + f.Name;
                tbBill.Text += "\n" + f.Quantity + "x " + f.Price + "\t\t\t" + f.Price * f.Quantity + " RSD";
            }

            tbBill.Text += "\n\n" + "Additional services:";
            foreach (var a in bill.AdditionalServiceList)
            {
                tbBill.Text += "\n" + a.Name + "\t\t" + a.Price + " RSD";
            }

            tbBill.Text += "\n"+"----------------------------------------------" + "\n";
            tbBill.Text += "Price: " + bill.FullPrice + " RSD\n" + "PDV: " + bill.FullPrice * 0.2 + " RSD\n" + "Full price: " + bill.FullPrice * 1.2 + " RSD\n";
            tbBill.Text += "============================";
            tbBill.Text += bill.DateOfSale + "\nBill No.: " + bill.BillNo + "\nCustomer: " + bill.Buyer + "\n";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
