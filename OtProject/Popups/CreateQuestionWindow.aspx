<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateQuestionWindow.aspx.cs"
    Inherits="OtProject.Popups.CreateQuestionWindow" %>

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
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div>
        <span style="font-size: 16px">Yeni Soru Oluştur</span>
        <table class="lblclass">
            <tr>
                <td>
                    Soru
                </td>
                <td>
                    <telerik:RadTextBox ID="txtQuestionName" runat="server" Skin="Forest" DisplayText=""
                        Width="400" Height="30" Font-Size="9px" MaxLength="160" TextMode="Multiline">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Soru Bitiş Tarihi
                </td>
                <td>
                    <telerik:RadComboBox ID="cmbDate" runat="server" Skin="Hay">
                    </telerik:RadComboBox>
                </td>
            </tr>
               <tr>
                <td>
                    İlgi Alan Ekle
                </td>
                <td>
                    <telerik:RadTextBox ID="txtAddInterest" runat="server" Skin="Hay">
                    </telerik:RadTextBox>
                    <telerik:RadButton ID="btnAddInterest" runat="server" OnClick="btnAddInterest_Click"
                        Text="Ekle">
                    </telerik:RadButton>
                </td>
            </tr>
            <tr>
                <td>
                    İlgi Alanları
                </td>
                <td>
                    <telerik:RadAutoCompleteBox ID="txtInterests" runat="server" EmptyMessage="İlgi alanları ara"
                        InputType="Token" Skin="Hay" Filter="Contains" Width="400" height="24" 
                        OnClientRequesting="requesting">
                        <WebServiceSettings Path="../OtProjectService.asmx" Method="IlgiAlanSonuc" />
                    </telerik:RadAutoCompleteBox>
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
