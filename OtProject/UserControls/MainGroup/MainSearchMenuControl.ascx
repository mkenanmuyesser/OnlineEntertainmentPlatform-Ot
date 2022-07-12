<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainSearchMenuControl.ascx.cs"
    Inherits="OtProject.UserControls.MainSearchMenuControl" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<script type="text/javascript">
    function requesting(sender, eventArgs) {
        var context = eventArgs.get_context();
        context["ClientData"] = "ClientData_Passed_To_The_Service";
    }
</script>
<style type="text/css"></style>
<div>
    <div id="topmenu">
        <div style="width: 1024px; margin: 0px auto;">
            <table>
                <tr>
                    <td>
                        <telerik:radautocompletebox id="txtSearch" runat="server" width="500px" height="22px"
                            cssclass="searchclass1" emptymessage="Kişileri ve iddiaları ara" inputtype="Token"
                            skin="Hay" filter="Contains" onclientrequesting="requesting">
                            <WebServiceSettings Path="OtProjectService.asmx" Method="AramaSonuc" />
                        </telerik:radautocompletebox>
                    </td>
                    <td>
                        <telerik:radbutton id="btnSearch" runat="server" buttontype="LinkButton" image-imageurl="Develops/icons/search-logo.png"
                            width="60" height="22" image-enableimagebutton="true" cssclass="searchclass2">
                        </telerik:radbutton>
                    </td>
                </tr>
            </table>
        </div>
        <div style="float: right; margin-top: -30px;">
        </div>
    </div>
    <div id="bottommenu" style="width: 1024px; margin: 0px auto">
        <telerik:radbutton id="btnWithoutClaims" runat="server" text="iddia edenler" skin="Hay"
            buttontype="LinkButton" font-size="11px" postbackurl="~/SearchPage.aspx?par=wclm">
        </telerik:radbutton>
        <telerik:radbutton id="btnWithClaims" runat="server" text="iddiaya girenler" skin="Hay"
            buttontype="LinkButton" font-size="11px" postbackurl="~/SearchPage.aspx?par=woclm">
        </telerik:radbutton>
        <telerik:radbutton id="btnVirtualClaims" runat="server" text="sanal iddialar" skin="Hay"
            buttontype="LinkButton" font-size="11px" postbackurl="~/SearchPage.aspx?par=vclm">
        </telerik:radbutton>
        <telerik:radbutton id="btnRealClaims" runat="server" text="gerçek iddialar" skin="Hay"
            buttontype="LinkButton" font-size="11px" postbackurl="~/SearchPage.aspx?par=rclm">
        </telerik:radbutton>
        <telerik:radbutton id="btnQuestions" runat="server" text="sorular" skin="Hay" buttontype="LinkButton"
            font-size="11px" postbackurl="~/SearchPage.aspx?par=que">
        </telerik:radbutton>
        <telerik:radbutton id="btnSurveys" runat="server" text="anketler" skin="Hay" buttontype="LinkButton"
            font-size="11px" postbackurl="~/SearchPage.aspx?par=srv">
        </telerik:radbutton>
        <telerik:radbutton id="btnGroups" runat="server" text="gruplar" skin="Hay" buttontype="LinkButton"
            font-size="11px" postbackurl="~/SearchPage.aspx?par=grp">
        </telerik:radbutton>
        <telerik:radbutton enablesplitbutton="true" id="SplitButton" autopostback="false"
            runat="server" text="Filtrele" onclientclicked="OnClientClicked1" buttontype="LinkButton"
            skin="Hay" font-size="11px">
        </telerik:radbutton>
        <telerik:radcontextmenu id="cntxtTime" runat="server" onclientitemclicked="OnClientItemClicked"
            skin="Hay" style="right: 39px" >
            <Items>
                <telerik:RadMenuItem Text="Herhangi bir zaman" Font-Size="11px" ImageUrl="../../Develops/icons/time.png">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem Text="Son 1 saat" Font-Size="11px" ImageUrl="../../Develops/icons/time.png">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem Text="Son 24 saat" Font-Size="11px" ImageUrl="../../Develops/icons/time.png">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem Text="Son 1 ay" Font-Size="11px" ImageUrl="../../Develops/icons/time.png">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem Text="Son 1 yıl" Font-Size="11px" ImageUrl="../../Develops/icons/time.png">
                </telerik:RadMenuItem>
            </Items>
        </telerik:radcontextmenu>
        <telerik:radcodeblock id="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                function OnClientClicked1(sender, args) {

                    if (args.IsSplitButtonClick() || !sender.get_commandName()) {
                        var currentLocation = $telerik.getLocation(sender.get_element());
                        var contextMenu = $find("<%=cntxtTime.ClientID%>");
                        contextMenu.showAt(currentLocation.x, currentLocation.y + 22);
                    } else if (sender.get_commandName() == "TransferRight") {

                    }
                    else {

                    }
                }

                function OnClientItemClicked(sender, args) {
                    var itemText = args.get_item().get_text();
                    var splitButton = $find("<%= SplitButton.ClientID %>");
                    if (itemText.toLowerCase() == "transfer right") {
                        transferRight();
                        splitButton.set_text("Transfer Right");
                        splitButton.set_commandName("TransferRight");
                    }
                    else if (itemText.toLowerCase() == "transfer left") {
                        transferLeft();
                        splitButton.set_text("Transfer Left");
                        splitButton.set_commandName("TransferLeft");
                    }
                }
            </script>
        </telerik:radcodeblock>
        <telerik:radbutton enablesplitbutton="true" id="btnMoreOptions" autopostback="false"
            runat="server" text="Daha fazla" onclientclicked="OnClientClicked2" buttontype="LinkButton"
            skin="Hay" font-size="11px">
        </telerik:radbutton>
        <telerik:radcontextmenu id="cntxtMost" runat="server" onclientitemclicked="OnClientItemClicked"
            skin="Hay">
            <Items>
                <telerik:RadMenuItem Text="en beğenilenler" Font-Size="11px" ImageUrl="../../Develops/icons/like.png">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem Text="en çok yorumlananlar" Font-Size="11px" ImageUrl="../../Develops/icons/top-comment.png">
                </telerik:RadMenuItem>
                <telerik:RadMenuItem Text="trend etiketler" Font-Size="11px" ImageUrl="../../Develops/icons/top-label.png">
                </telerik:RadMenuItem>
            </Items>
        </telerik:radcontextmenu>
        <telerik:radcodeblock id="RadCodeBlock2" runat="server">
            <script type="text/javascript">
                function OnClientClicked2(sender, args) {

                    if (args.IsSplitButtonClick() || !sender.get_commandName()) {
                        var currentLocation = $telerik.getLocation(sender.get_element());
                        var contextMenu = $find("<%=cntxtMost.ClientID%>");
                        contextMenu.showAt(currentLocation.x, currentLocation.y + 22);
                    } else if (sender.get_commandName() == "TransferRight") {

                    }
                    else {

                    }
                }

                function OnClientItemClicked(sender, args) {
                    var itemText = args.get_item().get_text();
                    var splitButton = $find("<%= SplitButton.ClientID %>");
                    if (itemText.toLowerCase() == "transfer right") {
                        transferRight();
                        splitButton.set_text("Transfer Right");
                        splitButton.set_commandName("TransferRight");
                    }
                    else if (itemText.toLowerCase() == "transfer left") {
                        transferLeft();
                        splitButton.set_text("Transfer Left");
                        splitButton.set_commandName("TransferLeft");
                    }
                }
            </script>
        </telerik:radcodeblock>
    </div>
</div>
