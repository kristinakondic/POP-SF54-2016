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
    class BillDAO
    {
        public static ObservableCollection<Bill> GetAll()
        {
            var bills = new ObservableCollection<Bill>();
            string commandTextA = "SELECT * FROM dbo.AdditionalService JOIN dbo.BillAdditionalServices ON AdditionalService.ID = BillAdditionalServices.AdditionalServiceId WHERE Deleted = 0 AND BillId = @id";
            string commandTextF = "SELECT * FROM dbo.Furniture JOIN dbo.BillFurniture ON Furniture.ID = BillFurniture.FurnitureId WHERE Deleted = 0 AND BillId = @id";


            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM Bill WHERE Deleted = 0;";
                da.SelectCommand = cmd;
                da.Fill(ds, "Bill");

                foreach (DataRow row in ds.Tables["Bill"].Rows)
                {
                    var bill = new Bill();
                    bill.AdditionalServiceList = new List<AdditionalService>();
                    bill.FurnitureForSaleList = new List<Furniture>();
                    bill.ID = Convert.ToInt32(row["ID"]);
                    bill.DateOfSale = (DateTime)row["DateOfSale"];
                    bill.BillNo = Convert.ToInt32(row["BillNo"]);
                    bill.Buyer = row["Buyer"].ToString();
                    bill.FullPrice = Convert.ToDouble(row["FUllPrice"]);
                    bill.Deleted = bool.Parse(row["Deleted"].ToString());

                    SqlCommand commandA = new SqlCommand(commandTextA, con);
                    commandA.Parameters.Add("@id", SqlDbType.Int);
                    commandA.Parameters["@id"].Value = bill.ID;
                    da.SelectCommand = commandA;
                    da.Fill(ds, "AdditionalService");

                    foreach (DataRow roww in ds.Tables["AdditionalService"].Rows)
                    {
                        var ads = new AdditionalService();
                        ads.ID = Convert.ToInt32(roww["ID"]);
                        ads.Name = roww["Name"].ToString();
                        ads.Price = Convert.ToDouble(roww["Price"]);
                        ads.Deleted = bool.Parse(roww["Deleted"].ToString());

                        bill.AdditionalServiceList.Add(ads);
                    }
                    ds.Tables["AdditionalService"].Clear();

                    SqlCommand commandF = new SqlCommand(commandTextF, con);
                    commandF.Parameters.Add("@id", SqlDbType.Int);
                    commandF.Parameters["@id"].Value = bill.ID;
                    da.SelectCommand = commandF;
                    da.Fill(ds, "Furniture");

                    foreach (DataRow rowww in ds.Tables["Furniture"].Rows)
                    {
                        var f = new Furniture();
                        f.Sales = new List<Sale>();
                        f.ID = Convert.ToInt32(rowww["ID"]);
                        f.Name = rowww["Name"].ToString();
                        f.FurnitureTypeId = Convert.ToInt32(rowww["FurnitureTypeId"]);
                        f.ProductCode = rowww["ProductCode"].ToString();
                        f.Quantity = Convert.ToInt32(rowww["Quantity"]);
                        f.Price = Convert.ToDouble(rowww["Price"]);
                        f.PriceOnSale = Convert.ToDouble(rowww["PriceOnSale"]);
                        f.Deleted = bool.Parse(rowww["Deleted"].ToString());

                        bill.FurnitureForSaleList.Add(f);
                    }
                    ds.Tables["Furniture"].Clear();
                    bills.Add(bill);
                }
            }
            return bills;
        }

        public static Bill Create(Bill bill)
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO Bill(DateOfSale, BillNo, Buyer, FullPrice, Deleted) VALUES (@DateOfSale, @BillNo, @Buyer, @FullPrice, @Deleted);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("DateOfSale", bill.DateOfSale);
                cmd.Parameters.AddWithValue("BillNo", bill.BillNo);
                cmd.Parameters.AddWithValue("Buyer", bill.Buyer);
                cmd.Parameters.AddWithValue("FullPrice", bill.FullPrice);
                cmd.Parameters.AddWithValue("Deleted", bill.Deleted);

                bill.ID = int.Parse(cmd.ExecuteScalar().ToString());
            }

            Project.Instance.BillsList.Add(bill);

            return bill;
        }

        public static void Update(Bill bill)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE Bill SET DateOfSale = @DateOfSale, BillNo = @BillNo, Buyer = @Buyer, FullPrice = @FullPrice, Deleted = @Deleted WHERE ID = @ID;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("ID", bill.ID);
                cmd.Parameters.AddWithValue("DateOfSale", bill.DateOfSale);
                cmd.Parameters.AddWithValue("BillNo", bill.BillNo);
                cmd.Parameters.AddWithValue("Buyer", bill.Buyer);
                cmd.Parameters.AddWithValue("FullPrice", bill.FullPrice);
                cmd.Parameters.AddWithValue("Deleted", bill.Deleted);

                cmd.ExecuteNonQuery();

                foreach (var b in Project.Instance.BillsList)
                {
                    if (bill.ID == b.ID)
                    {
                        b.DateOfSale = bill.DateOfSale;
                        b.BillNo = bill.BillNo;
                        b.Buyer = bill.Buyer;
                        b.FullPrice = bill.FullPrice;
                        b.Deleted = bill.Deleted;
                    }
                }
            }
        }
        public static void AddFurnitureOnBill(Bill bill, Furniture furniture)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO BillFurniture(FurnitureId, BillId) VALUES (@FurnitureId, @BillId);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("FurnitureId", furniture.ID);
                cmd.Parameters.AddWithValue("BillId", bill.ID);
                cmd.ExecuteNonQuery();
            }
        }
        public static void AddAdditionalServiceOnBill(Bill bill, AdditionalService additionalService)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO BillAdditionalServices(BillId, AdditionalServiceId) VALUES (@BillId, @AdditionalServiceId);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("BillId", bill.ID);
                cmd.Parameters.AddWithValue("AdditionalServiceId", additionalService.ID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
