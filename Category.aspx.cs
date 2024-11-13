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
                string categorySeo = Page.RouteData.Values["MaDanhmuc"] as string;
                if (!string.IsNullOrEmpty(categorySeo))
                {
                    LoadCategoryBlogs(categorySeo);
                }
            }
        }
        private void LoadCategoryBlogs(string categorySeo)
        {
            using (var context = new BlogDBEntities())
            {
                // Lấy danh mục theo mã seo
                var category = context.Danhmucs.SingleOrDefault(d => d.MaDanhmuc == categorySeo);

                if (category != null)
                {
                    ltCategoryTitle.InnerText = category.TenDanhmuc;

                    // Lấy danh sách BlogId từ bảng BlogDanhmuc có DanhmucId tương ứng
                    var blogIds = context.BlogDanhmuc
                        .Where(bd => bd.DanhmucId == category.DanhmucId)
                        .Select(bd => bd.BlogId)
                        .ToList();

                    // Lấy các blog theo BlogId
                    var blogs = context.Blogs
                        .Where(b => blogIds.Contains(b.BlogId))
                        .Select(b => new
                        {
                            b.BlogId,
                            b.BlogTitle,
                            b.summary_ct, // Tóm tắt
                            b.seo,
                            b.BlogCreatedDate,
                            b.BlogTitleImg
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