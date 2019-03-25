using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace iTool
{
    public class MyDB
    {
        public static List<User> GetUsersFromMysql()
        {
            try
            {
                List<User> users = new List<User>();
                string connStr = GetConnectionString();
                string sql = "SELECT * FROM user";
                using (MySqlConnection con = new MySqlConnection(connStr))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User u = new User();
                            u.UserID = int.Parse(reader.GetString(0));
                            u.FirstName = reader.GetString(1);
                            u.LastName = reader.GetString(2);
                            u.Address = reader.GetString(3);
                            u.Email = reader.GetString(4);
                            u.Location = reader.GetString(5);
                            u.PaymentMethod = reader.GetString(6);
                            u.Mobile = int.Parse(reader.GetString(7));
                            u.Password = reader.GetString(8);
                        }
                        return users;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        

        private static string GetConnectionString()
        {
            //yleensä connection string tallennetaan koodin ulkopuolelle
            //tässä demossa koodissa = HYI HYI Paha!
            //string passu = "3HX4IWlUK13DNdDnkK3oQEzo4zKIXMCC";
            //haetaan salasana App.Config-tiedostosta
            return string.Format("SERVER=mysql.labranet.jamk.fi;DATABASE=M3156_3;UID=M3156;PASSWORD=Mn1GQ5TbFX7UI0tjH2Y4H2oWtcfs4zra");
        }

    }
}
