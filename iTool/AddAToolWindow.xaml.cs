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
        #region PROPERTIES
        private List<string> conditions = new List<string>() { "Poor", "Ok", "Good", "Pristine" };
        private List<string> categories = new List<string>() { "Hionta", "Hitsauskoneet", "Juottaminen", "Käsityökalut", "Leikkaustyökalut", "Leikkuuterät", "Mittavälineet", "Paineilma", "Poranterät", "Työkalujen säilyttäminen", "Työpajan varustus", "Työstökoneet", "Sähkötyökalut" };
        private string path;
        private string imgFile;
        private string dirPath;
        private string relativePath;
        #endregion

        #region METHODS
        public AddAToolWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }

        private void IniMyStuff()
        {
            imgAddTool.Source = new BitmapImage(new Uri(@"F:\iTool\iTool\iTool\images\no_picture_tool.png", UriKind.RelativeOrAbsolute));
            cbToolCategories.ItemsSource = categories;
            cbToolCondition.ItemsSource = conditions;
        }

        private void Reset()
        {
            txtToolName.Text = "";
            cbToolCategories.SelectedValue = null;
            cbToolCondition.SelectedValue = null;
            txtPrice.Text = "";
            txtDescription.Text = "";
            txtBrowseToolImage.Text = "";
            imgAddTool.Source = new BitmapImage(new Uri(@"F:\iTool\iTool\iTool\images\no_picture_tool.png", UriKind.RelativeOrAbsolute));
        }
        #endregion

        #region EVENTHANDLERS
        private void btnBrowseToolImage_Click(object sender, RoutedEventArgs e)
        {
            try
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
                relativePath = $"{Directory.GetParent(Environment.CurrentDirectory).Parent.FullName}\\{path}";

                // polku valituun kuvatiedostoon
                dirPath = $@"{System.IO.Path.GetDirectoryName(dlg.FileName)}\{System.IO.Path.GetFileName(dlg.FileName)}";
            }
            catch
            {
                throw;
            }
            
        }

        private void btnAddaToolToMysql_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtToolName.Text.Length == 0)
                {
                    lblToolError.Content = "Enter a tool name";
                    txtToolName.Focus();
                }
                else if (cbToolCategories.SelectedValue is null)
                {
                    lblToolError.Content = "Select a category";
                    cbToolCategories.Focus();
                }
                else if (cbToolCondition.SelectedValue is null)
                {
                    lblToolError.Content = "Select a condition";
                    cbToolCondition.Focus();
                }
                else if (string.IsNullOrEmpty(txtPrice.Text) || !float.TryParse(txtPrice.Text, out float f))
                {
                    lblToolError.Content = "Enter a price, has to be a number";
                    txtPrice.Focus();
                }
                else if (string.IsNullOrEmpty(txtDescription.Text))
                {
                    lblToolError.Content = "Enter a description";
                    txtDescription.Focus();
                }
                else
                {
                    int cID = DB.GetToolCategoryID(cbToolCategories.SelectedValue.ToString());
                    DB.AddAToolToMysql(txtToolName.Text, cID, txtDescription.Text, Active.UserID, cbToolCondition.SelectedValue.ToString(), float.Parse(txtPrice.Text), imgFile);
                    lblToolError.Content = "You have successfully added a tool for rent!";
                    Active.profile.dgMyTools.ItemsSource = DB.GetOwnedToolsFromMysql();

                    if (!string.IsNullOrEmpty(txtBrowseToolImage.Text))
                    {
                        System.IO.File.Copy(dirPath, relativePath, true);
                        File.SetAttributes(relativePath, FileAttributes.Normal);
                    }
                    Reset();
                }
            }
            catch
            {
                throw;
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.F1)
            {
                AddRandomTools addRandomTools = new AddRandomTools();
                addRandomTools.ShowDialog();
            }
        }
        #endregion
    }
}
