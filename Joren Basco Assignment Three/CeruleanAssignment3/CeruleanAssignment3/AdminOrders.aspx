<%@ Page Title="" Language="C#" MasterPageFile="~/CeruleanMaster.Master" AutoEventWireup="true" CodeBehind="AdminOrders.aspx.cs" Inherits="CeruleanAssignment3.AdminOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container bodyframe">
        <asp:DropDownList ID="ddlOrderID" runat="server"></asp:DropDownList>
        <asp:Button ID="btnSelectDDL" runat="server" Text="Select" OnClick="btnSelectDDL_Click" />
        <br />

        <asp:GridView ID="gvOrders" runat="server" OnRowCommand="gvOrders_RowCommand" DataKeyNames="orderItemID">
            <Columns>
                <asp:ButtonField ButtonType="Button" Text="Delete" CommandName="del" />
                <asp:ButtonField ButtonType="Button" Text="Update" CommandName="upd" />
            </Columns>
        </asp:GridView>
        <asp:Panel ID="pnlUpdateOrders" runat="server" Visible="false">
            <table>
                <tr>
                    <td>Order ID:</td>
                    <td><asp:TextBox ID="txtAdminOrderID" runat="server"></asp:TextBox></td>
                </tr>
                                <tr>
                    <td>Order Item ID:</td>
                    <td><asp:TextBox ID="txtAdminOrderItemID" runat="server"></asp:TextBox></td>
                </tr>                <tr>
                    <td>User ID:</td>
                    <td><asp:TextBox ID="txtAdminUserID" runat="server"></asp:TextBox></td>
                </tr>                <tr>
                    <td>Item ID:</td>
                    <td><asp:TextBox ID="txtAdminItemID" runat="server"></asp:TextBox></td>
                </tr>
                                <tr>
                    <td>Item:</td>
                    <td><asp:TextBox ID="txtAdminItem" runat="server"></asp:TextBox></td>
                </tr>
                                <tr>
                    <td>Item Price:</td>
                    <td><asp:TextBox ID="txtAdminItemPrice" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        Quantity:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAdminItemQty" runat="server"></asp:TextBox>
                    </td>
                </tr>
                                <tr>
                    <td>User Email:</td>
                    <td><asp:TextBox ID="txtAdminUserEmail" runat="server"></asp:TextBox></td>
                </tr>
                                <tr>
                    <td>First Name:</td>
                    <td><asp:TextBox ID="txtAdminFirstName" runat="server"></asp:TextBox></td>
                </tr>
                                <tr>
                    <td>Last Name:</td>
                    <td><asp:TextBox ID="txtAdminLastName" runat="server"></asp:TextBox></td>
                </tr>
                                <tr>
                    <td>Address:</td>
                    <td><asp:TextBox ID="txtAdminAddress" runat="server"></asp:TextBox></td>
                </tr>
                                <tr>
                    <td>Phone:</td>
                    <td><asp:TextBox ID="txtAdminPhone" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSaveUpdate" runat="server" Text="Save!" OnClick="btnSaveUpdate_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>

</asp:Content>
