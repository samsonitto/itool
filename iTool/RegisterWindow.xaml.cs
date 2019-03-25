using Microsoft.Win32;
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
            users.Add(new User() { UserID = 1, Email = txtAddEmail.Text, Password = pwdCreatePassword.Password, FirstName = txtFirstName.Text, LastName = txtLastName.Text, Mobile = int.Parse(txtMobile.Text), Address = txtAddAddress.Text, Location = txtAddLocation.Text, PaymentMethod = cbPayment.SelectedValue.ToString(), PictureURL = txtPic.Text.Split('\\')[txtPic.Text.Split('\\').Length - 1] });
            ShowUser user = new ShowUser();
            user.Show();
            user.dgUsers.ItemsSource = users;
        }
    }
}
