using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP54.Model
{
    public class FurnitureType : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string name;
        private bool deleted;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
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
            return String.Format("{0,-5}{1,-15}{2,-5}", ID, Name, Deleted);
        }

        public static FurnitureType GetById(int Id)
        {
            foreach (var furnitureType in Project.Instance.FurnitureTypesList)
            {
                if (furnitureType.ID == Id)
                {
                    return furnitureType;
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
            return new FurnitureType
            {
                ID = id,
                Name = name,
                Deleted = deleted
            };
        }
    }
}
