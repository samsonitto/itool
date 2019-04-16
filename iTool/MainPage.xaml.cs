using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using iTool;
using System.Threading;

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
        private float price;
        private string toolName;
        
        public MainPage()
        {
            InitializeComponent();
            IniMyStuff(); 
        }

        #region METHODS
        private void IniMyStuff()
        {
            //LUODAAN DATAGRID KAIKISSA SAATAVILLA OLEVISTA TYÖKALUISTA
            tools = DB.GetToolsFromMysql();
            dgTools.ItemsSource = tools;

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
            cbToolCategory.ItemsSource = categories;

            //ACTIVE USER IMAGE
            imgMainPageProfile.Source = Active.ImageSource;
            //imgMainPageProfile.Source = new BitmapImage(new Uri(@"https://student.labranet.jamk.fi/~M3156/iTool/images/" + Active.ImageFileName, UriKind.RelativeOrAbsolute));

            //ACTIVE USER NAME
            txtUsername.Text = $"{Active.FirstName} {Active.LastName}";

            //TOOL IMAGE
            //imgTool.Source = new BitmapImage(new Uri(@"F:\iTool\iTool\iTool\images\no_picture_tool.png", UriKind.RelativeOrAbsolute));
            imgTool.Source = new BitmapImage(new Uri(@"images\no_picture_tool.png", UriKind.RelativeOrAbsolute));
        }

        private void GoToProfile()
        {
            Active.profile = new ProfileWindow();
            Active.profile.Show();
            this.Close();
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
                    txbMessages.Text = "Here you can see all tools that are available for rent. Use filters or the search bar to find a tool for you.";
                }
                else if (category != "All categories" && location != "All cities")
                {
                    dgTools.ItemsSource = tools.Where(t => t.ToolCategoryName.Contains(category) && t.ToolLocation.Contains(location));
                    txbMessages.Text = $"Here you can see tools, filtered by location: {cbCityFilter.SelectedValue.ToString()} and category: {cbToolCategory.SelectedValue.ToString()}.";
                }
                else if (location == "All cities" && cbToolCategory.SelectedValue.ToString() != "All categories")
                {
                    dgTools.ItemsSource = tools.Where(t => t.ToolCategoryName.Contains(category));
                    txbMessages.Text = $"Here you can see tools, filtered by category: {cbToolCategory.SelectedValue.ToString()}.";
                }
                else
                {
                    dgTools.ItemsSource = tools.Where(t => t.ToolLocation.Contains(location));
                    txbMessages.Text = $"Here you can see tools, filtered by location: {cbCityFilter.SelectedValue.ToString()}.";
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
        #endregion

        #region EVENTHANDLERS
        private void DgTools_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Object selected = dgTools.SelectedItem;
            if(selected != null)
            {
                try
                {
                    Tool tool = (Tool)selected;
                    ShowPicture(tool.ToolPictureURL);
                    txbToolName.Text = tool.ToolName;
                    toolName = tool.ToolName;
                    txbToolCondition.Text = tool.ToolCondition;
                    txbPrice.Text = tool.ToolPrice.ToString();
                    price = tool.ToolPrice;
                    txbDescription.Text = tool.ToolDescription;
                    imgTool.Source = new BitmapImage(new Uri($"{Active.ProjectPath}/images/{tool.ToolPictureURL}", UriKind.RelativeOrAbsolute));
                    Active.ToolID = tool.ToolID;
                    Active.OwnerID = tool.UserOwnerID;

                    User user = DB.GetToolOwnerFromMysql(tool.UserOwnerID);
                    txbOwner.Text = user.FirstName + " " + user.LastName;
                    txbNumber.Text = user.Mobile;

                    txbMessages.Text = $"You are viewing a tool: {toolName}, click Rent to rent a tool.";

                    if (!string.IsNullOrEmpty(txtDays.Text))
                    {
                        if (!int.TryParse(txtDays.Text, out int num))
                        {
                            txbMessages.Text = "Wrong input, numbers only.";
                        }
                        else
                        {
                            float totalPrice = price * int.Parse(txtDays.Text);
                            txbTotalPrice.Text = $"{totalPrice.ToString()} €";
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
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

        private void ImgMainPageProfile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GoToProfile();
        }

        private void TxtDays_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (!int.TryParse(txtDays.Text, out int num) && !string.IsNullOrEmpty(txtDays.Text))
                {
                    txbMessages.Text = "Wrong input, numbers only.";
                }
                else if (string.IsNullOrEmpty(txtDays.Text))
                {
                    txbTotalPrice.Text = "";
                    txbMessages.Text = "Enter amount of days to see the total price of the transaction.";
                }
                else
                {
                    float totalPrice = price * int.Parse(txtDays.Text);
                    txbTotalPrice.Text = $"{totalPrice.ToString()} €";
                    txbMessages.Text = $"Total price of the transaction is {totalPrice.ToString()} €";
                }
            }
            catch
            {

                throw;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtDays.Text) && int.TryParse(txtDays.Text, out int num))
                {
                    DateTime dateTime = DateTime.Now;
                    DateTime addDays = dateTime.AddDays(int.Parse(txtDays.Text));
                    string startDate = dateTime.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss");
                    string plannedEndDate = addDays.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss");
                    DB.AddTransactionToMysql(startDate, plannedEndDate, Active.OwnerID, Active.UserID, Active.ToolID);
                    tools = DB.GetToolsFromMysql();
                    dgTools.ItemsSource = tools;
                    txbMessages.Text = $"You have rented {toolName}";
                }
                else if (float.TryParse(txtDays.Text, out float fnum))
                {
                    txtDays.Focus();
                    txbMessages.Text = $"\"Days\" field can't be a decimal number";
                }
                else
                {
                    txtDays.Focus();
                    txbMessages.Text = $"\"Days\" field can't be empty or not a number";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DgTools_AutoGeneratedColumns(object sender, EventArgs e)
        {
            //dgTools.Columns[0].Visibility = Visibility.Collapsed;
            dgTools.Columns[1].Visibility = Visibility.Collapsed;
            dgTools.Columns[2].Visibility = Visibility.Collapsed;
            dgTools.Columns[3].Visibility = Visibility.Collapsed;
            dgTools.Columns[10].Visibility = Visibility.Collapsed;

            dgTools.Columns[4].Header = "Name";
            dgTools.Columns[5].Header = "Condition";
            dgTools.Columns[6].Header = "Description";
            dgTools.Columns[7].Header = "Price";
            dgTools.Columns[8].Header = "Category";
            dgTools.Columns[9].Header = "Location";
        }

        private void BtnSearchTools_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSearchBar.Text))
                {
                    dgTools.ItemsSource = tools.Where(t => t.ToolName.ToLower().Contains(txtSearchBar.Text.ToLower()));
                    txbMessages.Text = $"Here you can see all tools that have {txtSearchBar.Text} in their name and are available for rent.";
                }
                else
                {
                    txbMessages.Text = "Search bar can't be empty, type a name of a tool or part of it.";
                    txtSearchBar.Focus();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void TxtSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearchBar.Text == "")
            {
                dgTools.ItemsSource = tools;
                txbMessages.Text = "Here you can see all tools that are available for rent. Use filters or the search bar to find a tool for you.";
            }
        }

        private void BtnComment_Click(object sender, RoutedEventArgs e)
        {
            CommentWindow comment = new CommentWindow();
            comment.ShowDialog();
        }
        #endregion
    }
}
