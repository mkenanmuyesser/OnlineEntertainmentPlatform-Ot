<%@ Page Title="" Language="C#" MasterPageFile="~/WallMain.Master" AutoEventWireup="true"
    CodeBehind="RVC.aspx.cs" Inherits="OtProject.RVC" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../UserControls/WallGroup/WallLeftControl.ascx" TagName="WallLeftControl"
    TagPrefix="uc1" %>
<%@ Register Src="../UserControls/WallGroup/WithOpponentClaimControl.ascx" TagName="WithOpponentClaimControl"
    TagPrefix="uc2" %>
<%@ Register Src="../UserControls/WallGroup/WithoutOpponentClaimControl.ascx" TagName="WithoutOpponentClaimControl"
    TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #contentdiv
        {
            width: 1024px;
            margin: 0px auto;
        }
        
        #leftcontentdiv
        {
            width: 250px;
            float: left;
            margin: 5px 6px 5px 6px;
        }
        
        #middlecontentdiv
        {
            width: 700px;
            float: left;
            margin: 5px 10px 5px 10px;
        }
        
        .usernameclass
        {
            margin-left: 10px;
            font-weight: bold;
        }
        
        .notificationclass
        {
            width: 100%;
            height: 100px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middlecontent" runat="server">
    <telerik:RadWindowManager ID="wndWelcome" runat="server" ReloadOnShow="true" ShowContentDuringLoad="False"
        VisibleStatusbar="False" Skin="Hay" VisibleOnPageLoad="false" Style="z-index: 8000;"
        DestroyOnClose="False" EnableShadow="true" Animation="Fade" Modal="true" AnimationDuration="500">
        <Windows>
        </Windows>
    </telerik:RadWindowManager>
    <br />
    <br />
    <br />
    <div id="contentdiv">
        <div id="leftcontentdiv">
            <asp:LoginView ID="LoginView1" runat="server">
                <AnonymousTemplate>
                </AnonymousTemplate>
                <LoggedInTemplate>
                </LoggedInTemplate>
            </asp:LoginView>
            <uc1:WallLeftControl ID="WallLeftControl1" runat="server" />
        </div>
        <div id="middlecontentdiv">
            <asp:Panel ID="Panel1" runat="server">
                <uc3:WithoutOpponentClaimControl ID="woControl" runat="server" />
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server">
                <uc2:WithOpponentClaimControl ID="wControl" runat="server" />
            </asp:Panel>
        </div>
    </div>
</asp:Content>
