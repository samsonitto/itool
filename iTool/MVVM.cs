using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace iTool
{
    public static class Active
    {
        public static string ProjectPath { get { return Directory.GetParent(Environment.CurrentDirectory).Parent.FullName; } }
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static string ImagePath { get; set; }
        public static string ImageFileName { get; set; }
        public static int UserID { get; set; }
        public static BitmapImage ImageSource { get; set; }
        public static int OwnerID { get; set; }
        public static int ToolID { get; set; }

        //public static string ConvertStringtoMD5(string password)
        //{
        //    MD5 md5 = MD5.Create();


        //    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);

        //    byte[] hash = md5.ComputeHash(inputBytes);

        //    StringBuilder sb = new StringBuilder();
        //    for (int i = 0; i < hash.Length; i++)
        //    {
        //        sb.Append(hash[i].ToString("x2"));
        //    }
        //    return sb.ToString();
        //}
    }
}
