using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTLBlog
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public List<Blog> LoadBlogs()
        {
            using (var context = new BlogDBEntities())
            {
                return context.Blogs.ToList();
            }
        }
    }
}