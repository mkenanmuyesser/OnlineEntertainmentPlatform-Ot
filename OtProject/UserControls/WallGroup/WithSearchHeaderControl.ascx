<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WithSearchHeaderControl.ascx.cs"
    Inherits="OtProject.UserControls.WithSearchHeaderControl" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<script type="text/javascript">
    function requesting(sender, eventArgs) {
        var context = eventArgs.get_context();
        context["ClientData"] = "ClientData_Passed_To_The_Service";
    }
</script>
<style type="text/css">
     @font-face
    {
        font-family: "BenchNine";
        src: url('../../Develops/fonts/BenchNine-Regular.ttf');
    }
    #headertop
    {
        background-color: #279e33;
        height: 30px;
    }
    .topclass
    {
        margin-top: 3px;
    }
    .topclass2
    {
        margin-top: 10px;
    }
</style>
<div id="header" style="width: 100%; position: fixed; z-index: 5;">
    <div id="headertop">
        <div style="width: 1024px; margin: 0px auto;">
             <div id="logodiv">
            <a href="../../Default.aspx" style=" font-size:26px ;text-decoration: none;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a>
        </div>
            <div style="float: left;">
                <span style="margin-top: 6px; float: left; font-family: 'BenchNine' , sans-serif;
                    margin-left: -15px; font-size: 12px; color: White;">Benim Babam Senin Babanı Döver
                    !</span> &nbsp;
                <telerik:RadButton ID="btnMessage" runat="server" CssClass="topclass" Skin="Hay"
                    AutoPostBack="true" ButtonType="LinkButton" Width="18" Height="22" BorderStyle="None">
                  <Icon PrimaryIconUrl="~/Develops/icons/green-mail-icon.png" PrimaryIconLeft="5px">
                    </Icon>
                </telerik:RadButton>
                <telerik:RadButton ID="btnNotification" runat="server" CssClass="topclass" Skin="Hay"
                    AutoPostBack="true" ButtonType="LinkButton" Width="18" Height="22" BorderStyle="None">
                    <Icon PrimaryIconUrl="~/Develops/icons/green-chart-icon.png" PrimaryIconLeft="5px">
                    </Icon>
                </telerik:RadButton>
                &nbsp;
            </div>
            <div style="margin: 5px 0px 0px 20px; float: left;">                
                <telerik:RadAutoCompleteBox ID="txtSearch" runat="server" EmptyMessage="Kişileri ve iddiaları ara"
                    InputType="Token" Skin="Hay" Filter="Contains" Width="452" Height="24" OnClientRequesting="requesting">
                    <WebServiceSettings Path="OtProjectService.asmx" Method="AramaSonuc" />
                </telerik:RadAutoCompleteBox>
            </div>
            <div style="padding-top: 6px; float: right; color: White;">
                <img src="../../Develops/icons/yen-coins-icon.png" />
                <asp:Label ID="lblPokaScore" runat="server" Text="50.100 POKA"></asp:Label>
                &nbsp;&nbsp;&nbsp;
            </div>
        </div>
    </div>
    <div id="headerbottom">
    </div>
</div>
