using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTLBlog
{
    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            using (var context = new BlogDBEntities())
            {
                // Lấy user từ database dựa trên username
                var user = context.Users.FirstOrDefault(u => u.Username == username);

                if (user == null)
                {
                    lblMessage.Text = "Người dùng không tồn tại!";
                    return;
                }

                // Tạo hash cho mật khẩu nhập vào và so sánh với mật khẩu trong database
                string passwordHash = HashPassword(password);
                if (user.PasswordHash != passwordHash)
                {
                    string scripts = "<script>Custom.Mytoast('Sai mật khẩu!', '/images/error.svg');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "ShowToast", scripts);
                    return;
                }

                string script = "<script>Custom.Mytoast('Đăng nhập thành công!', '/images/success.svg');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "ShowToast", script);

                Session["Username"] = user.Username;
                Session["UserId"] = user.UserId;
                Session["ProfilePicture"] = user.ProfilePicture;

                if (chkRememberMe.Checked)
                {
                    HttpCookie rememberMeCookie = new HttpCookie("RememberMe");
                    rememberMeCookie.Values["Username"] = user.Username;
                    rememberMeCookie.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(rememberMeCookie);
                }

                Response.Redirect("Default.aspx");
            }
        }

        // Hàm tạo hash cho mật khẩu (tương tự như trong phần đăng ký)
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Kiểm tra xem cookie "RememberMe" có tồn tại không
                if (Request.Cookies["RememberMe"] != null)
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }
    }
}