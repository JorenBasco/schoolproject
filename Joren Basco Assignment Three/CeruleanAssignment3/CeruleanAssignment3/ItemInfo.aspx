<%@ Page Title="" Language="C#" MasterPageFile="~/CeruleanMaster.Master" AutoEventWireup="true" CodeBehind="ItemInfo.aspx.cs" Inherits="CeruleanAssignment3.ItemInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" id="divItemInfo">
        <div>
            <ul id="genreUl" runat="server" class="list-inline">
            </ul>
        </div>
        <div class="col-sm-4">
            <div id="divTitle" runat="server"></div>
            <div>
                <img id="itemImg" runat="server" />
            </div>
            <div id="divDescript" runat="server">
                <p id="description" runat="server">
                </p>
            </div>
            <div>
                <span id="itemInfoPrice" runat="server"></span>
            </div>
            <div id="divQtyAndBtn">
                <div>
                    Quantity:
                    <input type="number" runat="server" id="txtQty" style="margin-bottom: 8px;" min="0" value="1" />
                </div>
                <div>
                    <button id="btnAddCart" runat="server" class="btn btn-success" onserverclick="btnAddCart_ServerClick">Add to Cart</button>
                </div>
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            var userID = '<%=Session["userID"]%>';
            if (userID != "") {
                $("#divQtyAndBtn").show();
            }
            else {
                $("#divQtyAndBtn").hide()
            }
        })
        //$(document).ready(function () {
        //    var cartItem = $(".cartItems");
        //    if (cartItem.length > 0) {
        //        $("#cartModal").modal();
        //    }
        //})
        function addCartModal() {
            var cartItem = $(".cartItems");
            if (cartItem.length > 0) {
                $("#cartModal").modal();
            }
        };
    </script>
</asp:Content>
