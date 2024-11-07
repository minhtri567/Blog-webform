<%@ Page Title="Các bài đăng của tôi" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserBlogs.aspx.cs" Inherits="BTLBlog.UserBlogs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <main>
        <div class="text-center">
            <div class="blog-container" style="display: flex; flex-wrap: wrap; justify-content: center; gap: 20px;">
                <asp:Repeater ID="rptBlogs" runat="server">
                    <ItemTemplate>
                        <div class="item-link-wrapper" style="position: relative; width: 454px; height: 533px; border: 1px solid black;">
                            <div class="gallery-item-container" style="overflow: hidden; width: 100%; height: 100%; display: block;">
                                <div>
                                    <div class="gallery-item-wrapper" style="height: 255px; width: 100%;">
                                        <picture>
                                            <img alt='<%# Eval("BlogTitle") %>' src='<%# Eval("BlogTitleImg") %>' loading="eager" style="width: 100%; height: 255px;">
                                        </picture>
                                    </div>
                                </div>
                                <div class="content-section" style="height: 278px; box-sizing: content-box; padding: 15px;">
                                    <article style="border-width: 0px;">
                                        <div class="item-header" style="font-size: 12px; display: flex; justify-content: space-between;">
                                            <div class="item-infotime">
                                                <span><%# Eval("BlogCreatedDate", "{0:HH:mm dd/MM/yyyy}") %></span>
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
                                            <a class="item-link" href='<%# ResolveUrl("~/blog/" + Eval("Seo")) %>'>
                                                <div class="item-text" style="font-size: 26px;">
                                                    <p><%# Eval("BlogTitle") %></p>
                                                </div>
                                            </a>
                                            <div class="item-description" style="font-size: 16px;">
                                                <p><%# Eval("Summary", "{0}") %></p>
                                            </div>
                                        </div>
                                    </article>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </main>

</asp:Content>
