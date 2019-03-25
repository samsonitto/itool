using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private List<string> payment = new List<string>() { "Paypal", "MasterCard", "VISA", "Lasku"};
        private List<User> users;

        public RegisterWindow()
        {
            InitializeComponent();
            cbPayment.ItemsSource = payment;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Select a profile picture";
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "All supported graphics |*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
            dlg.RestoreDirectory = true;
            Nullable<bool> result = dlg.ShowDialog(); // näyttää dialogin
            if (result == true)
            {
                txtPic.Text = dlg.FileName;
            }
            if (string.IsNullOrEmpty(txtPic.Text))
            {
                dlg.FileName = "images/no_picture.png";
            }
            //BitmapImage bitmap = new BitmapImage();
            //bitmap.BeginInit();
            //bitmap.UriSource = new Uri(dlg.FileName, UriKind.RelativeOrAbsolute);
            //bitmap.EndInit();
            imgProfile.Stretch = Stretch.Fill;
            imgProfile.Source = new BitmapImage(new Uri(dlg.FileName, UriKind.RelativeOrAbsolute));
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            if (txtAddEmail.Text.Length == 0)
            {
                txbError.Text = "Enter an email.";
                txtAddEmail.Focus();
            }
            else if (!Regex.IsMatch(txtAddEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                txbError.Text = "Enter a valid email.";
                txtAddEmail.Focus();
            }
            else if (txtFirstName.Text.Length == 0)
            {
                txbError.Text = "Enter your first name";
                txtFirstName.Focus();
            }
            else if (txtLastName.Text.Length == 0)
            {
                txbError.Text = "Enter your last name";
                txtLastName.Focus();
            }
            else if (txtMobile.Text.Length < 10)
            {
                txbError.Text = "Enter valid mobile number";
                txtMobile.Focus();
            }
            else if (txtAddLocation.Text.Length == 0)
            {
                txbError.Text = "Enter your location";
                txtAddLocation.Focus();
            }
            else if (cbPayment == null)
            {
                txbError.Text = "Choose the payment method";
                cbPayment.Focus();
            }
            else if (txtAddAddress.Text.Length == 0)
            {
                txbError.Text = "Enter your address";
                txtAddAddress.Focus();
            }
            else
            {
                string firstname = txtFirstName.Text;
                string lastname = txtLastName.Text;
                string email = txtAddEmail.Text;
                string password = pwdCreatePassword.Password;
                string location = txtAddLocation.Text;
                int mobile = int.Parse(txtMobile.Text);
                string address = txtAddAddress.Text;
                if (pwdCreatePassword.Password.Length == 0)
                {
                    txbError.Text = "Enter password.";
                    pwdCreatePassword.Focus();
                }
                else if (pwdConfirm.Password.Length == 0)
                {
                    txbError.Text = "Enter Confirm password.";
                    pwdConfirm.Focus();
                }
                else if (pwdCreatePassword.Password != pwdConfirm.Password)
                {
                    txbError.Text = "Confirm password must be same as password.";
                    pwdConfirm.Focus();
                }
                else
                {
                    txbError.Text = "";

                    SqlConnection con = new SqlConnection("Data Source=mysql.labranet.jamk.fi;Initial Catalog=M3156_3;User ID=M3156;Password=Mn1GQ5TbFX7UI0tjH2Y4H2oWtcfs4zra");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into user (userName,userSurname,userAddress,userEmail,userLocation,paymentMethod,userMobile,userPassword,userPicture) values('" + firstname + "','" + lastname + "','" + address + "','" + email + "','" + password + "')", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    txbError.Text = "You have Registered successfully.";
                    //Reset();
                }
                //users.Add(new User() { UserID = 1, Email = txtAddEmail.Text, Password = pwdCreatePassword.Password, FirstName = txtFirstName.Text, LastName = txtLastName.Text, Mobile = int.Parse(txtMobile.Text), Address = txtAddAddress.Text, Location = txtAddLocation.Text, PaymentMethod = cbPayment.SelectedValue.ToString(), PictureURL = txtPic.Text.Split('\\')[txtPic.Text.Split('\\').Length - 1] });
                //ShowUser user = new ShowUser();
                //user.Show();
                //user.dgUsers.ItemsSource = users;
            }
        }
    }
}
