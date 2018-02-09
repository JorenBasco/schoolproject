<%@ Page Title="" Language="C#" MasterPageFile="~/CeruleanMaster.Master" AutoEventWireup="true" CodeBehind="EmailConfirm.aspx.cs" Inherits="CeruleanAssignment3.EmailConfirm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container bodyframe">
        <div class="well">
        <asp:Button ID="btnConfirm" runat="server" Text="Confirm Email" OnClick="btnConfirm_Click" />

        </div>
    </div>
    <script>
    </script>
</asp:Content>
