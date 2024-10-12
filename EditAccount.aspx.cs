using System;
using System.Collections.Generic;
using System.IO;
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
                var userImg = Session["ProfilePicture"];
                if (userImg != null)
                {
                    string imgUrl = userImg.ToString();

                    selectedAvatar.ImageUrl = imgUrl;
                }
                else
                {
                    selectedAvatar.ImageUrl = "images/user.png";
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int userId = (int)Session["UserId"];

            using (var context = new BlogDBEntities())
            {
                var user = context.Users.SingleOrDefault(u => u.UserId == userId);

                if (user == null)
                {
                    string scripts = "<script>Custom.Mytoast('Cập nhật thất bại! Người dùng không tồn tại!', '~/images/error.svg');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "ShowToast", scripts);
                    return; // Thoát nếu người dùng không tồn tại
                }

                if (fileInput.HasFile)
                {
                    try
                    {
                        // Đường dẫn đến thư mục trên server nơi bạn muốn lưu ảnh
                        string folderPath = Server.MapPath("~/images/");

                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }

                        if (!string.IsNullOrEmpty(user.ProfilePicture))
                        {
                            string oldImagePath = Server.MapPath(user.ProfilePicture);
                            if (File.Exists(oldImagePath))
                            {
                                File.Delete(oldImagePath); // Xóa ảnh cũ
                            }
                        }

                        // Lấy tên tệp và kết hợp với đường dẫn
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(fileInput.FileName);
                        string fullPath = Path.Combine(folderPath, fileName);

                        // Lưu tệp hình ảnh lên server
                        fileInput.SaveAs(fullPath);

                        // Cập nhật đường dẫn trong Session và CSDL
                        Session["ProfilePicture"] = "~/images/" + fileName;
                        user.ProfilePicture = "~/images/" + fileName;
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = "Có lỗi xảy ra: " + ex.Message;
                    }
                }

                // Cập nhật thông tin người dùng
                user.Username = txtUsername.Text;
                user.Email = txtEmail.Text;
                user.Bio = txtBio.Text;
                context.SaveChanges();

                string script = "<script>Custom.Mytoast('Cập nhật thành công!', 'images/success.svg');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "ShowToast", script);
            }
        }
    }
}