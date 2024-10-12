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
    public partial class Register : System.Web.UI.Page
    {
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            if (password != confirmPassword)
            {
                lblMessage.Text = "Mật khẩu xác nhận không khớp!";
                return;
            }

            using (var context = new BlogDBEntities())
            {
                // Kiểm tra nếu Username đã tồn tại
                if (context.Users.Any(u => u.Username == username))
                {
                    lblMessage.Text = "Tên người dùng đã tồn tại!";
                    return;
                }

                // Tạo hash cho mật khẩu
                string passwordHash = HashPassword(password);

                // Thêm người dùng mới
                User newUser = new User
                {
                    Username = username,
                    Email = email,
                    PasswordHash = passwordHash,
                    Role = "User",
                    CreatedDate = DateTime.Now
                };

                context.Users.Add(newUser);
                context.SaveChanges();

                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Đăng ký thành công!";
                Response.Redirect("Login.aspx");
            }
        }

        // Hàm tạo hash cho mật khẩu
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

        }
    }
}