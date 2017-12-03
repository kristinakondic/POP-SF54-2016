using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP54.Model
{
    [Serializable]
    public class FurnitureStore : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private string address;
        private string phone;
        private string email;
        private string website;
        private int companyNo;
        private string accountNo;
        private int pib;

        public int Pib
        {
            get { return pib; }
            set
            {
                pib = value;
                OnPropertyChanged("PIB");
            }
        }


        public string AccountNo
        {
            get { return accountNo; }
            set
            {
                accountNo = value;
                OnPropertyChanged("AccountNo");
            }
        }


        public int CompanyNo
        {
            get { return companyNo; }
            set
            {
                companyNo = value;
                OnPropertyChanged("CompanyNo");
            }
        }


        public string Website
        {
            get { return website; }
            set
            {
                website = value;
                OnPropertyChanged("Website");
            }
        }


        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }


        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }


        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
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

        public override string ToString()
        {
            return String.Format("{0,-5}{1,-15}{2,-15}{3,-15}{4,-20}{5,-20}{6,-10}{7,-15}{8,-10}", ID, Name, Address, Phone, Email, Website, CompanyNo, AccountNo, Pib);
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
