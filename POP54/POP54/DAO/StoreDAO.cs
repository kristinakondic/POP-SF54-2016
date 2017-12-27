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
    class StoreDAO
    {
        public static FurnitureStore GetStore()
        {
            var s = new FurnitureStore();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM FurnitureStore;";
                da.SelectCommand = cmd;
                da.Fill(ds, "FurnitureStore");

                foreach (DataRow row in ds.Tables["FurnitureStore"].Rows)
                {
                    s.ID = Convert.ToInt32(row["ID"]);
                    s.Name = row["Name"].ToString();
                    s.Address = row["Address"].ToString();
                    s.Phone = row["Phone"].ToString();
                    s.Email = row["Email"].ToString();
                    s.Website = row["Website"].ToString();
                    s.CompanyNo = row["CompanyNo"].ToString();
                    s.AccountNo = row["AccountNo"].ToString();
                    s.Pib = row["Pib"].ToString();
                }
            }
            return s;
        }
        public static void Update(FurnitureStore store)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE FurnitureStore SET Name = @Name, Address = @Address, Phone = @Phone, Email = @Email, Website = @Website, CompanyNo = @CompanyNo, AccountNo=@AccountNo, Pib = @Pib;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Name", store.Name);
                cmd.Parameters.AddWithValue("Address", store.Address);
                cmd.Parameters.AddWithValue("Phone", store.Phone);
                cmd.Parameters.AddWithValue("Email", store.Email);
                cmd.Parameters.AddWithValue("Website", store.Website);
                cmd.Parameters.AddWithValue("CompanyNo", store.CompanyNo);
                cmd.Parameters.AddWithValue("AccountNo", store.AccountNo);
                cmd.Parameters.AddWithValue("Pib", store.Pib);

                cmd.ExecuteNonQuery();

                var s = Project.Instance.Store;
                s.Name = store.Name;
                s.Address = store.Address;
                s.Phone = store.Phone;
                s.Email = store.Email;
                s.Website = store.Website;
                s.CompanyNo = store.CompanyNo;
                s.AccountNo = store.AccountNo;
                s.Pib = store.Pib;
            }
        }
    }
}
