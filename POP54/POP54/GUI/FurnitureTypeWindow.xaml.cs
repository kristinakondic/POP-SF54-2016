﻿using POP54.Model;
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
            switch (operation)
            {
                case Operation.ADD:

                    furnitureType.ID = Project.Instance.FurnitureTypesList.Count + 1;
                    Project.Instance.FurnitureTypesList.Add(furnitureType);
                    MessageBox.Show("Success!", "Congratulations", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;

                case Operation.EDIT:

                    foreach (var ft in Project.Instance.FurnitureTypesList)
                    {
                        if (ft.ID == furnitureType.ID)
                            ft.Name = furnitureType.Name;
                        break;
                    }
                    break;
            }
            GenericSerializer.Serialize("furniture_type.xml", Project.Instance.FurnitureTypesList);
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}