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
    class UserDAO
    {
        public static ObservableCollection<User> GetAll()
        {
            var users = new ObservableCollection<User>();
            string commandText = "SELECT * FROM dbo.[User] WHERE Deleted = 0;";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                SqlCommand command = new SqlCommand(commandText, con);
                da.SelectCommand = command;
                da.Fill(ds, "User");

                foreach (DataRow row in ds.Tables["User"].Rows)
                {
                    var user = new User();
                    user.ID = Convert.ToInt32(row["ID"]);
                    user.Name = row["Name"].ToString();
                    user.Surname = row["Surname"].ToString();
                    user.Username = row["Username"].ToString();
                    user.Password = row["Password"].ToString();
                    user.UserType =(TypeOfUser) Convert.ToInt32(row["UserType"]);
                    user.Deleted = bool.Parse(row["Deleted"].ToString());

                    users.Add(user);
                }
            }
            return users;
        }

        public static User Create(User user)
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO User(Name, Surname, Username, Password, UserType, Deleted) VALUES (@Name, @Surname, @Username, @Password, @UserType, @Deleted);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Name", user.Name);
                cmd.Parameters.AddWithValue("Surname", user.Surname);
                cmd.Parameters.AddWithValue("Username", user.Username);
                cmd.Parameters.AddWithValue("Password", user.Password);
                cmd.Parameters.AddWithValue("UserType", user.UserType);
                cmd.Parameters.AddWithValue("Deleted", user.Deleted);

                user.ID = int.Parse(cmd.ExecuteScalar().ToString());
            }

            Project.Instance.UsersList.Add(user);

            return user;
        }

        public static ObservableCollection<User> Update(User user)
        {
            var users = new ObservableCollection<User>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE User SET Name = @Name, Surname = @Surname, Username = @Username, Password = @Password, UserType = @UserType, Deleted = @Deleted;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Name", user.Name);
                cmd.Parameters.AddWithValue("Surname", user.Surname);
                cmd.Parameters.AddWithValue("Username", user.Username);
                cmd.Parameters.AddWithValue("Password", user.Password);
                cmd.Parameters.AddWithValue("UserType", user.UserType);
                cmd.Parameters.AddWithValue("Deleted", user.Deleted);

                cmd.ExecuteNonQuery();

                foreach (var u in Project.Instance.UsersList)
                {
                    if (user.ID == u.ID)
                    {
                        u.Name = user.Name;
                        u.Surname = user.Surname;
                        u.Username = user.Username;
                        u.Password = user.Password;
                        u.UserType = user.UserType;
                        u.Deleted = user.Deleted;
                    }
                }
            }
            return users;
        }

        public static void Delete(User user)
        {
            user.Deleted = true;
            Update(user);
        }
    }
}
