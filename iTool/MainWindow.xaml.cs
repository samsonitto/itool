using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using iTool;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;
using System.IO;
using System.Net;

namespace iTool
{
    
    public partial class MainWindow : Window
    {
        #region METHODS
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region EVENTHANDLERS
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            //AVATAAAN REKISTRÖINTI-IKKUNA
            RegisterWindow register = new RegisterWindow();
            register.Show();
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //KIRJAUDUTAAN SISÄÄN
            try
            {
                //TARKISTETAAN ONKO ANNETTU OIKEAT TUNNUKSET
                if (txtEmail.Text.Length == 0) //JOS S-POSTIKENTTÄ ON TYHJÄ
                {
                    txbMainError.Text = "Enter an email.";
                    txtEmail.Focus();
                }
                else if (!Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$")) //JOS S-POSTI ON VÄÄRÄSSÄ MUODOSSA
                {
                    txbMainError.Text = "Enter a valid email.";
                    txbMainError.Focus();
                }
                else
                {
                    string email = txtEmail.Text;
                    string password = pwdPassword.Password;
                    string connStr = DB.GetConnectionString();
                    MySqlConnection con = new MySqlConnection(connStr);
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand($"Select * from user where userEmail='{email}' and userPassword=MD5('{password}')", con); //HAETAAN KÄYTTÄJÄ TIETOKANNASTA JOLLA SYÖTETTY S-POSTI JA SALASANA KOHTAA
                    cmd.CommandType = CommandType.Text;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(); //LUODAAN MYSQL DATA ADAPTER
                    adapter.SelectCommand = cmd;
                    DataSet dataSet = new DataSet(); //LUODAAN DATASET
                    adapter.Fill(dataSet); //TÄYTETÄÄN DATASET ADAPTERIA KÄYTTÄEN
                    if (dataSet.Tables[0].Rows.Count > 0) //JOS KÄYTTÄJÄ ON LÖYTYNYT JA ON SIIRRETTY DATASETIIN
                    {
                        Active.UserID = int.Parse(dataSet.Tables[0].Rows[0]["userID"].ToString()); //MÄÄRITETÄÄN AKTIIVIKÄYTTÄJÄN ID
                        Active.ImagePath = $"{Active.ProjectPath}/images/{dataSet.Tables[0].Rows[0]["userPicture"].ToString()}"; //MÄÄRITETÄÄN AKTIIVIKÄYTTÄJÄN PROFIILIKUVA
                        Active.FirstName = dataSet.Tables[0].Rows[0]["userName"].ToString(); //MÄÄRITETÄÄN AKTIIVIKÄYTTÄJÄN ETUNIMI
                        Active.LastName = dataSet.Tables[0].Rows[0]["userSurname"].ToString(); //MÄÄRITETÄÄN AKTIIVIKÄYTTÄJÄN SUKUNIMI
                        Active.ImageFileName = dataSet.Tables[0].Rows[0]["userPicture"].ToString(); //MÄÄRITETÄÄN AKTIIVIKÄYTTÄJÄN KUVATIEDOSTON NIMI

                        if (string.IsNullOrEmpty(Active.ImageFileName)) //JOS KUVATIEDOSTON NIMI ON TYHJÄ TAI NULL
                        {
                            Active.ImageSource = new BitmapImage(new Uri($"{Active.ProjectPath}/images/no_picture.png", UriKind.RelativeOrAbsolute));
                        }
                        else //JOS KUVATIEDOSTON NIMI EI OLE TYHJÄ
                        {
                            Active.ImageSource = new BitmapImage(new Uri(Active.ImagePath, UriKind.RelativeOrAbsolute));
                        }

                        MainPage main = new MainPage(); //LUODAAN MAIN IKKUNA
                        main.Show(); //NÄYTETÄÄN MAIN IKKUNA
                        this.Close(); //SULJETAAN LOGIN IKKUNA
                    }
                    else //JOS JOKO S-POSTI TAI SALASANA ON SYÖTETTY VÄÄRIN
                    {
                        txbMainError.Text = "Sorry! Please enter existing emailid/password.";
                    }
                    con.Close(); //SULJETAAN YHTEYS
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        #endregion
    }
}
