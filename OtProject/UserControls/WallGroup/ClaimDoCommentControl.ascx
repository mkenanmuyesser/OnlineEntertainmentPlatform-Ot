<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClaimDoCommentControl.ascx.cs"
    Inherits="OtProject.UserControls.ClaimDoCommentControl" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<div style="width: 700px; height: 40px;">
    <div style="width: 25px; float: left;">
        <center>
            <telerik:radbinaryimage id="imgWriterUser" runat="server" width="20" height="20"
                imageurl="~/Develops/images/boy.jpg" />
        </center>
    </div>
    <div style="width: 600px; float: left;">
        <telerik:radtextbox id="txtComment" runat="server" skin="Forest" displaytext="Yorum Yaz"
            width="600px" height="30px" font-size="10pt" 
            MaxLength="160" TextMode="MultiLine" >
        </telerik:radtextbox>
    </div>
    <div style="float: right;margin-top:5px;">
        <telerik:radbutton id="btnComment" runat="server" text="Paylaş" buttontype="LinkButton"
            onclick="btnComment_Click">
        </telerik:radbutton>
    </div>
</div>
