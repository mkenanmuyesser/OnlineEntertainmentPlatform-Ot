<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dummy.aspx.cs" Inherits="OtProject.dummy" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager runat="server">
    </telerik:RadScriptManager> 
    
    <table style="width: 600px; height: 72px;">
                        <tr>
                            <td>
                                <asp:Repeater ID="rptKeywords" runat="server">
                                    <ItemTemplate>
                                        <a href="#">
                                            <%# Eval("IlgiAlanTanim")%></a>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <div style="float: right;">
                                    <asp:Image ID="imgOpen" runat="server" Width="16" Height="16" ImageUrl="~/Develops/icons/lock-g.png" />
                                    <asp:Image ID="imgType1" runat="server" Width="16" Height="16" Visible="false" ImageUrl="~/Develops/icons/virtual-g.png"
                                        onmouseover="this.src='/Develops/icons/virtual.png'" onmouseout="this.src='/Develops/icons/virtual-g.png'" />
                                    <asp:Image ID="imgType2" runat="server" Width="16" Height="16" Visible="false" ImageUrl="~/Develops/icons/real-g.png"
                                        onmouseover="this.src='/Develops/icons/real.png'" onmouseout="this.src='/Develops/icons/real-g.png'" />
                                    <asp:Image ID="imgType3" runat="server" Width="16" Height="16" ImageUrl="~/Develops/icons/questions-g.png"
                                        Visible="false" onmouseover="this.src='/Develops/icons/questions.png'" onmouseout="this.src='/Develops/icons/questions-g.png'" />
                                    <asp:Image ID="imgType4" runat="server" Width="16" Height="16" ImageUrl="~/Develops/icons/survey-g.png"
                                        Visible="false" onmouseover="this.src='/Develops/icons/survey.png'" onmouseout="this.src='/Develops/icons/survey-g.png'" />
                                    <asp:Image ID="imgType5" runat="server" Width="16" Height="16" ImageUrl="~/Develops/icons/group-g.png"
                                        Visible="false" onmouseover="this.src='/Develops/icons/group.png'" onmouseout="this.src='/Develops/icons/group-g.png'" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lnkPage" runat="server"></asp:LinkButton>
                                <asp:LinkButton ID="lnkU1" runat="server" CommandArgument='<%# Eval("UyeID1") %>'><%# Eval("Ad1") %></asp:LinkButton>
                                &nbsp;
                                <asp:Label ID="lblVS" runat="server" Text="VS" Visible="false"></asp:Label>
                                &nbsp;
                                <asp:LinkButton ID="lnkU2" runat="server" CommandArgument='<%# Eval("UyeID2") %>'><%# Eval("Ad2") %></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span>
                                    <%# Eval("BaslangicTarih")%></span> &nbsp; <span>
                                        <%# Eval("BitisTarih")%></span> &nbsp; <span>
                                            <%# Eval("KalanSure")%></span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span>
                                    <%# Eval("Aciklama")%></span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadButton ID="btnShare" runat="server" Icon-PrimaryIconUrl="~/Develops/images/otapoka-logo-kucuk.png" ButtonType="LinkButton">
                                </telerik:RadButton>
                                <telerik:RadSocialShare ID="scsControl" runat="server">
                                    <MainButtons>
                                        <telerik:RadSocialButton SocialNetType="ShareOnFacebook"></telerik:RadSocialButton>
                                        <telerik:RadSocialButton SocialNetType="ShareOnTwitter"></telerik:RadSocialButton>
                                        <telerik:RadSocialButton SocialNetType="GoogleBookmarks"></telerik:RadSocialButton>
                                        <telerik:RadSocialButton SocialNetType="MailTo"></telerik:RadSocialButton>
                                    </MainButtons>
                                </telerik:RadSocialShare>
                            </td>
                        </tr>
                    </table>      
    </form>
</body>
</html>
