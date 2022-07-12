<%@ Page Title="" Language="C#" MasterPageFile="~/WallMain.Master" AutoEventWireup="true"
    CodeBehind="WallPage.aspx.cs" Inherits="OtProject.WallPage" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="UserControls/WallGroup/WallLeftControl.ascx" TagName="WallLeftControl"
    TagPrefix="uc1" %>
<%@ Register Src="UserControls/WallGroup/WallMiddleControl.ascx" TagName="WallMiddleControl"
    TagPrefix="uc3" %>
<%@ Register Src="UserControls/WallGroup/WallTopControl.ascx" TagName="WallTopControl"
    TagPrefix="uc4" %>
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
            <uc1:WallLeftControl ID="wlControl" runat="server" />
        </div>
        <div id="middlecontentdiv">
            <uc4:WallTopControl ID="wtControl" runat="server" />
            <br />
            <br />
            <div style="width: 580px; height: 2px; border-bottom-style: solid; border-bottom-width: 1px;
                border-bottom-color: #DCDCDC;">
            </div>
            <p>
                <uc3:WallMiddleControl ID="wmControl" runat="server" />
            </p>
            <br />
        </div>
    </div>
</asp:Content>
