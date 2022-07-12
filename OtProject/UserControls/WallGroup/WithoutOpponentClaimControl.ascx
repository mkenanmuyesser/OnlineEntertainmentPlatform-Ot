<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WithoutOpponentClaimControl.ascx.cs"
    Inherits="OtProject.UserControls.WithoutOpponentClaimControl" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="ClaimDoCommentControl.ascx" TagName="ClaimDoCommentControl" TagPrefix="uc1" %>
<%@ Register Src="ClaimCommentsControl.ascx" TagName="ClaimCommentsControl" TagPrefix="uc2" %>
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
        font-style: italic;
    }
    
    .lblclass1
    {
        color: #279e33;
        font-size: 12px;
        font-weight: bold;
    }
    
    
    .lblclass3
    {
        font-style: italic;
        color: Gray;
        font-size: 9px;
    }
    
    .lblclass4
    {
        font-style: normal;
        font-size: 11px;
    }
</style>
<div style="width: 700px; height: 230px;">
    <div>
        <div>
            <div style="width: 60px; float: left;">
                <center>
                    <telerik:RadBinaryImage ID="imgUser" runat="server" Width="50" Height="50" ImageUrl="~/Develops/images/boy.jpg" />
                </center>
            </div>
            <div style="width:700px;">
                <div style="width: 690px; height: 30px; background-color: #fdfee0; padding: 5px;">
                    <div style="width: 400px; float: left;">
                        <asp:LinkButton ID="lnkUserName1" runat="server" Font-Bold="true">Maniacboxer</asp:LinkButton>
                        &nbsp;
                        <asp:LinkButton ID="lnkSendMessage" runat="server" CssClass="btnclass">Mesaj Gönder</asp:LinkButton>
                        &nbsp;
                        <asp:LinkButton ID="lnkFollow" runat="server" CssClass="btnclass">Takip Et</asp:LinkButton><br />
                        <asp:Label ID="lblCity" runat="server">Ankara</asp:Label>&nbsp;-&nbsp;<asp:Label
                            ID="lblAge" runat="server">30</asp:Label>&nbsp;<asp:Label ID="lblGender" runat="server"
                                Text="Label">e</asp:Label>
                    </div>
                    <div style="width: 150px; float: left;">
                        İddianın Değeri&nbsp;:&nbsp;<asp:Label ID="lblPoka" runat="server" CssClass="lblclass1">500 POKA</asp:Label>
                        <br />
                        Kalan Süre&nbsp;:&nbsp;<asp:Label ID="lblTiming" runat="server" CssClass="lblclass1">23 Saat 14 Dk.</asp:Label>
                    </div>
                </div>
                <div style=" width: 690px; height: 90px; padding: 5px 0px 5px 5px;">
                    <div>
                        <asp:LinkButton ID="lnkUserName2" runat="server" Font-Italic="true">Maniacboxer</asp:LinkButton>&nbsp;<asp:LinkButton
                            ID="lblOther1" runat="server" Font-Italic="true">Diyor ki;</asp:LinkButton>
                        <br />
                        <div style="width: 530px; height: 24px; float: left;">
                            <asp:Label ID="lblMainComment" runat="server" CssClass="lblclass4">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi luctus nisi et orci euismod vitae molestie arcu aliquam. Phasellus gravida tincidunt tortor vel u</asp:Label>
                        </div>
                        <div>
                            &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="lnkProof" runat="server" Font-Bold="true" CssClass="lblclass2">KANIT</asp:LinkButton><br />
                            &nbsp;&nbsp; &nbsp;<asp:LinkButton ID="lnkVideo" runat="server" CssClass="lblclass3">1 Video</asp:LinkButton>&nbsp;<asp:LinkButton
                                ID="lnkPhoto" runat="server" CssClass="lblclass3">2 Foto</asp:LinkButton>
                        </div>
                        <br />
                        <div style="width: 340px; float: right;">
                            <asp:LinkButton ID="lnkShare" runat="server" CssClass="lblclass2">Paylaş</asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="lnkComment" runat="server" CssClass="lblclass2">Yorum Yap</asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="lnkWatch" runat="server" CssClass="lblclass2">İzle</asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="lnkLike" runat="server" CssClass="lblclass2">Beğen</asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="lnkClaim" runat="server" CssClass="lblclass2">Meydan Oku</asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="lnkComplaint" runat="server" Font-Bold="true" Font-Italic="true">!</asp:LinkButton>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="imgCorpAnswer" runat="server" ImageUrl="../Develops/icons/comment-remove-icon.png" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="width: 420px; height: 4px;">
        </div>
        <uc2:ClaimCommentsControl ID="clControl" runat="server" />
        <div style="width: 420px; height: 4px;">
        </div>
        <uc1:ClaimDoCommentControl ID="cldControl" runat="server" />
    </div>
</div>
<hr />
<br />
