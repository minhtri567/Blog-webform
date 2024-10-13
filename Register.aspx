<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BTLBlog.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng ký</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="mt-5" style="max-width:400px;margin : auto;">
            <h2 class="text-center">Đăng ký tài khoản</h2>
            <div class="form-outline mb-4">
                <asp:Label ID="lblUsername" runat="server">Tên tài khoản</asp:Label>
                <asp:TextBox ID="txtUsername" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="form-outline mb-4">
                <asp:Label ID="lblEmail" runat="server">Email</asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="form-outline mb-4">
                <asp:Label ID="lblPassword" runat="server" >Mật khẩu</asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
            </div>
            <div class="form-outline mb-4">
                <asp:Label ID="lblConfirmPassword" runat="server">Nhập lại mật khẩu</asp:Label>
                <asp:TextBox ID="txtConfirmPassword" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
            </div>
            <asp:Button ID="btnRegister" runat="server" Text="Đăng ký" class="btn btn-primary btn-block mb-4 w-100" OnClick="btnRegister_Click" />
            <span> Đã có tài khoản ? <a class="" href="Login">Đăng Nhập</a> </span>
            <br />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</body>
</html>
