<%@ Page Title="Danh sách bạn bè" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listfriend.aspx.cs" Inherits="BTLBlog.Listfriend" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="nagative-fr">
         <asp:Button ID="btnNguoiLa" runat="server" Text="Gợi ý kết bạn" OnClick="btnNguoiLa_Click" CssClass="ng-nguoila"/>
         <asp:Button ID="btnMoiBan" runat="server" Text="Lời mời kết bạn" OnClick="btnMoiBan_Click" CssClass="ng-cho"/>
         <asp:Button ID="btnLaBan" runat="server" Text="Bạn bè" OnClick="btnLaBan_Click" CssClass="ng-banbe" />
    </div>

    <asp:MultiView ID="mvFriendList" runat="server" ActiveViewIndex="0">
        <!-- View cho Người lạ -->
        <asp:View ID="viewNguoiLa" runat="server">
            <h3>Gợi ý kết bạn</h3>
            <asp:GridView ID="gvNguoiLa" runat="server" AutoGenerateColumns="false" CssClass="table" OnRowCommand="gvNguoiLa_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Username" HeaderText="Tên" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnInviteFriend" runat="server" 
                                Text='<%# Convert.ToInt32(Eval("fr_status")) == 2 ? "Hủy Lời Mời" : "Kết Bạn" %>' 
                                CommandName='<%# Convert.ToInt32(Eval("fr_status")) == 2 ? "CancelInvite" : "InviteFriend" %>'
                                CommandArgument='<%# Eval("UserId") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:View>

        <!-- View cho Mời bạn -->
        <asp:View ID="viewMoiBan" runat="server">
            <h3>Chờ kết bạn</h3>
            <asp:GridView ID="gvMoiBan" runat="server" AutoGenerateColumns="false" OnRowCommand="gvMoiBan_RowCommand">
                <Columns>
                    <asp:BoundField DataField="FriendName" HeaderText="Tên" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnCancelInvite" runat="server" Text="Chấp nhận" CommandName="AcceptInvite" CommandArgument='<%# Eval("UserId") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:View>

        <!-- View cho Bạn bè -->
        <asp:View ID="viewLaBan" runat="server">
            <h3>Bạn bè</h3>
            <asp:GridView ID="gvLaBan" runat="server" AutoGenerateColumns="false" OnRowCommand="gvLaBan_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Tên" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnUnfriend" runat="server" Text="Hủy Kết Bạn" CommandName="Unfriend" CommandArgument='<%# Eval("UserId") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:View>
    </asp:MultiView>
</asp:Content>
