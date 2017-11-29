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
    /// Interaction logic for SalesListWindow.xaml
    /// </summary>
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
            furniture.SaleId = SelectedSale.ID;
            furniture.PriceOnSale = furniture.Price - (furniture.Price / 100 * SelectedSale.Discount);
            MessageBox.Show("Success!", "Congratulations", MessageBoxButton.OK, MessageBoxImage.Information);
            GenericSerializer.Serialize("furniture.xml", Project.Instance.FurnitureList);
            this.Close();
        }
    }
}
