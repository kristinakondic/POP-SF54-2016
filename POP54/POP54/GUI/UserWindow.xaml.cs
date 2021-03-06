﻿using POP54.DAO;
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
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public enum Operation
        {
            ADD,
            EDIT
        };
        
        private User user;
        private Operation operation;

        public UserWindow(User user, Operation operation)
        {
            InitializeComponent();
            DataContext = this;

            this.user = user;
            this.operation = operation;

            cbUserType.ItemsSource = Enum.GetValues(typeof(TypeOfUser)).Cast<TypeOfUser>();
            tbName.DataContext = user;
            tbSurname.DataContext = user;
            tbUsername.DataContext = user;
            tbPassword.DataContext = user;
            cbUserType.DataContext = user;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (IsValid() == false)
            {
                return;
            }
            switch (operation)
            {
                case Operation.ADD:

                    foreach (var u in Project.Instance.UsersList)
                    {
                        if (user.Username == u.Username)
                        {
                            MessageBox.Show("This username is already used.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                            return;
                        }
                    }
                    UserDAO.Create(user);
                    break;

                case Operation.EDIT:

                    foreach(var u in Project.Instance.UsersList)
                    {
                        if(u.ID == user.ID)
                        {
                            u.Name = user.Name;
                            u.Surname = user.Surname;
                            u.Username = user.Username;
                            u.Password = user.Password;
                            u.UserType = user.UserType;
                            u.Deleted = user.Deleted;
                            break;
                        }
                        UserDAO.Update(user);
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
            BindingExpression expression1 = tbName.GetBindingExpression(TextBox.TextProperty);
            expression1.UpdateSource();
            BindingExpression expression2 = tbSurname.GetBindingExpression(TextBox.TextProperty);
            expression2.UpdateSource();
            BindingExpression expression3 = tbUsername.GetBindingExpression(TextBox.TextProperty);
            expression3.UpdateSource();
            BindingExpression expression4 = tbPassword.GetBindingExpression(TextBox.TextProperty);
            expression4.UpdateSource();
            if (System.Windows.Controls.Validation.GetHasError(tbName) == true)
            {
                return false;
            }
            return true;
        }
    }
}
