<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="New-blog.aspx.cs" Inherits="BTLBlog.new_blog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlCreateBlog" CssClass="container-newblog" runat="server">
        <h2>Tạo bài viết mới</h2>
        <div class="container-input">
            <label class="form-text">Tiêu đề bài viết:</label>
            <asp:TextBox ID="txtBlogTitle" runat="server" CssClass="form-control" />
        </div>
        <div class="container-input">
            <label class="form-text">Hình ảnh tiêu đề:</label>
            <asp:FileUpload ID="fileBlogTitleImg" runat="server" CssClass="form-control" />
       </div>
        <div class="container-input">
            <label class="form-text">Danh mục:</label>
            <asp:ListBox ID="ddlBlogDanhmuc" runat="server" CssClass="form-control" SelectionMode="Multiple">
            </asp:ListBox>
        </div>

        <div class="ckeditor" >
            <label class="form-text">Nội dung bài viết:</label>
            <asp:TextBox ID="txtBlogContent" TextMode="MultiLine" runat="server" />
        </div>
        <br />

        <asp:Button ID="btnSaveBlog" runat="server" Text="Lưu bài viết" OnClick="btnLuu_Click" CssClass="btn btn-primary" />
    </asp:Panel>
    <script src="/Scripts/ckeditor/ckeditor.js"></script>
    <script>
        ClassicEditor
            .create(document.querySelector('#MainContent_txtBlogContent'))
            .catch(error => {
                console.error(error);
            });

        document.querySelector('form').onsubmit = function () {
            document.querySelector('#MainContent_txtBlogContent').value = editor.getData();
        };
    </script>
</asp:Content>
