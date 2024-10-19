<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BlogDetails.aspx.cs" Inherits="BTLBlog.BlogDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="cotainer-blog">
        <div class="header-blog">
            <div class="cateblog">
                <asp:Repeater ID="rptDanhMuc" runat="server">
                    <ItemTemplate>
                        <div class="danh-muc-item">
                            <a href="/the-loai/<%# Eval("MaDanhmuc") %>"><%# Eval("TenDanhmuc") %></a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <asp:Literal ID="ltBlogTitle" runat="server" />
            <div class="avatar-poster mt-4">
                <div class="d-flex align-items-center">
                    <div class="avatar">
                        <asp:HyperLink runat="server" ID="linkposter">
                          <asp:Image runat="server" ID="avartarposter" />
                        </asp:HyperLink>
                    </div>
                    <div class="name">
                        <asp:HyperLink runat="server" ID="linkposter1">
                        </asp:HyperLink>
                    </div>
                </div>
                <asp:Label runat="server" ID="blogcreactat"></asp:Label>
            </div>
        </div>
        <hr />
        <div class="content-blog">
            <asp:Literal ID="ltBlogContent" runat="server" />
        </div>
        <div class="footer-blog">

        </div>
        <div class="comment-blog">
            <div class="mt-5">
                <h4 class="mb-3">Bình luận</h4>
                <hr />
                <div class="form-group">
                    <asp:TextBox ID="txtCommentContent" CssClass="form-control" TextMode="MultiLine" Rows="3" runat="server" placeholder="Nhập bình luận của bạn..." />
                </div>
                <asp:Button ID="btnSubmitComment" CssClass="btn btn-primary mt-3 d-block ms-auto" runat="server" Text="Gửi bình luận" OnClick="btnSubmitComment_Click" />
            </div>
            <div class="mt-5">
                <asp:Repeater ID="rptComments" runat="server">
                    <ItemTemplate>
                        <div class="media mb-4">
                            <div class="acc-comment">
                                <a href='<%# ResolveUrl("~/AccountInfo/" + Eval("UserId")) %>'>
                                    <img class="mr-3 rounded-circle" src="<%# Page.ResolveClientUrl("/" + Eval("ProfilePicture")) %>" alt="<%# Eval("UserName") %>">
                                </a>
                                <div class="infor-user-comment">
                                    <a href='<%# ResolveUrl("~/AccountInfo/" + Eval("UserId")) %>'>
                                        <span class="mt-0"><%# Eval("UserName") %></span>
                                    </a>
                                    <small class="text-muted"><%# Eval("CreatedDate", "{0:dd/MM/yyyy HH:mm}") %></small>
                                </div>
                                
                            </div>
                            <div class="media-body">
                                <p><%# Eval("Content") %></p>
                                <hr />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
