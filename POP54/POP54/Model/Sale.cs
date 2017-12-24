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
    public class Sale : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private int discount;
        private DateTime startDate;
        private DateTime endDate;
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


        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                OnPropertyChanged("EndDate");
            }
        }


        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                OnPropertyChanged("StartDate");
            }
        }

        

        public int Discount
        {
            get { return discount; }
            set
            {
                discount = value;
                OnPropertyChanged("Discount");
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

        public object Clone()
        {
            return new Sale()
            {
                ID = id,
                Discount = discount,
                StartDate = startDate,
                EndDate = endDate,
                Deleted = deleted
            };
        }

        /*public override string ToString()
        {
            return String.Format("{0,-5} {1,-15} {2,-5} {3,-15} {4,-15} {5,-5}", ID, Furniture.GetId(FurnitureOnSale), Discount, StartDate, EndDate, Deleted);
        }*/
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
