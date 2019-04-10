using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
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
using System.Drawing;
using System.IO;

namespace iTool
{

    public partial class RegisterWindow : Window
    {
        //PROPERTIES
        private List<string> payment = new List<string>() { "Invoice", "MasterCard", "Paypal", "VISA" };
        private  List<string> locations = new List<string>() { "Ähtäri", "Espoo", "Helsinki", "Jyväskylä", "Kuopio", "Kuusamo", "Lahti", "Lappeenranta", "Oulu", "Rauma", "Rovanniemi", "Savonlinna", "Seinäjoki", "Tampere", "Turku", "Vaasa", "Vantaa" };
        private string path;
        private string imgFile;

        //METHODS
        public RegisterWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }

        private void IniMyStuff()
        {
            cbPayment.ItemsSource = payment;
            cbLocation.ItemsSource = locations;
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
            
            imgProfile.Stretch = Stretch.Fill;
            Uri u = new Uri(dlg.FileName, UriKind.RelativeOrAbsolute);
            imgProfile.Source = new BitmapImage(new Uri(dlg.FileName, UriKind.RelativeOrAbsolute));
            string i = imgProfile.Source.ToString().Split('/')[imgProfile.Source.ToString().Split('/').Length - 1];
            //path = $@"F:\iTool\iTool\iTool\images\{i}";
            path = $@"images\{i}";
            if (File.Exists(path))
            {
                int x = 0;
                for (; File.Exists(path); )
                {
                    path = $@"images\{x}{i}";
                    //path = $@"F:\iTool\iTool\iTool\images\{x}{i}";
                    imgFile = $"{x}{i}";
                    x++;
                }
            }
            
            else
            {
                imgFile = path.Split('\\')[path.Split('\\').Length - 1];
            }

            // relaatiivinen polku images kansioon
            string relativePath = $"{Directory.GetParent(Environment.CurrentDirectory).Parent.FullName}\\{path}";

            // pulku valituun kuvatiedostoon
            string dirPath = $@"{System.IO.Path.GetDirectoryName(dlg.FileName)}\{System.IO.Path.GetFileName(dlg.FileName)}";
            System.IO.File.Copy(dirPath, relativePath, true);
            File.SetAttributes(relativePath, FileAttributes.Normal);

        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            if (txtAddEmail.Text.Length == 0)
            {
                txbError.Text = "Enter an email";
                txtAddEmail.Focus();
            }
            else if (!Regex.IsMatch(txtAddEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                txbError.Text = "Enter a valid email.";
                txtAddEmail.Focus();
            }
            else if (DB.EmailChecker().Contains(txtAddEmail.Text))
            {
                txbError.Text = "Email is already in use";
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
            else if (txtMobile.Text.Length < 10 || !int.TryParse(txtMobile.Text, out int num))
            {
                txbError.Text = "Enter valid mobile number";
                txtMobile.Focus();
            }
            else if (cbLocation.Text.Length == 0)
            {
                txbError.Text = "Enter your location";
                cbLocation.Focus();
            }
            else if (cbPayment.SelectedValue is null)
            {
                txbError.Text = "Choose the payment method";
                cbPayment.Focus();
            }
            else if (txtAddAddress.Text.Length == 0)
            {
                txbError.Text = "Enter your address";
                txtAddAddress.Focus();
            }
            //else if (string.IsNullOrEmpty(imgFile))
            //{
            //    imgFile = null;
            //}
            else
            {
                string firstname = txtFirstName.Text;
                string lastname = txtLastName.Text;
                string email = txtAddEmail.Text;
                string password = pwdCreatePassword.Password;
                string location = cbLocation.SelectedValue.ToString();
                string mobile = txtMobile.Text;
                string imgSource = imgProfile.Source.ToString();

                string address = txtAddAddress.Text;
                string payment = cbPayment.SelectedValue.ToString();
                if (pwdCreatePassword.Password.Length == 0)
                {
                    txbError.Text = "Enter password";
                    pwdCreatePassword.Focus();
                }
                else if (pwdConfirm.Password.Length == 0)
                {
                    txbError.Text = "Enter Confirm password";
                    pwdConfirm.Focus();
                }
                else if (pwdCreatePassword.Password != pwdConfirm.Password)
                {
                    txbError.Text = "Confirm password must be same as password";
                    pwdConfirm.Focus();
                }
                else
                {
                    txbError.Text = "";

                    MySqlConnection con = new MySqlConnection("SERVER=mysql.labranet.jamk.fi;DATABASE=M3156_3;UID=M3156;PASSWORD=Mn1GQ5TbFX7UI0tjH2Y4H2oWtcfs4zra");
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand($"Insert into user (userName,userSurname,userAddress,userEmail,userLocation,paymentMethod,userMobile,userPassword,userPicture) values('{firstname}','{lastname}','{address}','{email}','{location}','{payment}','{mobile}',MD5('{password}'),'{imgFile}')", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MainWindow mw = new MainWindow();
                    mw.txbMainError.Text = "You have Registered successfully\nYou can login now";
                    mw.Show();
                    this.Close();
                }
            }
        
        }
        public void Reset()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAddEmail.Text = "";
            pwdCreatePassword.Password = "";
            pwdConfirm.Password = "";
            txtMobile.Text = "";
            txtAddAddress.Text = "";
            cbLocation.SelectedValue = null;
            txtPic.Text = "";
            cbPayment.SelectedItem = null;
        }

        public void Fill()
        {
            Random rand = new Random();
            char[] abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            char[] c123 = "1234567890".ToCharArray();
            string fName = abc[rand.Next(abc.Length)].ToString().ToUpper();
            string lName = abc[rand.Next(abc.Length)].ToString().ToUpper();
            string eMail = abc[rand.Next(abc.Length)].ToString().ToLower();
            string pw = abc[rand.Next(abc.Length)].ToString().ToLower();
            string mobile = c123[rand.Next(c123.Length)].ToString();
            string address = abc[rand.Next(abc.Length)].ToString().ToUpper();
            string location = abc[rand.Next(abc.Length)].ToString().ToUpper();

            for (int i = 0; i < 5; i++)
            {
                eMail = $"{eMail}{abc[rand.Next(abc.Length)].ToString().ToLower()}";
            }

            for (int i = 0; i < 5; i++)
            {
                pw = $"{pw}{abc[rand.Next(abc.Length)].ToString().ToLower()}";
            }

            for (int i = 0; i < 5; i++)
            {
                fName = $"{fName}{abc[rand.Next(abc.Length)].ToString().ToLower()}";
            }

            for (int i = 0; i < 5; i++)
            {
                lName = $"{lName}{abc[rand.Next(abc.Length)].ToString().ToLower()}";
            }

            for (int i = 0; i < 9; i++)
            {
                mobile = $"{mobile}{c123[rand.Next(c123.Length)].ToString()}";
            }

            for (int i = 0; i < 5; i++)
            {
                address = $"{address}{abc[rand.Next(abc.Length)].ToString().ToLower()}";
            }

            for (int i = 0; i < 5; i++)
            {
                location = $"{location}{abc[rand.Next(abc.Length)].ToString().ToLower()}";
            }

            txtAddEmail.Text = $"{eMail}@gmail.com";
            pwdCreatePassword.Password = pw;
            pwdConfirm.Password = pw;
            txtFirstName.Text = fName;
            txtLastName.Text = lName;
            txtMobile.Text = mobile;
            txtAddAddress.Text = $"{address} {c123[rand.Next(c123.Length)].ToString()} {abc[rand.Next(abc.Length)].ToString().ToLower()} {c123[rand.Next(c123.Length)].ToString()}";
            cbLocation.SelectedValue = cbLocation.Items[rand.Next(cbLocation.Items.Count)];
            cbPayment.SelectedValue = cbPayment.Items[rand.Next(cbPayment.Items.Count)];
        }

        private void BtnFill_Click(object sender, RoutedEventArgs e)
        {
            Fill();
        }
    }
}
