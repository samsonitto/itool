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

namespace iTool
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void dgUsers_Loaded(object sender, RoutedEventArgs e)
        {
            dgUsers.ItemsSource = iTool.DB.GetToolsFromMysql();
            dgUsers.Columns[0].Visibility = Visibility.Collapsed;
            dgUsers.Columns[5].Visibility = Visibility.Collapsed;
            dgUsers.Columns[6].Visibility = Visibility.Collapsed;
        }
    }
}
