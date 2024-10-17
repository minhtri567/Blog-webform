using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTLBlog
{
    public partial class new_blog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLuu_Click(object sender, EventArgs e)
        {
            // Lấy danh sách các DanhmucId đã chọn từ ListBox
            List<int> selectedDanhmucIds = new List<int>();
            foreach (ListItem item in ddlBlogDanhmuc.Items)
            {
                if (item.Selected)
                {
                    selectedDanhmucIds.Add(int.Parse(item.Value));
                }
            }

            // Sử dụng các danh mục đã chọn để xử lý tiếp
            using (var context = new BlogDBEntities())
            {
                var blog = new Blog
                {
                    BlogTitle = txtBlogTitle.Text,
                    BlogContent = txtBlogContent.Text,
                    BlogCreatedDate = DateTime.Now,
                    UserId = (int)Session["UserId"]
                };

                // Nếu chọn nhiều danh mục, bạn cần xử lý tùy theo cấu trúc của bảng Blog và Danhmuc.
                // Ví dụ: Lưu các DanhmucId đã chọn trong mối quan hệ riêng biệt.

                context.Blogs.Add(blog);
                context.SaveChanges();

                // Hiển thị thông báo thành công
                string script = "<script>Custom.Mytoast('Lưu bài viết thành công!', '/images/success.svg');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "ShowToast", script);
            }
        }
        private string SaveBlogTitleImage(FileUpload fileUpload)
        {
            if (fileUpload.HasFile)
            {
                string folderPath = Server.MapPath("~/images/blogs/");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(fileUpload.FileName);
                string fullPath = Path.Combine(folderPath, fileName);

                fileUpload.SaveAs(fullPath);

                return "~/images/blog/" + fileName;
            }
            return null;
        }
        private void LoadDanhmuc(string Madanhmuc)
        {
            using (var context = new BlogDBEntities())
            {
                var query = from d in context.Danhmucs
                            join l in context.LoaiDanhmucs on d.IdLoaiDanhmuc equals l.LoaiDanhmucId
                            where l.MaLoai == Madanhmuc
                            select new
                            {
                                d.DanhmucId,
                                d.TenDanhmuc
                            };

                var danhmucs = query.ToList();
                ddlBlogDanhmuc.DataSource = danhmucs;
                ddlBlogDanhmuc.DataTextField = "TenDanhmuc";
                ddlBlogDanhmuc.DataValueField = "DanhmucId";
                ddlBlogDanhmuc.DataBind();
            }
        }
    }
}