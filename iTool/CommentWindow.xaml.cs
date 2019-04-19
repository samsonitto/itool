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
        #region PROPERTIES
        private List<Comment> comments;
        private List<User> users;
        private int? selectedComment = null;
        #endregion

        #region METHODS
        public CommentWindow()
        {
            InitializeComponent();
            IniMyStuuf();
        }

        private void IniMyStuuf()
        {
            users = DB.GetAllUsersFromMysql();
            comments = DB.GetCommentsFromMysql(Active.ToolID);

            IniComments();
        }

        private void AddComment()
        {
            try
            {
                string body = txtComment.Text;
                string query;

                if (selectedComment == null)
                    query = $"INSERT INTO comment (commentDate, commentText, userID, commentParentID, toolID) VALUES (CURRENT_TIMESTAMP,'{body}',{Active.UserID},null,{Active.ToolID});";
                else
                    query = $"INSERT INTO comment (commentDate, commentText, userID, commentParentID, toolID) VALUES (CURRENT_TIMESTAMP,'{body}',{Active.UserID},{selectedComment},{Active.ToolID});";

                DB.AddCommentToMysql(query);
                lbxComments.Items.Clear();
                comments = DB.GetCommentsFromMysql(Active.ToolID);
                IniComments();
            }
            catch
            {

                throw;
            }
        }

        private User GetUser(int userID)
        {
            try
            {
                foreach (User user in users)
                {
                    if (user.UserID == userID)
                    {
                        return user;
                    }
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        private void IniComments()
        {
            try
            {
                foreach (Comment item in comments)
                {
                    if (item.CommentParentID == null)
                    {
                        //User u = DB.GetToolOwnerFromMysql(item.userID);
                        User u = GetUser(item.userID);

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
                            //User us = DB.GetToolOwnerFromMysql(reply.userID);
                            User us = GetUser(reply.userID);

                            Label lbComment = new Label();
                            lbComment.Content = $"Comment #{reply.CommentID}";
                            lbComment.FontSize = 12;
                            lbComment.FontWeight = FontWeights.Bold;
                            Label lb = new Label();
                            lb.Content = $"{us.FirstName} {us.LastName}, User ID: #{us.UserID}   {item.DateTime.ToString()}   In reply to comment #{item.CommentID}";
                            lb.FontSize = 12;
                            lb.FontWeight = FontWeights.Bold;

                            TextBlock reply1 = new TextBlock();
                            reply1.Text = reply.Text;
                            reply1.VerticalAlignment = VerticalAlignment.Top;
                            reply1.HorizontalAlignment = HorizontalAlignment.Left;
                            reply1.FontSize = 12;
                            reply1.TextWrapping = TextWrapping.Wrap;

                            StackPanel spReply = new StackPanel();
                            spReply.Margin = new Thickness(20, 10, 0, 0);
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
            catch
            {
                throw;
            }
        }
        #endregion

        #region EVENTHANDLERS
        private void TxtComment_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddComment();
            }
        }

        private void lbxComments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StackPanel selected = (StackPanel)lbxComments.SelectedItem;

            if (selected != null)
            {
                Label l = (Label)selected.Children[0];
                string content = l.Content.ToString();
                selectedComment = int.Parse(content.Split('#')[content.Split('#').Length - 1]); 
            }

            lblCommentMessages.Content = $"Comment #{selectedComment} is selected, reply to it by typing a comment and pressing 'Enter'";

        }
        #endregion
    }
}
