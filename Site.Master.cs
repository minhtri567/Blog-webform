using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTLBlog
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["RememberMe"] != null)
                {
                    var cookie = Request.Cookies["RememberMe"];
                    string username = cookie.Values["Username"];

                    using (var context = new BlogDBEntities())
                    {
                        // Lấy thông tin người dùng từ cơ sở dữ liệu
                        var user = context.Users.SingleOrDefault(u => u.Username == username);

                        if (user != null)
                        {
                            // Tự động đăng nhập bằng cách lưu thông tin người dùng vào session
                            Session["UserId"] = user.UserId;
                            Session["Username"] = user.Username;

                        }
                    }
                }
                if (Session["Username"] != null)
                {
                    // Nếu người dùng đã đăng nhập, hiển thị phần đã đăng nhập
                    lblUsername.Text = Session["Username"].ToString();
                    phNotLoggedIn.Visible = false;
                    phLoggedIn.Visible = true;
                }
                else
                {
                    // Nếu người dùng chưa đăng nhập, hiển thị phần chưa đăng nhập
                    phNotLoggedIn.Visible = true;
                    phLoggedIn.Visible = false;
                }
            }

        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            if (Request.Cookies["RememberMe"] != null)
            {
                HttpCookie rememberMeCookie = new HttpCookie("RememberMe");
                rememberMeCookie.Expires = DateTime.Now.AddDays(-1); 
                Response.Cookies.Add(rememberMeCookie);
            }
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
    }
}