<%@ Page Title="" Language="C#" MasterPageFile="~/WallMain.Master" AutoEventWireup="true"
    CodeBehind="SettingsPage.aspx.cs" Inherits="OtProject.Settings" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="UserControls/WallGroup/UserSettingsControl.ascx" TagName="UserSettingsControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middlecontent" runat="server">
    <uc1:UserSettingsControl ID="UserSettingsControl1" runat="server" />
</asp:Content>
