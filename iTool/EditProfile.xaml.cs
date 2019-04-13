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
        public EditProfile()
        {
            InitializeComponent();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            User activeUser = DB.GetUserFromMysqlWhere($"userID = {Active.UserID}");
            User confirmPwd = DB.GetUserFromMysqlWhere($"userPassword = MD5('{pwdCurrentPassword.Password}')");
            //string pwd = Active.ConvertStringtoMD5("samson");

            string emailFormat = @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";

            MD5 md5 = MD5.Create();

            if (!string.IsNullOrEmpty(txtNewAddress.Text) && !Regex.IsMatch(txtNewEmail.Text, emailFormat))
            {
                txbNewError.Text = "Enter a valid email.";
                txtNewAddress.Focus();
            }
            else if (!string.IsNullOrEmpty(txtConfirmNewEmail.Text) && txtNewEmail.Text != txtConfirmNewEmail.Text)
            {
                txbNewError.Text = $"You must confirm your new Email";
                txtNewAddress.Focus();
            }
            else if (!string.IsNullOrEmpty(pwdNewPassword.Password) && !string.IsNullOrEmpty(pwdConfirmNewPassword.Password) && pwdNewPassword.Password != pwdConfirmNewPassword.Password)
            {
                txbNewError.Text = "Confirm password must be same as password";
                pwdConfirmNewPassword.Focus();
            }
            else if (confirmPwd.Password != activeUser.Password)
            {
                txbNewError.Text = "Wrong password! Enter your current password";
                pwdCurrentPassword.Focus();
            }
        }
    }
}
