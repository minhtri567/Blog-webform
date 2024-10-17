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
                // Kiểm tra xem LoaiDanhmuc có tồn tại với TenLoai hoặc MaLoai này chưa
                var dataExist = context.LoaiDanhmucs.Any(l => l.MaLoai == txtMaLoai.Text || l.TenLoai == txtTenLoai.Text);

                if (dataExist)
                {
                    string script = "<script>Custom.Mytoast('Loại danh mục đã tồn tại!', '/images/error.svg');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "ShowToast", script);
                }
                else
                {
                    // Nếu không tồn tại, thêm mới
                    var loaiDanhmuc = new LoaiDanhmuc
                    {
                        TenLoai = txtTenLoai.Text,
                        MaLoai = txtMaLoai.Text
                    };

                    context.LoaiDanhmucs.Add(loaiDanhmuc);
                    context.SaveChanges();

                    // Cập nhật lại GridView
                    LoadData();

                    // Hiển thị thông báo thành công
                    string script = "<script>Custom.Mytoast('Thêm thành công!', '/images/success.svg');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "ShowToast", script);

                    // Chuyển về View danh sách
                    mvLoaiDanhmuc.ActiveViewIndex = 0;
                }
            }
        }
    }
}