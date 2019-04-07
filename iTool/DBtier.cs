using System;
using System.Collections.Generic;
using System.Globalization;
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
                string sql = $"SELECT userID, userName, userSurname, userAddress, userEmail, userLocation, paymentMethod, userMobile, userPicture FROM user WHERE userID != {Active.UserID}";
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
                            u.Mobile = reader.GetString(7);
                            //u.Password = reader.GetString(8);
                            if (reader.IsDBNull(8) || string.IsNullOrEmpty(reader.GetString(8)))
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
        public static User GetToolOwnerFromMysql(int toolOwnerID)
        {
            try
            {
                User user = new User();
                string connStr = GetConnectionString();
                string sql = $"SELECT userID, userName, userSurname, userAddress, userEmail, userLocation, paymentMethod, userMobile, userPicture FROM user WHERE userID = {toolOwnerID.ToString()}";
                using (MySqlConnection con = new MySqlConnection(connStr))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        User u = new User();
                        while (reader.Read())
                        {
                            
                            u.UserID = int.Parse(reader.GetString(0));
                            u.FirstName = reader.GetString(1);
                            u.LastName = reader.GetString(2);
                            u.Address = reader.GetString(3);
                            u.Email = reader.GetString(4);
                            u.Location = reader.GetString(5);
                            u.PaymentMethod = reader.GetString(6);
                            u.Mobile = reader.GetString(7);
                            //u.Password = reader.GetString(8);
                            if (reader.IsDBNull(8) || string.IsNullOrEmpty(reader.GetString(8)))
                            {
                                u.PictureURL = "no_picture.jpg";
                            }

                            else
                            {
                                u.PictureURL = reader.GetString(8);
                            }
                        }
                        return u;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public static List<string> EmailChecker()
        {
            try
            {
                List<string> emails = new List<string>();
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
                            emails.Add(u.Email.ToString());
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
                string sql = $"SELECT toolID, userOwnerID, toolCategoryID, toolPicture, toolName, toolDescription, toolPrice, toolCondition, toolCategoryName, userLocation FROM all_tools WHERE userOwnerID != {Active.UserID} AND toolID NOT IN (select toolID from rented_tools);";
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
                            t.UserOwnerID = int.Parse(reader.GetString(1));
                            t.ToolCategoryID = int.Parse(reader.GetString(2));
                            if (reader.IsDBNull(3) || string.IsNullOrEmpty(reader.GetString(3)))
                            {
                                t.ToolPictureURL = "no_picture_tool.png";
                            }
                            else
                            {
                                t.ToolPictureURL = reader.GetString(3);
                            }
                            t.ToolName = reader.GetString(4);
                            t.ToolDescription = reader.GetString(5);
                            t.ToolPrice = float.Parse(reader.GetString(6));
                            t.ToolCondition = reader.GetString(7);
                            t.ToolCategoryName = reader.GetString(8);
                            t.ToolLocation = reader.GetString(9);

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

        public static List<Tool> GetOwnedToolsFromMysql()
        {
            try
            {
                List<Tool> tools = new List<Tool>();
                string connStr = GetConnectionString();
                string sql = $"SELECT toolID, userOwnerID, toolCategoryID, toolPicture, toolName, toolDescription, toolPrice, toolCondition, toolCategoryName, userLocation FROM all_tools WHERE userOwnerID = {Active.UserID} GROUP BY toolID";
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
                            t.UserOwnerID = int.Parse(reader.GetString(1));
                            t.ToolCategoryID = int.Parse(reader.GetString(2));
                            if (reader.IsDBNull(3) || string.IsNullOrEmpty(reader.GetString(3)))
                            {
                                t.ToolPictureURL = "no_picture_tool.png";
                            }
                            else
                            {
                                t.ToolPictureURL = reader.GetString(3);
                            }
                            t.ToolName = reader.GetString(4);
                            t.ToolDescription = reader.GetString(5);
                            t.ToolPrice = float.Parse(reader.GetString(6));
                            t.ToolCondition = reader.GetString(7);
                            t.ToolCategoryName = reader.GetString(8);
                            t.ToolLocation = reader.GetString(9);

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

        public static bool AddTransactionToMysql(string transactionStartDate, string transactionPlannedEndDate, int userOwnerID, int userLesseeID, int toolID)
        {
            try
            {
                string connStr = GetConnectionString();
                string sql = $"INSERT INTO transaction (transactionStartDate, transactionPlannedEndDate, userOwnerID, userLesseeID, toolID ) VALUES ('{transactionStartDate}','{transactionPlannedEndDate}',{userOwnerID},{userLesseeID},{toolID});";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            }
            catch
            {
                throw;
            }
        }

        public static string GetConnectionString()
        {
            string mysqlServer = Properties.Settings.Default.server;
            string mysqlDatabase = Properties.Settings.Default.database;
            string mysqlUID = Properties.Settings.Default.userID;
            string mysqlPassword = Properties.Settings.Default.password;
            //yleensä connection string tallennetaan koodin ulkopuolelle
            //tässä demossa koodissa = HYI HYI Paha!
            //haetaan salasana App.Config-tiedostosta
            return string.Format($"SERVER={mysqlServer};DATABASE={mysqlDatabase};UID={mysqlUID};PASSWORD={mysqlPassword}");
        }

        public static List<Tool> GetMyRentedToolsFromMysql()
        {
            try
            {
                List<Tool> tools = new List<Tool>();
                string connStr = GetConnectionString();
                string sql = $"SELECT toolID, userOwnerID, toolCategoryID, toolPicture, toolName, toolDescription, toolPrice, toolCondition, toolCategoryName, userLocation, transactionPlannedEndDate FROM rented_tools WHERE userLesseeID = {Active.UserID}";
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
                            t.UserOwnerID = int.Parse(reader.GetString(1));
                            t.ToolCategoryID = int.Parse(reader.GetString(2));
                            if (reader.IsDBNull(3) || string.IsNullOrEmpty(reader.GetString(3)))
                            {
                                t.ToolPictureURL = "no_picture_tool.png";
                            }
                            else
                            {
                                t.ToolPictureURL = reader.GetString(3);
                            }
                            t.ToolName = reader.GetString(4);
                            t.ToolDescription = reader.GetString(5);
                            t.ToolPrice = float.Parse(reader.GetString(6));
                            t.ToolCondition = reader.GetString(7);
                            t.ToolCategoryName = reader.GetString(8);
                            t.ToolLocation = reader.GetString(9);
                            t.TransactionPlannedEndDate = DateTime.Parse(reader.GetString(10));

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
    }
}
