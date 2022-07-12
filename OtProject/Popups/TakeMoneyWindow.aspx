<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TakeMoneyWindow.aspx.cs"
    Inherits="OtProject.Popups.TakeMoneyWindow" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        function requesting(sender, eventArgs) {
            var context = eventArgs.get_context();
            context["ClientData"] = "ClientData_Passed_To_The_Service";
        }
        function OnClientValueChanged(sender, args) {
            document.getElementById("lblPoka").innerHTML = sender.get_value().toString();
        }
        function CloseRadWindow() {
            GetRadWindow().close();
        }
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow;
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
            return oWindow;
        }
    </script>
    <style type="text/css">
        body, .lblclass, a
        {
            margin: 0px;
            font-size: 14px;
            font-family: Arial;
            color: #79cf83;
            text-decoration: none;
            font-size: 12px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div style="border-top-width: 1px; border-top-style: solid;">
        <span style="font-size: 16px">Borç iste</span>
        <table class="lblclass">
            <tr>
                <td>
                    Ne kadar gerekli
                </td>
                <td>
                    <div style="float: left;">
                        <telerik:RadSlider ID="sldPoka" runat="server" MinimumValue="1" Skin="Hay" OnClientValueChanged="OnClientValueChanged">
                        </telerik:RadSlider>
                    </div>
                    <div style="float: left;">
                        <asp:Label ID="lblPoka" runat="server">1</asp:Label></div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="lnkCreate" runat="server" Font-Size="14px" OnClick="lnkCreate_Click">İste</asp:LinkButton>
                </td>
                <td>
                    <asp:LinkButton ID="lnkCancel" runat="server" Font-Size="14px" OnClick="lnkCancel_Click">İptal Et</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
