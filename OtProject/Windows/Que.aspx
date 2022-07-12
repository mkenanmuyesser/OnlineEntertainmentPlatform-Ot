<%@ Page Title="" Language="C#" MasterPageFile="~/WallMain.Master" AutoEventWireup="true"
    CodeBehind="Que.aspx.cs" Inherits="OtProject.Que" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../UserControls/WallGroup/WallLeftControl.ascx" TagName="WallLeftControl"
    TagPrefix="uc1" %>
<%@ Register Src="../UserControls/WallGroup/QuestionControl.ascx" TagName="QuestionControl"
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
            <uc2:QuestionControl ID="qControl" runat="server" />
        </div>
    </div>
</asp:Content>
