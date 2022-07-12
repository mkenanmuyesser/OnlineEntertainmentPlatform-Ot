<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WallMiddleControl.ascx.cs"
    Inherits="OtProject.UserControls.WallMiddleControl" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="StateControl.ascx" TagName="StateControl" TagPrefix="uc1" %>
<style type="text/css">
    
</style>
<asp:Repeater ID="rptFeeds" runat="server" OnItemDataBound="rptFeeds_ItemDataBound">
</asp:Repeater>
