using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTLBlog
{
    public partial class Listfriend : System.Web.UI.Page
    {
        //fr_status : 0 : chưa là bạn , 1 đã là bạn , 2 đã mời kết bạn 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadNguoiLa();
                LoadMoiBan();
                LoadLaBan();
            }
        }
        private void LoadNguoiLa()
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("Default.aspx");
                return;
            }
            int userid = (int)Session["UserId"];
            using (var context = new BlogDBEntities())
            {
                var result = (from user in context.Users.Where( s => s.UserId != userid)
                              join friend in context.Friends    
                              on user.UserId equals friend.UserId 
                              where friend.fr_status != 1 && friend.FriendUserId != userid
                              select new
                              {
                                  friend.fr_status,
                                  user.UserId,
                                  user.Username,
                                  user.ProfilePicture
                              }).ToList();

                 gvNguoiLa.DataSource = result;
                 gvNguoiLa.DataBind();
            }
           
        }

        private void LoadMoiBan()
        {
            int userid = (int)Session["UserId"];
            using (var context = new BlogDBEntities())
            {
                var result = context.Friends.Where(f => f.fr_status == 2 && f.FriendUserId == userid).ToList();

                gvMoiBan.DataSource = result;
                gvMoiBan.DataBind();
            }
        }

        private void LoadLaBan()
        {
            int userid = (int)Session["UserId"];
            using (var context = new BlogDBEntities())
            {
                var result = context.Friends.Where(f => f.fr_status == 1 && f.UserId == userid).ToList();
                gvLaBan.DataSource = result;
                gvLaBan.DataBind();
            }
        }

        protected void btnNguoiLa_Click(object sender, EventArgs e)
        {
            mvFriendList.ActiveViewIndex = 0;
        }

        protected void btnMoiBan_Click(object sender, EventArgs e)
        {
            mvFriendList.ActiveViewIndex = 1;
        }

        protected void btnLaBan_Click(object sender, EventArgs e)
        {
            mvFriendList.ActiveViewIndex = 2;
        }

        protected void gvNguoiLa_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "InviteFriend")
            {
                int userId = (int)Session["UserId"];
                int friendId = Convert.ToInt32(e.CommandArgument);
                
                using (var context = new BlogDBEntities())
                {
                    var friendUser = context.Users.FirstOrDefault(u => u.UserId == friendId);
                    var friendRequest = new Friend
                    {
                        UserId = userId,
                        FriendUserId = friendId,
                        FriendName = friendUser.Username,
                        fr_img_url = friendUser.ProfilePicture,
                        fr_status = 2 
                    };
                    context.Friends.Add(friendRequest);
                    context.SaveChanges();
                }
                LoadNguoiLa();
            }
            else if (e.CommandName == "CancelInvite")
            {
                using (var context = new BlogDBEntities())
                {
                    int userId = (int)Session["UserId"];
                    int friendId = Convert.ToInt32(e.CommandArgument);
                    var invite = context.Friends.FirstOrDefault(f => f.UserId == userId && f.FriendUserId == friendId && f.fr_status == 2);
                    if (invite != null)
                    {
                        context.Friends.Remove(invite);
                    }
                    context.SaveChanges();
                }
            }
            Response.Redirect(Request.RawUrl);
        }

        protected void gvMoiBan_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AcceptInvite")
            {
                int userId = (int)Session["UserId"];
                int friendId = Convert.ToInt32(e.CommandArgument);
                using (var context = new BlogDBEntities())
                {
                    var invite = context.Friends.FirstOrDefault(f => f.UserId == userId && f.FriendId == friendId && f.fr_status == 2);
                    if (invite != null)
                    {
                        invite.fr_status = 1;
                        context.SaveChanges();
                    }
                }
                LoadNguoiLa();
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void gvLaBan_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Unfriend")
            {
                int userId = (int)Session["UserId"];
                int friendId = Convert.ToInt32(e.CommandArgument);
                using (var context = new BlogDBEntities())
                {
                    var friend = context.Friends.FirstOrDefault(f => f.UserId == userId && f.FriendId == friendId && f.fr_status == 0);
                    if (friend != null)
                    {
                        context.Friends.Remove(friend);
                        context.SaveChanges();
                    }
                }
                LoadNguoiLa();
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}