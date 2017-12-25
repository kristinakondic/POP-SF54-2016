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
            string commandText = "SELECT * FROM dbo.Sale JOIN dbo.FurnitureSales ON FurnitureSales.SaleId = Sale.Id WHERE Deleted = 0 AND FurnitureId = @id";

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
                    f.Sales = new List<Sale>();
                    f.ID = Convert.ToInt32(row["ID"]);
                    f.Name = row["Name"].ToString();
                    f.FurnitureTypeId = Convert.ToInt32(row["FurnitureTypeId"]);
                    f.ProductCode = row["ProductCode"].ToString();
                    f.Quantity = Convert.ToInt32(row["Quantity"]);
                    f.Price = Convert.ToDouble(row["Price"]);
                    f.PriceOnSale = Convert.ToDouble(row["PriceOnSale"]);
                    f.Deleted = bool.Parse(row["Deleted"].ToString());

                    SqlCommand command = new SqlCommand(commandText, con);
                    command.Parameters.Add("@id", SqlDbType.Int);
                    command.Parameters["@id"].Value = f.ID;
                    da.SelectCommand = command;
                    da.Fill(ds, "Sale");
                    
                    foreach (DataRow roww in ds.Tables["Sale"].Rows)
                    {
                        var s = new Sale();
                        s.ID = Convert.ToInt32(roww["ID"]);
                        s.StartDate = (DateTime)roww["StartDate"];
                        s.EndDate = (DateTime)roww["EndDate"];
                        s.Discount = Convert.ToInt32(roww["Discount"]);
                        
                        f.Sales.Add(s);
                        
                    }
                    
                    
                    furniture.Add(f);
                    ds.Tables["Sale"].Clear();
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

                cmd.CommandText = "INSERT INTO Furniture(Name, FurnitureTypeId, ProductCode, Quantity, Price, PriceOnSale, Deleted) VALUES (@Name, @FurnitureTypeId, @ProductCode, @Quantity, @Price, @PriceOnSale, @Deleted);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Name", f.Name);
                cmd.Parameters.AddWithValue("FurnitureTypeId", f.FurnitureTypeId);
                cmd.Parameters.AddWithValue("ProductCode", f.ProductCode);
                cmd.Parameters.AddWithValue("Quantity", f.Quantity);
                cmd.Parameters.AddWithValue("Price", f.Price);
                cmd.Parameters.AddWithValue("PriceOnSale", f.PriceOnSale);
                cmd.Parameters.AddWithValue("Deleted", f.Deleted);

                f.ID = int.Parse(cmd.ExecuteScalar().ToString());
            }

            Project.Instance.FurnitureList.Add(f);

            return f;
        }

        public static void Update(Furniture f)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE Furniture SET Name = @Name, FurnitureTypeId = @FurnitureTypeId, ProductCode = @ProductCode, Quantity = @Quantity, Price = @Price, PriceOnSale = @PriceOnSale, Deleted=@Deleted WHERE ID = @ID;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("ID", f.ID);
                cmd.Parameters.AddWithValue("Name", f.Name);
                cmd.Parameters.AddWithValue("FurnitureTypeId", f.FurnitureTypeId);
                cmd.Parameters.AddWithValue("ProductCode", f.ProductCode);
                cmd.Parameters.AddWithValue("Quantity", f.Quantity);
                cmd.Parameters.AddWithValue("Price", f.Price);
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
                        fur.PriceOnSale = f.PriceOnSale;
                        fur.Deleted = f.Deleted;
                    }
                }
            }
        }

        public static void Delete(Furniture f)
        {
            f.Deleted = true;
            Update(f);
        }
    }
}
