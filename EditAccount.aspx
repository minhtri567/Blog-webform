<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditAccount.aspx.cs" Inherits="BTLBlog.EditAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Chỉnh sửa tài khoản</h2>

    <div class="edit-account-form">
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

        <div>
            <div class="d-flex justify-content-center mb-4">
                <asp:Image runat="server" id="selectedAvatar" class="rounded-circle" style="width: 200px; height: 200px; object-fit: cover;" alt="Avatar" />
            </div>
            <div class="d-flex justify-content-center">
                <div class="btn btn-primary btn-rounded">
                    <label class="form-label text-white m-1" for="MainContent_fileInput" >Chọn tệp</label>
                    <asp:FileUpload runat="server" id="fileInput" class="form-control d-none" accept="image/*" onchange="Custom.displaySelectedImage(event, 'MainContent_selectedAvatar')" />
                </div>
            </div>
        </div>

        <p><strong>Tên người dùng:</strong></p>
        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" />

        <p><strong>Email:</strong></p>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />

        <p><strong>Thông tin cá nhân:</strong></p>
        <asp:TextBox ID="txtBio" runat="server" TextMode="MultiLine" CssClass="form-control" />

        <br />
        <asp:Button ID="btnSave" runat="server" Text="Lưu thay đổi" OnClick="btnSave_Click" CssClass="btn btn-success" />
    </div>
</asp:Content>
