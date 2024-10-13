<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BTLBlog.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="mt-5" style="max-width: 400px;margin:auto">
            <h2 class="text-center">Đăng nhập</h2>
            <div class="form-outline mb-4">
                <asp:Label ID="lblUsername" runat="server" Text="Username:">Tên tài khoản</asp:Label>
                <asp:TextBox ID="txtUsername" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="form-outline mb-4">
                <asp:Label ID="lblPassword" runat="server" Text="Password:">Mật khẩu</asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
            </div>
            <div class="form-outline mb-4">
                <asp:CheckBox class="" ID="chkRememberMe" runat="server" Text="Ghi nhớ tôi" />
             </div>
            <asp:Button ID="btnLogin" runat="server" Text="Đăng nhập" class="btn btn-primary btn-block mb-4 w-100" OnClick="btnLogin_Click" />
            <div class="text-center">
                <span> Chưa có tài khoản ? <a class="" href="Register">Đăng ký</a> </span>
            </div>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</body>
</html>
