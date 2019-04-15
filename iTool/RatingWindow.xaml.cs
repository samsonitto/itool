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
    /// Interaction logic for RatingWindow.xaml
    /// </summary>
    public partial class RatingWindow : Window
    {
        private int counter = 1000;
        public int ratedID;
        public int transactionID;
        public string ratedName;

        public RatingWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }

        private void IniMyStuff()
        {

        }

        private void BtnGiveRating_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string rating = txtRating.Text;
                string feedback = txtRatingComments.Text;

                if (string.IsNullOrEmpty(rating))
                    lblMessagesRating.Content = "Input rating";
                else if (!int.TryParse(rating, out int num))
                    lblMessagesRating.Content = "Not a number";
                else if (int.Parse(rating) < 1 || int.Parse(rating) > 5)
                    lblMessagesRating.Content = "Input 1-5 number to rate";
                
                else
                {
                    DB.AddRatingToMysql(int.Parse(rating), feedback, Active.UserID, ratedID, transactionID);
                    Active.profile.txbMessagesProfile.Text = $"You have rated {ratedName}";
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TxtRatingComments_TextChanged(object sender, TextChangedEventArgs e)
        {
            string input = txtRatingComments.Text;
            int c = counter - input.Length;
            lblCharCount.Content = $"{c}";
        }
    }
}
