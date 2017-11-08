using POP54.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP54.Model
{
    public class Project
    {
        public static Project Instance { get; } = new Project();
        private List<User> usersList;
        private List<FurnitureSelling> furnitureSellingList;
        private List<FurnitureType> furnitureTypesList;
        private List<Furniture> furnitureList;
        private List<AdditionalService> additionalServicesList;
        private List<Sale> salesList;

        public List<User> UsersList
        {
            get
            {
                this.usersList = GenericSerializer.Deserialize<User>("users.xml");
                return this.usersList;
            }
            set
            {
                this.usersList = value;
                GenericSerializer.Serialize<User>("users.xml", this.usersList);
            }
        }
        public List<FurnitureSelling> FurnitureSellingList
        {
            get
            {
                this.furnitureSellingList = GenericSerializer.Deserialize<FurnitureSelling>("furniture_selling.xml");
                return this.furnitureSellingList;
            }
            set
            {
                this.furnitureSellingList = value;
                GenericSerializer.Serialize<FurnitureSelling>("furniture_selling.xml", this.furnitureSellingList);
            }
        }
        public List<FurnitureType> FurnitureTypesList
        {
            get
            {
                this.furnitureTypesList = GenericSerializer.Deserialize<FurnitureType>("furniture_types.xml");
                return this.furnitureTypesList;
            }
            set
            {
                this.furnitureTypesList = value;
                GenericSerializer.Serialize<FurnitureType>("furniture_types.xml", this.furnitureTypesList);
            }
        }
        public List<Furniture> FurnitureList
        {
            get
            {
                this.furnitureList = GenericSerializer.Deserialize<Furniture>("furniture.xml");
                return this.furnitureList;
            }
            set
            {
                this.furnitureList = value;
                GenericSerializer.Serialize<Furniture>("furniture.xml", this.furnitureList);
            }
        }
        public List<AdditionalService> AdditionalServicesList
        {
            get
            {
                this.additionalServicesList = GenericSerializer.Deserialize<AdditionalService>("additional_services.xml");
                return this.additionalServicesList;
            }
            set
            {
                this.additionalServicesList = value;
                GenericSerializer.Serialize<AdditionalService>("additional_services.xml", this.additionalServicesList);
            }
        }
        public List<Sale> SalesList
        {
            get
            {
                this.salesList = GenericSerializer.Deserialize<Sale>("sales.xml");
                return this.salesList;
            }
            set
            {
                this.salesList = value;
                GenericSerializer.Serialize<Sale>("sales.xml", this.SalesList);
            }
        }
    }
}
