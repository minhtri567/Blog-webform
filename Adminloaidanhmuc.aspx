<%@ Page Language="C#"  MasterPageFile="~/Admin.Master"  CodeBehind="Adminloaidanhmuc.aspx.cs" Inherits="BTLBlog.Adminloaidanhmuc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div class="ad-container-dm">
        <asp:MultiView ID="mvLoaiDanhmuc" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewDanhSach" runat="server">
                <asp:GridView ID="gvLoaiDanhmuc" runat="server" AutoGenerateColumns="false" CssClass="table table-striped ad-table-data" OnRowCommand="gvLoaiDanhmuc_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="LoaiDanhmucId" HeaderText="ID" />
                        <asp:BoundField DataField="TenLoai" HeaderText="Tên Loại" />
                        <asp:BoundField DataField="MaLoai" HeaderText="Mã Loại" />
                        <asp:BoundField DataField="MaLoai" HeaderText="Mã Loại" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnSua" runat="server" Text="Sửa" CommandName="Sua" CommandArgument='<%# Eval("LoaiDanhmucId") %>' />
                                <asp:Button ID="btnXoa" runat="server" Text="Xóa" CommandName="Xoa" CommandArgument='<%# Eval("LoaiDanhmucId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Button ID="btnThemMoi" runat="server" Text="Thêm mới" OnClick="btnThemMoi_Click" />
            </asp:View>
            <asp:View ID="ViewThemMoi" runat="server">
                <h2>Thêm mới Loại Danh mục</h2>
                <label>Tên loại</label>
                <asp:TextBox ID="txtTenLoai" runat="server"/>
                <asp:RequiredFieldValidator ControlToValidate="txtTenLoai" ErrorMessage="Tên loại không được để trống" runat="server" />
                <br />
                <label>Mã loại</label>
                <asp:TextBox ID="txtMaLoai" runat="server" />
                <asp:RequiredFieldValidator ControlToValidate="txtMaLoai" ErrorMessage="Mã loại không được để trống" runat="server" />
                <br />
                <asp:Button ID="btnLuuMoi" runat="server" Text="Lưu" OnClick="btnLuuMoi_Click" />
                <asp:Button ID="btnHuyMoi" runat="server" Text="Hủy" OnClick="btnHuyMoi_Click" />
            </asp:View>
            <asp:View ID="ViewSua" runat="server">
                <h2>Sửa Loại Danh mục</h2>
                <asp:Label ID="lblSuaTenLoai" runat="server" Text="Tên Loại: "></asp:Label>
                <asp:TextBox ID="txtSuaTenLoai" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtSuaTenLoai" ErrorMessage="Tên loại không được để trống" runat="server" />
                <br />
                <asp:Label ID="lblSuaMaLoai" runat="server" Text="Mã Loại: "></asp:Label>
                <asp:TextBox ID="txtSuaMaLoai" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtSuaMaLoai" ErrorMessage="Mã loại không được để trống" runat="server" />
                <br />
                <asp:Button ID="btnCapNhat" runat="server" Text="Cập nhật" OnClick="btnCapNhat_Click" />
                <asp:Button ID="btnHuySua" runat="server" Text="Hủy" OnClick="btnHuyMoi_Click" />
            </asp:View>
            <asp:View ID="ViewXoa" runat="server">
                <!-- Xóa LoaiDanhmuc -->
            </asp:View>
        </asp:MultiView>
     </div>
</asp:Content>