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
    public partial class SalesListWindow : Window
    {
        public Sale SelectedSale { get; set; }
        private Furniture furniture;
        public SalesListWindow(Furniture selectedFurniture)
        {
            InitializeComponent();

            this.furniture = selectedFurniture;

            dgSalesList.ItemsSource = Project.Instance.SalesList;
            SelectedSale = Project.Instance.SalesList[0];
            dgSalesList.IsSynchronizedWithCurrentItem = true;
            dgSalesList.DataContext = this;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAddSale_Click(object sender, RoutedEventArgs e)
        {
            SaleDAO.AddFurnitureSale(SelectedSale, furniture);

            furniture.Sales.Add(SelectedSale);
            var pricePrim = furniture.Price;
            if (furniture.Sales != null)
            {
                foreach (var s in furniture.Sales)
                {
                    furniture.PriceOnSale = pricePrim - (pricePrim / 100 * s.Discount);
                    pricePrim = furniture.PriceOnSale;
                }
            }
           
            FurnitureDAO.Update(furniture);
            MessageBox.Show("Success!", "Congratulations", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
