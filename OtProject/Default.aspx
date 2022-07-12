<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="OtProject.Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="UserControls/MainGroup/MainSearchControl.ascx" TagName="MainSearchControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .citylblclass
        {
            margin-left: 5px;
            float: left;
            font-family: 'Source Sans Pro' , sans-serif;
            color: #C0C0C0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="topcontent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="middlecontent" runat="server">
    <uc2:MainSearchControl ID="msControl" runat="server" />
</asp:Content>
