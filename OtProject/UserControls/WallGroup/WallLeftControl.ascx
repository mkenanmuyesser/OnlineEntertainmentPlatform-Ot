<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WallLeftControl.ascx.cs"
    Inherits="OtProject.UserControls.WallLeftControl" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
    body
    {
        font-size: 11px;
        font-family: Arial;
        color: Gray;
    }
    
    a img
    {
        border: 0;
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
        font-size: 12px;
        font-weight: bold;
    }
    
    .lblclass2
    {
        color: #279e33;
    }
    
    .lblclass3
    {
        color: Gray;
        font-size: 9px;
    }
    
    .lblclass4
    {
        font-style: normal;
        font-size: 11px;
    }
    
    .lblclass5
    {
        color: #279e33;
        font-size: 9px;
    }
</style>
<div style="width: 250px;">
    <telerik:RadWindowManager ID="windowmanager" runat="server" ReloadOnShow="true" ShowContentDuringLoad="False"
        Skin="Hay" VisibleOnPageLoad="false" Style="z-index: 8000;" DestroyOnClose="False"
        Animation="Fade" AnimationDuration="500" Modal="true">
    </telerik:RadWindowManager>
    <windows>
        <telerik:radwindow runat="server" ID="msgWindow" Skin="Hay" NavigateUrl ="~/Popups/SendMessageWindow.aspx" Modal="true"
         OpenerElementID  ="lnkSendMessage"              
                Width = "500"
                Height = "100"
                Behaviors ="Close"
                VisibleStatusbar = "false"
                VisibleTitlebar = "false"></telerik:radwindow>
                <telerik:radwindow runat="server" ID="reportWindow" Skin="Hay" NavigateUrl ="~/Popups/ReportWindow.aspx" Modal="true"
         OpenerElementID  ="lnkComplaint"              
                Width = "500"
                Height = "150"
                Behaviors ="Close"
                VisibleStatusbar = "false"
                VisibleTitlebar = "false"></telerik:radwindow>
                  <telerik:radwindow runat="server" ID="refereeWindow" Skin="Hay" NavigateUrl ="~/Popups/AssignRefereeWindow.aspx" Modal="true"
         OpenerElementID  ="lnkAssignRefree"              
                Width = "500"
                Height = "120"
                Behaviors ="Close"
                VisibleStatusbar = "false"
                VisibleTitlebar = "false"></telerik:radwindow>
                   <telerik:radwindow runat="server" ID="pokaWindow" Skin="Hay" NavigateUrl ="~/Popups/TakeMoneyWindow.aspx" Modal="true"
         OpenerElementID  ="lnkTakePoka"              
                Width = "500"
                Height = "120"
                Behaviors ="Close"
                VisibleStatusbar = "false"
                VisibleTitlebar = "false"></telerik:radwindow>
                <telerik:radwindow runat="server" ID="interestWindow" Skin="Hay" NavigateUrl ="~/Popups/AddInterestWindow.aspx" Modal="true"
         OpenerElementID  ="lnkAddInterest"              
                Width = "500"
                Height = "120"
                Behaviors ="Close"
                VisibleStatusbar = "false"
                VisibleTitlebar = "false"></telerik:radwindow>
        </windows>
    <div>
        <div style="width: 60px; float: left;">
            <telerik:RadBinaryImage ID="imgUser" runat="server" Width="50" Height="50" ImageUrl="~/Develops/images/boy.jpg" />
        </div>
        <div style="background-color: #fdfee0;">
            <div style="float: left; width: 190px;">
                <div style="float: left; width: 70px;">
                    <asp:LinkButton ID="lnkUserName" runat="server" Font-Bold="true">Maniacboxer</asp:LinkButton>
                    <br />
                    <asp:Label ID="lblCity" runat="server">Ankara</asp:Label>&nbsp;-&nbsp;<asp:Label
                        ID="lblAge" runat="server">30</asp:Label>&nbsp;<asp:Label ID="lblGender" runat="server"
                            Text="Label">e</asp:Label>
                </div>
                <div style="float: right; width: 90px;">
                    <asp:Label ID="lblFollowers" runat="server">Takip Eden : 225</asp:Label><br />
                    <asp:Label ID="lblFollows" runat="server">Takip Ettiği : 322</asp:Label>
                </div>
                <br />
            </div>
            <br />
            <asp:LinkButton ID="lnkProfile" runat="server" CssClass="btnclass">Profilim</asp:LinkButton>
            &nbsp;
            <asp:LinkButton ID="lnkSettings" runat="server" CssClass="btnclass" PostBackUrl="~/SettingsPage.aspx">Düzenle</asp:LinkButton>
        </div>
        <br />
        <asp:Panel id="buttongroup" runat="server">
            <a href="#" id="lnkSendMessage" class="lblclass2">Mesaj Gönder</a>&nbsp;
            <asp:LinkButton ID="lnkFollow" runat="server" CssClass="lblclass2" OnClick="lnkFollow_Click">Takip Et</asp:LinkButton>&nbsp;
            <a href="#" id="lnkAssignRefree" class="lblclass2">Hakem Ata</a>&nbsp; <a href="#"
                id="lnkTakePoka" class="lblclass2">Borç İste</a>&nbsp; &nbsp;&nbsp; <a href="#" id="lnkComplaint"
                    style="font-weight: bold; font-style: italic;">!</a>
        </asp:Panel>
        <div id="about" style="margin: 5px 0px 5px 0px;">
            <div style="width: 250px; background-color: #f7f7f7; margin-bottom: 5px;">
                Hakkında</div>
            <asp:Label ID="lblAbout" runat="server" Font-Bold="False" Font-Names="Arial" ForeColor="Black">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi luctus nisi et orci euismod vitae molestie arcu aliquam. Phasellus gravida tincidunt tortor vel u</asp:Label>
        </div>
        <div style="width: 250px; height: 1px; background-color: Black;">
        </div>
        <div id="notification" style="margin: 5px 0px 5px 0px;">
            <div style="width: 250px; background-color: #f7f7f7; margin-bottom: 5px;">
                Bildirimler
            </div>
            <telerik:RadRotator runat="server" ID="rotReal" Width="250px" ItemWidth="250px" Height="100px"
                ItemHeight="40px" Skin="Hay" ScrollDirection="Up" FrameDuration="2000">
                <ItemTemplate>
                    <div>
                        <div style="width: 30px; float: left; padding: 5px;">
                            <center>
                                <telerik:RadBinaryImage ID="imgUser" runat="server" Width="30" Height="30" ImageUrl='<%# Eval("UyeDetayResim") %>' />
                            </center>
                        </div>
                        <div style="width: 200px; height: 60px; float: left; padding: 5px; background-color: #f7f7f7;
                            border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #DCDCDC;">
                            <a href='../../WallPage.aspx?ID=<%# Eval("UyeID") %>' id="lnkUserName" style="font-weight: bold;">
                                <%# Eval("UyeDetayTakmaAd")%></a>
                            <asp:Label ID="lblDescription" runat="server" CssClass="lblclass4"><%# Eval("BildirimTanim")%></asp:Label>
                        </div>
                    </div>
                </ItemTemplate>
            </telerik:RadRotator>
        </div>
        <div style="width: 250px; height: 1px; background-color: Black;">
        </div>
        <div id="interests" style="margin: 5px 0px 5px 0px;">
            <div style="width: 250px; background-color: #f7f7f7; margin-bottom: 5px;">
                İlgi Alanları <span style="float: right;"><a href="#" id="lnkAddInterest" class="lblclass2">
                    İlgi Alanı Ekle</a></span></div>
            <telerik:RadTagCloud runat="server" ID="rptInterests" DataTextField="IlgiAlanTanim"
                DataValueField="ID" DataWeightField="Izlenme" Skin="Hay" AutoPostBack="True"
                OnItemClick="rptInterests_ItemClick">
            </telerik:RadTagCloud>
            <span style="float: right;">
                <asp:LinkButton ID="lnkMoreInterest" runat="server" CssClass="lblclass2" OnClick="lnkMoreInterest_Click">Daha Fazla</asp:LinkButton></span>
            <br />
        </div>
        <div style="width: 250px; height: 1px; background-color: Black;">
        </div>
        <div id="virtualbets" style="margin: 5px 0px 5px 0px;">
            <div style="width: 250px; background-color: #f7f7f7; margin-bottom: 5px;">
                Sanal İddialar</div>
            <asp:LinkButton ID="LinkButton8" runat="server" CssClass="lblclass2" PostBackUrl="~/WallPage.aspx?par=wiwin">Kazandığı İddialar</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton9" runat="server" CssClass="lblclass2" PostBackUrl="~/WallPage.aspx?par=wilos">Kaybettiği İddialar</asp:LinkButton><br />
            <asp:LinkButton ID="LinkButton10" runat="server" CssClass="lblclass2" PostBackUrl="~/WallPage.aspx?par=wiwa">İzlediği İddialar</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;
            <asp:LinkButton ID="LinkButton11" runat="server" CssClass="lblclass2" PostBackUrl="~/WallPage.aspx?par=wili">Beğendiği İddialar</asp:LinkButton><br />
        </div>
        <div style="width: 250px; height: 1px; background-color: Black;">
        </div>
        <div id="realbets" style="margin: 5px 0px 5px 0px;">
            <div style="width: 250px; background-color: #f7f7f7; margin-bottom: 5px;">
                Gerçek İddialar</div>
            <asp:LinkButton ID="LinkButton7" runat="server" CssClass="lblclass2" PostBackUrl="~/WallPage.aspx?par=rewin">Kazandığı İddialar</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton12" runat="server" CssClass="lblclass2" PostBackUrl="~/WallPage.aspx?par=relos">Kaybettiği İddialar</asp:LinkButton><br />
            <asp:LinkButton ID="LinkButton13" runat="server" CssClass="lblclass2" PostBackUrl="~/WallPage.aspx?par=rere">Hakem Olduğu İddialar</asp:LinkButton>&nbsp; &nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton14" runat="server" CssClass="lblclass2" PostBackUrl="~/WallPage.aspx?par=rewa">İzleyici Olduğu İddialar</asp:LinkButton><br />
        </div>
        <div style="width: 250px; height: 1px; background-color: Black;">
        </div>
        <div id="questions" style="margin: 5px 0px 5px 0px;">
            <div style="width: 250px; background-color: #f7f7f7; margin-bottom: 5px;">
                Sorular</div>
            <asp:LinkButton ID="LinkButton15" runat="server" CssClass="lblclass2" PostBackUrl="~/WallPage.aspx?par=que">Sorduğu Sorular</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton16" runat="server" CssClass="lblclass2" PostBackUrl="~/WallPage.aspx?par=sur">Yaptığı Anketler</asp:LinkButton><br />
        </div>
        <div style="width: 250px; height: 1px; background-color: Black;">
        </div>
        <div id="maybeknow" style="margin: 5px 0px 5px 0px;">
            <div style="width: 250px; background-color: #f7f7f7; margin-bottom: 5px;">
                Benzer Kişiler</div>
            <!-- buraya koddan rasgele 20 kişi civarı bir item ekliycez -->
            <telerik:RadRotator runat="server" ID="rotSimilar" Height="70px" ItemHeight="70px"
                ItemWidth="70" Skin="Transparent" ScrollDirection="Left" FrameDuration="1000"
                Width="250px">
                <ItemTemplate>
                    <a href="#" style="border: 0px;">
                        <telerik:RadBinaryImage ID="imgUser" runat="server" Width="60" Height="60" ImageUrl='<%# Eval("Resim") %>' />
                    </a>
                </ItemTemplate>
            </telerik:RadRotator>
        </div>
        <div style="width: 250px; height: 1px; background-color: Black;">
        </div>
        <div id="commercialdiv1" style="margin: 5px 0px 5px 0px;">
            <div style="width: 250px; background-color: #f7f7f7; margin-bottom: 5px;">
                Reklamlar</div>
        </div>
    </div>
</div>
