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
            tools = DB.GetToolsFromMysql();
            dgTools.ItemsSource = tools;

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
            cbCityFilter.SelectedIndex = 0;
            cbToolCategory.ItemsSource = categories;
            cbToolCategory.SelectedIndex = 0;
            //USER IMAGE
            imgMainPageProfile.Source = Active.ImageSource;

            //USER NAME
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
            }
        }

        private void CbCityFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string location = cbCityFilter.SelectedValue.ToString();
            string category = cbToolCategory.SelectedValue.ToString();
            
            else if (category == "All categories" && location == "All cities")
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

        private void CbToolCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string category = cbToolCategory.SelectedValue.ToString();
            string location = cbCityFilter.SelectedValue.ToString();
            if (category == "All categories" && location == "All cities")
            {
                dgTools.ItemsSource = tools;
            }
            else if (category == "All categories" && location != "All cities")
            {
                dgTools.ItemsSource = tools.Where(t => t.ToolLocation.Contains(location));
            }
            else
            {
                dgTools.ItemsSource = tools.Where(t => t.ToolCategoryName.Contains(category));
            }
        }

        //private void Filters()
        //{
        //    string location = cbCityFilter.SelectedValue.ToString();
        //    string category = cbToolCategory.SelectedValue.ToString();
        //    if (string.IsNullOrEmpty(location) && string.IsNullOrEmpty(category))
        //    {
        //        dgTools.ItemsSource = tools;
        //    }
        //    else
        //    {
        //        if (string.IsNullOrEmpty(location) && !string.IsNullOrEmpty(category))
        //        {
        //            dgTools.ItemsSource = tools.Where(t => t.ToolCategoryName.Contains(category));
        //        }
        //        else if (!string.IsNullOrEmpty(location) && string.IsNullOrEmpty(category))
        //        {
        //            dgTools.ItemsSource = tools.Where(t => t.ToolLocation.Contains(location));
        //        }
        //        else
        //        {
        //            dgTools.ItemsSource = tools.Where(t => t.ToolLocation.Contains(location) && t.ToolCategoryName.Contains(category));
        //        }
        //    }
        //}

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
