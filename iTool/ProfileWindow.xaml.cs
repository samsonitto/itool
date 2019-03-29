﻿using System;
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
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        public ProfileWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }

        private void IniMyStuff()
        {
            imgUserProfile.Source = new BitmapImage(new Uri(MainWindow.activeUserImage, UriKind.RelativeOrAbsolute));
            txbFirstName.Text = MainWindow.fName;
            txbLastName.Text = MainWindow.lName;
            txbUserID.Text = $"User ID: {MainWindow.activeUserID.ToString()}";
        }
    }
}
