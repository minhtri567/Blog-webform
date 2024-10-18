using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTLBlog
{
    public partial class AccountInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var userId = Session["UserId"] != null ? (int)Session["UserId"] : 0;
                if (userId > 0)
                {
                    using (var context = new BlogDBEntities())
                    {
                        // Truy xuất người dùng từ cơ sở dữ liệu
                        var user = context.Users.SingleOrDefault(u => u.UserId == userId);

                        if (user != null)
                        {
                            Userimg.ImageUrl = user.ProfilePicture;
                            lblUsername.Text = user.Username;
                            lblEmail.Text = user.Email;
                            lblCreatedDate.Text = user.CreatedDate.Value.ToString("dd/MM/yyyy");
                            lblBio.Text = user.Bio;
                        }
                    }
                }
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditAccount.aspx");
        }
    }
}