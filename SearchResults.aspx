<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchResults.aspx.cs" Inherits="BTLBlog.SearchResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1>Kết quả tìm kiếm</h1>
        <asp:PlaceHolder ID="phNoResults" runat="server">
            <h2>Không có kết quả</h2>
        </asp:PlaceHolder>

        <asp:Repeater ID="rptSearchResults" runat="server">
            <ItemTemplate>
                <div class="search-item">
                    <h3>
                        <a href='<%# "/blog/" + Eval("seo") %>'><%# Eval("BlogTitle") %></a>
                    </h3>
                    <p><%# Eval("summary_ct") %></p>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
