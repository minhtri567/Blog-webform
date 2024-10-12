<%@ Page Title="Thông tin tài khoản" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountInfo.aspx.cs" Inherits="BTLBlog.AccountInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Thông tin tài khoản</h2>
    
    <div class="account-info">
        <p><strong>Tên người dùng:</strong> <asp:Label ID="lblUsername" runat="server" /></p>
        <p><strong>Email:</strong> <asp:Label ID="lblEmail" runat="server" /></p>
        <p><strong>Ngày đăng ký:</strong> <asp:Label ID="lblCreatedDate" runat="server" /></p>
        <p><strong>Thông tin cá nhân:</strong> <asp:Label ID="lblBio" runat="server" /></p>
        
        <asp:Button ID="btnEdit" runat="server" Text="Chỉnh sửa" OnClick="btnEdit_Click" CssClass="btn btn-primary" />
    </div>
</asp:Content>
