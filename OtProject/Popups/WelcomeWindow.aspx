<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WelcomeWindow.aspx.cs"
    Inherits="OtProject.Popups.Welcome" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            font-size: 14px;
            font-family: Arial;
            width: 680px;
            height: 500px;
        }
        .style1
        {
            width: 100%;
        }
        .style2
        {
        }
        .style4
        {
            height: 386px;
            width: 672px;
        }
        .style5
        {
            height: 56px;
        }
        .style6
        {
            width: 170px;
            height: 39px;
        }
    </style>
    <script type="text/javascript">
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
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <table class="style1">
        <tr>
            <td class="style5">
                &nbsp;&nbsp;&nbsp;
                <img class="style6" src="../Develops/images/otapoka-logo-kucuk.png" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <span style="margin-top: -15; font-size: 36px">Hoşgeldiniz</span>
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;&nbsp;&nbsp; <span>Nasıl kullanacağınızı aşağıdaki video ile öğrenin.</span>
                <br />
                <br />
                <center>
                    <object width="640" height="360">
                        <param name="movie" value="http://www.youtube-nocookie.com/v/ncqQBoxPz3Y?version=3&amp;hl=tr_TR&amp;rel=0">
                        </param>
                        <param name="allowFullScreen" value="false"></param>
                        <param name="allowscriptaccess" value="always"></param>
                        <embed src="http://www.youtube-nocookie.com/v/ncqQBoxPz3Y?version=3&amp;hl=tr_TR&amp;rel=0"
                            type="application/x-shockwave-flash" width="640" height="360" allowscriptaccess="always"
                            allowfullscreen="true"></embed></object>
                </center>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <br />
                &nbsp;&nbsp;&nbsp;
                <telerik:RadButton ID="btnGo" runat="server" Text="Artık kullanmaya başlayabilirsiniz."
                    Skin="Hay" OnClick="btnGo_Click">
                </telerik:RadButton>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
