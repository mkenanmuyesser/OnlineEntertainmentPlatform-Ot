<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddInterestWindow.aspx.cs"
    Inherits="OtProject.Popups.AddInterestWindow" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
        <span style="font-size: 16px">İlgi Alanı Ekle</span>
        <table class="lblclass">
            <tr>
                <td>
                    İlgi Alan Ekle
                </td>
                <td>
                    <telerik:radtextbox id="txtAddInterest" runat="server" skin="Hay">
                    </telerik:radtextbox>
                    <telerik:radbutton id="btnAddInterest" runat="server" onclick="btnAddInterest_Click"
                        text="Ekle">
                    </telerik:radbutton>
                </td>
            </tr>
            <tr>
                <td>
                    İlgi Alanları
                </td>
                <td>
                    <telerik:radautocompletebox id="txtInterests" runat="server" emptymessage="Kişileri ve iddiaları ara"
                        inputtype="Token" skin="Hay" filter="Contains" width="400" height="24" onclientrequesting="requesting">
                        <WebServiceSettings Path="../OtProjectService.asmx" Method="IlgiAlanSonuc" />
                    </telerik:radautocompletebox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="lnkCreate" runat="server" Font-Size="14px" OnClick="lnkCreate_Click">Oluştur</asp:LinkButton>
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
