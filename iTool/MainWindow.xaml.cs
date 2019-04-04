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

namespace iTool
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
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
                string connStr = DB.GetConnectionString();
                MySqlConnection con = new MySqlConnection(connStr);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from user where userEmail='" + email + "'  and userPassword='" + password + "'", con);
                cmd.CommandType = CommandType.Text;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    //string username = dataSet.Tables[0].Rows[0]["userName"].ToString() + " " + dataSet.Tables[0].Rows[0]["userSurname"].ToString();
                    Active.UserID = int.Parse(dataSet.Tables[0].Rows[0]["userID"].ToString());
                    Active.ImagePath = $"{Active.ProjectPath}/images/{dataSet.Tables[0].Rows[0]["userPicture"].ToString()}";
                    Active.FirstName = dataSet.Tables[0].Rows[0]["userName"].ToString();
                    Active.LastName = dataSet.Tables[0].Rows[0]["userSurname"].ToString();

                    if (string.IsNullOrEmpty(Active.ImagePath))
                    {
                        Active.ImageSource = new BitmapImage(new Uri($"{Active.ProjectPath}/images/no_picture.png", UriKind.RelativeOrAbsolute));
                    }
                    else
                    {
                        Active.ImageSource = new BitmapImage(new Uri(Active.ImagePath, UriKind.RelativeOrAbsolute));
                    }

                    MainPage main = new MainPage();
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
