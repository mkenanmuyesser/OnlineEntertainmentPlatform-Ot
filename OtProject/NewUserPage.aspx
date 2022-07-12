<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="NewUserPage.aspx.cs" Inherits="OtProject.NewUser" EnableEventValidation="true" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="UserControls/NewUserGroup/NewUserStep1Control.ascx" TagName="NewUserStep1"
    TagPrefix="uc1" %>
<%@ Register Src="UserControls/NewUserGroup/NewUserStep2Control.ascx" TagName="NewUserStep2"
    TagPrefix="uc2" %>
<%@ Register Src="UserControls/NewUserGroup/NewUserStep3Control.ascx" TagName="NewUserStep3"
    TagPrefix="uc3" %>
<%@ Register Src="UserControls/NewUserGroup/NewUserStep4Control.ascx" TagName="NewUserStep4"
    TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        span
        {
            font-size: 12px;
            margin-right: 10px;
        }
        
        table
        {
            text-align: left;
        }
        
        .fileup
        {
            color: Green;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="topcontent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="middlecontent" runat="server">
    <center style="margin-top: 150px">
        <asp:MultiView ID="multi" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <uc1:newuserstep1 id="step1" runat="server" />
            </asp:View>
            <asp:View ID="View2" runat="server">
                <uc2:newuserstep2 id="step2" runat="server" />
            </asp:View>
            <asp:View ID="View3" runat="server">
                <uc3:newuserstep3 id="step3" runat="server" />
            </asp:View>
            <asp:View ID="View4" runat="server">
                <uc4:newuserstep4 id="step4" runat="server" />
            </asp:View>
        </asp:MultiView>
    </center>
</asp:Content>
