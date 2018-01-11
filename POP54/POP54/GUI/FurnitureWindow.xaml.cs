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
    public partial class FurnitureWindow : Window
    {
        public enum Operation
        {
            ADD,
            EDIT
        };

        private Furniture furniture;
        private Operation operation;

        public FurnitureWindow(Furniture furniture, Operation operation)
        {
            InitializeComponent();
            DataContext = this;

            this.furniture = furniture;
            this.operation = operation;

            cbFurnitureType.ItemsSource = Project.Instance.FurnitureTypesList;
            if (furniture.FurnitureType == null) //ovo prolazi samo ako je odabran ADD, za edit ce biti vrednost tipa tip selektovanog namestaja
                foreach (var f in Project.Instance.FurnitureTypesList)
                    if (!f.Deleted) 
                    {
                        furniture.FurnitureType = f;
                        break;
                    }
            tbName.DataContext = furniture;
            cbFurnitureType.DataContext = furniture;
            tbCode.DataContext = furniture;
            tbPrice.DataContext = furniture;
            tbQuantity.DataContext = furniture;
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
                    
                    FurnitureDAO.Create(furniture);
                    break;

                case Operation.EDIT:

                    foreach (var f in Project.Instance.FurnitureList)
                    {
                        if (f.ID == furniture.ID)
                        {
                            var pricePrim = furniture.Price;
                            f.Name = furniture.Name;
                            f.ProductCode = furniture.ProductCode;
                            f.Price = furniture.Price;
                            if (f.Sales != null)
                            {
                                foreach(var s in f.Sales)
                                {
                                    f.PriceOnSale = pricePrim - (pricePrim / 100 * s.Discount);
                                    pricePrim = f.PriceOnSale;
                                }
                            }
                            f.Quantity = furniture.Quantity;
                            f.FurnitureType = furniture.FurnitureType;
                            f.Deleted = furniture.Deleted;
                            break;
                        }
                        FurnitureDAO.Update(furniture);
                    }
                    break;
            }
            this.Close();
        }

        public bool IsValid()
        {
            BindingExpression expression1 = tbName.GetBindingExpression(TextBox.TextProperty);
            expression1.UpdateSource();
            BindingExpression expression2 = tbCode.GetBindingExpression(TextBox.TextProperty);
            expression2.UpdateSource();
            BindingExpression expression3 = tbPrice.GetBindingExpression(TextBox.TextProperty);
            expression3.UpdateSource();
            BindingExpression expression4 = tbQuantity.GetBindingExpression(TextBox.TextProperty);
            expression4.UpdateSource();
            if (System.Windows.Controls.Validation.GetHasError(tbName) == true
                || System.Windows.Controls.Validation.GetHasError(tbCode) == true
                || System.Windows.Controls.Validation.GetHasError(tbPrice) == true 
                || System.Windows.Controls.Validation.GetHasError(tbQuantity) == true)
            {
                return false;
            }
            return true;
        } 

    }
}
