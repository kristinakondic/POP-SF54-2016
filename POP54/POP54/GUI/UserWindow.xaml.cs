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
            switch (operation)
            {
                case Operation.ADD:

                    UserDAO.Create(user);
                    break;

                case Operation.EDIT:

                    foreach(var u in Project.Instance.UsersList)
                    {
                        if(u.ID == user.ID)
                        {
                            u.Name = user.Name;
                            u.Surname = user.Surname;
                            u.Username = user.Surname;
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
    }
}
