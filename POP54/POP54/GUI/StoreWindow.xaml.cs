using POP54.DAO;
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
    public partial class StoreWindow : Window
    {
        private FurnitureStore store;
        public StoreWindow(FurnitureStore store)
        {
            InitializeComponent();
            this.store = store;
            DataContext = this;
            tbName.DataContext = store;
            tbPhone.DataContext = store;
            tbAddress.DataContext = store;
            tbEmail.DataContext = store;
            tbWebsite.DataContext = store;
            tbCompanyNo.DataContext = store;
            tbAccountNo.DataContext = store;
            tbPib.DataContext = store;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            StoreDAO.Update(store);
            MessageBox.Show("Successful edit", "Supeeer", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
