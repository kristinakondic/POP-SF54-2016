using POP54.DAO;
using POP54.Model;
using POP54.Util;
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
    public partial class BillWindow : Window
    {
        public BillWindow()
        {
            InitializeComponent();
            DataContext = this;
            tbBuyer.DataContext = Project.Instance.Bill;
            foreach (var fur in Project.Instance.Bill.FurnitureForSaleList)
            {
                if (fur.PriceOnSale == 0)
                    tbBill.Text += "\nFurniture: " + fur.Name + " Price: " + fur.Price + ",00 RSD" + " Quantity: " + fur.Quantity;
                else
                    tbBill.Text += "\nFurniture: " + fur.Name + " Price: " + fur.PriceOnSale + ",00 RSD" + " Quantity: " + fur.Quantity;
            }
            foreach (var ads in Project.Instance.Bill.AdditionalServiceList)
            {
                tbBill.Text += "\nAdditional service: " + ads.Name + " Price: " + ads.Price + ",00 RSD";
            }
            
            tbBill.Text += "\n\n\t\t Price: " + Project.Instance.Bill.FullPrice + ",00 RSD";
            tbBill.Text += "\n\n\t\t PDV: " + Project.Instance.Bill.FullPrice * 0.2 + ",00 RSD";
            tbBill.Text += "\n\n\t\t BILL: " + Project.Instance.Bill.FullPrice * 1.2 + ",00 RSD";
        }

        private void PrintBill_Click(object sender, RoutedEventArgs e)
        {
            if (Project.Instance.Bill.FullPrice == 0)
            {
                MessageBox.Show("Bill cannot be empty", "Congratulations", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
               
            if (IsValid() == false)
                return;
            Project.Instance.Bill.DateOfSale = DateTime.Now;
            Project.Instance.Bill.BillNo = DateTime.Now.Millisecond;
            BillDAO.Create(Project.Instance.Bill);
            foreach (var b in Project.Instance.Bill.FurnitureForSaleList)
            {
                foreach (var f in Project.Instance.FurnitureList)
                {
                    if (f.ID == b.ID)
                    {
                        BillDAO.AddFurnitureOnBill(Project.Instance.Bill, f);
                        f.Quantity -= b.Quantity;
                        FurnitureDAO.Update(f);
                    }
                }
            }
            foreach (var b in Project.Instance.Bill.AdditionalServiceList)
            {
                foreach (var a in Project.Instance.AdditionalServicesList)
                {
                    BillDAO.AddAdditionalServiceOnBill(Project.Instance.Bill, a);
                }
            }
            MessageBox.Show("Success!", "Congratulations", MessageBoxButton.OK, MessageBoxImage.Information);
            Project.Instance.Bill = new Bill();

            MainWindow.DeleteSoldFurniture();
            this.Close();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public bool IsValid()
        {
            BindingExpression expression = tbBuyer.GetBindingExpression(TextBox.TextProperty);
            expression.UpdateSource();
            if (System.Windows.Controls.Validation.GetHasError(tbBuyer) == true)
            {
                return false;
            }
            return true;
        }
    }
}
