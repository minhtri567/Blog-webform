using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTLBlog
{
    public partial class UserBlogs : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserBlogs();
            }
        }
        public void LoadUserBlogs()
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("~/Login.aspx");
                return ;
            }
            int iduser = (int)Session["UserId"];
           
            using (var context = new BlogDBEntities())
            {
                var blogs = context.Blogs
                    .Where(s => s.UserId == iduser)
                    .Select(blog => new
                    {
                        blog.BlogTitle,
                        blog.BlogTitleImg,
                        BlogCreatedDate = blog.BlogCreatedDate.HasValue ? blog.BlogCreatedDate : DateTime.Now,
                        blog.seo,
                        Summary = blog.summary_ct.Length > 100 ? blog.summary_ct.Substring(0, 100) : blog.summary_ct
                    })
                    .ToList();
                rptBlogs.DataSource = blogs;
                rptBlogs.DataBind();
            }
        }
    }
}