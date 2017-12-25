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
    class SaleDAO
    {
        public static ObservableCollection<Sale> GetAll()
        {
            var sales = new ObservableCollection<Sale>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM dbo.[Sale] WHERE Deleted = 0;";
                da.SelectCommand = cmd;
                da.Fill(ds, "Sale");

                foreach (DataRow row in ds.Tables["Sale"].Rows)
                {
                    var sale = new Sale();
                    sale.ID = Convert.ToInt32(row["ID"]);
                    sale.Discount = Convert.ToInt32(row["Discount"]);
                    sale.StartDate = (DateTime)row["StartDate"];
                    sale.EndDate = (DateTime)row["EndDate"];
                    sale.Deleted = bool.Parse(row["Deleted"].ToString());

                    sales.Add(sale);
                }
            }
            return sales;
        }

        public static Sale Create(Sale sale)
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO Sale(Discount, StartDate, EndDate, Deleted) VALUES (@Discount, @StartDate, @EndDate, @Deleted);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Discount", sale.Discount);
                cmd.Parameters.AddWithValue("StartDate", sale.StartDate);
                cmd.Parameters.AddWithValue("EndDate", sale.EndDate);
                cmd.Parameters.AddWithValue("Deleted", sale.Deleted);

                sale.ID = int.Parse(cmd.ExecuteScalar().ToString());
            }

            Project.Instance.SalesList.Add(sale);

            return sale;
        }

        public static void Update(Sale sale)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE Sale SET Discount = Discount, StartDate = @StartDate, EndDate = @EndDate, Deleted = @Deleted WHERE ID = @ID;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("ID", sale.ID);
                cmd.Parameters.AddWithValue("Discount", sale.Discount);
                cmd.Parameters.AddWithValue("StartDate", sale.StartDate);
                cmd.Parameters.AddWithValue("EndDate", sale.EndDate);
                cmd.Parameters.AddWithValue("Deleted", sale.Deleted);

                cmd.ExecuteNonQuery();

                foreach (var s in Project.Instance.SalesList)
                {
                    if (sale.ID == s.ID)
                    {
                        s.Discount = sale.Discount;
                        s.StartDate = sale.StartDate;
                        s.EndDate = sale.EndDate;
                        s.Deleted = sale.Deleted;
                    }
                }
            }
        }

        public static void Delete(Sale sale)
        {
            sale.Deleted = true;
            Update(sale);
        }

        public static void DeleteFurnitureSale(Sale sale)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "DELETE FROM FurnitureSales WHERE SaleId = @id";
                cmd.Parameters.Add(new SqlParameter("SaleId", sale.ID));

            } 
        }

        public static void AddFurnitureSale(Sale sale, Furniture furniture)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO FurnitureSales(FurnitureId, SaleId) VALUES (@FurnitureId, @SaleId);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("FurnitureId", furniture.ID);
                cmd.Parameters.AddWithValue("SaleId", sale.ID);
                cmd.ExecuteNonQuery();

            }
        }
    }
}
