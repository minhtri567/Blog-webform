using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTLBlog
{
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string categorySeo = Request.QueryString["seo"]; // Lấy tham số từ URL
                LoadCategoryBlogs(categorySeo);
            }
        }
        private void LoadCategoryBlogs(string categorySeo)
        {
            using (var context = new BlogDBEntities())
            {
                // Lấy danh mục theo seo
                var category = context.Danhmucs.SingleOrDefault(d => d.MaDanhmuc == categorySeo);

                if (category != null)
                {
                    ltCategoryTitle.InnerText = category.TenDanhmuc; 

                    var blogs = context.Blogs
                        .Where(b => b.Blogdanhmuc == category.DanhmucId)
                        .Select(b => new
                        {
                            b.BlogId,
                            b.BlogTitle,
                            b.summary_ct, // Tóm tắt
                            b.seo
                        })
                        .ToList();

                    // Gán dữ liệu cho Repeater
                    rptBlogs.DataSource = blogs;
                    rptBlogs.DataBind();
                }
                else
                {
                    Response.Redirect("~/NotFound.aspx");
                }
            }
        }
    }
}