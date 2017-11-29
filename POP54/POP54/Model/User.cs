using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP54.Model
{
    public enum TypeOfUser
    {
        ADMIN,
        SALESMAN
    }

    [Serializable]
    public class User : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string name;
        private string surname;
        private string username;
        private string password;
        private TypeOfUser userType;
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


        public TypeOfUser UserType
        {
            get { return userType; }
            set
            {
                userType = value;
                OnPropertyChanged("UserType");
            }
        }


        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }


        public string  Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }


        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
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

        public object Clone()
        {
            return new User()
            {
                ID = id,
                Name = name,
                Surname = surname,
                Username = username,
                Password = password,
                UserType = userType,
                Deleted = Deleted
            };
        }

        public override string ToString()
        {
            return String.Format("{0,-5}{1,-15}{2,-15}{3,-15}{4,-15}{5,-18}{6,-5}", ID, Name, Surname, Username, Password, UserType, Deleted);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
