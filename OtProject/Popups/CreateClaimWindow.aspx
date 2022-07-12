﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateClaimWindow.aspx.cs"
    Inherits="OtProject.Popups.CreateClaimWindow" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function OnClientValueChanged(sender, args) {
            document.getElementById("lblPoka").innerHTML = sender.get_value().toString();
        }
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
    <div style="border-top-width: 1px; border-top-style: solid;">
        <span style="font-size: 16px">Yeni İddia Aç</span>
        <table class="lblclass">
            <tr>
                <td>
                    İddia Tipi
                </td>
                <td>
                    <telerik:RadButton ID="btnClaimType" runat="server" ToggleType="CustomToggle" ButtonType="ToggleButton"
                        AutoPostBack="false" CssClass="lblclass">
                        <ToggleStates>
                            <telerik:RadButtonToggleState Text="Sanal iddia" CssClass="lblclass" />
                            <telerik:RadButtonToggleState Text="Gerçek iddia" CssClass="lblclass" />
                        </ToggleStates>
                    </telerik:RadButton>
                </td>
            </tr>
            <tr>
                <td>
                    İddia Süresi
                </td>
                <td>
                    <telerik:RadComboBox ID="cmbDate" runat="server" Skin="Hay">
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td>
                    İddia Açıklaması
                </td>
                <td>
                    <telerik:RadTextBox ID="txtComment" runat="server" Skin="Forest" DisplayText="Bence ... "
                        Width="400" Height="30" Font-Size="9px" MaxLength="160" TextMode="MultiLine">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Kanıtlar
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    Ortaya Konulacak Poka
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
                    Diğer seçenekler
                </td>
                <td>
                    <telerik:RadButton ID="btn18" runat="server" ToggleType="CustomToggle" ButtonType="ToggleButton"
                        AutoPostBack="false" CssClass="lblclass">
                        <ToggleStates>
                            <telerik:RadButtonToggleState Text="Normal" CssClass="lblclass" />
                            <telerik:RadButtonToggleState Text="Müstehcen (+18)" CssClass="lblclass" />
                        </ToggleStates>
                    </telerik:RadButton>
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
