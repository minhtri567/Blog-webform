<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BTLBlog.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Đăng nhập</h2>
            <asp:Label ID="lblUsername" runat="server" Text="Username:">Tên tài khoản</asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblPassword" runat="server" Text="Password:">Mật khẩu</asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:CheckBox ID="chkRememberMe" runat="server" Text="Ghi nhớ tôi" />
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Đăng nhập" OnClick="btnLogin_Click" />
            <br />
            <span> Chưa có tài khoản ? <a class="" href="Register">Đăng ký</a> </span>
            <br />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
