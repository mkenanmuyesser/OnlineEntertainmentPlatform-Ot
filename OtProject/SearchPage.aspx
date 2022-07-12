<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="SearchPage.aspx.cs" Inherits="OtProject.SearchPage" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="UserControls/MainGroup/MainSearchMenuControl.ascx" TagName="MainSearchMenuControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function showWindow() {
            var oWindowCust = $find('<%= shrWindow.ClientID %>');
            oWindowCust.show();
        }   
    </script>
    <style type="text/css">
        .searchclass1
        {
            margin-top: 12px;
        }
        .searchclass2
        {
            margin-top: 1px;
        }
        body
        {
            font-size: 11px;
            font-family: Arial;
            color: Gray;
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
        
        .img1class:hover
        {
            background-image: url('~/Develops/icons/virtual.png');
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="topcontent" runat="server">
    <uc1:MainSearchMenuControl ID="smControl" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="middlecontent" runat="server">
    <telerik:RadWindowManager ID="windowmanager" runat="server" ReloadOnShow="true" ShowContentDuringLoad="False"
        Skin="Hay" VisibleOnPageLoad="false" Style="z-index: 8000;" DestroyOnClose="False"
        Animation="Fade" AnimationDuration="500" Modal="true">
        <Windows>
            <telerik:RadWindow runat="server" ID="shrWindow" Skin="Hay" NavigateUrl="~/Popups/ShareWindow.aspx"
                Modal="true" Width="500" Height="100" Behaviors="Close" VisibleStatusbar="false"
                VisibleTitlebar="false">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <div style="width: 1024px; margin: 0px auto; height: 400px;">
        <div style="width: 1024px; margin: 0px auto">
            <telerik:RadListView ID="rptResults" runat="server" OnItemDataBound="rptResults_ItemDataBound"
                AllowPaging="True">
                <ItemTemplate>
                    <table style="width: 600px; height: 10px;">
                        <tr>
                            <td>
                                <asp:LinkButton ID="lnkPage" runat="server" CssClass="lblclass2"></asp:LinkButton>
                                <asp:Repeater ID="rptKeywords" runat="server">
                                    <ItemTemplate>
                                        <a href="#" style="color: #279e33">
                                            <img src="Develops/icons/ticket-small-icon.png" />
                                            <%# Eval("IlgiAlanTanim")%></a>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <div style="float: right;">
                                    <asp:Label ID="lblPoka" runat="server"></asp:Label>
                                    <%-- <asp:Image ID="imgOpen" runat="server" Width="16" Height="16" ImageUrl="~/Develops/icons/lock-g.png" />
                                    <asp:Image ID="imgType1" runat="server" Width="16" Height="16" Visible="false" ImageUrl="~/Develops/icons/virtual-g.png"
                                        onmouseover="this.src='/Develops/icons/virtual.png'" onmouseout="this.src='/Develops/icons/virtual-g.png'" />
                                    <asp:Image ID="imgType2" runat="server" Width="16" Height="16" Visible="false" ImageUrl="~/Develops/icons/real-g.png"
                                        onmouseover="this.src='/Develops/icons/real.png'" onmouseout="this.src='/Develops/icons/real-g.png'" />
                                    <asp:Image ID="imgType3" runat="server" Width="16" Height="16" ImageUrl="~/Develops/icons/questions-g.png"
                                        Visible="false" onmouseover="this.src='/Develops/icons/questions.png'" onmouseout="this.src='/Develops/icons/questions-g.png'" />
                                    <asp:Image ID="imgType4" runat="server" Width="16" Height="16" ImageUrl="~/Develops/icons/survey-g.png"
                                        Visible="false" onmouseover="this.src='/Develops/icons/survey.png'" onmouseout="this.src='/Develops/icons/survey-g.png'" />
                                    <asp:Image ID="imgType5" runat="server" Width="16" Height="16" ImageUrl="~/Develops/icons/group-g.png"
                                        Visible="false" onmouseover="this.src='/Develops/icons/group.png'" onmouseout="this.src='/Develops/icons/group-g.png'" />--%>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lnkU1" runat="server" ForeColor="Black" CommandArgument='<%# Eval("UyeID1") %>'><%# Eval("AdYer1") %></asp:LinkButton>
                                &nbsp;
                                <asp:Label ID="lblVS" runat="server" Text="VS" Visible="false"></asp:Label>
                                &nbsp;
                                <asp:LinkButton ID="lnkU2" runat="server" ForeColor="Black" CommandArgument='<%# Eval("UyeID2") %>'><%# Eval("AdYer2") %></asp:LinkButton>
                                <asp:LinkButton ID="lnkVS" runat="server" Text="Rakip Ol" ForeColor="Red" Visible="false"></asp:LinkButton>
                                <div style="float: right;">
                                    <asp:Label ID="lblFile" runat="server"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span>
                                    <%# Eval("BaslangicTarih")%></span> &nbsp; <span>
                                        <%# Eval("BitisTarih")%></span> &nbsp; <span>
                                            <%# Eval("KalanSure")%></span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span>
                                    <%# Eval("Aciklama")%></span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div>
                                    <div style="float: left; margin-top: 5px;">
                                        <asp:LinkButton ID="shrButton" runat="server" OnClick="shrButton_Click"> <img src="Develops/images/otapoka-logo-kucuk.png" width="16" height="16" /></asp:LinkButton>
                                    </div>
                                    <telerik:RadSocialShare ID="scsControl" runat="server" BorderStyle="None" BorderWidth="0"
                                        DialogHeight="600px" DialogWidth="600px" Height="10">
                                        <MainButtons>
                                            <telerik:RadSocialButton SocialNetType="ShareOnFacebook"></telerik:RadSocialButton>
                                            <telerik:RadSocialButton SocialNetType="ShareOnTwitter"></telerik:RadSocialButton>
                                            <telerik:RadSocialButton SocialNetType="GoogleBookmarks"></telerik:RadSocialButton>
                                            <telerik:RadSocialButton SocialNetType="MailTo"></telerik:RadSocialButton>
                                        </MainButtons>
                                    </telerik:RadSocialShare>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <div style="width: 600px; height: 4px;">
                    </div>
                    <hr style="width: 600px; float: left;" />
                    <br />
                </ItemTemplate>
            </telerik:RadListView>
        </div>
    </div>
    <br />
    <br />
    <br />
    <p>
        <br />
        <div style="width: 1024px; margin: 0px auto;">
            <telerik:RadDataPager ID="pgrSearchResults" runat="server" PageSize="4" Skin="Metro"
                PagedControlID="rptResults" Height="25px">
                <Fields>
                    <telerik:RadDataPagerButtonField FieldType="FirstPrev"></telerik:RadDataPagerButtonField>
                    <telerik:RadDataPagerButtonField FieldType="Numeric"></telerik:RadDataPagerButtonField>
                    <telerik:RadDataPagerButtonField FieldType="NextLast"></telerik:RadDataPagerButtonField>
                </Fields>
            </telerik:RadDataPager>
        </div>
    </p>
    <br />
    <br />
</asp:Content>
