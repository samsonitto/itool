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
using iTool;

namespace iTool
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        private List<Tool> tools;
        private List<string> locations = new List<string>();
        private List<string> categories = new List<string>();
        public MainPage()
        {
            InitializeComponent();
            IniMyStuff(); 
        }

        private void IniMyStuff()
        {
            //LUODAAN DATAGRID KAIKISSA SAATAVILLA OLEVISTA TYÖKALUISTA
            tools = DB.GetToolsFromMysql();
            dgTools.DataContext = tools;
            //dgTools.Columns[0].Visibility = Visibility.Collapsed;
            //dgTools.Columns[1].Visibility = Visibility.Collapsed;
            //dgTools.Columns[2].Visibility = Visibility.Collapsed;

            //LUODAAN SUODATIN COMBOBOXIT
            var location = tools.Select(t => t.ToolLocation).Distinct();
            locations.Add("All cities");
            foreach (var item in location)
            {
                locations.Add(item);
            }

            var category = tools.Select(c => c.ToolCategoryName).Distinct();
            categories.Add("All categories");
            foreach (var item in category)
            {
                categories.Add(item);
            }

            cbCityFilter.ItemsSource = locations;
            //cbCityFilter.SelectedIndex = 0;
            cbToolCategory.ItemsSource = categories;
            //cbToolCategory.SelectedIndex = 0;

            //ACTIVE USER IMAGE
            imgMainPageProfile.Source = Active.ImageSource;

            //ACTIVE USER NAME
            txtUsername.Text = $"{Active.FirstName} {Active.LastName}";
        }

        private void GoToProfile()
        {
            ProfileWindow profile = new ProfileWindow();
            profile.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GoToProfile();
        }

        private void DgTools_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Object selected = dgTools.SelectedItem;
            if(selected != null)
            {
                Tool tool = (Tool)selected;
                ShowPicture(tool.ToolPictureURL);
                txbToolName.Text = tool.ToolName;
                txbToolCondition.Text = tool.ToolCondition;
                txbPrice.Text = tool.ToolPrice.ToString();
                txbDescription.Text = tool.ToolDescription;

                User user = DB.GetToolOwnerFromMysql(tool.UserOwnerID);
                txbOwner.Text = user.FirstName + " " + user.LastName;
                txbNumber.Text = user.Mobile;
            }
        }

        private void CbCityFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filters();
        }

        private void CbToolCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filters();
        }

        private void Filters()
        {
            if (cbCityFilter.SelectedValue != null && cbToolCategory.SelectedValue != null)
            {
                string location = cbCityFilter.SelectedValue.ToString();
                string category = cbToolCategory.SelectedValue.ToString();

                if (category == "All categories" && location == "All cities")
                {
                    dgTools.ItemsSource = tools;
                }
                else if (category != "All categories" && location != "All cities")
                {
                    dgTools.ItemsSource = tools.Where(t => t.ToolCategoryName.Contains(category) && t.ToolLocation.Contains(location));
                }
                else if (location == "All cities" && cbToolCategory.SelectedValue.ToString() != "All categories")
                {
                    dgTools.ItemsSource = tools.Where(t => t.ToolCategoryName.Contains(category));
                }
                else
                {
                    dgTools.ItemsSource = tools.Where(t => t.ToolLocation.Contains(location));
                }
            }
        }

        private void ShowPicture(string imageFile)
        {
            try
            {
                if (string.IsNullOrEmpty(imageFile) || !File.Exists(imageFile))
                {
                    imageFile = "no_picture_tool.png";
                }
                BitmapImage toolImage = new BitmapImage(new Uri($"{Active.ProjectPath}/images/{imageFile}", UriKind.RelativeOrAbsolute));
                imgTool.Stretch = Stretch.Fill;
                imgTool.Source = toolImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ImgMainPageProfile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GoToProfile();
        }
    }
}
