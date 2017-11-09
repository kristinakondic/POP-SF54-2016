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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            
        }
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var username = tbUsername.Text;
            var password = tbPassword.Text;

            var users = Project.Instance.UsersList;
            var ok = false;

            foreach (var user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    if (user.UserType == TypeOfUser.salesman)
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        ok = true;
                    }
                    else
                    {
                        AdminWindow adminWindow = new AdminWindow();
                        adminWindow.Show();
                        ok = true;
                    }
                }
            }

            if (ok == false)
            {
                lblWrongLogin.Visibility=Visibility.Visible;
            }
        }

    }
}