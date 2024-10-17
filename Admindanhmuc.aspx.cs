using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTLBlog
{
    public partial class Admindanhmuc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                LoadLoaiDanhmucCha();
            }
        }
        protected void btn_clear_Click(object sender, EventArgs e)
        {
            // Gọi phương thức LoadData để làm mới dữ liệu trong GridView
            LoadData();
        }
        private void LoadLoaiDanhmucCha()
        {
            using (var context = new BlogDBEntities())
            {
                var loaiDanhmucs = context.LoaiDanhmucs.ToList();

                ddlLoaiDanhmucCha.DataSource = loaiDanhmucs;
                ddlLoaiDanhmucCha.DataBind();

                ddlSuaLoaiDanhmucCha.DataSource = loaiDanhmucs;
                ddlSuaLoaiDanhmucCha.DataBind();
            }
        }
        private void LoadData()
        {
            using (var context = new BlogDBEntities())
            {
                var data = from d in context.Danhmucs
                           join ld in context.LoaiDanhmucs on d.IdLoaiDanhmuc equals ld.LoaiDanhmucId into danhMucLoai
                           from ld in danhMucLoai.DefaultIfEmpty()
                           select new
                           {
                               d.DanhmucId,
                               d.TenDanhmuc,
                               d.MaDanhmuc,
                               TenDanhmucCha = ld != null ? ld.TenLoai : "Không có danh mục cha"
                           };

                gvDanhmuc.DataSource = data.ToList();
                gvDanhmuc.DataBind();


                var loaiDanhmucs = context.LoaiDanhmucs.ToList();
                gvLoaiDanhmuc.DataSource = loaiDanhmucs;
                gvLoaiDanhmuc.DataBind();

                mvDanhmuc.ActiveViewIndex = 0;
            }
        }
        protected void gvLoaiDanhmuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedLoaiDanhmucId = Convert.ToInt32(gvLoaiDanhmuc.SelectedDataKey.Value);

            LoadDanhmucByLoaiDanhmucId(selectedLoaiDanhmucId);
        }
        private void LoadDanhmucByLoaiDanhmucId(int loaiDanhmucId)
        {
            using (var context = new BlogDBEntities())
            {
                var data = from d in context.Danhmucs
                           where d.IdLoaiDanhmuc == loaiDanhmucId
                           join ld in context.LoaiDanhmucs on d.IdLoaiDanhmuc equals ld.LoaiDanhmucId into danhMucLoai
                           from ld in danhMucLoai.DefaultIfEmpty()
                           select new
                           {
                               d.DanhmucId,
                               d.TenDanhmuc,
                               d.MaDanhmuc,
                               TenDanhmucCha = ld != null ? ld.TenLoai : "Không có danh mục cha"
                           };

                gvDanhmuc.DataSource = data.ToList();
                gvDanhmuc.DataBind();
            }
        }
        protected void gvDanhmuc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sua")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                using (var context = new BlogDBEntities())
                {
                    var danhmuc = context.Danhmucs.SingleOrDefault(d => d.DanhmucId == id);
                    if (danhmuc != null)
                    {
                        hfDanhmucId.Value = Convert.ToString(danhmuc.DanhmucId);
                        txtSuaTenLoai.Text = danhmuc.TenDanhmuc;
                        txtSuaMaLoai.Text = danhmuc.MaDanhmuc;
                        ddlSuaLoaiDanhmucCha.SelectedValue = danhmuc.IdLoaiDanhmuc.ToString();

                        // Chuyển đến View chỉnh sửa
                        mvDanhmuc.ActiveViewIndex = 1; // Giả sử View chỉnh sửa là View index 1
                    }
                }

                mvDanhmuc.ActiveViewIndex = 2;
            }
            if (e.CommandName == "Xoa")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                using (var context = new BlogDBEntities())
                {
                    var Danhmuc = context.Danhmucs.SingleOrDefault(ld => ld.DanhmucId == id);
                    if (Danhmuc != null)
                    {
                        context.Danhmucs.Remove(Danhmuc);
                        context.SaveChanges();
                    }
                }
                LoadData();
            }
        }
        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            mvDanhmuc.ActiveViewIndex = 1;
        }

        protected void btnHuyMoi_Click(object sender, EventArgs e)
        {
            mvDanhmuc.ActiveViewIndex = 0;
        }
        protected void btnLuuMoi_Click(object sender, EventArgs e)
        {
            using (var context = new BlogDBEntities())
            {
                var Danhmuc = new Danhmuc
                {
                    TenDanhmuc = txtTenLoai.Text,
                    MaDanhmuc = txtMaLoai.Text,
                    IdLoaiDanhmuc = int.Parse(ddlLoaiDanhmucCha.SelectedValue)
                };

                context.Danhmucs.Add(Danhmuc);
                context.SaveChanges();

                // Cập nhật lại GridView
                LoadData();

                // Chuyển về View danh sách
                mvDanhmuc.ActiveViewIndex = 0;
            }
        }
        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            using (var context = new BlogDBEntities())
            {
                int id = Convert.ToInt32(hfDanhmucId.Value);

                var danhmuc = context.Danhmucs.SingleOrDefault(d => d.DanhmucId == id);

                if (danhmuc != null)
                {
                    // Cập nhật thông tin danh mục
                    danhmuc.TenDanhmuc = txtSuaTenLoai.Text;
                    danhmuc.MaDanhmuc = txtSuaMaLoai.Text;
                    danhmuc.IdLoaiDanhmuc = int.Parse(ddlLoaiDanhmucCha.SelectedValue);

                    context.SaveChanges();

                    // Cập nhật lại GridView
                    LoadData();

                    // Hiển thị thông báo thành công
                    string script = "<script>Custom.Mytoast('Cập nhật thành công!', '/images/success.svg');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "ShowToast", script);

                    // Chuyển về View danh sách
                    mvDanhmuc.ActiveViewIndex = 0;
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