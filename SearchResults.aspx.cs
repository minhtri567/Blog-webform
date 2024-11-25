using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTLBlog
{
    public partial class SearchResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string keyword = Request.QueryString["q"]; // Lấy từ khóa từ QueryString
                if (!string.IsNullOrEmpty(keyword))
                {
                    LoadSearchResults(keyword);
                }
            }
        }
        private void LoadSearchResults(string keyword)
        {
            using (var context = new BlogDBEntities())
            {
                var results = context.Blogs
                    .Where(b => b.BlogTitle.Contains(keyword) || b.summary_ct.Contains(keyword)) 
                    .Select(b => new
                    {
                        b.BlogId,
                        b.BlogTitle,
                        b.summary_ct, // Tóm tắt nội dung
                        b.seo
                    })
                    .ToList();

                if (results.Count == 0)
                {
                    phNoResults.Visible = true;
                    rptSearchResults.Visible = false;
                }
                else
                {
                    phNoResults.Visible = false;
                    rptSearchResults.Visible = true;
                    rptSearchResults.DataSource = results;
                    rptSearchResults.DataBind();
                }
            }
        }
    }
}