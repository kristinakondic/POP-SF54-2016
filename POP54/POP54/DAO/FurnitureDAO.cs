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
    class FurnitureDAO
    {
        public static ObservableCollection<Furniture> GetAll()
        {
            var furniture = new ObservableCollection<Furniture>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM Furniture WHERE Deleted = 0;";
                da.SelectCommand = cmd;
                da.Fill(ds, "Furniture");

                foreach (DataRow row in ds.Tables["Furniture"].Rows)
                {
                    var f = new Furniture();
                    f.ID = Convert.ToInt32(row["ID"]);
                    f.Name = row["Name"].ToString();
                    f.FurnitureTypeId = Convert.ToInt32(row["FurniturTypeId"]);
                    f.ProductCode = row["ProductCode"].ToString();
                    f.Quantity = Convert.ToInt32(row["Quantity"]);
                    f.Price = Convert.ToDouble(row["Price"]);
                    f.SaleId = Convert.ToInt32(row["SaleId"]);
                    f.PriceOnSale = Convert.ToInt32(row["PriceOnSale"]);
                    f.Deleted = bool.Parse(row["Deleted"].ToString());

                    furniture.Add(f);
                }
            }
            return furniture;
        }

        public static Furniture Create(Furniture f)
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO Furniture(Name, FurnitureTypeId, ProductCode, Quantity, Price, SaleId, PriceOnSale, Deleted) VALUES (@Name, @FurnitureTypeId, @ProductCode, @Quantity, @Price, @SaleId, @PriceOnSale, @Deleted);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Name", f.Name);
                cmd.Parameters.AddWithValue("FurnitureTypeId", f.FurnitureTypeId);
                cmd.Parameters.AddWithValue("ProductCode", f.ProductCode);
                cmd.Parameters.AddWithValue("Quantity", f.Quantity);
                cmd.Parameters.AddWithValue("Price", f.Price);
                cmd.Parameters.AddWithValue("SaleId", f.SaleId);
                cmd.Parameters.AddWithValue("PriceOnSale", f.PriceOnSale);
                cmd.Parameters.AddWithValue("Deleted", f.Deleted);

                f.ID = int.Parse(cmd.ExecuteScalar().ToString());
            }

            Project.Instance.FurnitureList.Add(f);

            return f;
        }

        public static ObservableCollection<Furniture> Update(Furniture f)
        {
            var furniture = new ObservableCollection<Furniture>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE Furniture SET Name=@Name, Name, FurnitureTypeId, ProductCode, Quantity, Price, SaleId, PriceOnSale, Deleted) VALUES (Name = @Name, FurnitureTypeId = @FurnitureTypeId, ProductCode = @ProductCode, Quantity = @Quantity, Price = @Price, SaleId = @SaleId, PriceOnSale = @PriceOnSale, Delete=@Delete WHERE ID = @ID;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("ID", f.ID);
                cmd.Parameters.AddWithValue("Name", f.Name);
                cmd.Parameters.AddWithValue("FurnitureTypeId", f.FurnitureTypeId);
                cmd.Parameters.AddWithValue("ProductCode", f.ProductCode);
                cmd.Parameters.AddWithValue("Quantity", f.Quantity);
                cmd.Parameters.AddWithValue("Price", f.Price);
                cmd.Parameters.AddWithValue("SaleId", f.SaleId);
                cmd.Parameters.AddWithValue("PriceOnSale", f.PriceOnSale);
                cmd.Parameters.AddWithValue("Deleted", f.Deleted);

                cmd.ExecuteNonQuery();

                foreach (var fur in Project.Instance.FurnitureList)
                {
                    if (f.ID == fur.ID)
                    {
                        fur.Name = f.Name;
                        fur.FurnitureTypeId = f.FurnitureTypeId;
                        fur.ProductCode = f.ProductCode;
                        fur.Quantity = f.Quantity;
                        fur.Price = f.Price;
                        fur.SaleId = f.SaleId;
                        fur.PriceOnSale = f.PriceOnSale;
                        fur.Deleted = f.Deleted;
                    }
                }
            }
            return furniture;
        }

        public static void Delete(Furniture f)
        {
            f.Deleted = true;
            Update(f);
        }
    }
}
