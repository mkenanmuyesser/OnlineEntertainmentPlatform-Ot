<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="RecoveryPasswordPage.aspx.cs" Inherits="OtProject.RecoveryPasswordPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #motto
        {
            font-family: 'BenchNine' , sans-serif;
            font-size: 14px;
            margin-top: -2px;
            color: #279e33;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="topcontent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="middlecontent" runat="server">
    <p>
        <center>
            <br />
            <br />
            <br />
            <br />
            <a href="Default.aspx">
                <img src="/Develops/images/otapoka-logo.png" />
            </a>
            <p id="motto">
                Benim Babam Senin Babanı Döver !
            </p>
            <asp:PasswordRecovery ID="pwdRecovery" runat="server" MailDefinition-BodyFileName="~/ChangePassword.htm"
                MailDefinition-IsBodyHtml="true" MailDefinition-Subject="Şifre kurtarma" GeneralFailureText="Bu isimde bir üyemiz bulunmamaktadır."
                UserNameFailureText="Bu isimde bir üyemiz bulunmamaktadır.">
                <MailDefinition BodyFileName="~/ChangePassword.htm" IsBodyHtml="True" Subject="Şifre kurtarma">
                </MailDefinition>
                <SuccessTemplate>
                    <table cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                        <tr>
                            <td>
                                <table cellpadding="0">
                                    <tr>
                                        <td>
                                            Şifreniz e-posta adresinize başarıyla gönderildi.
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </SuccessTemplate>
                <UserNameTemplate>
                    <table cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                        <tr>
                            <td>
                                <table cellpadding="0">
                                    <tr>
                                        <td align="center" colspan="2" style="font-size:12px;">
                                            Kullanıcı adınızı girerek şifrenizin daha önce
                                            <br />
                                            belirttiğiniz e-posta adresine gönderimini sağlayabilirsiniz.
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Kullanıcı adı:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="UserName" runat="server" Width="200"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                ErrorMessage="Kullanıcı adı kısmı boş bırakılamaz." ValidationGroup="pwdRecovery">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="color: Red;">
                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                            <%--Text="Bu isimde bir üyemiz bulunmamaktadır."--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2">
                                            <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="Gönder" ValidationGroup="pwdRecovery" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </UserNameTemplate>
            </asp:PasswordRecovery>
        </center>
    </p>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footercontent" runat="server">
</asp:Content>
