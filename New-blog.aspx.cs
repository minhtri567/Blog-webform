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
            if (!IsPostBack)
            {
                if (Session["Username"] == null)
                {
                    string script = "<script>Custom.Mytoast('Vui lòng đăng nhập để thực hiện chức năng', '/images/error.svg');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "ShowToast", script);
                    
                    Response.Redirect("Login.aspx");
                }
                LoadDanhmuc("THE_LOAI");
            }
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
                    BlogContent = HttpUtility.HtmlEncode(txtBlogContent.Text),
                    BlogCreatedDate = DateTime.Now,
                    summary_ct = txtsumaruct.Text,
                    seo = GenerateSeo(txtBlogTitle.Text),
                    Bloglike = 0,
                    BlogComments = 0,
                    UserId = (int)Session["UserId"]
                };

                string imagePath = SaveBlogTitleImage(fileBlogTitleImg);
                blog.BlogTitleImg = imagePath;

                context.Blogs.Add(blog);
                context.SaveChanges();

                foreach (ListItem item in ddlBlogDanhmuc.Items)
                {
                    if (item.Selected)
                    {
                        BlogDanhmuc blogDanhmuc = new BlogDanhmuc
                        {
                            BlogId = blog.BlogId,
                            DanhmucId = Convert.ToInt32(item.Value)
                        };
                        context.BlogDanhmuc.Add(blogDanhmuc);
                    }
                }

                context.SaveChanges();

                // Hiển thị thông báo thành công
                string script = "<script>Custom.Mytoast('Lưu bài viết thành công!', '/images/success.svg');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "ShowToast", script);
            }
        }
        public static string GenerateSeo(string title)
        {
            // Chuyển đổi về chữ thường
            string seoTitle = title.ToLower();

            // Thay thế khoảng trắng bằng dấu gạch ngang
            seoTitle = seoTitle.Replace(" ", "-");

            // Loại bỏ các ký tự không hợp lệ
            seoTitle = System.Text.RegularExpressions.Regex.Replace(seoTitle, @"[^a-z0-9\-]", "");

            // Loại bỏ các dấu gạch ngang liên tiếp
            seoTitle = System.Text.RegularExpressions.Regex.Replace(seoTitle, @"-+", "-");

            // Trả về chuỗi SEO đã chuẩn hóa
            return seoTitle;
        }
        private string SaveBlogTitleImage(FileUpload fileUpload)
        {
            if (fileUpload.HasFile)
            {
                string folderPath = Server.MapPath("images/blogs/");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(fileUpload.FileName);
                string fullPath = Path.Combine(folderPath, fileName);

                fileUpload.SaveAs(fullPath);

                return "images/blogs/" + fileName;
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