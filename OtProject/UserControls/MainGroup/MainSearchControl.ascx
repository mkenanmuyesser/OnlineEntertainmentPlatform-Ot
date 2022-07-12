<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainSearchControl.ascx.cs"
    Inherits="OtProject.UserControls.MainSearchControl" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<script type="text/javascript">
    function requesting(sender, eventArgs) {
        var context = eventArgs.get_context();
        context["ClientData"] = "ClientData_Passed_To_The_Service";
    }
</script>
<style type="text/css">
    #mainlogo
    {
        margin-top: 200px;
    }
    .search
    {
        border: 1px solid #6fcd78;
        margin-bottom: 1px;
    }
    #motto
    {
        font-family: 'BenchNine' , sans-serif;
        font-size: 14px;
        margin-top: -2px;
        color: #279e33;
    }
</style>
<div id="mainlogo">
    <center>
        <a id="mainlink" href="javascript:void(0);"></a>
        <br />
        <a href="Default.aspx">
            <img src="/Develops/images/otapoka-logo.png" />
        </a>
        <%--<telerik:RadToolTip runat="server" ID="ToolTip1" Skin="Default" TargetControlID="mainlink"
            IsClientID="true" ShowEvent="OnClick" Width="230px" Height="10px" VisibleOnPageLoad="true"
            Position="TopCenter" RelativeTo="Element" 
            HideDelay="50000">
            Dünyanın ilk iddia arama motoruna hoşgeldiniz.<br />
            Hemen ilgi alanınıza göre arama yapıp eğlenceye başlayın.
        </telerik:RadToolTip>--%>
        <p id="motto">
            Benim Babam Senin Babanı Döver !
        </p>
        <telerik:RadAutoCompleteBox ID="txtSearch" runat="server" EmptyMessage="Kişileri,iddiaları,soruları ve grupları ara"
            InputType="Token" Skin="Hay" Filter="Contains" Width="400" Height="24" OnClientRequesting="requesting">
            <WebServiceSettings Path="../../OtProjectService.asmx" Method="AnaAramaSonuc" />
        </telerik:RadAutoCompleteBox>
        <br />
        <br />
        <table>
            <tr>
                <td>
                    <telerik:RadButton ID="btnSearch" runat="server" Text="Otapoka'da ara" Width="120px"
                        Skin="Hay" OnClick="btnSearch_Click">
                    </telerik:RadButton>
                </td>
                <td>
                    <div style="width: 10px;">
                    </div>
                </td>
                <td>
                    <telerik:RadButton ID="btnReady" runat="server" Text="Hazır mısın ?" Width="120px"
                        Skin="Hay" onclick="btnReady_Click">
                    </telerik:RadButton>
                </td>
            </tr>
        </table>
    </center>
</div>
