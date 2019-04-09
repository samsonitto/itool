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
        private List<Comment> comments;
        public CommentWindow()
        {
            InitializeComponent();
            IniMyStuuf();
        }

        private void IniMyStuuf()
        {

            comments = DB.GetCommentsFromMysql(Active.ToolID);

            int margin = 0;
            foreach(Comment item in comments)
            {

                if (item.CommentParentID == 0)
                {
                    User u = DB.GetToolOwnerFromMysql(item.userID);

                    Label lbComment = new Label();
                    lbComment.Content = $"Comment #{item.CommentID}";
                    lbComment.FontSize = 12;
                    lbComment.FontWeight = FontWeights.Bold;

                    Label l = new Label();
                    l.Content = $"{u.FirstName} {u.LastName}, User ID: #{u.UserID}   {item.DateTime.ToString()}";
                    l.FontSize = 12;
                    l.FontWeight = FontWeights.Bold;

                    TextBlock txbComment1 = new TextBlock();
                    txbComment1.Text = item.Text;
                    txbComment1.VerticalAlignment = VerticalAlignment.Top;
                    txbComment1.HorizontalAlignment = HorizontalAlignment.Left;
                    txbComment1.FontSize = 12;
                    txbComment1.TextWrapping = TextWrapping.Wrap;

                    StackPanel spComment = new StackPanel();
                    spComment.Margin = new Thickness(0, 10, 10, 10);
                    spComment.Orientation = Orientation.Vertical;
                    spComment.HorizontalAlignment = HorizontalAlignment.Left;
                    spComment.Children.Add(lbComment);
                    spComment.Children.Add(l);
                    spComment.Children.Add(txbComment1);

                    lbxComments.Items.Add(spComment); 
                }

                foreach (Comment reply in comments)
                {
                    if (reply.CommentParentID == item.CommentID)
                    {
                        User us = DB.GetToolOwnerFromMysql(reply.userID);

                        Label lbComment = new Label();
                        lbComment.Content = $"Comment #{reply.CommentID}";
                        lbComment.FontSize = 12;
                        lbComment.FontWeight = FontWeights.Bold;
                        Label lb = new Label();
                        lb.Content = $"{us.FirstName} {us.LastName}, User ID: #{us.UserID}   {item.DateTime.ToString()}   In reply to comment #{item.CommentID}";
                        lb.FontSize = 12;
                        lb.FontWeight = FontWeights.Bold;

                        TextBlock reply1 = new TextBlock();
                        reply1.Text = item.Text;
                        reply1.VerticalAlignment = VerticalAlignment.Top;
                        reply1.HorizontalAlignment = HorizontalAlignment.Left;
                        reply1.FontSize = 12;
                        reply1.TextWrapping = TextWrapping.Wrap;

                        StackPanel spReply = new StackPanel();
                        spReply.Margin = new Thickness(margin += 20, 10, 0, 0);
                        spReply.Orientation = Orientation.Vertical;
                        spReply.HorizontalAlignment = HorizontalAlignment.Left;
                        spReply.Children.Add(lbComment);
                        spReply.Children.Add(lb);
                        spReply.Children.Add(reply1);

                        lbxComments.Items.Add(spReply);
                    }
                }

            }

            
        }

        private void TxtComment_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddComment();
            }
        }

        private void lbxComments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Object selected = lbxComments.SelectedItem;
            
            
        }

        private void btnComment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddComment()
        {
            Label user = new Label();
            user.Content = $"{Active.FirstName} {Active.LastName}, User ID: #{Active.UserID}";
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
