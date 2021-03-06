﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using iTool;

namespace iTool
{

    public class User
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string PaymentMethod { get; set; }
        public string PictureURL { get; set; }
    }

    public class Tool
    {
        public int ToolID { get; set; }
        public int UserOwnerID { get; set; }
        public int ToolCategoryID { get; set; }
        public string ToolPictureURL { get; set; }
        public string ToolName { get; set; }
        public string ToolCondition { get; set; }
        public string ToolDescription { get; set; }
        public float ToolPrice { get; set; }
        public string ToolCategoryName { get; set; }
        public string ToolLocation { get; set; }
        public DateTime TransactionPlannedEndDate { get; set; }

        public Tool()
        {

        }
    }

    public class ToolCategory
    {
        public int ToolCategoryID { get; set; }
        public string ToolCategoryName { get; set; }
        public string ToolCategoryDescription { get; set; }

    }

    public class Comment
    {
        public int CommentID { get; set; }
        public DateTime DateTime { get; set; }
        public string Text { get; set; }
        public int ToolID { get; set; }
        public int userID { get; set; }
        public int? CommentParentID { get; set; } //NULLABLE, KOSKA KENTTÄ VOI OLLA NULL
    }

    public class Transaction
    {
        public int TransactionID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? PlannedEndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public int UserOwnerID { get; set; }
        public int UserLesseeID { get; set; }
        public int ToolID { get; set; }
    }

    

}
