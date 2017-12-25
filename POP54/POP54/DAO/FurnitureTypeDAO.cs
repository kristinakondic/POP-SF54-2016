using POP54.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP54.DAO
{
    class FurnitureTypeDAO
    {
        public static ObservableCollection<FurnitureType> GetAll()
        {
            var furnitureTypes = new ObservableCollection<FurnitureType>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM FurnitureType WHERE Deleted = 0;";
                da.SelectCommand = cmd;
                da.Fill(ds, "FurnitureType");

                foreach (DataRow row in ds.Tables["FurnitureType"].Rows)
                {
                    var ft = new FurnitureType();
                    ft.ID = Convert.ToInt32(row["ID"]);
                    ft.Name = row["Name"].ToString();
                    ft.Deleted = bool.Parse(row["Deleted"].ToString());

                    furnitureTypes.Add(ft);
                }
            }
            return furnitureTypes;
        }

        public static FurnitureType Create(FurnitureType ft)
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO FurnitureType(Name, Deleted) VALUES (@Name, @Deleted);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Name", ft.Name);
                cmd.Parameters.AddWithValue("Deleted", ft.Deleted);

                ft.ID = int.Parse(cmd.ExecuteScalar().ToString());
            }

            Project.Instance.FurnitureTypesList.Add(ft);

            return ft;
        }

        public static void Update(FurnitureType ft)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE FurnitureType SET Name=@Name, Deleted=@Deleted WHERE ID = @ID;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("ID", ft.ID);
                cmd.Parameters.AddWithValue("Name", ft.Name);
                cmd.Parameters.AddWithValue("Deleted", ft.Deleted);

                cmd.ExecuteNonQuery();

                foreach (var type in Project.Instance.FurnitureTypesList)
                {
                    if (ft.ID == type.ID)
                    {
                        type.Name = ft.Name;
                        type.Deleted = ft.Deleted;
                    }
                }
            }
        }

        public static void Delete(FurnitureType ft)
        {
            ft.Deleted = true;
            Update(ft);
        }
    }
}
