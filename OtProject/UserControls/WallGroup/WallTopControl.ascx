<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WallTopControl.ascx.cs"
    Inherits="OtProject.UserControls.WallGroup.WallTopControl" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<script type="text/javascript"></script>
<style type="text/css">
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
</style>
<div>
    <telerik:radwindowmanager id="wndWallTop" runat="server" reloadonshow="true" showcontentduringload="False"
        visiblestatusbar="False" skin="Hay" visibleonpageload="false" style="z-index: 8000;"
        destroyonclose="False" enableshadow="true" modal="true">
        <Windows>
            <telerik:RadWindow runat="server" ID="claimWindow" Skin="Hay" NavigateUrl="~/Popups/CreateClaimWindow.aspx"
                Modal="true" OpenerElementID="lnkCreateClaim" Width="600" Height="350" Behaviors="Close"
                VisibleStatusbar="false" VisibleTitlebar="false">
            </telerik:RadWindow>
            <telerik:RadWindow runat="server" ID="questionWindow" Skin="Hay" NavigateUrl="~/Popups/CreateQuestionWindow.aspx"
                Modal="true" OpenerElementID="lnkCreateQuestion" Width="600" Height="270" Behaviors="Close"
                VisibleStatusbar="false" VisibleTitlebar="false">
            </telerik:RadWindow>
            <telerik:RadWindow runat="server" ID="surveyWindow" Skin="Hay" NavigateUrl="~/Popups/CreateSurveyWindow.aspx"
                Modal="true" OpenerElementID="lnkCreateSurvey" Width="600" Height="350" Behaviors="Close"
                VisibleStatusbar="false" VisibleTitlebar="false">
            </telerik:RadWindow>
            <telerik:RadWindow runat="server" ID="groupWindow" Skin="Hay" NavigateUrl="~/Popups/CreateGroupWindow.aspx"
                Modal="true" OpenerElementID="lnkCreateGroup" Width="600" Height="300" Behaviors="Close"
                VisibleStatusbar="false" VisibleTitlebar="false">
            </telerik:RadWindow>
        </Windows>
    </telerik:radwindowmanager>
    <div>
        <center>
            <telerik:radtextbox id="txtStatus" runat="server" skin="Forest" width="450px" height="48px"
                maxlength="160" displaytext="Ne düşünüyorsun?" textmode="MultiLine">
        </telerik:radtextbox>
            <div style="float: right; margin: 5px 17px 0px 0px">
                <telerik:radbutton id="btnStatus" runat="server" text="Paylaş" skin="Hay" buttontype="LinkButton"
                    onclick="btnStatus_Click">
            </telerik:radbutton>
            </div>
        </center>
    </div>
    <p style="float: left;">
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="#" id="lnkCreateClaim" class="lblclass2">İddia
            Oluştur</a>&nbsp; <a href="#" id="lnkCreateQuestion" class="lblclass2">Soru Oluştur</a>&nbsp;
        <a href="#" id="lnkCreateSurvey" class="lblclass2">Anket Oluştur</a>&nbsp; <a href="#"
            id="lnkCreateGroup" class="lblclass2">Grup Oluştur</a>&nbsp;
    </p>
    <p >
      
    </p>
   
</div>
