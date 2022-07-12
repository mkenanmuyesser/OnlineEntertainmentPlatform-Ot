<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClaimCommentsControl.ascx.cs"
    Inherits="OtProject.UserControls.ClaimCommentsControl" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Repeater ID="rptComments" runat="server">
    <ItemTemplate>
        <div style=" width: 700px; height: 45px;">
            <div>
                <div style="width: 25px; float: left;">
                    <center>
                        <%--<telerik:radbinaryimage id="imgCommentUser" runat="server" width="20" height="20"
                            imageurl='~<%# Eval("UyeDetayResim") %>' />--%>
                            <img width="20" height="20" src='<%# Eval("UyeDetayResim") %>' />
                    </center>
                </div>
                &nbsp;
                <div style="float: left;">
                    <asp:LinkButton ID="lbkClaimUser" runat="server" Font-Bold="true"><%# Eval("UyeDetayAd")%></asp:LinkButton>&nbsp;&nbsp;
                </div>
                <div style="width: 480px; float: left;">
                    <asp:Label ID="lblComment" runat="server" CssClass="lblclass4"><%# Eval("YorumTanim")%></asp:Label>
                </div>
                <div style="float: right;">
                    <asp:LinkButton ID="lnkLike" runat="server" CssClass="lblclass2">Beğen</asp:LinkButton>&nbsp;<asp:LinkButton
                        ID="lnkComplaint" runat="server" Font-Bold="true">!</asp:LinkButton>&nbsp;<asp:ImageButton
                            ID="imgCorpAnswer" runat="server" ImageUrl="~/Develops/icons/corp-g.png" />
                </div>
            </div>
        </div>
    </ItemTemplate>
    <SeparatorTemplate>
        <div style="width: 690px; height: 4px;">
        </div>
    </SeparatorTemplate>
</asp:Repeater>
