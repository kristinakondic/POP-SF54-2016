using POP54.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP54.Model
{
    public class Project
    {
        public static Project Instance { get; private set; } = new Project();
        public ObservableCollection<User> UsersList { get; set; }
        public ObservableCollection<FurnitureSelling> FurnitureSellingList { get; set; }
        public ObservableCollection<FurnitureType> FurnitureTypesList { get; set; }
        public ObservableCollection<Furniture> FurnitureList { get; set; }
        public ObservableCollection<AdditionalService> AdditionalServicesList { get; set; }
        public ObservableCollection<Sale> SalesList { get; set; }

        private Project()
        {
            FurnitureList = GenericSerializer.Deserialize<Furniture>("furniture.xml");
            UsersList = GenericSerializer.Deserialize<User>("users.xml");
            FurnitureSellingList = GenericSerializer.Deserialize<FurnitureSelling>("furniture_selling.xml");
            FurnitureTypesList = GenericSerializer.Deserialize<FurnitureType>("furniture_type.xml");
            AdditionalServicesList = GenericSerializer.Deserialize<AdditionalService>("additional_service.xml");
            SalesList = GenericSerializer.Deserialize<Sale>("sales.xml");
        }
    }
}