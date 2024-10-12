<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditAccount.aspx.cs" Inherits="BTLBlog.EditAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Chỉnh sửa tài khoản</h2>

    <div class="edit-account-form">
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

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
