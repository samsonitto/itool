using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace iTool
{
    public class DB
    {
        public static List<User> GetUsersFromMysql()
        {
            try
            {
                List<User> users = new List<User>();
                string connStr = GetConnectionString();
                string sql = $"SELECT userID, userName, userSurname, userAddress, userEmail, userLocation, paymentMethod, userMobile, userPicture FROM user WHERE userID != {MainWindow.activeUserID}";
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
                            //u.Password = reader.GetString(8);
                            if (reader.IsDBNull(8))
                            {
                                u.PictureURL = "no_picture.jpg";
                            }
                            else
                            {
                                u.PictureURL = reader.GetString(8);
                            }
                            
                            users.Add(u);
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

        public static List<User> EmailChecker()
        {
            try
            {
                List<User> emails = new List<User>();
                string connStr = GetConnectionString();
                string sql = $"SELECT userEmail FROM user";
                using (MySqlConnection con = new MySqlConnection(connStr))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User u = new User();
                            u.Email = reader.GetString(0);
                            emails.Add(u);
                        }
                        return emails;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public static List<Tool> GetToolsFromMysql()
        {
            try
            {
                List<Tool> tools = new List<Tool>();
                string connStr = GetConnectionString();
                string sql = $"SELECT toolID, toolName, toolDescription, toolPrice, toolCondition, toolPicture, toolCategoryName FROM tool inner join toolCategory on tool.toolCategoryID = toolCategory.toolCategoryID WHERE userOwnerID != {MainWindow.activeUserID}";
                using (MySqlConnection con = new MySqlConnection(connStr))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Tool t = new Tool();
                            t.ToolID = int.Parse(reader.GetString(0));
                            t.ToolName = reader.GetString(1);
                            t.ToolDescription = reader.GetString(2);
                            t.ToolPrice = float.Parse(reader.GetString(3));
                            t.ToolCondition = reader.GetString(4);
                            
                            if (reader.IsDBNull(5))
                            {
                                t.ToolPictureURL = "no_picture_tool.png";
                            }
                            else
                            {
                                t.ToolPictureURL = reader.GetString(5);
                            }

                            t.ToolCategoryName = reader.GetString(6);

                            tools.Add(t);
                        }
                        return tools;
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
