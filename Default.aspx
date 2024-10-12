<%@ Page Title="Trang chủ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BTLBlog._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div class="text-center">
            <p class="">Thêm 1 input tạo blog ở đây</p>
            <div class="blog-container" style="display: flex; flex-wrap: wrap; justify-content: center; gap: 20px;">
                <% for (int i = 0; i < 10; i++)
                    {
                                %>
                    <div class="item-link-wrapper" style="position: relative; width: 454px; height: 533px; border: 1px solid black;">
                        <div class="gallery-item-container" style="overflow: hidden; width: 100%; height: 100%; display: block;">
                            <div>
                                <div class="gallery-item-wrapper" style="height: 255px; width: 100%;">
                                    <picture>
                                        <img alt="Do Not Leave Tokyo Before Eating This Ramen" src="https://static.wixstatic.com/media/c22c23_e3b5cb121db549fdbb1590f51d378b8c~mv2.png/v1/fill/w_454,h_255,fp_0.50_0.50,q_95,enc_auto/c22c23_e3b5cb121db549fdbb1590f51d378b8c~mv2.webp" loading="eager" style="width: 100%; height: 255px;">
                                    </picture>
                                </div>
                            </div>
                            <div class="content-section" style="height: 278px; box-sizing: content-box; padding: 15px;">
                                <article style="border-width: 0px;">
                                    <div class="item-header" style="font-size: 12px; display: flex; justify-content: space-between;">
                                        <div class="item-infotime">
                                            <span>Mar 23, 2023</span>
                                            <span> - </span>
                                            <span title="1 min" data-hook="time-to-read">1 min</span>
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
                                        <a class="item-link" href="#">
                                            <div class="item-text" style="font-size: 26px;">
                                                <p>Do Not Leave Tokyo Before Eating This Ramen</p>
                                            </div>
                                        </a>
                                        <div class="item-description" style="font-size: 16px;">
                                            <p>Create a blog post subtitle that summarizes your post in a few short, punchy sentences and entices your audience to continue reading...</p>
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
