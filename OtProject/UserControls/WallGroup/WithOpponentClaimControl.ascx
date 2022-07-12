<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WithOpponentClaimControl.ascx.cs"
    Inherits="OtProject.UserControls.WithOpponentClaimControl" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="ClaimDoCommentControl.ascx" TagName="ClaimDoCommentControl" TagPrefix="uc1" %>
<%@ Register Src="ClaimCommentsControl.ascx" TagName="ClaimCommentsControl" TagPrefix="uc2" %>
<style type="text/css">
    body
    {
        font-size: 11px;
        font-family: Arial;
       
    }
    
    a
    {
        text-decoration: none;
        color: Black;
    }
    
    a:hover
    {
        text-decoration: underline;
    }
    
    .btnclass
    {
        text-decoration: none;
        color: #279e33;
    }
    
    .lblclass1
    {
        color: #279e33;
        font-size: 14px;
        font-weight: bold;
    }
    
    
    .lblclass3
    {
        color: Gray;
        font-size:11px;
    }
    
    .lblclass4
    {
        font-style: normal;
        font-size: 12px;
    }
</style>
<div style="width: 700px; height: 250px;">
    <div style="width: 100%;">
       <div style="width: 700px; height: 160px;">
           <div id="leftside">
                <div style="width: 55px; float: left;">
                    <center>
                        <telerik:RadBinaryImage ID="imgUser" runat="server" Width="50" Height="50" ImageUrl="~/Develops/images/boy.jpg" />
                    </center>
                </div>
                <div style="width: 240px; float: left; padding: 5px;">
                    <div style="background-color: #fdfee0;">
                        <asp:LinkButton ID="lnkUserName1" runat="server" Font-Bold="true">Maniacboxer</asp:LinkButton>
                        <br />
                        <asp:Label ID="lblCity" runat="server">Ankara</asp:Label>&nbsp;-&nbsp;<asp:Label
                            ID="lblAge" runat="server">30</asp:Label>&nbsp;<asp:Label ID="lblGender" runat="server"
                                Text="Label">e</asp:Label>
                        <br />
                        <asp:LinkButton ID="lnkSendMessage" runat="server" CssClass="btnclass">Mesaj Gönder</asp:LinkButton>
                        &nbsp;
                        <asp:LinkButton ID="lnkFollow" runat="server" CssClass="btnclass">Takip Et</asp:LinkButton>
                        <br />
                    </div>
                    <div>
                        <asp:Label ID="lblComment1" runat="server" CssClass="lblclass3">Bence Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi luctus nisi et orci euismod vitae molestie arcu aliquam. Phasellus gravida tincidunt tortor vel u</asp:Label>
                    </div>
                    <div style="float: right;">
                        <asp:LinkButton ID="lnkComplaint" runat="server" Font-Bold="true" Font-Italic="true">!</asp:LinkButton>
                        &nbsp;
                        <asp:ImageButton ID="imgCorpAnswer" runat="server" ImageUrl="../Develops/icons/comment-remove-icon.png" />
                    </div>
                    <br />
                    <div style="float: left;">
                        <asp:LinkButton ID="lnkShare" runat="server" CssClass="lblclass2">Destek Ver</asp:LinkButton>&nbsp;
                        <asp:LinkButton ID="lnkComment" runat="server" CssClass="lblclass2">Beğen</asp:LinkButton>
                    </div>
                </div>
            </div>
            <div id="middleside" style="width: 90px; float: left;">
                <center>
                    <span style="font-style: italic; font-size: 20px; color: #279e33;">
                        <img src="../../Develops/icons/vs-b.jpg" />
                    </span>
                    <br />
                    <asp:LinkButton ID="LinkButton4" runat="server" CssClass="btnclass">İzle</asp:LinkButton>
                    &nbsp;
                    <asp:LinkButton ID="LinkButton5" runat="server" CssClass="btnclass">Paylaş</asp:LinkButton>
                    <br />
                    <asp:Label ID="lblEstimatedTime" runat="server" Font-Size="10px">Kalan süre 3 saat 25 dk.</asp:Label>
                    <telerik:RadHtmlChart runat="server" ID="pieChart" Width="60" Height="60" Skin="Office2010Silver"
                        Font-Size="1px">
                        <Legend>
                            <Appearance Visible="false" />
                        </Legend>
                        <PlotArea>
                            <Series>
                                <telerik:PieSeries StartAngle="0">
                                    <LabelsAppearance Visible="false" />
                                    <Items>
                                        <telerik:SeriesItem YValue="80" />
                                        <telerik:SeriesItem YValue="20" />
                                    </Items>
                                </telerik:PieSeries>
                            </Series>
                        </PlotArea>
                    </telerik:RadHtmlChart>
                    Ortadaki POKA<br />
                    <asp:Label ID="Label5" runat="server" Font-Size="12px" ForeColor="#279e33">12500 Poka</asp:Label>
                    <br />
                    <asp:Label ID="Label6" runat="server" Font-Size="10px" ForeColor="#279e33">125 Kişi</asp:Label>
                </center>
            </div>
            <div id="rightside">
                <div style="width: 240px; float: left; padding: 5px;">
                    <div style="background-color: #fdfee0;">
                        <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="true">Maniacboxer</asp:LinkButton>
                        <br />
                        <asp:Label ID="Label1" runat="server">Ankara</asp:Label>&nbsp;-&nbsp;<asp:Label ID="Label2"
                            runat="server">30</asp:Label>&nbsp;<asp:Label ID="Label3" runat="server" Text="Label">e</asp:Label>
                        <br />
                        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btnclass">Mesaj Gönder</asp:LinkButton>
                        &nbsp;
                        <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btnclass">Takip Et</asp:LinkButton>
                        <br />
                    </div>
                    <div>
                        <asp:Label ID="lblComment2" runat="server" CssClass="lblclass3">Bence Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi luctus nisi et orci euismod vitae molestie arcu aliquam. Phasellus gravida tincidunt tortor vel u</asp:Label>
                    </div>
                    <div style="float: left;">
                        <asp:LinkButton ID="LinkButton6" runat="server" Font-Bold="true" Font-Italic="true">!</asp:LinkButton>
                        &nbsp;
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../Develops/icons/comment-remove-icon.png" />
                    </div>
                    <br />
                    <div style="float: right;">
                        <asp:LinkButton ID="LinkButton7" runat="server" CssClass="lblclass2">Destek Ver</asp:LinkButton>&nbsp;
                        <asp:LinkButton ID="LinkButton8" runat="server" CssClass="lblclass2">Beğen</asp:LinkButton>
                    </div>
                </div>
                <div style="width: 55px; float: left;">
                    <center>
                        <telerik:RadBinaryImage ID="RadBinaryImage1" runat="server" Width="50" Height="50"
                            ImageUrl="~/Develops/images/boy.jpg" />
                    </center>
                </div>
            </div>
        </div>
    </div>
    <div style="width: 700px; height: 4px; background-color: White;">
    </div>
    <div>
        <uc2:ClaimCommentsControl ID="clControl" runat="server" />
 </div>
    <div style="width: 700px; height: 4px; background-color: White;">
    </div>
    <div>
        <uc1:ClaimDoCommentControl ID="cldControl" runat="server" />
    </div>
</div>
<hr />
<br />
