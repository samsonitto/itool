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
    /// Interaction logic for CommentWindow.xaml
    /// </summary>
    public partial class CommentWindow : Window
    {
        public CommentWindow()
        {
            InitializeComponent();
        }

        private void TxtComment_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Label user = new Label();
                user.Content = $"{Active.FirstName} {Active.LastName}";
                user.FontSize = 16;
                user.FontWeight = FontWeights.Bold;

                TextBlock txbComment1 = new TextBlock();
                txbComment1.Text = txtComment.Text;
                txbComment1.VerticalAlignment = VerticalAlignment.Top;
                txbComment1.HorizontalAlignment = HorizontalAlignment.Left;
                txbComment1.FontSize = 16;
                txbComment1.TextWrapping = TextWrapping.Wrap;

                StackPanel spComment = new StackPanel();
                spComment.Margin = new Thickness(0, 10, 10, 10);
                spComment.Orientation = Orientation.Vertical;
                spComment.HorizontalAlignment = HorizontalAlignment.Left;
                spComment.Children.Add(user);
                spComment.Children.Add(txbComment1);
                

                lbxComments.Items.Add(spComment);
            }
        }
    }
}
