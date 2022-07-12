<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuestionControl.ascx.cs"
    Inherits="OtProject.UserControls.QuestionControl" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="ClaimCommentsControl.ascx" TagName="ClaimCommentsControl" TagPrefix="uc1" %>
<%@ Register Src="ClaimDoCommentControl.ascx" TagName="ClaimDoCommentControl" TagPrefix="uc2" %>
<style type="text/css"></style>
<div style="width: 700px; height: 203; padding: 5px;">
    <div style="height: 45px;">
        <div style="width: 35px; float: left;">
            <center>
                <telerik:RadBinaryImage ID="imgCommentUser" runat="server" Width="30" Height="30"
                    ImageUrl="~/Develops/images/boy.jpg" />
            </center>
        </div>
        &nbsp;
        <div style="float: left;">
            <div>
                <asp:LinkButton ID="lnkUser" runat="server" Font-Bold="true">Maniacboxer</asp:LinkButton>
                &nbsp;&nbsp;
            </div>
        </div>
        <div style="width: 480px; float: left;">
            <asp:Label ID="lblSubject" runat="server" CssClass="lblclass4">Soru ipsum dolor sit amet, consectetur adipiscing elit. Morbi luctus nisi et orci euismod vitae molestie arcu aliquam. Phasellus gravida tincidunt tortor vel u</asp:Label>
        </div>
        <div style="float: right;">
            <asp:LinkButton ID="lnkLike" runat="server" CssClass="lblclass2">Beğen</asp:LinkButton>&nbsp;<asp:LinkButton
                ID="lnkComplaint" runat="server" Font-Bold="true" Font-Italic="true">!</asp:LinkButton>&nbsp;<asp:ImageButton
                    ID="imgCorpAnswer" runat="server" ImageUrl="~/Develops/icons/comment-remove-icon.png" />
        </div>
    </div>
   <div style="width: 690px; height: 4px;">
    </div>
    <asp:Repeater ID="rptComments" runat="server">
    </asp:Repeater>
    <uc1:ClaimCommentsControl ID="clControl" runat="server" />
    <div style="width: 690px; height: 4px;">
    </div>
    <uc2:ClaimDoCommentControl ID="cldControl" runat="server" />
    <div style="width: 690px; height: 4px;">
    </div>
</div>
 
<hr />
<br />