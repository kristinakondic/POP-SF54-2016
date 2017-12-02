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
                dpEndDate.SelectedDate = DateTime.Today;
            }
            else if (operation == Operation.EDIT)
            {
                dpStartDate.SelectedDate = sale.StartDate;
                dpEndDate.SelectedDate = sale.EndDate;
            }
            
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            switch (operation)
            {
                case Operation.ADD:

                    sale.ID = Project.Instance.SalesList.Count + 1;
                    sale.StartDate =(DateTime) dpStartDate.SelectedDate;
                    sale.EndDate = (DateTime)dpEndDate.SelectedDate;
                    Project.Instance.SalesList.Add(sale);
                    MessageBox.Show("Success!", "Congratulations", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;

                case Operation.EDIT:
                    foreach (var s in Project.Instance.SalesList)
                    {
                        if (s.ID == sale.ID)
                        {
                            
                            s.Discount = sale.Discount;
                            s.StartDate = (DateTime)dpStartDate.SelectedDate;
                            s.EndDate = (DateTime)dpEndDate.SelectedDate;
                            s.Deleted = sale.Deleted;
                            MainWindow.checkSaleDate();
                            break;
                        }
                    }
                    break;
            }
            GenericSerializer.Serialize("sales.xml", Project.Instance.SalesList);
            this.Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
