using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace iTool
{
    /// <summary>
    /// Interaction logic for AddAToolWindow.xaml
    /// </summary>
    public partial class AddAToolWindow : Window
    {
        private List<string> conditions = new List<string>() { "Poor", "Ok", "Good", "Pristine" };
        private List<string> categories = new List<string>() { "Ähtäri", "Espoo", "Helsinki", "Jyväskylä", "Kuopio", "Kuusamo", "Lahti", "Lappeenranta", "Oulu", "Rauma", "Rovanniemi", "Savonlinna", "Seinäjoki", "Tampere", "Turku", "Vaasa", "Vantaa" };
        private string path;
        private string imgFile;
        public AddAToolWindow()
        {
            InitializeComponent();
        }

        private void btnBrowseToolImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Select a tool image";
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "All supported graphics |*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
            dlg.RestoreDirectory = true;
            Nullable<bool> result = dlg.ShowDialog(); // näyttää dialogin
            if (result == true)
            {
                txtBrowseToolImage.Text = dlg.FileName;
            }
            if (string.IsNullOrEmpty(txtBrowseToolImage.Text))
            {
                dlg.FileName = "images/no_picture_tool.png";
            }

            imgAddTool.Stretch = Stretch.Fill;
            Uri u = new Uri(dlg.FileName, UriKind.RelativeOrAbsolute);
            imgAddTool.Source = new BitmapImage(new Uri(dlg.FileName, UriKind.RelativeOrAbsolute));
            string i = imgAddTool.Source.ToString().Split('/')[imgAddTool.Source.ToString().Split('/').Length - 1];
            //path = $@"F:\iTool\iTool\iTool\images\{i}";
            path = $@"images\{i}";
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
            string relativePath = $"{Directory.GetParent(Environment.CurrentDirectory).Parent.FullName}\\{path}";

            // polku valituun kuvatiedostoon
            string dirPath = $@"{System.IO.Path.GetDirectoryName(dlg.FileName)}\{System.IO.Path.GetFileName(dlg.FileName)}";
            System.IO.File.Copy(dirPath, relativePath, true);
            File.SetAttributes(relativePath, FileAttributes.Normal);
        }
    }
}
