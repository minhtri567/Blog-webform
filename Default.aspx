<%@ Page Title="Trang chủ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BTLBlog._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div class="text-center">
            <div class="blog-container" style="display: flex; flex-wrap: wrap; justify-content: center; gap: 20px;">
                <% 
                    var blogs = LoadBlogs();

                    foreach (var blog in blogs)
                    {
                %>
                    <div class="item-link-wrapper" style="position: relative; width: 454px; height: 533px; border: 1px solid black;">
                        <div class="gallery-item-container" style="overflow: hidden; width: 100%; height: 100%; display: block;">
                            <div>
                                <div class="gallery-item-wrapper" style="height: 255px; width: 100%;">
                                    <picture>
                                        <img alt="<%= blog.BlogTitle %>" src="<%= blog.BlogTitleImg %>" loading="eager" style="width: 100%; height: 255px;">
                                    </picture>
                                </div>
                            </div>
                            <div class="content-section" style="height: 278px; box-sizing: content-box; padding: 15px;">
                                <article style="border-width: 0px;">
                                    <div class="item-header" style="font-size: 12px; display: flex; justify-content: space-between;">
                                        <div class="item-infotime">
                                            <span><%= blog.BlogCreatedDate?.ToString("HH:mm dd/MM/yyyy") %></span>
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
                                        <a class="item-link" href="<%= ResolveUrl("~/blog/" + blog.seo) %>">
                                            <div class="item-text" style="font-size: 26px;">
                                                <p><%= blog.BlogTitle %></p>
                                            </div>
                                        </a>
                                        <div class="item-description" style="font-size: 16px;">
                                            <p><%= blog.summary_ct.Substring(0, Math.Min(100, blog.summary_ct.Length)) %></p>
                                        </div>
                                    </div>
                                </article>
                            </div>
                        </div>
                    </div>
                <% 
                    }
                %>
            </div>
        </div>

    </main>

</asp:Content>
