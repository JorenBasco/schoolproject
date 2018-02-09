<%@ Page Title="" Language="C#" MasterPageFile="~/CeruleanMaster.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="CeruleanAssignment3.LogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="well">
            <div class="table-centered">
                <b>LOGIN </b>
                <table>
                    <tr>
                        <td>E-Mail:
                        </td>
                        <td>
                            <input type="text" id="txtLogInEmail" runat="server" />
                        </td>
                    </tr>
                    <tr id="passwordColumn" runat="server">
                        <td>Password:
                        </td>
                        <td>
                            <input type="password" id="txtLogInPassword" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="submit" id="btnLogIn" runat="server" onserverclick="btnLogIn_ServerClick" value="Log In!" />
                        </td>
                        <%--onclick="parent.logInRemove();"--%>
                        <td>
                            <input type="button" id="btnGetPass" runat="server" visible="false" onserverclick="btnGetPass_ServerClick" value="Get Password!" />
                            <a href="#" id="btnForgot" runat="server" onserverclick="btnForgot_ServerClick">Forgot Password?</a>
                        </td>
                    </tr>
                </table>
            </div>
            <asp:Label ID="lbltest" runat="server" />
        </div>
    </div>
</asp:Content>
