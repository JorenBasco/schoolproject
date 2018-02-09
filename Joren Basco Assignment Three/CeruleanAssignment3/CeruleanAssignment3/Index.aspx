<%@ Page Title="" Language="C#" MasterPageFile="~/CeruleanMaster.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CeruleanAssignment3.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <div id="divDLItems">
        <div class="container" id="divSearchError" runat="server">
            <div id="merchlog"></div>
            <%-- This repeater is just a data thing now :P --%>
            <asp:Repeater ID="homeItemRepeater" runat="server" OnItemCommand="homeItemRepeater_ItemCommand">
                <ItemTemplate>

                        <article class="col-sm-3">
                        <span>
                            <asp:ImageButton ID="imgItem" runat="server" ImageUrl='<%#"\\Merch\\" +Eval("itemImg") %>'
                                CommandArgument='<%#Eval("itemID") %>'  CssClass="img-responsive"/>
                        </span>
                        <br />
                        <asp:LinkButton ID="lnkbtnItem" runat="server" Text='<%#Eval("itemName") %>' CommandArgument='<%#Eval("itemID") %>'></asp:LinkButton>
                        <br />
                        <asp:Label runat="server" Text='<%#"$ "+ Eval("itemPrice") %>'></asp:Label>
                        </article>

                </ItemTemplate>
            </asp:Repeater>


            <script>
                //made this script to make the items more organize 
                $(document).ready(function () { 
                    var merch = $(".col-sm-3");
                    var division = 3; // controls how many item shows in the index page
                    //alert(x);
                    for (var i = 0; i < merch.length; i++) {
                        var element = merch[i];
                        if (i % division == 0) {
                            $("#merchlog").append("<div class='row'>");
                            $("#merchlog").append(element);
                        } else if (i % division == division - 1) {// 2 % 3 = 2 -- 0 index, 2 is 3rd one (for me 2 / 3 = 0 hence remainder is 2)
                            $("#merchlog").append(element);
                            $("#merchlog").append("</div>");
                        }
                        else {
                            $("#merchlog").append(element);
                        }
                    }
                });
                $(document).ready(function () {
                    $("#wrapper").toggleClass("toggled");
                })
            </script>
        </div>
    </div>



</asp:Content>
