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
    /// <summary>
    /// Interaction logic for SaleWindow.xaml
    /// </summary>
    public partial class SaleWindow : Window
    {
        public enum Operation
        {
            ADD,
            EDIT
        };

        private Sale sale;
        private Operation operation;
        public SaleWindow(Sale sale, Operation operation)
        {
            InitializeComponent();
            DataContext = this;
            

            this.sale = sale;
            this.operation = operation;

            tbDiscount.DataContext = sale;
            dpStartDate.DataContext = sale;
            dpEndDate.DataContext = sale;
            if (operation == Operation.ADD)
            {
                dpStartDate.SelectedDate = DateTime.Now;
                dpEndDate.SelectedDate = DateTime.Now.AddDays(1);
            }
            else if (operation == Operation.EDIT)
            {
                dpStartDate.SelectedDate = sale.StartDate;
                dpEndDate.SelectedDate = sale.EndDate;
            }
            
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (IsValid() == false)
            {
                return;
            }
            if (dpStartDate.SelectedDate > dpEndDate.SelectedDate ||
                dpStartDate.SelectedDate < DateTime.Now.AddDays(-1))
            {
                MessageBox.Show("Please pick a valid date.", "Bad date", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
                switch (operation)
            {
                case Operation.ADD:
                    
                    sale.StartDate =(DateTime) dpStartDate.SelectedDate;
                    sale.EndDate = (DateTime)dpEndDate.SelectedDate;
                    SaleDAO.Create(sale);
                    break;

                case Operation.EDIT:
                    
                    foreach (var s in Project.Instance.SalesList)
                    {
                        if (s.ID == sale.ID)
                        {
                            if(s.StartDate != (DateTime)dpStartDate.SelectedDate)
                            {
                                MessageBox.Show("You cannot edit start date.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                                return;
                            }
                            s.Discount = sale.Discount;
                            s.StartDate = (DateTime)dpStartDate.SelectedDate;
                            s.EndDate = (DateTime)dpEndDate.SelectedDate;
                            s.Deleted = sale.Deleted;
                            MainWindow.CheckSaleDate();
                            SaleDAO.Update(s);
                            break;
                        }
                    }
                    break;
            }
            this.Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public bool IsValid()
        {
            BindingExpression expression = tbDiscount.GetBindingExpression(TextBox.TextProperty);
            expression.UpdateSource();
            if (System.Windows.Controls.Validation.GetHasError(tbDiscount) == true)
            {
                return false;
            }
            return true;
        }
    }
}
