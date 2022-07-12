<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssignRefereeWindow.aspx.cs"
    Inherits="OtProject.Popups.AssignRefereeWindow" %>

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
    <telerik:radscriptmanager id="RadScriptManager1" runat="server">
    </telerik:radscriptmanager>
    <div style="border-top-width: 1px; border-top-style: solid;">
        <span style="font-size: 16px">Hakem Ata</span>
        <table class="lblclass">
            <tr>
                <td>
                    Gerçek Iddia seç
                </td>
                <td>
                    <telerik:radcombobox id="cmbClaim" runat="server" skin="Hay"></telerik:radcombobox>
                </td>
            </tr>
            <tr>
                <td>
                    Ortak arkadaşlardan birini seç
                </td>
                <td>
                    <telerik:radcombobox id="cmbReferee" runat="server" skin="Hay"></telerik:radcombobox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="lnkCreate" runat="server" Font-Size="14px" OnClick="lnkCreate_Click">Ata</asp:LinkButton>
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
