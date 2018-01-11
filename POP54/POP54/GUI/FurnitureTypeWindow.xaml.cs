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
    
    public partial class FurnitureTypeWindow : Window
    {
        public enum Operation
        {
            ADD,
            EDIT
        };

        private FurnitureType furnitureType;
        private Operation operation;

        public FurnitureTypeWindow(FurnitureType furnitureType, Operation operation)
        {
            InitializeComponent();
            

            this.furnitureType = furnitureType;
            this.operation = operation;

            tbName.DataContext = furnitureType;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IsValid() == false)
            {
                return;
            }
            switch (operation)
            {
                case Operation.ADD:

                    FurnitureTypeDAO.Create(furnitureType);
                    break;

                case Operation.EDIT:

                    FurnitureTypeDAO.Update(furnitureType);
                    break;
            }
            
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public bool IsValid()
        {
            BindingExpression expression = tbName.GetBindingExpression(TextBox.TextProperty);
            expression.UpdateSource();
            if (System.Windows.Controls.Validation.GetHasError(tbName) == true)
            {
                return false;
            }
            return true;
        }
    }
}
