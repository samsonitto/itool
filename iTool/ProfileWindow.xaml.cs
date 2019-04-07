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
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        public ProfileWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }

        private void IniMyStuff()
        {
            //imgUserProfile.Source = new BitmapImage(new Uri(MainWindow.activeUserImage, UriKind.RelativeOrAbsolute));
            imgUserProfile.Source = Active.ImageSource;
            //MainWindow.bi.CacheOption = BitmapCacheOption.OnLoad;
            txbFirstName.Text = Active.FirstName;
            txbLastName.Text = Active.LastName;
            txbUserID.Text = $"User ID: {Active.UserID.ToString()}";
            dgMyTools.ItemsSource = DB.GetOwnedToolsFromMysql();
            dgRentedToolsByMe.ItemsSource = DB.GetMyRentedToolsFromMysql();
        }

        private void DgMyTools_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Object selected = dgMyTools.SelectedItem;
            if (selected != null)
            {
                Tool tool = (Tool)selected;
                ShowPicture(tool.ToolPictureURL);
                txbToolNameProfile.Text = tool.ToolName;
                txbToolConditionProfile.Text = tool.ToolCondition;
                txbPriceProfile.Text = tool.ToolPrice.ToString();
                txbDescriptionProfile.Text = tool.ToolDescription;
                imgToolProfile.Source = new BitmapImage(new Uri($"{Active.ProjectPath}/images/{tool.ToolPictureURL}"));
                btnReturnDelete.Content = "Delete Tool";
            }
        }

        private void ShowPicture(string imageFile)
        {
            try
            {
                if (string.IsNullOrEmpty(imageFile) || !File.Exists($"{Active.ProjectPath}/images/{imageFile}"))
                {
                    imageFile = "no_picture_tool.png";
                }
                BitmapImage toolImage = new BitmapImage(new Uri($"{Active.ProjectPath}/images/{imageFile}", UriKind.RelativeOrAbsolute));
                imgToolProfile.Stretch = Stretch.Fill;
                imgToolProfile.Source = toolImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DgRentedToolsByMe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Object selected = dgRentedToolsByMe.SelectedItem;
            if (selected != null)
            {
                Tool tool = (Tool)selected;
                ShowPicture(tool.ToolPictureURL.ToString());
                txbToolNameProfile.Text = tool.ToolName;
                txbToolConditionProfile.Text = tool.ToolCondition;
                txbPriceProfile.Text = tool.ToolPrice.ToString();
                txbDescriptionProfile.Text = tool.ToolDescription;
                //imgToolProfile.Source = new BitmapImage(new Uri($"{Active.ProjectPath}/images/{tool.ToolPictureURL}"));
                btnReturnDelete.Content = "Return Tool";
            }
        }

        private void BtnReturnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (btnReturnDelete.Content == "Return Tool")
            {
                DateTime dateTime = DateTime.Now;
                string actualEndDate = dateTime.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss");
            }
            else if(btnReturnDelete.Content == "Delete Tool")
            {

            }
            else
            {

            }
        }
    }
}
