using POP54.GUI;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POP54
{
    public enum TableType
    {
        FURNITURE, FURNITURE_TYPE, SALES, USERS
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowTable(TableType.FURNITURE);
        }


        public void ShowTable(TableType tbType)
        {
            if (tbType == TableType.FURNITURE)
            {
                dgFurniture.Items.Clear();
                foreach (var furniture in Project.Instance.FurnitureList)
                {
                    if (furniture.Deleted == false)
                    {
                        dgFurniture.Items.Add(furniture);
                    }
                }
                dgFurniture.SelectedIndex = 0;
            }
            else if (tbType == TableType.FURNITURE_TYPE)
            {
                dgFurnitureType.Items.Clear();
                foreach (var furnitureTypes in Project.Instance.FurnitureTypesList)
                {
                    if (furnitureTypes.Deleted == false){
                        dgFurnitureType.Items.Add(furnitureTypes);
                    }
                }
                dgFurnitureType.SelectedIndex = 0;
                dgFurnitureType.Visibility = Visibility.Visible;
            }
            else if (tbType == TableType.SALES)
            {
                dgSales.Items.Clear();
                foreach (var sales in Project.Instance.SalesList)
                {
                    if (sales.Deleted == false)
                    {
                        dgSales.Items.Add(sales);
                    }
                }
                dgSales.SelectedIndex = 0;
                dgSales.Visibility = Visibility.Visible;
            }
            else if (tbType == TableType.USERS)
            {
                dgSales.Items.Clear();
                foreach (var user in Project.Instance.UsersList)
                {
                    if (user.Deleted == false)
                    {
                        dgUsers.Items.Add(user);
                    }
                }
                dgUsers.SelectedIndex = 0;
                dgUsers.Visibility = Visibility.Visible;
            }
        }
        private void BtnFurniture_Click(object sender, RoutedEventArgs e)
        {
            dgFurniture.Visibility = Visibility.Visible;
            dgFurnitureType.Visibility = Visibility.Collapsed;
            dgSales.Visibility = Visibility.Collapsed;
            dgUsers.Visibility = Visibility.Collapsed;
            ShowTable(TableType.FURNITURE);
        }

        private void BtnFurnitureType_Click(object sender, RoutedEventArgs e)
        {
            dgFurniture.Visibility = Visibility.Collapsed;
            dgFurnitureType.Visibility = Visibility.Visible;
            dgSales.Visibility = Visibility.Collapsed;
            dgUsers.Visibility = Visibility.Collapsed;
            ShowTable(TableType.FURNITURE_TYPE);
        }

        private void BtnSales_Click(object sender, RoutedEventArgs e)
        {
            dgFurniture.Visibility = Visibility.Collapsed;
            dgFurnitureType.Visibility = Visibility.Collapsed;
            dgSales.Visibility = Visibility.Visible;
            dgUsers.Visibility = Visibility.Collapsed;
            ShowTable(TableType.SALES);
        }

        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            dgFurniture.Visibility = Visibility.Collapsed;
            dgFurnitureType.Visibility = Visibility.Collapsed;
            dgSales.Visibility = Visibility.Collapsed;
            dgUsers.Visibility = Visibility.Visible;
            ShowTable(TableType.USERS);
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var newFurniture = new Furniture();
            FurnitureWindow furnitureWindow = new FurnitureWindow(newFurniture, FurnitureWindow.Operation.ADD);
            furnitureWindow.Show();
            ShowTable(TableType.FURNITURE);
        }
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Furniture editFurniture = (Furniture)dgFurniture.SelectedItem;
            FurnitureWindow furnitureWindow = new FurnitureWindow(editFurniture, FurnitureWindow.Operation.EDIT);
            furnitureWindow.Show();
            ShowTable(TableType.FURNITURE);
        }
    }
}