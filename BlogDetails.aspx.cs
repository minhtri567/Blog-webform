using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

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

                    rptDanhMuc.DataSource = Ldanhmuc;
                    rptDanhMuc.DataBind();

                    ltBlogTitle.Text = "<h1>" + blog.BlogTitle + "</h1>";
                    ltBlogContent.Text = HttpUtility.HtmlDecode(blog.BlogContent);
                    imgBlogTitleImg.ImageUrl = blog.BlogTitleImg;
                }
                else
                {
                    Response.Redirect("~/NotFound.aspx");
                }
            }
        }
    }
}