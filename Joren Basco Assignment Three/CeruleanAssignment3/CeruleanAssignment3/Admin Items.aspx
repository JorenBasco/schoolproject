<%@ Page Title="" Language="C#" MasterPageFile="~/CeruleanMaster.Master" AutoEventWireup="true" CodeBehind="Admin Items.aspx.cs" Inherits="CeruleanAssignment3.Admin_Items" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container bodyframe">
        <asp:GridView ID="gvItems" runat="server" OnRowCommand="GridView1_RowCommand"
             DataKeyNames="itemID" OnPageIndexChanging="gvItems_PageIndexChanging" AllowPaging="true" PageSize="5" AllowSorting="True" OnSorting="gvItems_Sorting">
            <Columns>
                <asp:ButtonField ButtonType="Button" Text="Delete" CommandName="del" />
                <asp:ButtonField ButtonType="Button" Text="Update" CommandName="upd" />
            </Columns>
        </asp:GridView>
        <a id="btnAddnew" runat="server" onserverclick="btnAddnew_ServerClick">Add new Item</a>
        <asp:Panel ID="pnlItemUpdate" runat="server" Visible="false">
            <table class="table-centered">
                <tr>
                    <td>Item ID:</td>
                    <td>
                        <asp:TextBox ID="txtItemID" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Item Name:</td>
                    <td>
                        <asp:TextBox ID="txtItemName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Item Description:</td>
                    <td>
                        <asp:TextBox ID="txtItemDescript" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Item Price:</td>
                    <td>
                        <asp:TextBox ID="txtItemPrice" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Item Genre:</td>
                    <td>
                        <asp:TextBox ID="txtItemGenre" runat="server" ToolTip="Use / to divide genres" placeholder="Use / for multi genre"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Item Image:</td>
                    <td>
                        <asp:FileUpload ID="flItemImage" runat="server" /></td>
                    <td>
                        <asp:Image ID="imgItem" runat="server" Height="50" Width="50" />
                    </td>
                </tr>
                <tr>
                    <td>Item Stock:</td>
                    <td>
                        <asp:TextBox ID="txtStock" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="Save"  OnClick="btnSave_Click"/></td>
                    <td>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" /></td>
                </tr>
            </table>
        </asp:Panel>
    </div>

</asp:Content>
