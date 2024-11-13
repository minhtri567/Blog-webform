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
                <div class="item-link-wrapper" style="position: relative; width: 454px; height: 533px; border: 1px solid black;">
                    <div class="gallery-item-container" style="overflow: hidden; width: 100%; height: 100%; display: block;">
                        <div>
                            <div class="gallery-item-wrapper" style="height: 255px; width: 100%;">
                                <picture>
                                    <img alt="<%# Eval("BlogTitle") %>" src="<%# Eval("BlogTitleImg") %>" loading="eager" style="width: 100%; height: 255px;">
                                </picture>
                            </div>
                        </div>
                        <div class="content-section" style="height: 278px; box-sizing: content-box; padding: 15px;">
                            <article style="border-width: 0px;">
                                <div class="item-header" style="font-size: 12px; display: flex; justify-content: space-between;">
                                    <div class="item-infotime">
                                        <span><%# Eval("BlogCreatedDate") %></span>
                                    </div>
                                    <div>
                                        <button class="btn-share" type="button">
                                            <span class="">
                                                <i class="fa-solid fa-ellipsis-vertical"></i>
                                            </span>
                                        </button>
                                    </div>
                                </div>
                                <div class="item-title">
                                    <a class="item-link" href='<%# "/blog/" + Eval("seo") %>'>
                                        <div class="item-text" style="font-size: 26px;">
                                            <p><%# Eval("BlogTitle") %></p>
                                        </div>
                                    </a>
                                    <div class="item-description" style="font-size: 16px;">
                                        <p><%# Eval("summary_ct") %></p>
                                    </div>
                                </div>
                            </article>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                <div class="clearfix"></div>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
