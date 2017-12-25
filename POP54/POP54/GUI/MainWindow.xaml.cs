using POP54.DAO;
using POP54.GUI;
using POP54.Model;
using POP54.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        FURNITURE, FURNITURE_TYPE, SALES, USERS, ADDITIONAL, BILL
    }

    public partial class MainWindow : Window
    {
        public Furniture SelectedFurniture { get; set; }
        public FurnitureType SelectedFurnitureType { get; set; }
        public User SelectedUser { get; set; }
        public Sale SelectedSale { get; set; }
        public AdditionalService SelectedAdditionalService { get; set; }
        public Bill SelectedBill { get; set; }

        public ObservableCollection<Furniture> Furnitures { get; set; }

        public MainWindow()
        {
            
            InitializeComponent();

            

            dgFurniture.ItemsSource = Project.Instance.FurnitureList;
            dgFurniture.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgFurniture.IsSynchronizedWithCurrentItem = true;
            dgFurniture.DataContext = this;
            int i = GetFirstItemIndex(TableType.FURNITURE);     // vraca indeks prvog elementa koji nije obrisan
            if(i != -1) SelectedFurniture = Project.Instance.FurnitureList[i];

            dgFurnitureType.ItemsSource = Project.Instance.FurnitureTypesList;
            dgFurnitureType.IsSynchronizedWithCurrentItem = true;
            dgFurnitureType.DataContext = this;
            i = GetFirstItemIndex(TableType.FURNITURE_TYPE);
            if (i != -1) SelectedFurnitureType = Project.Instance.FurnitureTypesList[i];

            dgUsers.ItemsSource = Project.Instance.UsersList;
            dgUsers.IsSynchronizedWithCurrentItem = true;
            dgUsers.DataContext = this;
            i = GetFirstItemIndex(TableType.USERS);
            if (i != -1) SelectedUser = Project.Instance.UsersList[i];

            dgSales.ItemsSource = Project.Instance.SalesList;
            dgSales.IsSynchronizedWithCurrentItem = true;
            dgSales.DataContext = this;
            i = GetFirstItemIndex(TableType.SALES);
            if (i != -1) SelectedSale = Project.Instance.SalesList[i];

            dgAdditionalService.ItemsSource = Project.Instance.AdditionalServicesList;
            dgAdditionalService.IsSynchronizedWithCurrentItem = true;
            dgAdditionalService.DataContext = this;
            i = GetFirstItemIndex(TableType.ADDITIONAL);
            if (i != -1) SelectedAdditionalService = Project.Instance.AdditionalServicesList[i];

            dgBill.ItemsSource = Project.Instance.BillsList;
            dgBill.IsSynchronizedWithCurrentItem = true;
            dgBill.DataContext = this;
            i = GetFirstItemIndex(TableType.BILL);
            if (i != -1) SelectedBill = Project.Instance.BillsList[i];

            CheckSaleDate();
        }
       
       
        public static void CheckSaleDate()
        {
            foreach (var sale in Project.Instance.SalesList)
            {
                int dateCompare = DateTime.Compare(sale.EndDate, DateTime.Now);
                if (dateCompare < 0)
                {
                    SaleDAO.Delete(sale);
                    SaleDAO.DeleteFurnitureSale(sale);
                }
            }
        }
        private void BtnFurniture_Click(object sender, RoutedEventArgs e)
        {
            dgFurniture.Visibility = Visibility.Visible;
            dgFurnitureType.Visibility = Visibility.Collapsed;
            dgSales.Visibility = Visibility.Collapsed;
            dgUsers.Visibility = Visibility.Collapsed;
            dgAdditionalService.Visibility = Visibility.Collapsed;
            dgBill.Visibility = Visibility.Collapsed;
            btnAddSale.Visibility = Visibility.Visible;
        }

        private void BtnFurnitureType_Click(object sender, RoutedEventArgs e)
        {
            dgFurniture.Visibility = Visibility.Collapsed;
            dgFurnitureType.Visibility = Visibility.Visible;
            dgSales.Visibility = Visibility.Collapsed;
            dgUsers.Visibility = Visibility.Collapsed;
            dgAdditionalService.Visibility = Visibility.Collapsed;
            dgBill.Visibility = Visibility.Collapsed;
            btnAddSale.Visibility = Visibility.Hidden;
        }

        private void BtnSales_Click(object sender, RoutedEventArgs e)
        {
            dgFurniture.Visibility = Visibility.Collapsed;
            dgFurnitureType.Visibility = Visibility.Collapsed;
            dgSales.Visibility = Visibility.Visible;
            dgUsers.Visibility = Visibility.Collapsed;
            dgAdditionalService.Visibility = Visibility.Collapsed;
            dgBill.Visibility = Visibility.Collapsed;
            btnAddSale.Visibility = Visibility.Hidden;
        }

        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            dgFurniture.Visibility = Visibility.Collapsed;
            dgFurnitureType.Visibility = Visibility.Collapsed;
            dgSales.Visibility = Visibility.Collapsed;
            dgUsers.Visibility = Visibility.Visible;
            dgAdditionalService.Visibility = Visibility.Collapsed;
            dgBill.Visibility = Visibility.Collapsed;
            btnAddSale.Visibility = Visibility.Hidden;
        }

        private void BtnAditionalService_Click(object sender, RoutedEventArgs e)
        {
            dgFurniture.Visibility = Visibility.Collapsed;
            dgFurnitureType.Visibility = Visibility.Collapsed;
            dgSales.Visibility = Visibility.Collapsed;
            dgUsers.Visibility = Visibility.Collapsed;
            dgAdditionalService.Visibility = Visibility.Visible;
            dgBill.Visibility = Visibility.Collapsed;
            btnAddSale.Visibility = Visibility.Hidden;
        }

        private void BtnBills_Click(object sender, RoutedEventArgs e)
        {
            dgFurniture.Visibility = Visibility.Collapsed;
            dgFurnitureType.Visibility = Visibility.Collapsed;
            dgSales.Visibility = Visibility.Collapsed;
            dgUsers.Visibility = Visibility.Collapsed;
            dgAdditionalService.Visibility = Visibility.Collapsed;
            dgBill.Visibility = Visibility.Visible;
            btnAddSale.Visibility = Visibility.Hidden;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (dgFurniture.Visibility.Equals(Visibility.Visible))
            {
                var newFurniture = new Furniture();
                var fw = new FurnitureWindow(newFurniture, FurnitureWindow.Operation.ADD);
                fw.Show();
            }
            else if (dgFurnitureType.Visibility.Equals(Visibility.Visible))
            {
                var newFurnitureType = new FurnitureType();
                var ftw = new FurnitureTypeWindow(newFurnitureType, FurnitureTypeWindow.Operation.ADD);
                ftw.Show();
            }
            else if (dgSales.Visibility.Equals(Visibility.Visible))
            {
                var newSale = new Sale();
                var sw = new SaleWindow(newSale, SaleWindow.Operation.ADD);
                sw.Show();
            }
            else if (dgUsers.Visibility.Equals(Visibility.Visible))
            {
                var newUser = new User();
                var uw = new UserWindow(newUser, UserWindow.Operation.ADD);
                uw.Show();
            }
            else if (dgAdditionalService.Visibility.Equals(Visibility.Visible))
            {
                var newAdditionalService = new AdditionalService();
                var asw = new AdditionalServiceWindow(newAdditionalService, AdditionalServiceWindow.Operation.ADD);
                asw.Show();
            }
            else if (dgAdditionalService.Visibility.Equals(Visibility.Visible))
            {
                var newBill = new Bill();
                BillWindow bw = new BillWindow();
                bw.Show();
            }

        }
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgFurniture.Visibility.Equals(Visibility.Visible))
            {
                Furniture copy = (Furniture)SelectedFurniture.Clone();
                FurnitureWindow furnitureWindow = new FurnitureWindow(copy, FurnitureWindow.Operation.EDIT);
                furnitureWindow.Show();
            }
            else if (dgFurnitureType.Visibility.Equals(Visibility.Visible))
            {
                FurnitureType copy = (FurnitureType)SelectedFurnitureType.Clone();
                FurnitureTypeWindow furnitureWindow = new FurnitureTypeWindow(copy, FurnitureTypeWindow.Operation.EDIT);
                furnitureWindow.Show();
            }
            else if (dgSales.Visibility.Equals(Visibility.Visible))
            {
                Sale copy = (Sale)SelectedSale.Clone();
                SaleWindow saleWindow = new SaleWindow(copy, SaleWindow.Operation.EDIT);
                saleWindow.Show();
            }
            else if (dgUsers.Visibility.Equals(Visibility.Visible))
            {
                User copy = (User)SelectedUser.Clone();
                UserWindow userWindow = new UserWindow(copy, UserWindow.Operation.EDIT);
                userWindow.Show();
            }
            else if (dgAdditionalService.Visibility.Equals(Visibility.Visible))
            {
                AdditionalService copy = (AdditionalService)SelectedAdditionalService.Clone();
                AdditionalServiceWindow additionalServiceWindow = new AdditionalServiceWindow(copy, AdditionalServiceWindow.Operation.EDIT);
                additionalServiceWindow.Show();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show($"Are you sure that you want to delete this?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (dgFurniture.Visibility.Equals(Visibility.Visible))
                    FurnitureDAO.Delete(SelectedFurniture);
                
                else if (dgFurnitureType.Visibility.Equals(Visibility.Visible))
                    FurnitureTypeDAO.Delete(SelectedFurnitureType);
                
                else if (dgSales.Visibility.Equals(Visibility.Visible))
                {
                    SaleDAO.Delete(SelectedSale);
                    SaleDAO.DeleteFurnitureSale(SelectedSale);
                }
                else if (dgUsers.Visibility.Equals(Visibility.Visible))
                    UserDAO.Delete(SelectedUser);
                
                else if (dgAdditionalService.Visibility.Equals(Visibility.Visible))
                    AdditionalServiceDAO.Delete(SelectedAdditionalService);
                
                else if (dgBill.Visibility.Equals(Visibility.Visible))
                    BillDAO.Delete(SelectedBill);
            }
        }
        private void BtnAddSale_Click(object sender, RoutedEventArgs e)
        {
            if (dgFurniture.Visibility.Equals(Visibility.Visible))
            {
                SalesListWindow salesListWindow = new SalesListWindow(SelectedFurniture);
                salesListWindow.Show();
            }
        }
        private int GetFirstItemIndex(TableType tt)
        {
            int i = 0;
            if (tt == TableType.FURNITURE)
            {
                foreach (var f in Project.Instance.FurnitureList)
                {
                    if (f.Deleted == false)
                    {
                        return i;
                    }
                    i++;
                }
            }
            else if (tt == TableType.FURNITURE_TYPE)
            {
                foreach (var f in Project.Instance.FurnitureTypesList)
                {
                    if (f.Deleted == false)
                    {
                        return i;
                    }
                    i++;
                }
            }
            else if (tt == TableType.USERS)
            {
                foreach (var f in Project.Instance.UsersList)
                {
                    if (f.Deleted == false)
                    {
                        return i;
                    }
                    i++;
                }
            }
            else if (tt == TableType.SALES)
            {
                foreach (var f in Project.Instance.SalesList)
                {
                    if (f.Deleted == false)
                    {
                        return i;
                    }
                    i++;
                }
            }
            else if (tt == TableType.ADDITIONAL)
            {
                foreach (var f in Project.Instance.AdditionalServicesList)
                {
                    if (f.Deleted == false)
                    {
                        return i;
                    }
                    i++;
                }
            }
            return -1;

        }
        private void About_Click(object sender, RoutedEventArgs e)
        {
            FurnitureStore fs = new FurnitureStore();
            foreach(var s in Project.Instance.Store)
            {
                fs.ID = s.ID;
                fs.Name = s.Name;
                fs.Phone = s.Phone;
                fs.Address = s.Address;
                fs.Email = s.Email;
                fs.Website = s.Website;
                fs.CompanyNo = s.CompanyNo;
                fs.AccountNo = s.AccountNo;
                fs.Pib = s.Pib;
                break;
            }
            Console.WriteLine(fs);
            StoreWindow sw = new StoreWindow(fs);
            sw.Show();
        }

        private void AddOnBill_Click(object sender, RoutedEventArgs e)
        {
            if(dgFurniture.Visibility == Visibility.Visible)
            {
                AddOnBillWindow ab = new AddOnBillWindow(SelectedFurniture);
                ab.Show();
            }
            else if(dgAdditionalService.Visibility == Visibility.Visible)
            {
                bool added = false;

                foreach(var ads in Project.Instance.Bill.AdditionalServiceList)
                {
                    if (SelectedAdditionalService.ID == ads.ID)
                    {
                        added = true;
                        MessageBox.Show("This additional service is already added on the bill!", "Oops!!!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                if (!added)
                {
                    MessageBox.Show("Additional service is added on the bill.", "Congratulations", MessageBoxButton.OK, MessageBoxImage.Information);
                    Project.Instance.Bill.AdditionalServiceList.Add(SelectedAdditionalService);
                    Project.Instance.Bill.FullPrice += SelectedAdditionalService.Price;
                }
                   
            }
            
        }

        private void Bill_Click(object sender, RoutedEventArgs e)
        {
            BillWindow bw = new BillWindow();
            bw.Show();
        }
        private void ShowItems(object sender, RoutedEventArgs e)
        {
            ViewBills vb = new ViewBills(SelectedBill);
            vb.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(dgFurniture.ItemsSource);
            dataView.SortDescriptions.Clear();
            dataView.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            dataView.Refresh();
        }
    }
}