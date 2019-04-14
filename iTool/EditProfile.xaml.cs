using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for EditProfile.xaml
    /// </summary>
    public partial class EditProfile : Window
    {
        private List<string> payment = new List<string>() { "Invoice", "MasterCard", "Paypal", "VISA" };
        private List<string> locations = new List<string>() { "Ähtäri", "Espoo", "Helsinki", "Jyväskylä", "Kuopio", "Kuusamo", "Lahti", "Lappeenranta", "Oulu", "Rauma", "Rovanniemi", "Savonlinna", "Seinäjoki", "Tampere", "Turku", "Vaasa", "Vantaa" };

        public EditProfile()
        {
            InitializeComponent();
            IniMyStuff();
        }

        private void IniMyStuff()
        {
            imgEditProfile.Source = Active.ImageSource;
            cbNewLocation.ItemsSource = locations;
            cbNewPayment.ItemsSource = payment;
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            User activeUser = DB.GetUserFromMysqlWhere($"userID = {Active.UserID}");
            User confirmPwd = DB.GetUserFromMysqlWhere($"userPassword = MD5('{pwdCurrentPassword.Password}')");

            List<string> attributes = new List<string>();

            string emailFormat = @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";

            if (!string.IsNullOrEmpty(txtNewEmail.Text) && !Regex.IsMatch(txtNewEmail.Text, emailFormat))
            {
                txbNewError.Text = "Enter a valid email.";
                txtNewEmail.Focus();
            }
            else if (!string.IsNullOrEmpty(txtConfirmNewEmail.Text) && txtNewEmail.Text != txtConfirmNewEmail.Text)
            {
                txbNewError.Text = $"You must confirm your new Email";
                txtConfirmNewEmail.Focus();
            }
            else if (!string.IsNullOrEmpty(pwdNewPassword.Password) && !string.IsNullOrEmpty(pwdConfirmNewPassword.Password) && pwdNewPassword.Password != pwdConfirmNewPassword.Password)
            {
                txbNewError.Text = "Confirm password must be same as password";
                pwdConfirmNewPassword.Focus();
            }
            else if (!string.IsNullOrEmpty(txtNewMobile.Text) && txtNewMobile.Text.Length < 10 && !int.TryParse(txtNewMobile.Text, out int i))
            {
                txbNewError.Text = "Wrong mobile number format!";
                txtNewMobile.Focus();
            }
            else if (pwdNewPassword.Password == pwdCurrentPassword.Password)
            {
                txbNewError.Text = "New password cannot be the same as the old one!";
                pwdNewPassword.Focus();
            }
            else if (confirmPwd.Password != activeUser.Password)
            {
                txbNewError.Text = "Wrong password! Enter your current password";
                pwdCurrentPassword.Focus();
            }
            else
            {
                string sql = "SET";

                string email = txtNewEmail.Text;
                string password = pwdNewPassword.Password;
                string mobile = txtNewMobile.Text;
                string address = txtNewAddress.Text;
                string location = cbNewLocation.SelectedValue.ToString();
                string payment = cbNewPayment.SelectedValue.ToString();

                if (!string.IsNullOrEmpty(email))
                    attributes.Add($" userEmail = '{email}',");
                if (!string.IsNullOrEmpty(password))
                    attributes.Add($" userPassword = MD5('{password}'),");
                if (!string.IsNullOrEmpty(mobile))
                    attributes.Add($" userMobile = '{mobile}',");
                if (!string.IsNullOrEmpty(address))
                    attributes.Add($" userAddress = '{address}',");
                if (!string.IsNullOrEmpty(location))
                    attributes.Add($" userLocation = '{location}',");
                if (!string.IsNullOrEmpty(payment))
                    attributes.Add($" paymentMethod = '{payment}',");
                if (!string.IsNullOrEmpty(Active.imgFile))
                    attributes.Add($" userPicture = '{Active.imgFile}',");

                foreach (string item in attributes)
                {
                    sql = sql + item;
                }

                sql = sql.Remove(sql.Length - 1, 1);
                DB.UpdateUserToMysql(sql);
            }
        }

        private void BtnNewPicBrowse_Click(object sender, RoutedEventArgs e)
        {
            Active.BrowseImage(imgEditProfile, txtNewPic);
        }
    }
}
