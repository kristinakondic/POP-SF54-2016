using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP54.Model
{
    [Serializable]
    public class Bill : INotifyPropertyChanged
    {
        private int id;
        private DateTime dateOfSale;
        private int billNo;
        private string buyer;
        private double pdv;
        private List<AdditionalService> additionalServiceList;
        private double fullPrice = 0;
        private List<Furniture> furnitureForSaleList;
        private bool deleted;

        public bool Deleted
        {
            get { return deleted; }
            set
            {
                deleted = value;
                OnPropertyChanged("Deleted");
            }
        }


        public Bill()
        {
            furnitureForSaleList = new List<Furniture>();
            additionalServiceList = new List<AdditionalService>();
        }
        public List<Furniture> FurnitureForSaleList
        {
            get { return furnitureForSaleList; }
            set
            {
                furnitureForSaleList = value;
                OnPropertyChanged("FurnitureForSaleList");
            }
        }


        public List<AdditionalService> AdditionalServiceList
        {
            get { return additionalServiceList; }
            set
            {
                additionalServiceList = value;
                OnPropertyChanged("AdditionalServiceList");
            }
        }

        public double FullPrice
        {
            get { return fullPrice; }
            set {
                fullPrice = value;
                OnPropertyChanged("FullPrice");
            }
        }

        public double PDV
        {
            get { return pdv; }
            set
            {
                pdv = value;
                OnPropertyChanged("PDV");
            }
        }

        public string Buyer
        {
            get { return buyer; }
            set
            {
                buyer = value;
                OnPropertyChanged("Buyer");
            }
        }

        public int BillNo
        {
            get { return billNo; }
            set
            {
                billNo = value;
                OnPropertyChanged("BillNo");
            }
        }

        public DateTime DateOfSale
        {
            get { return dateOfSale; }
            set
            {
                dateOfSale = value;
                OnPropertyChanged("DateOfSale");
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

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
