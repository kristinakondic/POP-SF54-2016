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
            foreach(var f in bill.FurnitureForSaleList)
                tbBill.Text += "\n" + "Name: " + f.Name + "  Price: " + f.Price + "  Quantity: " + f.Quantity;

            foreach (var a in bill.AdditionalServiceList)
                tbBill.Text += "\n" + "Name: " + a.Name + "  Price: " + a.Price;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
