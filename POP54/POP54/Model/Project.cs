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
        public ObservableCollection<Bill> BillsList { get; set; }
        public ObservableCollection<FurnitureType> FurnitureTypesList { get; set; }
        public ObservableCollection<Furniture> FurnitureList { get; set; }
        public ObservableCollection<AdditionalService> AdditionalServicesList { get; set; }
        public ObservableCollection<Sale> SalesList { get; set; }
        public FurnitureStore Store{ get; set; }
        public Bill Bill { get; set; }
        public User User { get; set; }

        private Project()
        {
            FurnitureList = DAO.FurnitureDAO.GetAll();
            UsersList = DAO.UserDAO.GetAll();
            BillsList = DAO.BillDAO.GetAll();
            FurnitureTypesList = DAO.FurnitureTypeDAO.GetAll();
            AdditionalServicesList = DAO.AdditionalServiceDAO.GetAll();
            SalesList = DAO.SaleDAO.GetAll();
            Store = DAO.StoreDAO.GetStore();
            Bill = new Bill();
            User = new User();
        }
    }
}