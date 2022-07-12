<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserLoginControl.ascx.cs"
    Inherits="OtProject.UserControls.UserLoginControl" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<script src="../Develops/files/jquery-1.8.3.js" type="text/javascript"></script>
<script type="text/jscript">
    $(document).ready(function () {
        $(".signin").click(function (e) {
            e.preventDefault();
            $("fieldset#signin_menu").toggle();
            $(".signin").toggleClass("menu-open");
        });
        $("fieldset#signin_menu").mouseup(function () {
            return false
        });
        $(document).mouseup(function (e) {
            if ($(e.target).parent("a.signin").length == 0) {
                $(".signin").removeClass("menu-open");
                $("fieldset#signin_menu").hide();
            }
        });
    });
</script>
<style type="text/css">
    
</style>
<div>
    <div id="topnav" class="topnav" style="font-size: 12px;">
        <a href="NewUserPage.aspx" style="text-decoration: none; color: Black;">Hesap oluştur</a><a href="login" class="signin" style="width: 50px; text-align: center;"><span>
                Giriş yap</span></a>
    </div>
    <fieldset id="signin_menu">
        <p>
            <label for="username">
                Kullanıcı adı</label>
            <br />
            <telerik:RadTextBox ID="txtUserName" runat="server" Width="170px" Height="27" Skin="Forest">
            </telerik:RadTextBox>
        </p>
        <p>
            <label for="password">
                Şifre</label>
            <br />
            <telerik:RadTextBox ID="txtPassword" runat="server" Width="170px" Height="27" Skin="Forest"
                TextMode="Password">
            </telerik:RadTextBox>
        </p>
        <asp:Label ID="lblWarning" runat="server" ForeColor="Red"></asp:Label>
        <p class="remember">
            &nbsp;<telerik:RadButton ID="btnLogin" runat="server" Text="Giriş" Skin="Hay" OnClick="btnLogin_Click">
            </telerik:RadButton>
            <asp:CheckBox ID="chkRemember" runat="server" Text="Beni hatırla" />
        </p>
        <p class="forgot">
            <a href="../../RecoveryPasswordPage.aspx" id="resend_password_link">Şifreni mi unuttun?</a>
        </p>
    </fieldset>
</div>
