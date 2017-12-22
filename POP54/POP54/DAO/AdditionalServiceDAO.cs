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
    class AdditionalServiceDAO
    {
        public static ObservableCollection<AdditionalService> GetAll()
        {
            var additionalService = new ObservableCollection<AdditionalService>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM AdditionalService WHERE Deleted = 0;";
                da.SelectCommand = cmd;
                da.Fill(ds, "AdditionalService");

                foreach (DataRow row in ds.Tables["AdditionalService"].Rows)
                {
                    var ads = new AdditionalService();
                    ads.ID = Convert.ToInt32(row["ID"]);
                    ads.Name = row["Name"].ToString();
                    ads.Price = Convert.ToDouble(row["Price"]);
                    ads.Deleted = bool.Parse(row["Deleted"].ToString());

                    additionalService.Add(ads);
                }
            }
            return additionalService;
        }

        public static AdditionalService Create(AdditionalService ads)
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO AdditionalService(Name, Price, Deleted) VALUES (@Name, @Price, @Deleted);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Name", ads.Name);
                cmd.Parameters.AddWithValue("Price", ads.Price);
                cmd.Parameters.AddWithValue("Deleted", ads.Deleted);

                ads.ID = int.Parse(cmd.ExecuteScalar().ToString());
            }

            Project.Instance.AdditionalServicesList.Add(ads);

            return ads;
        }

        public static ObservableCollection<AdditionalService> Update(AdditionalService ads)
        {
            var additionalService = new ObservableCollection<AdditionalService>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE AdditionalService SET Namee=@Namee, Price=@Price, Delete=@Delete WHERE ID = @ID;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("ID", ads.ID);
                cmd.Parameters.AddWithValue("Name", ads.Name);
                cmd.Parameters.AddWithValue("Price", ads.Price);
                cmd.Parameters.AddWithValue("Deleted", ads.Deleted);

                cmd.ExecuteNonQuery();

                foreach (var a in Project.Instance.AdditionalServicesList)
                {
                    if (ads.ID == a.ID)
                    {
                        a.Name = ads.Name;
                        a.Deleted = ads.Deleted;
                    }
                }
            }
            return additionalService;
        }

        public static void Delete(AdditionalService ads)
        {
            ads.Deleted = true;
            Update(ads);
        }
    }
}