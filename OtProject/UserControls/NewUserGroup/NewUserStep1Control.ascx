<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewUserStep1Control.ascx.cs"
    Inherits="OtProject.UserControls.NewUserStep1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css"></style>
<div>
    <table>
        <tr>
            <td colspan="2" style="text-align:left;">
                <a id="mainlink1" href="javascript:void(0);"></a>
                <br />
                <a href="Default.aspx">
                    <img src="../../Develops/images/member-logo.jpg" />
                </a>
                <br />
                 <br />
               Otapoka dünyasına katılmak için birkaç mini adım atmanız gerekiyor 
                   
                <%--<telerik:RadToolTip runat="server" ID="ToolTip1" Skin="Telerik" TargetControlID="mainlink1"
                    IsClientID="true" ShowEvent="OnClick" Width="230px" Height="10px" VisibleOnPageLoad="true"
                    Position="TopCenter" RelativeTo="Element" Animation="Fade" AnimationDuration="1000"
                    HideDelay="5000">
                    Otapoka dünyasına katılmak için gerçek isminizle ya da bir kullanıcı adı seçerek
                    profil oluşturabilirsiniz.</telerik:RadToolTip>--%>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <span>Kullanıcı adı:</span>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                    ControlToValidate="txtUserName" ForeColor="Red" ValidationGroup="step1group"></asp:RequiredFieldValidator>
                <telerik:RadTextBox ID="txtUserName" runat="server" Width="170px" Skin="Forest">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <span>E-posta:</span>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                    ControlToValidate="txtEmail" ForeColor="Red" ValidationGroup="step1group"></asp:RequiredFieldValidator>
                <telerik:RadTextBox ID="txtEmail" runat="server" Width="170px" Skin="Forest">
                </telerik:RadTextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Yanlış e-posta formatı" ForeColor="Red" 
                    ValidationGroup="step1group" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <span>Şifre:</span>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                    ControlToValidate="txtPassword" ForeColor="Red" ValidationGroup="step1group"></asp:RequiredFieldValidator>
                <telerik:RadTextBox ID="txtPassword" runat="server" Width="166px" Skin="Forest" TextMode="Password"
                    EnableSingleInputRendering="false">
                    <PasswordStrengthSettings ShowIndicator="true" MinimumNumericCharacters="6" PreferredPasswordLength="8"
                        TextStrengthDescriptions="Çok Zayıf;Zayıf;Orta;Güçlü;Mükemmel"></PasswordStrengthSettings>
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <span>Şifre tekrar:</span>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                    ControlToValidate="txtRePassword" ForeColor="Red" ValidationGroup="step1group"></asp:RequiredFieldValidator>
                <telerik:RadTextBox ID="txtRePassword" runat="server" Width="170px" Skin="Forest"
                    TextMode="Password">
                </telerik:RadTextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Şifreler eşleşmiyor"
                    ControlToCompare="txtPassword" ControlToValidate="txtRePassword" ForeColor="Red"
                    ValidationGroup="step1group"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right;">
                <telerik:RadButton ID="btnLevel1Forward" runat="server" Text="Devam et" Skin="Hay"
                    ValidationGroup="step1group">
                </telerik:RadButton>
                &nbsp;&nbsp;&nbsp;
            </td>
        </tr>
    </table>
</div>
