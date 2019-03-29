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

namespace iTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int activeUserID;
        public static string activeUserImage;
        public static BitmapImage bi;
        public MainWindow()
        {
            InitializeComponent();

        }
        MainPage main = new MainPage();
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow register = new RegisterWindow();
            register.Show();
            this.Close();
            
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmail.Text.Length == 0)
            {
                txbMainError.Text = "Enter an email.";
                txtEmail.Focus();
            }
            else if (!Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                txbMainError.Text = "Enter a valid email.";
                txbMainError.Focus();
            }
            else
            {
                string email = txtEmail.Text;
                string password = pwdPassword.Password;
                MySqlConnection con = new MySqlConnection("SERVER=mysql.labranet.jamk.fi;DATABASE=M3156_3;UID=M3156;PASSWORD=Mn1GQ5TbFX7UI0tjH2Y4H2oWtcfs4zra");
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from user where userEmail='" + email + "'  and userPassword='" + password + "'", con);
                cmd.CommandType = CommandType.Text;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    string username = dataSet.Tables[0].Rows[0]["userName"].ToString() + " " + dataSet.Tables[0].Rows[0]["userSurname"].ToString();
                    activeUserID = int.Parse(dataSet.Tables[0].Rows[0]["userID"].ToString());
                    string img = $"images/{dataSet.Tables[0].Rows[0]["userPicture"].ToString()}";

                    Uri u = new Uri(img, UriKind.RelativeOrAbsolute);
                    bi = new BitmapImage(u);
                    main.txtUsername.Text = username;//Sending value from one form to another form.  
                    main.imgMainPageProfile.Stretch = Stretch.Fill;
                    main.imgMainPageProfile.Source = new BitmapImage(u);
                    main.Show();
                    this.Close();
                }
                else
                {
                    txbMainError.Text = "Sorry! Please enter existing emailid/password.";
                }
                con.Close();
            }
        }
    }
}
