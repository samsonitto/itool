using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace iTool
{
    public static class Active
    {
        #region PROPERTIES
        public static string ProjectPath { get { return Directory.GetParent(Environment.CurrentDirectory).Parent.FullName; } }
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static string ImagePath { get; set; }
        public static string ImageFileName { get; set; }
        public static int UserID { get; set; }
        public static BitmapImage ImageSource { get; set; }
        public static int OwnerID { get; set; }
        public static int ToolID { get; set; }
        public static string relativePath;
        public static string dirPath;
        public static string imgFile;
        public static MainWindow main;
        public static ProfileWindow profile;
        #endregion

        #region METHODS
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

        public static void BrowseImage(Image imgProfile, TextBox txtPic)
        {
            try
            {
                string path;
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Select a profile picture";
                dlg.InitialDirectory = "c:\\";
                dlg.Filter = "All supported graphics |*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
                dlg.RestoreDirectory = true;
                Nullable<bool> result = dlg.ShowDialog(); // näyttää dialogin
                if (result == true)
                {
                    txtPic.Text = dlg.FileName;
                }
                if (string.IsNullOrEmpty(txtPic.Text))
                {
                    dlg.FileName = "images/no_picture.png";
                }

                imgProfile.Stretch = Stretch.Fill;
                Uri u = new Uri(dlg.FileName, UriKind.RelativeOrAbsolute);
                imgProfile.Source = new BitmapImage(new Uri(dlg.FileName, UriKind.RelativeOrAbsolute));
                string i = imgProfile.Source.ToString().Split('/')[imgProfile.Source.ToString().Split('/').Length - 1];
                //path = $@"F:\iTool\iTool\iTool\images\{i}";
                //path = $@"images\{i}";
                path = $"{ProjectPath}\\images\\{i}";
                if (File.Exists(path))
                {
                    int x = 0;
                    for (; File.Exists(path);)
                    {
                        path = $@"images\{x}{i}";
                        //path = $@"F:\iTool\iTool\iTool\images\{x}{i}";
                        imgFile = $"{x}{i}";
                        x++;
                    }
                }

                else
                {
                    imgFile = path.Split('\\')[path.Split('\\').Length - 1];
                }

                // relaatiivinen polku images kansioon
                relativePath = $"{ProjectPath}\\images\\{imgFile}";

                // polku valituun kuvatiedostoon
                dirPath = $@"{System.IO.Path.GetDirectoryName(dlg.FileName)}\{System.IO.Path.GetFileName(dlg.FileName)}";
            }
            catch
            {
                throw;
            }

        }
        #endregion
    }
}
