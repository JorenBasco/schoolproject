<%@ Page Title="" Language="C#" MasterPageFile="~/CeruleanMaster.Master" AutoEventWireup="true" CodeBehind="AdminUser.aspx.cs" Inherits="CeruleanAssignment3.AdminUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container bodyframe">

        <asp:GridView ID="gvUsers" runat="server" OnRowCommand="gvUsers_RowCommand" DataKeyNames="userID">
            <Columns>
                <asp:ButtonField ButtonType="Button" Text="Delete" CommandName="del" />
                <asp:ButtonField ButtonType="Button" Text="Update" CommandName="upd" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnAddUser" runat="server" Text="Add new User?" OnClick="btnAddUser_Click" />
        <asp:Panel ID="pnlUserInfo" runat="server" Visible="false">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblUserID" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>EMAIL: 
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Password: 
                    </td>
                    <td>
                        <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Security Level: 
                    </td>
                    <td>
                        <asp:TextBox ID="txtSecurity" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>

        </asp:Panel>
    </div>


</asp:Content>
