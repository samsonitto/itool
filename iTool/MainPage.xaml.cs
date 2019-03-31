using System;
using System.Collections.Generic;
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
        public MainPage()
        {
            InitializeComponent();
            IniMyStuff(); 
        }

        private void IniMyStuff()
        {
            tools = DB.GetToolsFromMysql();
            //USER IMAGE
            imgMainPageProfile.Source = Active.ImageSource;

            //USER NAME
            txtUsername.Text = $"{Active.FirstName} {Active.LastName}";
        }
        private void dgTools_Loaded(object sender, RoutedEventArgs e)
        {
            dgTools.ItemsSource = DB.GetToolsFromMysql();
            dgTools.Columns[0].Visibility = Visibility.Collapsed;
            dgTools.Columns[1].Visibility = Visibility.Collapsed;
            dgTools.Columns[2].Visibility = Visibility.Collapsed;
            dgTools.Columns[3].Visibility = Visibility.Collapsed;
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
    }


}
