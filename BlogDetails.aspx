<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BlogDetails.aspx.cs" Inherits="BTLBlog.BlogDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Repeater ID="rptDanhMuc" runat="server">
            <ItemTemplate>
                <div class="danh-muc-item">
                    <a href="/the-loai/<%# Eval("MaDanhmuc") %>"><%# Eval("TenDanhmuc") %></a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="cotainer-blog">
            <asp:Image ID="imgBlogTitleImg" runat="server" />
            <asp:Literal ID="ltBlogTitle" runat="server" />
            <asp:Literal ID="ltBlogContent" runat="server" />
    </div>
</asp:Content>
