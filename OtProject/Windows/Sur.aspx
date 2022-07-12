<%@ Page Title="" Language="C#" MasterPageFile="~/WallMain.Master" AutoEventWireup="true"
    CodeBehind="Sur.aspx.cs" Inherits="OtProject.Sur" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../UserControls/WallGroup/WallLeftControl.ascx" TagName="WallLeftControl"
    TagPrefix="uc1" %>
<%@ Register Src="../UserControls/WallGroup/SurveyControl.ascx" TagName="SurveyControl"
    TagPrefix="uc2" %>
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
    <telerik:radwindowmanager id="wndWelcome" runat="server" reloadonshow="true" showcontentduringload="False"
        visiblestatusbar="False" skin="Hay" visibleonpageload="false" style="z-index: 8000;"
        destroyonclose="False" enableshadow="true" animation="Fade" modal="true" animationduration="500">
        <Windows>
        </Windows>
    </telerik:radwindowmanager>
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
            <uc1:wallleftcontrol id="wlControl" runat="server" />
        </div>
        <div id="middlecontentdiv">
            <uc2:surveycontrol id="sControl" runat="server" />
        </div>
    </div>
</asp:Content>
