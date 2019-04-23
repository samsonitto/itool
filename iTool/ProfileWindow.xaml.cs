using System;
using System.Collections.Generic;
using System.IO;
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
using System.Globalization;
using System.Threading;

namespace iTool
{
    /// <summary>
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        #region METHODS

        public ProfileWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }

        private void IniMyStuff()
        {
            imgUserProfile.Source = Active.ImageSource;
            lblUserProfile.Content = $"{Active.FirstName} {Active.LastName}";

            txbUserID.Text = $"User ID: {Active.UserID.ToString()}";
            txbAvgRating.Text = $"Average rating: {DB.GetAvgRatingFromMysql(Active.UserID).ToString()}";

            dgMyTools.ItemsSource = DB.GetOwnedToolsFromMysql();
            dgRentedToolsByMe.ItemsSource = DB.GetMyRentedToolsFromMysql();
            dgMyTransactions.ItemsSource = DB.GetTransactionsFromMysql();

            imgToolProfile.Source = new BitmapImage(new Uri(@"images\no_picture_tool.png", UriKind.RelativeOrAbsolute));

            txbMessagesProfile.Text = $"Here you can see your profile info, the tool collections and the transaction history";
        }

        private void ShowPicture(string imageFile)
        {
            //NÄYTETÄÄN VALITUN TYÖKALUN KUVA
            try
            {
                if (string.IsNullOrEmpty(imageFile) || !File.Exists($"{Active.ProjectPath}/images/{imageFile}")) //JOS TYÖKALULLA EI OLE KUVAA
                {
                    imageFile = "no_picture_tool.png";
                }
                BitmapImage toolImage = new BitmapImage(new Uri($"{Active.ProjectPath}/images/{imageFile}", UriKind.RelativeOrAbsolute));
                imgToolProfile.Stretch = Stretch.Fill;
                imgToolProfile.Source = toolImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region EVENTHANDLERS

        private void DgMyTools_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //HAETAAN TYÖKALUN TIEDOT DATAGRID VALINNAN MUKAAN
            Object selected = dgMyTools.SelectedItem;
            if (selected != null)
            {
                try
                {
                    //VAIHDETAAN LABELIEN SISÄLLÖT
                    lblHeader.Content = "Tool";
                    lblHeader1.Content = "Name";
                    lblHeader2.Content = "Condition";
                    lblHeader3.Content = "Price";
                    lblHeader4.Content = "Description";

                    Tool tool = (Tool)selected; //CASTATAAN DATAGRID VALINNASTA TYÖKALUN OLIO
                    ShowPicture(tool.ToolPictureURL);
                    txbToolNameProfile.Text = tool.ToolName;
                    txbToolConditionProfile.Text = tool.ToolCondition;
                    txbPriceProfile.Text = $"{tool.ToolPrice.ToString()}€";
                    txbDescriptionProfile.Text = tool.ToolDescription;
                    imgToolProfile.Source = new BitmapImage(new Uri($"{Active.ProjectPath}/images/{tool.ToolPictureURL}"));

                    txbMessagesProfile.Text = $"You have selected {tool.ToolName}, press 'Delete' key to delete tool from iTool database";
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DgRentedToolsByMe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //HAETAAN TYÖKALUN TIEDOT DATAGRID VALINNAN MUKAAN
            Object selected = dgRentedToolsByMe.SelectedItem;
            if (selected != null)
            {
                try
                {
                    //VAIHDETAAN LABELIEN SISÄLLÖT
                    lblHeader.Content = "Tool";
                    lblHeader1.Content = "Name";
                    lblHeader2.Content = "Condition";
                    lblHeader3.Content = "Price";
                    lblHeader4.Content = "Description";

                    Tool tool = (Tool)selected; //CASTATAAN DATAGRID VALINNASTA TYÖKALUN OLIO
                    ShowPicture(tool.ToolPictureURL.ToString());
                    txbToolNameProfile.Text = tool.ToolName;
                    txbToolConditionProfile.Text = tool.ToolCondition;
                    txbPriceProfile.Text = $"{tool.ToolPrice.ToString()}€";
                    txbDescriptionProfile.Text = tool.ToolDescription;
                    //imgToolProfile.Source = new BitmapImage(new Uri($"{Active.ProjectPath}/images/{tool.ToolPictureURL}"));
                    txbMessagesProfile.Text = $"You have selected {tool.ToolName}, press 'Space' to return this tool";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BtnBackToMainPage_Click(object sender, RoutedEventArgs e)
        {
            //PALATAAN TAKAISIN MAIN IKKUNAAN
            MainPage main = new MainPage();
            main.Show();
            this.Close();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            //KIRJAUDUTAAN ULOS
            var result = MessageBox.Show($"You are logging out, confirm.", "iTool: Logout", MessageBoxButton.YesNo); //VARMISTUSIKKUNA

            if (result == MessageBoxResult.Yes) //YES
            {
                MainWindow mw = new MainWindow();
                mw.txbMainError.Text = "You have succesfully logged out of iTool";
                mw.Show();
                this.Close(); 
            }
        }

        private void btnAddTool_Click(object sender, RoutedEventArgs e)
        {
            //AVATAAN ADDATOOL IKKUNA
            AddAToolWindow a = new AddAToolWindow();
            a.ShowDialog();
        }

        private void dgMyTools_AutoGeneratedColumns(object sender, EventArgs e)
        {
            //PIILOTETAAN DATAGRIDIN KOLUMNEJA JA VAIHDETAAN DATAGRIDIN KOLUMNIEN OTSIKOT
            dgMyTools.Columns[0].Visibility = Visibility.Collapsed;
            dgMyTools.Columns[1].Visibility = Visibility.Collapsed;
            dgMyTools.Columns[2].Visibility = Visibility.Collapsed;
            dgMyTools.Columns[3].Visibility = Visibility.Collapsed;
            dgMyTools.Columns[10].Visibility = Visibility.Collapsed;

            dgMyTools.Columns[4].Header = "Name";
            dgMyTools.Columns[5].Header = "Condition";
            dgMyTools.Columns[6].Header = "Description";
            dgMyTools.Columns[7].Header = "Price";
            dgMyTools.Columns[8].Header = "Category";
            dgMyTools.Columns[9].Header = "Location";
        }

        private void dgRentedToolsByMe_AutoGeneratedColumns(object sender, EventArgs e)
        {
            //PIILOTETAAN DATAGRIDIN KOLUMNEJA JA VAIHDETAAN DATAGRIDIN KOLUMNIEN OTSIKOT
            dgRentedToolsByMe.Columns[0].Visibility = Visibility.Collapsed;
            dgRentedToolsByMe.Columns[1].Visibility = Visibility.Collapsed;
            dgRentedToolsByMe.Columns[2].Visibility = Visibility.Collapsed;
            dgRentedToolsByMe.Columns[3].Visibility = Visibility.Collapsed;

            dgRentedToolsByMe.Columns[4].Header = "Name";
            dgRentedToolsByMe.Columns[5].Header = "Condition";
            dgRentedToolsByMe.Columns[6].Header = "Description";
            dgRentedToolsByMe.Columns[7].Header = "Price";
            dgRentedToolsByMe.Columns[8].Header = "Category";
            dgRentedToolsByMe.Columns[9].Header = "Location";
            dgRentedToolsByMe.Columns[10].Header = "Transaction Planned End Date";
        }

        private void dgMyTransactions_AutoGeneratedColumns(object sender, EventArgs e)
        {
            //PIILOTETAAN DATAGRIDIN KOLUMNEJA JA VAIHDETAAN DATAGRIDIN KOLUMNIEN OTSIKOT
            dgMyTransactions.Columns[4].Visibility = Visibility.Collapsed;
            dgMyTransactions.Columns[5].Visibility = Visibility.Collapsed;
            dgMyTransactions.Columns[6].Visibility = Visibility.Collapsed;

            dgMyTransactions.Columns[0].Header = "Transaction ID";
            dgMyTransactions.Columns[1].Header = "Start Date";
            dgMyTransactions.Columns[2].Header = "Planned End Date";
            dgMyTransactions.Columns[3].Header = "Actual End Date";

        }

        private void dgMyTransactions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //HAETAAN TRANSAKTION TIEDOT DATAGRID VALINNAN MUKAAN
            Object selected = dgMyTransactions.SelectedItem;
            if (selected != null)
            {
                try
                {
                    Transaction transaction = (Transaction)selected; //CASTATAAN DATAGRID VALINNASTA TRANSACTIO-OLIO

                    //MUUTETAAN LABELIEN SISÄLLÖT
                    lblHeader.Content = "Transaction";
                    lblHeader1.Content = "Tool Owner";
                    lblHeader2.Content = "Start Date";
                    lblHeader3.Content = "Planned End Date";
                    lblHeader4.Content = "Actual End Date";

                    User user = DB.GetToolOwnerFromMysql(transaction.UserOwnerID); //HAETAAN TYÖKALUN OMISTAJAN TIETOKANNASTA

                    txbToolNameProfile.Text = $"{user.FirstName} {user.LastName}";
                    txbToolConditionProfile.Text = transaction.StartDate.ToString();
                    txbPriceProfile.Text = transaction.PlannedEndDate.ToString();
                    txbDescriptionProfile.Text = transaction.ActualEndDate.ToString();

                    Tool tool = DB.GetToolFromMysql(transaction.ToolID); //HAETAAN TRANSAKTIOSSA OLEVA TYÖKALU TIETOKANNASTA
                    ShowPicture(tool.ToolPictureURL);

                    txbMessagesProfile.Text = $"You have selected the transaction of the tool: {tool.ToolName}, press 'Space' to rate the other party of the transaction";
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BtnEditProfile_Click(object sender, RoutedEventArgs e)
        {
            //AVATAAN EDIT PROFILE IKKUNA
            EditProfile editProfile = new EditProfile();
            editProfile.ShowDialog();
        }

        private void BtnDeleteProfile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //POISTETAAN KÄYTTÄJÄ
                List<Transaction> transactions = DB.GetTransactionsFromMysql();
                List<Transaction> checkTr = new List<Transaction>();
                bool transactionActive = false;

                foreach (Transaction item in transactions)
                {
                    if (item.ActualEndDate == null)
                    {
                        checkTr.Add(item);
                    }
                }

                if (checkTr.Count() > 0)
                    transactionActive = true;

                if (transactionActive)
                {
                    txbMessagesProfile.Text = "Cannot delete your profile while you have an ongoing transaction";
                }
                else
                {
                    var result = MessageBox.Show($"Do you really want to delete your user profile and all of your data from the iTool database?", "iTool: Delete Profile", MessageBoxButton.YesNo); //VARMISTUSIKKUNA

                    if (result == MessageBoxResult.Yes) //YES
                    {
                        DB.DeleteProfile(); //YLIKIRJOITETAAN KÄYTTÄJÄ TIETOKANNASSA
                        Active.main = new MainWindow(); //LUODAAN LOGIN IKKUNAN OLIO
                        Active.main.Show(); //NÄYTETÄÄN LOGIN IKKUNA
                        Active.main.txbMainError.Text = "You have deleted your profile successfully"; //ESITETÄÄN VIESTI KÄYTTÄJÄLLE
                        this.Close(); //SULJETAAN TÄMÄ IKKUNA
                    }
                    else //NO
                    {
                        txbMessagesProfile.Text = $"You did nothing";
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        private void DgMyTools_KeyUp(object sender, KeyEventArgs e)
        {
            //POISTETAAN TYÖKALU VALITSEMALLA SEN DATAGRIDISSA JA PAINAMALLA 'DELETE'
            if (e.Key == Key.Delete)
            {
                var result = MessageBox.Show($"Do you really want to delete this tool from the iTool database?", "iTool: Delete Tool", MessageBoxButton.YesNo); //VARMISTUSIKKUNA

                if (result == MessageBoxResult.Yes) //YES
                {
                    Object selected = dgMyTools.SelectedItem;

                    if (selected != null)
                    {
                        try
                        {
                            Tool tool = (Tool)selected; //CASTATAAN DATAGRID VALINNASTA TOOL OLIO
                            DB.DeleteTool(tool.ToolID); //YLIKIRJOITETAAN TYÖKALU TIETOKANASSA

                            dgMyTools.ItemsSource = DB.GetOwnedToolsFromMysql(); //PÄIVITETÄÄN DATAGRID
                            txbMessagesProfile.Text = $"You have deleted {tool.ToolName}";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    } 
                }
            }
        }

        private void DgRentedToolsByMe_KeyUp(object sender, KeyEventArgs e)
        {
            //PALAUTETAAN TYÖKALU OMISTAJALLE VALITSEMALLA SEN DATAGRIDISSA JA PAINAMALLA 'SPACE'
            try
            {
                if (e.Key == Key.Space)
                {
                    Object selected = dgRentedToolsByMe.SelectedItem;
                    if (selected != null)
                    {
                        var result = MessageBox.Show($"Do you really want to return this tool to it's owner?", "iTool: Return Tool", MessageBoxButton.YesNo); //VARMISTUSIKKUNA

                        if (result == MessageBoxResult.Yes) //YES
                        {
                            Tool tool = (Tool)selected; //CASTATAAN TYÖKALUOLIO DATAGRID VALINNASTA

                            Transaction transaction = DB.GetTransactionFromMysql(tool.ToolID); //HAETAAN KYSEISEN TYÖKALUN AUKI OLEVA TRANSAKTIO

                            DB.ReturnRentedToolMysql(transaction.TransactionID); //LISÄTÄÄN 'ACTUALENDDATE' TRANSAKTIOON

                            //PÄIVITETÄÄN DATAGRIDIT
                            dgMyTransactions.ItemsSource = DB.GetTransactionsFromMysql();
                            dgRentedToolsByMe.ItemsSource = DB.GetMyRentedToolsFromMysql();

                            txbMessagesProfile.Text = $"You have returned {tool.ToolName} to it's owner";
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        private void DgMyTransactions_KeyUp(object sender, KeyEventArgs e)
        {
            //ANNETAAN ARVIO TRANSAKTION TOISELLE OSAPUOLELLE VALITSEMALLA TRANSAKTIO JA PAINAMALLA 'SPACE'
            try
            {
                if(e.Key == Key.Space)
                {
                    Object selected = dgMyTransactions.SelectedItem;
                    Transaction transaction = (Transaction)selected; //CASTAUS

                    if (string.IsNullOrEmpty(transaction.ActualEndDate.ToString())) //TARKISTETAAN ONKO TRANSAKTIO SULJETTU
                        txbMessagesProfile.Text = "This transaction is in progress, transaction must be closed for you to give rating";
                    else
                    {
                        //TARKISTETAAN KUMPI OSAPUOLI AKTIIVIKÄYTTÄJÄ ON
                        User user;
                        if (transaction.UserOwnerID == Active.UserID)
                        {
                            user = DB.GetToolOwnerFromMysql(transaction.UserLesseeID);
                        }
                        else
                        {
                            user = DB.GetToolOwnerFromMysql(transaction.UserOwnerID);
                        }

                        Tool tool = DB.GetToolFromMysql(transaction.ToolID); //HAETAAN TRANSAKTIOSSA OLEVA TYÖKALU TIETOKANNASTA


                        RatingWindow rating = new RatingWindow(); //LUODAAN RATING IKKUNAN OLIO
                        rating.ratedID = user.UserID; //DELEGOIDAAN KÄYTTÄJÄN ID RATING IKKUNAN MUUTTUJAAN
                        rating.transactionID = transaction.TransactionID; //DELEGOIDAAN TRANSAKTION ID RATING IKKUNAN MUUTTUJAAN
                        rating.ratedName = $"{user.FirstName} {user.LastName}"; //DELEGOIDAAN ARVIOITAVANA OLEVAN OSAPUOLEN NIMI RATING IKKUNAN MUUTTUJAAN

                        rating.lblRatedPerson.Content = $"Name: {user.FirstName} {user.LastName}, Tool: {tool.ToolName}, Transaction ID: {transaction.TransactionID}";
                        rating.ShowDialog();  //NÄYTETÄÄN RATING IKKUNA
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}
