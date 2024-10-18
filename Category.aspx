<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="BTLBlog.Category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 id="ltCategoryTitle" runat="server"></h1>
        
        <asp:Repeater ID="rptBlogs" runat="server">
            <HeaderTemplate>
                <div class="blogs-header">
                    <h2>Bài viết trong thể loại:</h2>
                </div>
            </HeaderTemplate>
            <ItemTemplate>
                <div class="blog-item">
                    <h3>
                        <a href="/blog/<%= Eval("seo") %>"><%= Eval("BlogTitle") %></a>
                    </h3>
                    <p><%= Eval("summary_ct") %></p>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                <div class="clearfix"></div>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
