<%@ Page Title="" Language="C#" MasterPageFile="~/CeruleanMaster.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="CeruleanAssignment3.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div id="divSignUp" runat="server" class="well">
            <div class="table-centered">
            <b>SIGN UP</b>
            <table>
                <tr>
                    <td>E-mail: </td>
                    <td>
                        <input type="text" id="txtUseremail" name="UserEmail" placeholder="Enter Email here..." onchange="checkEmail()" />
                    </td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td>
                        <input type="text" id="txtPassword" name="UserPass" placeholder="Enter Password here..." />

                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="button" id="btnSign" value="Sign-Up!" runat="server" onserverclick="btnSign_ServerClick" />
                    </td>
                </tr>
            </table>
                </div>
        </div>
        <div id="divCustInfo" runat="server" visible="false" class="well">
            <table class="table-centered">
                <tr>
                    <td>First Name:
                    </td>
                    <td>
                        <input id="txtFirstName" name="firstName" placeholder="Enter First Name..." />
                    </td>
                </tr>
                <tr>
                    <td>Last Name:
                    </td>
                    <td>
                        <input id="txtLastName" name="lastName" placeholder="Enter Last Name..." type="text" />
                    </td>

                </tr>
                <tr>
                    <td>Phone Number:
                    </td>
                    <td>
                        <input id="txtPhone" name="phone" placeholder="Enter Phone #..." type="tel" />
                    </td>
                </tr>
                <tr>
                    <td>Address:
                    </td>
                    <td>
                        <input id="txtAddress" name="address" placeholder="Enter Address..." type="text" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="submit" id="btnSubmitInfo" runat="server" onserverclick="btnSubmitInfo_ServerClick" value="Submit" />
                    </td>
                    <%--onclick="parent.signUpRemove()" --%>
                </tr>
            </table>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $("#txtUseremail").focusout(function () {
                $("#txtUseremail").filter(function () {
                    var email = $("#txtUseremail").val();
                    if (email != "") {
                        var reg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
                        if (!reg.test(email)) {
                            $("#txtUseremail").addClass("validationRed");
                            alert("please enter a valid Email");
                        } else {
                            $("#txtUseremail").addClass("validationGreen");
                        }
                    } else {
                        $("#txtUseremail").addClass("validationRed");
                    }
                })
            })
            $("#txtPassword").focusout(function () {
                $("#txtPassword").filter(function () {
                    var pass = $("#txtPassword").val();
                    if (pass != "") {
                        var reg = /^[a-zA-Z0-9]{8,}?$/;
                        if (!reg.test(pass)) {
                            $("#txtPassword").addClass("validationRed");
                            alert("Enter atleast 9 characters")
                        } else {
                            $("#txtPassword").addClass("validationGreen");
                        }
                    } else {
                        $("#txtPassword").addClass("validationRed");

                    }
                })
            })
            $("#txtFirstName").focusout(function () {
                $("#txtFirstName").filter(function () {
                    var firstname = $("#txtFirstName").val();
                    if (firstname != "") {
                        $("#txtFirstName").addClass("validationGreen");
                    } else {
                        $("#txtFirstName").addClass("validationRed");
                    }
                })
            })
            $("#txtLastName").focusout(function () {
                $("#txtLastName").filter(function () {
                    var lastname = $("#txtLastName").val();
                    if (lastname != "") {
                        $("#txtLastName").addClass("validationGreen");
                    } else {
                        $("#txtLastName").addClass("validationRed");
                    }
                })
            })
            $("#txtPhone").focusout(function () {
                $("#txtPhone").filter(function () {
                    var phone = $("#txtPhone").val();
                    var regex = /^[(]{0,1}[0-9]{3}[)]{0,1}[-\s\.]{0,1}[0-9]{3}[-\s\.]{0,1}[0-9]{4}$/;
                    if (phone != "") {
                        if (!regex.test(phone)) {
                            $("#txtPhone").addClass("validationRed");
                        } else {
                            $("#txtPhone").addClass("validationGreen");
                        }
                    } else {
                        $("#txtPhone").addClass("validationRed");
                    }
                })
            })
            $("#txtAddress").focusout(function () {
                $("#txtAddress").filter(function () {
                    var address = $("#txtAddress").val();
                    var reg = /^[a-zA-Z0-9\s,'-]*$/;
                    if (address != "") {
                        if (!reg.test(address)) {
                            $("#txtAddress").addClass("validationRed");
                        } else {
                            $("#txtAddress").addClass("validationGreen");
                        }
                    } else {
                        $("#txtAddress").addClass("validationRed");
                    }
                })
            })

        })
        $(document).ready(function () {
            $("#btnSubmitInfo").hide();
            var address = $("#txtAddress").val();
            if ($("#txtAddress").hasClass("validationGreen")) {
                $("#btnSubmitInfo").show();
            }
        })
        //function checkEmail() {
        //    var email = $("#txtUseremail").val();
        //    var reg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
        //    if (!reg.test(email)) {
        //        $("#txtUseremail").addClass("validationRed");
        //        alert("BUTT");
        //    } else {
        //        $("#txtUseremail").addClass("validationBlue");
        //    }
        //}

    </script>
</asp:Content>
