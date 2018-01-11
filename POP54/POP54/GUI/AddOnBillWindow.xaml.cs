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
    public partial class AddOnBillWindow : Window
    {
        private Furniture furniture;
        public AddOnBillWindow(Furniture furniture)
        {
            InitializeComponent();
            this.furniture = furniture;
            DataContext = furniture;
            bool firstTime = true;
            bool t = true;
            
            foreach (var f in Project.Instance.Bill.FurnitureForSaleList)
            {
                if (furniture.ID == f.ID)   // ako je taj furniture vec dodavan u racun
                {
                    firstTime = false;
                    for (int i = 1; i <= furniture.Quantity - f.Quantity; i++)
                    {
                        t = false;
                        cbQuantity.Items.Add(i);
                    }
                    if (t)
                    {
                        MessageBox.Show("You've already added all available items on your bill.", "No more items", MessageBoxButton.OK, MessageBoxImage.Information);
                        Loaded += (s, e) => Close();
                        return;
                    }
                        
                }
            }
            
            if (firstTime)
            {
                for (int i = 1; i <= furniture.Quantity; i++)
                {
                    cbQuantity.Items.Add(i);
                }
            }

            cbQuantity.SelectedIndex = 0;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int quant = Int32.Parse(cbQuantity.Text);
            bool firstTime = true;
            foreach (var f in Project.Instance.Bill.FurnitureForSaleList)
            {
                var price = f.Price;
                if (f.PriceOnSale != 0)
                {
                    price = f.PriceOnSale;
                }
                if (furniture.ID == f.ID)
                {
                    firstTime = false;
                    f.Quantity = f.Quantity + quant;
                    Project.Instance.Bill.FullPrice = Project.Instance.Bill.FullPrice + (price * quant);
                }
            }
            if (firstTime)
            {
                Furniture selledFurniture = (Furniture)furniture.Clone();
                selledFurniture.Quantity = quant;
                Project.Instance.Bill.FurnitureForSaleList.Add(selledFurniture);
                foreach (var f in Project.Instance.Bill.FurnitureForSaleList)
                {
                    var price = f.Price;
                    if (f.PriceOnSale != 0)
                    {
                        price = f.PriceOnSale;
                        Project.Instance.Bill.FullPrice = Project.Instance.Bill.FullPrice + (price * quant);
                    }
                }
            }
            this.Close();
        }
    }
}
