using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Xml.Linq;

namespace BTLBlog
{
    public partial class BlogDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Lấy slug (seo) từ URL
                string seo = Page.RouteData.Values["seo"] as string;

                if (!string.IsNullOrEmpty(seo))
                {
                    LoadBlogDetails(seo);
                }
                else
                {
                    Response.Redirect("~/NotFound.aspx");
                }
            }
        }
        private void LoadBlogDetails(string seo)
        {
            using (var context = new BlogDBEntities())
            {
                var blog = context.Blogs.Include(b => b.Comments).Include(b => b.User).SingleOrDefault(b => b.seo == seo);

                if (blog != null)
                {
                    Page.Title = blog.BlogTitle;

                    var Ldanhmuc = context.Danhmucs
                   .Where(d => d.BlogDanhmucs.Any(bd => bd.BlogId == blog.BlogId))
                   .Select(d => new {
                       d.TenDanhmuc,
                       d.MaDanhmuc
                   })
                   .ToList();
                    linkposter.NavigateUrl = "~/AccountInfo/" + blog.UserId;
                    linkposter1.NavigateUrl = "~/AccountInfo/" + blog.UserId;
                    linkposter1.Text = blog.User.Username;
                    avartarposter.ImageUrl = blog.User.ProfilePicture;
                    rptDanhMuc.DataSource = Ldanhmuc;
                    rptDanhMuc.DataBind();

                    ltBlogTitle.Text = "<h1>" + blog.BlogTitle + "</h1>";
                    ltBlogContent.Text = HttpUtility.HtmlDecode(blog.BlogContent);
                    blogcreactat.Text = blog.BlogCreatedDate.Value.ToString("dd/MM/yyyy HH:mm 'UTC'");
                    LoadComments(blog.BlogId);
                }
                else
                {
                    Response.Redirect("~/NotFound.aspx");
                }
            }
        }
        protected void btnSubmitComment_Click(object sender, EventArgs e)
        {
            if(Session["UserId"] == null)
            {
                string script = "<script>Custom.Mytoast('Vui lòng đăng nhập để thực hiện chức năng', '/images/error.svg');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "ShowToast", script);

                return;
            }
            using (var context = new BlogDBEntities())
            {
                string seo = Page.RouteData.Values["seo"] as string;
                var blog = context.Blogs.SingleOrDefault(b => b.seo == seo);
                var comment = new Comment
                {
                    BlogId = blog.BlogId,
                    UserId = (int)Session["UserId"],
                    Content = txtCommentContent.Text ,
                    CreatedDate = DateTime.Now
                };

                context.Comments.Add(comment);
                context.SaveChanges();

                LoadComments(blog.BlogId);

                Response.Redirect(Request.RawUrl);
            }
        }
        private void LoadComments(int blogId)
        {
            using (var context = new BlogDBEntities())
            {
                var comments = context.Comments
                .Where(c => c.BlogId == blogId)
                .Select(c => new {
                    c.User.ProfilePicture,
                    c.User.UserId,
                    c.User.Username,
                    c.Content, 
                    c.CreatedDate
                })
                .ToList();

                rptComments.DataSource = comments;
                rptComments.DataBind();
            }
        }
    }
}