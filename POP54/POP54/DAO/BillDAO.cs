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
                    bill.ID = Convert.ToInt32(row["ID"]);
                    bill.DateOfSale = (DateTime)row["DateOfSale"];
                    bill.BillNo = Convert.ToInt32(row["BillNo"]);
                    bill.Buyer = row["Buyer"].ToString();
                    bill.PDV = Convert.ToDouble(row["PDV"]);
                    bill.FullPrice = Convert.ToDouble(row["FUllPrice"]);
                    bill.Deleted = bool.Parse(row["Deleted"].ToString());

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

                cmd.CommandText = "INSERT INTO Bill(DateOfSale, BillNo, Buyer, PDV, FullPrice, Deleted) VALUES (@DateOfSale, @BillNo, @Buyer, @PDV, @FullPrice, @Deleted);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("DateOfSale", bill.DateOfSale);
                cmd.Parameters.AddWithValue("BillNo", bill.BillNo);
                cmd.Parameters.AddWithValue("Buyer", bill.Buyer);
                cmd.Parameters.AddWithValue("PDV", bill.PDV);
                cmd.Parameters.AddWithValue("FullPrice", bill.FullPrice);
                cmd.Parameters.AddWithValue("Deleted", bill.Deleted);

                bill.ID = int.Parse(cmd.ExecuteScalar().ToString());
            }

            Project.Instance.BillsList.Add(bill);

            return bill;
        }

        public static ObservableCollection<Bill> Update(Bill bill)
        {
            var bills = new ObservableCollection<Bill>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE Bill SET DateOfSale = @DateOfSale, BillNo = @BillNo, Buyer = @Buyer, PDV = @PDV, FullPrice = @FullPrice, Deleted = @Deleted WHERE ID = @ID;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("DateOfSale", bill.DateOfSale);
                cmd.Parameters.AddWithValue("BillNo", bill.BillNo);
                cmd.Parameters.AddWithValue("Buyer", bill.Buyer);
                cmd.Parameters.AddWithValue("PDV", bill.PDV);
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
                        b.PDV = bill.PDV;
                        b.FullPrice = bill.FullPrice;
                        b.Deleted = bill.Deleted;
                    }
                }
            }
            return bill;
        }

        public static void Delete(Bill bill)
        {
            bill.Deleted = true;
            Update(bill);
        }
    }
}
