using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP54.Model
{
    [Serializable]
    public class Furniture : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string name;
        private string productCode;
        private double price;
        private int quantity;
        private int furnitureTypeId;
        private bool deleted;
        private int saleId;
        private double priceOnSale = 0;

        public double PriceOnSale
        {
            get { return priceOnSale; }
            set
            {
                priceOnSale = value;
                OnPropertyChanged("PriceOnSale");
            }
        }


        public int SaleId
        {
            get { return saleId; }
            set
            {
                saleId = value;
                OnPropertyChanged("SaleId");
            }
        }

        private FurnitureType furnitureType;

        [XmlIgnore]
        public FurnitureType FurnitureType
        {
            get
            {
                if(furnitureType == null)
                {
                    furnitureType = FurnitureType.GetById(FurnitureTypeId);
                }
                return furnitureType;
            }
            set
            {
                furnitureType = value;
                FurnitureTypeId = furnitureType.ID;
                OnPropertyChanged("FurnitureType");
            }
        }


        public bool Deleted
        {
            get { return deleted; }
            set
            {
                deleted = value;
                OnPropertyChanged("Deleted");
            }
        }
        public int FurnitureTypeId
        {
            get { return furnitureTypeId; }
            set
            {
                furnitureTypeId = value;
                OnPropertyChanged("FurnitureTypeId");
            }
        }
        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                OnPropertyChanged("Quantity");
            }
        }
        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }
        public string ProductCode
        {
            get { return productCode; }
            set
            {
                productCode = value;
                OnPropertyChanged("ProductCode");
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return String.Format("{0,-5} {1,-15} {2,-15} {3,-10} {4,-5} {5,-5} {6,-5}", ID, Name, Price, ProductCode, Quantity, FurnitureType.GetById(FurnitureTypeId), Deleted);
        }

        public static Furniture GetById(int Id)
        {
            foreach (var furniture in Project.Instance.FurnitureList)
            {
                if (furniture.ID == Id)
                {
                    return furniture;
                }
            }
            return null;
        }
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new Furniture()
            {
                ID = id,
                Name = name,
                ProductCode = productCode,
                Price = price,
                PriceOnSale = priceOnSale,
                Quantity = quantity,
                FurnitureTypeId = furnitureTypeId,
                Deleted = deleted
 
            };
        }
    }
}
