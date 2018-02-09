<%@ Page Title="" Language="C#" MasterPageFile="~/CeruleanMaster.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="CeruleanAssignment3.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="well">
        <div id="divUserInfo" runat="server">
            <table class="table-centered">
                <tr>
                    <td>Email: 
                    </td>
                    <td>
                        <input type="text" id="txtEmail" runat="server" readonly="true" />
                    </td>
                </tr>
                <tr id="passwordColumn" runat="server">
                    <td>Password: 
                    </td>
                    <td>
                        <input type="text" id="txtPassword" runat="server" readonly="true" />
                    </td>
                    <td>
                        <a runat="server" id="btnChangePassword" onserverclick="btnChangePassword_ServerClick">Change Password?</a>
                    </td>
                </tr>
            </table>
            <table id="passChange" runat="server" visible="false" class="table-centered">
                <tr>
                    <td>Enter Old Password:
                    </td>
                    <td>
                        <input type="text" id="txtOldpass" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Enter new Password:
                    </td>
                    <td>
                        <input type="text" id="txtNewPass" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="button" runat="server" id="btnSavePass" onserverclick="btnSavePass_ServerClick" value="Save" />
                    </td>
                    <td>
                        <input type="button" runat="server" id="btnCancelPass" onserverclick="btnCancelPass_ServerClick" value="Cancel" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="divCustomerInfo" runat="server">
            <table class="table-centered">
                <tr>
                    <td>First Name: </td>
                    <td>
                        <input type="text" id="txtFirst" runat="server" readonly="true" /></td>
                    <td><a id="editCustomerInfo" runat="server" onserverclick="editCustomerInfo_ServerClick">Edit info</a></td>
                </tr>
                <tr>
                    <td>Last Name: </td>
                    <td>
                        <input type="text" id="txtLast" runat="server" readonly="true" /></td>
                </tr>
                <tr>
                    <td>Phone Number: </td>
                    <td>
                        <input type="text" id="txtPhone" runat="server" readonly="true" /></td>
                </tr>
                <tr>
                    <td>Address: </td>
                    <td>
                        <input type="text" id="txtAddress" runat="server" readonly="true" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Visible="false" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" Visible="false" />
                    </td>
                </tr>
            </table>    
          <div runat="server" id="divReVerifyEmail" visible="false">
              <a runat="server" id="btnReVerify" onserverclick="btnReVerify_ServerClick">Send Verification Email</a>
        </div>
        </div>
            </div>
    </div>
    <script>
        $(document).ready(function () {
            $("#btnReVerify").click(function () {
                alert("Verification Email Sent!");
            })
        })
    </script>
</asp:Content>
