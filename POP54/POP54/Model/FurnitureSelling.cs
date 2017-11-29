using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP54.Model
{
    [Serializable]
    public class FurnitureSelling : INotifyPropertyChanged
    {
        private int id;
        private DateTime dateOfSale;
        private int billNo;
        private int buyer;
        private double pdv;
        private int idAdditionalServices;
        private double fullPrice;
        private int idFurnitureForSale;

        public int IdFurnitureForSale
        {
            get { return idFurnitureForSale; }
            set
            {
                idFurnitureForSale = value;
                OnPropertyChanged("IdFurnitureForSale");
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

        public int IdAdditionalServices
        {
            get { return idAdditionalServices; }
            set
            {
                idAdditionalServices = value;
                OnPropertyChanged("IdAdditionalServices");
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

        public int Buyer
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
