using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTLBlog
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["RememberMe"] != null)
                {
                    var cookie = Request.Cookies["RememberMe"];
                    string username = cookie.Values["Username"];

                    using (var context = new BlogDBEntities())
                    {
                        // Lấy thông tin người dùng từ cơ sở dữ liệu
                        var user = context.Users.SingleOrDefault(u => u.Username == username);

                        if (user != null)
                        {
                            Session["UserId"] = user.UserId;
                            Session["Username"] = user.Username;
                            Session["ProfilePicture"] = user.ProfilePicture;
                            Session["Role"] = user.Role;

                        }
                    }
                }
                if (Session["Username"] != null)
                {
                    var userImg = Session["ProfilePicture"];
                    if (userImg != null)
                    {
                        string imgUrl = userImg.ToString();

                        avartarimg.ImageUrl = imgUrl;
                    }
                    else
                    {
                        avartarimg.ImageUrl = "images/user.png";
                    }
                    phNotLoggedIn.Visible = false;
                    phLoggedIn.Visible = true;
                }
                else
                {
                    phNotLoggedIn.Visible = true;
                    phLoggedIn.Visible = false;
                }
                string Urole = (string)Session["Role"];

                if (Urole == "Admin")
                {
                    adminPanel.Visible = true;
                }
                else
                {
                    // Ẩn chức năng chỉ dành cho Admin
                    adminPanel.Visible = false;
                }
                LoadDanhSachTheLoai();
            }

        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            if (Request.Cookies["RememberMe"] != null)
            {
                HttpCookie rememberMeCookie = new HttpCookie("RememberMe");
                rememberMeCookie.Expires = DateTime.Now.AddDays(-1); 
                Response.Cookies.Add(rememberMeCookie);
            }
            Session.Abandon();
            Response.Redirect("/");
        }
        private void LoadDanhSachTheLoai()
        {
            using (var context = new BlogDBEntities())
            {
                var theLoaiList = context.Danhmucs.Where( t => t.LoaiDanhmuc.MaLoai == "THE_LOAI").Select(t => new
                {
                    t.TenDanhmuc,
                    t.MaDanhmuc
                }).ToList();

                rptTheLoai.DataSource = theLoaiList;
                rptTheLoai.DataBind();
            }
        }
    }
}