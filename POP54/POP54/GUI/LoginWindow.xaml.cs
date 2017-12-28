﻿using POP54.DAO;
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
            
            var ok = false;

            foreach (var user in Project.Instance.UsersList)
            {
                if (user.Username == username && user.Password == password)
                {
                    if (user.UserType == TypeOfUser.SALESMAN)
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        Project.Instance.User = user;
                        this.Close();
                        ok = true;
                    }
                    else
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        Project.Instance.User = user;
                        this.Close();
                        ok = true;
                    }
                }
            }

            if (ok == false)
                lblWrongLogin.Visibility = Visibility.Visible;
        }

    }
}