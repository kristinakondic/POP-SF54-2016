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
    /// Interaction logic for FurnitureWindow.xaml
    /// </summary>
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
            DataContext = new Project();
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var lsFurniture = Project.Instance.FurnitureList;
            var furType = (FurnitureType) cbFurnitureType.SelectedItem;
            switch (operation)
            {
                case Operation.ADD:
                    try
                    {
                        var newFurniture = new Furniture()
                        {
                            ID = lsFurniture.Count + 1,
                            Name = this.tbName.Text,
                            ProductCode = this.tbCode.Text,
                            Price = double.Parse(this.tbPrice.Text),
                            Quantity = int.Parse(this.tbQuantity.Text),
                            FurnitureTypeId = furType.ID
                        };
                        lsFurniture.Add(newFurniture);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error input!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                case Operation.EDIT:
                    var editFurniture = Furniture.GetId(furniture.ID);
                    foreach (var f in lsFurniture)
                    {
                        if (f.ID == editFurniture.ID)
                        {
                            f.Name = this.tbName.Text;
                            break;
                        }
                    }
                    break;
            }

            Project.Instance.FurnitureList = lsFurniture;
            this.Close();
        }
    }
}
