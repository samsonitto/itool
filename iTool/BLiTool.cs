using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTool
{
    public class BLiTool
    {
        public List<User> users = new List<User>();

        public BLiTool()
        {

        }
    }

    public class User
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public int Mobile { get; set; }
        public string Address { get; set; }
        public string PaymentMethod { get; set; }
        public string PictureURL { get; set; }
        //public List<Tool> ToolCollection = new List<Tool>();

        public User()
        {

        }
    }

    public class Tool
    {
        public int ToolID { get; set; }
        public string ToolName { get; set; }
        public string ToolCondition { get; set; }
        public string ToolDescription { get; set; }
        public float ToolPrice { get; set; }
        public int ToolCategoryID { get; set; }
        public int UserOwnerID { get; set; }

        public Tool()
        {

        }
    }

    public class ToolCategory
    {
        public int ToolCategoryID { get; set; }
        public string ToolCategoryName { get; set; }
        public string ToolCategoryDescription { get; set; }

        public ToolCategory()
        {

        }
    }

}
