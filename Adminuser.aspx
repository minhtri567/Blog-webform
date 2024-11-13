<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Adminuser.aspx.cs" Inherits="BTLBlog.Adminuser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:GridView ID="GridViewUsers" runat="server" AutoGenerateColumns="False" OnRowEditing="GridViewUsers_RowEditing" OnRowDeleting="GridViewUsers_RowDeleting" OnRowUpdating="GridViewUsers_RowUpdating" OnRowCancelingEdit="GridViewUsers_RowCancelingEdit">
        <Columns>
            <asp:BoundField DataField="UserId" HeaderText="User ID" />
            <asp:BoundField DataField="Username" HeaderText="Username" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Role" HeaderText="Role" />
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>

    <asp:TextBox ID="txtUsername" runat="server" placeholder="Username"></asp:TextBox>
    <asp:TextBox ID="txtEmail" runat="server" placeholder="Email"></asp:TextBox>
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
    <asp:TextBox ID="txtRole" runat="server" placeholder="Role"></asp:TextBox>
    <asp:Button ID="btnAddUser" runat="server" Text="Add User" OnClick="btnAddUser_Click" />
</asp:Content>
