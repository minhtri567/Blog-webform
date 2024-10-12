using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTLBlog
{
    public partial class EditAccount : System.Web.UI.Page
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
                            txtUsername.Text = user.Username;
                            txtEmail.Text = user.Email;
                            txtBio.Text = user.Bio;
                        }
                    }
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int userId = (int)Session["UserId"];

            using (var context = new BlogDBEntities())
            {
                var user = context.Users.SingleOrDefault(u => u.UserId == userId);

                if (user != null)
                {
                    user.Username = txtUsername.Text;
                    user.Email = txtEmail.Text;
                    user.Bio = txtBio.Text;
                    context.SaveChanges();

                    string script = "<script>Custom.Mytoast('Cập nhật thành công!', '/images/success.svg');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "ShowToast", script);

                }
                else
                {
                    string script = "<script>Custom.Mytoast('Cập nhật thất bại!', '/images/error.svg');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "ShowToast", script);
                }
            }
        }
    }
}