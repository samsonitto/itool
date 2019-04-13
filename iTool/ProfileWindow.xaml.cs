﻿using System;
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
        public ProfileWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }

        #region METHODS

        private void IniMyStuff()
        {
            imgUserProfile.Source = Active.ImageSource;
            txbFirstName.Text = Active.FirstName;
            txbLastName.Text = Active.LastName;
            txbUserID.Text = $"User ID: {Active.UserID.ToString()}";

            dgMyTools.ItemsSource = DB.GetOwnedToolsFromMysql();
            dgRentedToolsByMe.ItemsSource = DB.GetMyRentedToolsFromMysql();
            dgMyTransactions.ItemsSource = DB.GetTransactionsFromMysql();

            imgToolProfile.Source = new BitmapImage(new Uri(@"images\no_picture_tool.png", UriKind.RelativeOrAbsolute));

            txbMessagesProfile.Text = $"Here you can see your profile info, the tool collections and the transaction history";
        }

        private void ShowPicture(string imageFile)
        {
            try
            {
                if (string.IsNullOrEmpty(imageFile) || !File.Exists($"{Active.ProjectPath}/images/{imageFile}"))
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
            Object selected = dgMyTools.SelectedItem;
            if (selected != null)
            {
                try
                {
                    lblHeader.Content = "Tool";
                    lblHeader1.Content = "Name";
                    lblHeader2.Content = "Condition";
                    lblHeader3.Content = "Price";
                    lblHeader4.Content = "Description";

                    Tool tool = (Tool)selected;
                    ShowPicture(tool.ToolPictureURL);
                    txbToolNameProfile.Text = tool.ToolName;
                    txbToolConditionProfile.Text = tool.ToolCondition;
                    txbPriceProfile.Text = $"{tool.ToolPrice.ToString()}€";
                    txbDescriptionProfile.Text = tool.ToolDescription;
                    imgToolProfile.Source = new BitmapImage(new Uri($"{Active.ProjectPath}/images/{tool.ToolPictureURL}"));

                    txbMessagesProfile.Text = $"You have selected {tool.ToolName}, double click to delete this tool";
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DgRentedToolsByMe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Object selected = dgRentedToolsByMe.SelectedItem;
            if (selected != null)
            {
                try
                {
                    lblHeader.Content = "Tool";
                    lblHeader1.Content = "Name";
                    lblHeader2.Content = "Condition";
                    lblHeader3.Content = "Price";
                    lblHeader4.Content = "Description";

                    Tool tool = (Tool)selected;
                    ShowPicture(tool.ToolPictureURL.ToString());
                    txbToolNameProfile.Text = tool.ToolName;
                    txbToolConditionProfile.Text = tool.ToolCondition;
                    txbPriceProfile.Text = $"{tool.ToolPrice.ToString()}€";
                    txbDescriptionProfile.Text = tool.ToolDescription;
                    //imgToolProfile.Source = new BitmapImage(new Uri($"{Active.ProjectPath}/images/{tool.ToolPictureURL}"));
                    txbMessagesProfile.Text = $"You have selected {tool.ToolName}, double click to return this tool";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BtnBackToMainPage_Click(object sender, RoutedEventArgs e)
        {
            MainPage main = new MainPage();
            main.Show();
            this.Close();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.txbMainError.Text = "You have succesfully logged out of iTool";
            mw.Show();
            this.Close();
        }

        private void btnAddTool_Click(object sender, RoutedEventArgs e)
        {
            AddAToolWindow a = new AddAToolWindow();
            a.ShowDialog();
        }

        private void dgMyTools_AutoGeneratedColumns(object sender, EventArgs e)
        {
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
            dgMyTransactions.Columns[0].Visibility = Visibility.Collapsed;
            dgMyTransactions.Columns[4].Visibility = Visibility.Collapsed;
            dgMyTransactions.Columns[5].Visibility = Visibility.Collapsed;
            dgMyTransactions.Columns[6].Visibility = Visibility.Collapsed;

            dgMyTransactions.Columns[1].Header = "Start Date";
            dgMyTransactions.Columns[2].Header = "Planned End Date";
            dgMyTransactions.Columns[3].Header = "Actual End Date";
        }

        private void dgMyTransactions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Object selected = dgMyTransactions.SelectedItem;
            if (selected != null)
            {
                try
                {
                    Transaction transaction = (Transaction)selected;

                    lblHeader.Content = "Transaction";
                    lblHeader1.Content = "Tool Owner";
                    lblHeader2.Content = "Start Date";
                    lblHeader3.Content = "Planned End Date";
                    lblHeader4.Content = "Actual End Date";

                    User user = DB.GetToolOwnerFromMysql(transaction.UserOwnerID);

                    txbToolNameProfile.Text = $"{user.FirstName} {user.LastName}";
                    txbToolConditionProfile.Text = transaction.StartDate.ToString();
                    txbPriceProfile.Text = transaction.PlannedEndDate.ToString();
                    txbDescriptionProfile.Text = transaction.ActualEndDate.ToString();

                    Tool tool = DB.GetToolFromMysql(transaction.ToolID);
                    ShowPicture(tool.ToolPictureURL);

                    txbMessagesProfile.Text = $"You have selected the transaction of a tool: {tool.ToolName}, double click to give a rating to the other party of the transaction";
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        #endregion
    }
}
