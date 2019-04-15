using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
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
                string sql = $"SELECT toolID, userOwnerID, toolCategoryID, toolPicture, toolName, toolDescription, toolPrice, toolCondition, toolCategoryName, userLocation FROM all_tools WHERE userOwnerID != {Active.UserID} AND userLocation != 'DELETED' AND toolName != 'CODE002' AND toolID NOT IN (select toolID from rented_tools);";
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
                string sql = $"SELECT toolID, userOwnerID, toolCategoryID, toolPicture, toolName, toolDescription, toolPrice, toolCondition, toolCategoryName, userLocation FROM all_tools WHERE userOwnerID = {Active.UserID} AND toolName != 'CODE002' GROUP BY toolID";
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
        public static bool ReturnRentedToolMysql(int transactionID)
        {
            try
            {
                string connStr = GetConnectionString();
                string sql = $"UPDATE transaction SET actualEndDate = CURRENT_TIMESTAMP WHERE transactionID = {transactionID};";
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
        public static List<Comment> GetCommentsFromMysql(int toolID)
        {
            List<Comment> comments = new List<Comment>();
            string connStr = GetConnectionString();
            string sql = $"SELECT commentID, commentDate, commentText, userID, toolID, commentParentID FROM comment WHERE toolID = {toolID}";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    
                    while (reader.Read())
                    {
                        Comment c = new Comment();
                        c.CommentID = int.Parse(reader.GetString(0));
                        c.DateTime = DateTime.Parse(reader.GetString(1));
                        c.Text = reader.GetString(2);
                        c.userID = int.Parse(reader.GetString(3));
                        c.ToolID = int.Parse(reader.GetString(4));
                        if (!reader.IsDBNull(5))
                        {
                            c.CommentParentID = int.Parse(reader.GetString(5));
                        }
                        
                        comments.Add(c);
                    }
                    return comments;
                }
            }
        }
        public static bool AddAToolToMysql(string toolName, int toolCategoryID, string toolDescription, int toolOwnerID, string toolCondition, float toolPrice, string toolImage)
        {
            try
            {
                string connStr = GetConnectionString();
                string sql = $"INSERT INTO tool (toolName, toolDescription, toolPrice, toolCondition, toolCategoryID, userOwnerID, toolPicture) VALUES ('{toolName}','{toolDescription}',{toolPrice.ToString(CultureInfo.InvariantCulture)},'{toolCondition}',{toolCategoryID}, {toolOwnerID}, '{toolImage}');";
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
        public static int GetToolCategoryID(string toolCategoryName)
        {
            try
            {
                
                string connStr = GetConnectionString();
                string sql = $"SELECT toolCategoryID FROM toolCategory WHERE toolCategoryName = '{toolCategoryName}'";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        int toolCategoryID = 0;
                        while (reader.Read())
                        {
                            toolCategoryID = int.Parse(reader.GetString(0));
                            
                        }
                        return toolCategoryID;
                    }
                    
                }
            }
            catch
            {
                throw;
            }
        }
        public static List<int> GetToolCategoryIDs()
        {
            try
            {
                List<int> ids = new List<int>();
                string connStr = GetConnectionString();
                string sql = $"SELECT toolCategoryID FROM toolCategory;";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        int toolCategoryID = 0;
                        while (reader.Read())
                        {
                            toolCategoryID = int.Parse(reader.GetString(0));
                            ids.Add(toolCategoryID);

                        }
                        return ids;
                    }

                }
            }
            catch
            {
                throw;
            }
        }
        public static List<int> GetUserIDsFromMysql()
        {
            try
            {
                List<int> ids = new List<int>();
                string connStr = GetConnectionString();
                string sql = $"SELECT userID FROM user;";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        int userID = 0;
                        while (reader.Read())
                        {
                            userID = int.Parse(reader.GetString(0));
                            ids.Add(userID);

                        }
                        return ids;
                    }

                }
            }
            catch
            {
                throw;
            }
        }
        public static List<Transaction> GetTransactionsFromMysql()
        {
            try
            {
                List<Transaction> transactions = new List<Transaction>();
                string connStr = GetConnectionString();
                string sql = $"SELECT transactionID, transactionStartDate, transactionPlannedEndDate, userOwnerID, userLesseeID, toolID, actualEndDate  FROM transaction WHERE userOwnerID = {Active.UserID} || userLesseeID = {Active.UserID};";
                using (MySqlConnection con = new MySqlConnection(connStr))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Transaction t = new Transaction();
                            t.TransactionID = int.Parse(reader.GetString(0));
                            t.StartDate = DateTime.Parse(reader.GetString(1));
                            t.PlannedEndDate = DateTime.Parse(reader.GetString(2));
                            t.UserOwnerID = int.Parse(reader.GetString(3));
                            t.UserLesseeID = int.Parse(reader.GetString(4));
                            t.ToolID = int.Parse(reader.GetString(5));
                            if (!reader.IsDBNull(6))
                            {
                                t.ActualEndDate = DateTime.Parse(reader.GetString(6));
                            }
                            else
                            {
                                t.ActualEndDate = null;
                            }
                            

                            transactions.Add(t);
                        }
                        return transactions;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public static Tool GetToolFromMysql(int toolID)
        {
            try
            {
                Tool tool = new Tool();
                string connStr = GetConnectionString();
                string sql = $"SELECT toolID, toolName, toolDescription, toolPrice, toolCondition, toolCategoryID, userOwnerID, toolPicture FROM tool WHERE toolID = {toolID}";
                using (MySqlConnection con = new MySqlConnection(connStr))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            tool.ToolID = int.Parse(reader.GetString(0));
                            tool.ToolName = reader.GetString(1);
                            tool.ToolDescription = reader.GetString(2);
                            tool.ToolPrice = float.Parse(reader.GetString(3));
                            tool.ToolCondition = reader.GetString(4);
                            tool.ToolCategoryID = int.Parse(reader.GetString(5));
                            tool.UserOwnerID = int.Parse(reader.GetString(6));
                            tool.ToolPictureURL = reader.GetString(7);
                            //u.Password = reader.GetString(8);
                            
                        }
                        return tool;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public static User GetUserFromMysqlWhere(string where)
        {
            try
            {
                User user = new User();
                string connStr = GetConnectionString();
                string sql = $"SELECT userID, userName, userSurname, userAddress, userEmail, userLocation, paymentMethod, userMobile, MD5(userPassword), userPicture FROM user WHERE {where};";
                using (MySqlConnection con = new MySqlConnection(connStr))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            user.UserID = int.Parse(reader.GetString(0));
                            user.FirstName = reader.GetString(1);
                            user.LastName = reader.GetString(2);
                            user.Address = reader.GetString(3);
                            user.Email = reader.GetString(4);
                            user.Location = reader.GetString(5);
                            user.PaymentMethod = reader.GetString(6);
                            user.Mobile = reader.GetString(7);
                            user.Password = reader.GetString(8);
                            if (reader.IsDBNull(9) || string.IsNullOrEmpty(reader.GetString(9)))
                            {
                                user.PictureURL = "no_picture.jpg";
                            }

                            else
                            {
                                user.PictureURL = reader.GetString(9);
                            }
                        }
                        return user;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public static bool UpdateUserToMysql(string set)
        {
            try
            {
                string connStr = GetConnectionString();
                string sql = $"UPDATE user {set} WHERE userID = {Active.UserID};";
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
        public static bool DeleteProfile()
        {
            try
            {
                Random rand = new Random();
                char[] abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
                string pw = abc[rand.Next(abc.Length)].ToString().ToLower();
                for (int i = 0; i < 5; i++)
                {
                    pw = $"{pw}{abc[rand.Next(abc.Length)].ToString().ToLower()}";
                }

                string connStr = GetConnectionString();
                string sql = $"UPDATE user SET userName = 'CODE001', userSurname = 'PROFILE DELETED', userAddress = 'DELETED', userEmail = 'DELETED', userLocation = 'DELETED', paymentMethod = 'DELETED', userMobile = 0000000000, userPassword = '{pw}', userPicture = null WHERE userID = {Active.UserID};";
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
        public static bool DeleteTool(int toolID)
        {
            try
            {
                string connStr = GetConnectionString();
                string sql = $"UPDATE tool SET toolName = 'CODE002', toolDescription = 'TOOL DELETED', toolPrice = 0, toolCondition = 'DELETED', toolPicture = null WHERE toolID = {toolID};";
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
        public static Transaction GetTransactionFromMysql(int toolID)
        {
            try
            {
                Transaction t = new Transaction();
                string connStr = GetConnectionString();
                string sql = $"SELECT  transactionID, transactionStartDate, transactionPlannedEndDate, userOwnerID, userLesseeID, toolID, actualEndDate FROM transaction WHERE toolID = {toolID} AND actualEndDate IS NULL";
                using (MySqlConnection con = new MySqlConnection(connStr))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            t.TransactionID = int.Parse(reader.GetString(0));
                            t.StartDate = DateTime.Parse(reader.GetString(1));
                            t.PlannedEndDate = DateTime.Parse(reader.GetString(2));
                            t.UserOwnerID = int.Parse(reader.GetString(3));
                            t.UserLesseeID = int.Parse(reader.GetString(4));
                            t.ToolID = int.Parse(reader.GetString(5));
                            if (reader.IsDBNull(6))
                                t.ActualEndDate = null;
                            else
                                t.ActualEndDate = DateTime.Parse(reader.GetString(6));
                        }
                        return t;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public static bool AddRatingToMysql(int rating, string feedback, int raterID, int ratedID, int transactionID)
        {
            try
            {
                string connStr = GetConnectionString();
                string sql = $"INSERT INTO rating (ratingFeedback, raterID, ratedID, transactionID, rating ) VALUES ('{feedback}',{raterID},{ratedID},{transactionID},{rating});";

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
        public static float GetAvgRatingFromMysql(int ratedID)
        {
            try
            {

                string connStr = GetConnectionString();
                string sql = $"SELECT avg(rating) FROM rating WHERE ratedID = {ratedID}";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        float avgRating = 0F;
                        while (reader.Read())
                        {
                            avgRating = float.Parse(reader.GetString(0));
                        }
                        return avgRating;
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
