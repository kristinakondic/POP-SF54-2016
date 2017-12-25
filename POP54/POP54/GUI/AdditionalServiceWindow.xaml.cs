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
    /// Interaction logic for AdditionalServiceWindow.xaml
    /// </summary>
    public partial class AdditionalServiceWindow : Window
    {
        public enum Operation
        {
            ADD,
            EDIT
        };

        private AdditionalService additionalService;
        private Operation operation;

        public AdditionalServiceWindow(AdditionalService additionalService, Operation operation)
        {
            InitializeComponent();

            this.additionalService = additionalService;
            this.operation = operation;

            tbName.DataContext = additionalService;
            tbPrice.DataContext = additionalService;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            switch (operation)
            {
                case Operation.ADD:

                    AdditionalServiceDAO.Create(additionalService);
                    break;

                case Operation.EDIT:

                    foreach (var ads in Project.Instance.AdditionalServicesList)
                    {
                        if (ads.ID == additionalService.ID)
                        {
                            ads.Name = additionalService.Name;
                            ads.Price = additionalService.Price;
                            break;
                        }
                            
                    }
                    AdditionalServiceDAO.Update(additionalService);
                    break;
            }
            this.Close();
        }
    }
}
