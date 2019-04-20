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
        #region PROPERTIES
        private List<string> payment = new List<string>() { "Invoice", "MasterCard", "Paypal", "VISA" };
        private  List<string> locations = new List<string>() { "Ähtäri", "Espoo", "Helsinki", "Jyväskylä", "Kuopio", "Kuusamo", "Lahti", "Lappeenranta", "Oulu", "Rauma", "Rovanniemi", "Savonlinna", "Seinäjoki", "Tampere", "Turku", "Vaasa", "Vantaa" };
        private string path;
        private string imgFile;
        private string relativePath;
        private string dirPath;
        #endregion

        #region METHODS
        public RegisterWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }

        private void IniMyStuff()
        {
            //KOMBOBOKSIT
            cbPayment.ItemsSource = payment;
            cbLocation.ItemsSource = locations;
        }

        private void Register()
        {
            //REKSTRÖINTITAPAHTUMA
            try
            {
                //TARKISTETAAN ONKO KAIKKI KENTÄT OIKEIN TÄYTETTY
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

                    //TARKISTETAAN ETTÄ SALASANAKENTÄT ON OIKEIN TÄYTETTY
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

                        //LISÄTÄÄN UUSI KÄYTTÄJÄ TIETOKANTAAN
                        string connStr = DB.GetConnectionString();
                        MySqlConnection con = new MySqlConnection(connStr);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand($"Insert into user (userName,userSurname,userAddress,userEmail,userLocation,paymentMethod,userMobile,userPassword,userPicture) values('{firstname}','{lastname}','{address}','{email}','{location}','{payment}','{mobile}',MD5('{password}'),'{Active.imgFile}')", con);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();

                        if (!string.IsNullOrEmpty(txtPic.Text)) //KUVAA ON VALITTU, KOPIOIDAAN KUVA 'IMAGES' KANSIOON
                        {
                            System.IO.File.Copy(Active.dirPath, Active.relativePath, true);
                            File.SetAttributes(Active.relativePath, FileAttributes.Normal);
                        }

                        Active.imgFile = null;

                        MainWindow mw = new MainWindow();
                        mw.txbMainError.Text = "You have Registered successfully\nYou can login now";
                        mw.Show();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void Reset()
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

        private void Fill()
        {
            //TÄYTETÄÄN KENTÄT SATUNNAISILLA TIEDOILLA (TESTAAMISTA VARTEN)
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region EVENTHANDLERS
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            //PALATAAN TAKAISIN LOGIN IKKUNAAN
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            //SELATAAN KUVA
            Active.BrowseImage(imgProfile, txtPic);
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            Register();
        }

        private void BtnFill_Click(object sender, RoutedEventArgs e)
        {
            Fill();
        }
        #endregion
    }
}
