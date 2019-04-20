using System;
using System.Collections.Generic;
using System.IO;
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
        #region PROPERTIES
        private List<string> payment = new List<string>() { "Invoice", "MasterCard", "Paypal", "VISA" };
        private List<string> locations = new List<string>() { "Ähtäri", "Espoo", "Helsinki", "Jyväskylä", "Kuopio", "Kuusamo", "Lahti", "Lappeenranta", "Oulu", "Rauma", "Rovanniemi", "Savonlinna", "Seinäjoki", "Tampere", "Turku", "Vaasa", "Vantaa" };
        #endregion

        #region METHODS
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
        #endregion

        #region EVENTHANDLERS
        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            User activeUser = DB.GetUserFromMysqlWhere($"userID = {Active.UserID}"); //LUODAAN AKTIIVIKÄYTTÄJÄSTÄ OLIO
            User confirmPwd = DB.GetUserFromMysqlWhere($"userPassword = MD5('{pwdCurrentPassword.Password}')"); //HAETAAN KYTTÄJÄ, JONKA SALASANA VASTAA CURRENT PASSWORD KENTÄN SISÄLTÖÄ

            List<string> attributes = new List<string>(); //LUODAAN SQL QUERRY:N LUONTIA VARTEN APULISTA

            string emailFormat = @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"; //S-POSTI MUOTOSTRINGI

            try
            {
                //TARKISTETAAN ETTÄ KAIKKI KENTÄT ON OIKEIN TÄYTETTY
                if (!string.IsNullOrEmpty(txtNewEmail.Text) && !Regex.IsMatch(txtNewEmail.Text, emailFormat))
                {
                    txbNewError.Text = "Enter a valid email.";
                    txtNewEmail.Focus();
                }
                else if (txtNewEmail.Text != txtConfirmNewEmail.Text)
                {
                    txbNewError.Text = $"You must confirm your new Email";
                    txtConfirmNewEmail.Focus();
                }
                else if (!string.IsNullOrEmpty(pwdNewPassword.Password) && pwdNewPassword.Password != pwdConfirmNewPassword.Password)
                {
                    txbNewError.Text = "Confirm password must be same as password";
                    pwdConfirmNewPassword.Focus();
                }
                else if (!string.IsNullOrEmpty(txtNewMobile.Text) && txtNewMobile.Text.Length < 10 || !string.IsNullOrEmpty(txtNewMobile.Text) && !int.TryParse(txtNewMobile.Text, out int i))
                {
                    txbNewError.Text = "Wrong mobile number format!";
                    txtNewMobile.Focus();
                }
                else if (pwdNewPassword.Password == pwdCurrentPassword.Password && !string.IsNullOrEmpty(pwdNewPassword.Password))
                {
                    txbNewError.Text = "New password cannot be the same as the old one!";
                    pwdNewPassword.Focus();
                }
                else if (string.IsNullOrEmpty(txtNewEmail.Text) && string.IsNullOrEmpty(pwdNewPassword.Password) && string.IsNullOrEmpty(txtNewMobile.Text) && string.IsNullOrEmpty(txtNewAddress.Text) && cbNewLocation.SelectedValue == null && cbNewPayment.SelectedValue == null && string.IsNullOrEmpty(txtNewPic.Text))
                {
                    txbNewError.Text = "Nothing to update...";
                }
                else if (confirmPwd.Password != activeUser.Password)
                {
                    txbNewError.Text = "Wrong password! Enter your current password";
                    pwdCurrentPassword.Focus();
                }
                else
                {
                    string sql = "SET";
                    string message = "You have updated your";

                    string email = txtNewEmail.Text;
                    string password = pwdNewPassword.Password;
                    string mobile = txtNewMobile.Text;
                    string address = txtNewAddress.Text;
                    string location = null;
                    string payment = null;
                    if (cbNewLocation.SelectedValue != null) //JOS UUSI SIJAINTI ON VALITTU
                    {
                        location = cbNewLocation.SelectedValue.ToString();
                    }
                    if (cbNewPayment.SelectedValue != null) //JOS UUSI MAKSUTAPA ON VALITTU
                    {
                        payment = cbNewPayment.SelectedValue.ToString();
                    }

                    bool newPassword = false;

                    if (!string.IsNullOrEmpty(email)) //JOS UUSI S-POSTI ON MÄÄRITETTY
                    {
                        attributes.Add($" userEmail = '{email}',"); //LISÄTÄÄN LISTALLE
                        message = message + " e-mail,"; //RAKENNETAAN VIESTI
                    }
                        
                    if (!string.IsNullOrEmpty(password)) //JOS UUSI SALASANA ON MÄÄRITETTY
                    {
                        attributes.Add($" userPassword = MD5('{password}'),"); //LISÄTÄÄN LISTALLE
                        newPassword = true; //RAKENNETAAN VIESTI
                    }
                    if (!string.IsNullOrEmpty(mobile)) //JOS UUSI PUHNRO ON MÄÄRITETTY
                    {
                        attributes.Add($" userMobile = '{mobile}',"); //LISÄTÄÄN LISTALLE
                        message = message + " mobile,"; //RAKENNETAAN VIESTI
                    }
                        
                    if (!string.IsNullOrEmpty(address)) //JOS UUSI OSOITE MÄÄRITETTY
                    {
                        attributes.Add($" userAddress = '{address}',"); //LISÄTÄÄN LISTALLE
                        message = message + " address,"; //RAKENNETAAN VIESTI
                    }
                        
                    if (!string.IsNullOrEmpty(location))
                    {
                        attributes.Add($" userLocation = '{location}',"); //LISÄTÄÄN LISTALLE
                        message = message + " location,"; //RAKENNETAAN VIESTI
                    }
                        
                    if (!string.IsNullOrEmpty(payment))
                    {
                        attributes.Add($" paymentMethod = '{payment}',"); //LISÄTÄÄN LISTALLE
                        message = message + " payment,"; //RAKENNETAAN VIESTI
                    }
                        
                    if (!string.IsNullOrEmpty(Active.imgFile)) //JOS UUSI PROFIILIKUVA ON VALITTU
                    {
                        attributes.Add($" userPicture = '{Active.imgFile}',"); //LISÄTÄÄN LISTALLE
                        message = message + " profile image,"; //RAKENNETAAN VIESTI
                    }
                        
                    foreach (string item in attributes) //REKENNETAAN SQL QUERRY STRINGI
                    {
                        sql = sql + item;
                    }

                    message = message.Remove(message.Length - 1, 1); //POSTETAAN VIIMEINEN PILKKU VIESTISTÄ

                    sql = sql.Remove(sql.Length - 1, 1); //POISTETAAN VIIMEINEN PILKKU SQL QUERRYSTÄ

                    var result = MessageBox.Show($"Do you really want to update {message}?", "iTool: Update Profile", MessageBoxButton.YesNo); //YES/NO VARMISTUSIKKUNA

                    if (result == MessageBoxResult.Yes) //JOS ON VALITTU 'YES' VARMISTUSIKKUNASSA
                    {
                        DB.UpdateUserToMysql(sql); //PÄIVITETÄÄN KÄYTTÄJÄN TIEDOT TIETOKANNASSA



                        if (!string.IsNullOrEmpty(Active.imgFile)) //JOS UUSI KUVA ON VALITTU, KOPIOIDAAN UUSI KUVATIEDOSTO 'images' KANSIOON
                        {
                            System.IO.File.Copy(Active.dirPath, Active.relativePath, true);
                            File.SetAttributes(Active.relativePath, FileAttributes.Normal);
                            Active.ImageSource = new BitmapImage(new Uri($"{Active.ProjectPath}/images/{Active.imgFile}")); //VAIHDETAAN AKTIIVIKÄYTTÄJÄN AKTIIVIKUVA
                        }

                        if (newPassword) //JOS SALASANA ON VAIHDETTU, KIRJAUDUTAAN ULOS
                        {
                            Active.main = new MainWindow();
                            Active.main.txbMainError.Text = "You have changed your password \nLog in using your new password";
                            Active.main.Show();
                            this.Close();
                            Active.profile.Close();
                        }

                        Active.profile.imgUserProfile.Source = Active.ImageSource;
                        Active.profile.txbMessagesProfile.Text = message; //ESITETÄÄN VIESTI KÄYTTÄJÄLLE
                        this.Close(); 
                    }
                }
            }
            catch //(Exception ex)
            {
                throw;
                //MessageBox.Show(ex.Message);
            }
        }

        private void BtnNewPicBrowse_Click(object sender, RoutedEventArgs e)
        {
            Active.BrowseImage(imgEditProfile, txtNewPic);
        }
        #endregion
    }
}
