using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTLBlog
{
    public partial class Adminloaidanhmuc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        private void LoadData()
        {
            using (var context = new BlogDBEntities())
            {
                // Lấy dữ liệu từ bảng LoaiDanhmuc
                var loaiDanhmucs = context.LoaiDanhmucs.ToList();

                gvLoaiDanhmuc.DataSource = loaiDanhmucs;
                gvLoaiDanhmuc.DataBind();
                mvLoaiDanhmuc.ActiveViewIndex = 0;
            }
        }
        protected void gvLoaiDanhmuc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Sua")
            {

                using (var context = new BlogDBEntities())
                {
                    var loaiDanhmuc = context.LoaiDanhmucs.SingleOrDefault(ld => ld.LoaiDanhmucId == id);
                    if (loaiDanhmuc != null)
                    {
                        hLoaiDanhmucId.Value = Convert.ToString(loaiDanhmuc.LoaiDanhmucId);
                        txtSuaTenLoai.Text = loaiDanhmuc.TenLoai;
                        txtSuaMaLoai.Text = loaiDanhmuc.MaLoai;
                    }
                }

                mvLoaiDanhmuc.ActiveViewIndex = 2;
            }
            if (e.CommandName == "Xoa")
            {
                using (var context = new BlogDBEntities())
                {
                    var loaiDanhmuc = context.LoaiDanhmucs.SingleOrDefault(ld => ld.LoaiDanhmucId == id);
                    if (loaiDanhmuc != null)
                    {
                        context.LoaiDanhmucs.Remove(loaiDanhmuc);
                        context.SaveChanges();
                    }
                }
                LoadData();
            }
        }
        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            mvLoaiDanhmuc.ActiveViewIndex = 1; 
        }

        protected void btnHuyMoi_Click(object sender, EventArgs e)
        {
            mvLoaiDanhmuc.ActiveViewIndex = 0; 
        }
        protected void btnLuuMoi_Click(object sender, EventArgs e)
        {
            using (var context = new BlogDBEntities())
            {
                var loaiDanhmuc = new LoaiDanhmuc
                {
                    TenLoai = txtTenLoai.Text,
                    MaLoai = txtMaLoai.Text
                };

                context.LoaiDanhmucs.Add(loaiDanhmuc);
                context.SaveChanges();

                // Cập nhật lại GridView
                LoadData();

                // Chuyển về View danh sách
                mvLoaiDanhmuc.ActiveViewIndex = 0;
            }
        }
        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            using (var context = new BlogDBEntities())
            {
                int id = Convert.ToInt32(hLoaiDanhmucId.Value);

                var danhmuc = context.LoaiDanhmucs.SingleOrDefault(d => d.LoaiDanhmucId == id);

                if (danhmuc != null)
                {
                    danhmuc.TenLoai = txtSuaTenLoai.Text;
                    danhmuc.MaLoai = txtSuaMaLoai.Text;

                    context.SaveChanges();

                    // Cập nhật lại GridView
                    LoadData();

                    // Hiển thị thông báo thành công
                    string script = "<script>Custom.Mytoast('Cập nhật thành công!', '/images/success.svg');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "ShowToast", script);

                    // Chuyển về View danh sách
                    mvLoaiDanhmuc.ActiveViewIndex = 0;
                }
                else
                {
                    // Trường hợp danh mục không tồn tại
                    string script = "<script>Custom.Mytoast('Danh mục không tồn tại!', '/images/error.svg');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "ShowToast", script);
                }
            }
        }
    }
}