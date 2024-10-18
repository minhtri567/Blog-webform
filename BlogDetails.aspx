<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BlogDetails.aspx.cs" Inherits="BTLBlog.BlogDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="cotainer-blog">
            <asp:Image ID="imgBlogTitleImg" runat="server" />
            <asp:Literal ID="ltBlogTitle" runat="server" />
            <asp:Literal ID="ltBlogContent" runat="server" />
    </div>
</asp:Content>
