<%@ Page Title="" Language="C#" MasterPageFile="~/CeruleanMaster.Master" AutoEventWireup="true" CodeBehind="OrderReview.aspx.cs" Inherits="CeruleanAssignment3.OrderReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container bodyframe">
        <div runat="server" id="divOrderReview"></div>
        <asp:Xml ID="xmlReviewOrder" runat="server" TransformSource="~/ReviewOrder.xslt">
        </asp:Xml>
    </div>
</asp:Content>
