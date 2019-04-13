using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    }
}
