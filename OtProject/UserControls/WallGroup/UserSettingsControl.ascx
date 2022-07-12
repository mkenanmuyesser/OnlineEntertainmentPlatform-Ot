<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserSettingsControl.ascx.cs"
    Inherits="OtProject.UserControls.UserSettingsControl" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
<div style="width: 1024px; margin: 0px auto;">
    <telerik:RadTabStrip ID="RadTabStrip2" runat="server" SelectedIndex="4" MultiPageID="RadMultiPage1"
        Orientation="VerticalLeft" Style="float: left; width: 126px; margin: 30px 0px 0px 0px;"
        Skin="Transparent">
        <Tabs>
            <telerik:RadTab Text="Genel">
            </telerik:RadTab>
            <telerik:RadTab Text="Güvenlik">
            </telerik:RadTab>
            <telerik:RadTab Text="Bildirimler">
            </telerik:RadTab>
            <telerik:RadTab Text="Destek Panosu">
            </telerik:RadTab>
            <telerik:RadTab Text="Ödemeler" Selected="True">
            </telerik:RadTab>
            <telerik:RadTab Text="Hediyeler" Selected="True">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage runat="server" CssClass="multiPage" ID="RadMultiPage1" SelectedIndex="4"
        title="This is a screenshot only.">
        <telerik:RadPageView runat="server" ID="PageView1">
            <table style="margin: 80px 0px 0px 10px;">
                <tr>
                    <td colspan="3">
                        <span style="font-size: x-large;">Genel Hesap Ayarları</span>
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px;">
                        Adın
                    </td>
                    <td style="width: 400px;">
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadButton ID="RadButton5" runat="server" Text="Düzenle" Font-Size="10px"
                            ButtonType="LinkButton" Skin="Hay">
                        </telerik:RadButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        Kullanıcı Adı
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadButton ID="RadButton4" runat="server" Text="Düzenle" Font-Size="10px"
                            ButtonType="LinkButton" Skin="Hay">
                        </telerik:RadButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        E-posta
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadButton ID="RadButton3" runat="server" Text="Düzenle" Font-Size="10px"
                            ButtonType="LinkButton" Skin="Hay">
                        </telerik:RadButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        Şifre
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadButton ID="RadButton2" runat="server" Text="Düzenle" Font-Size="10px"
                            ButtonType="LinkButton" Skin="Hay">
                        </telerik:RadButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        Dil
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadButton ID="RadButton1" runat="server" Text="Düzenle" Font-Size="10px"
                            ButtonType="LinkButton" Skin="Hay">
                        </telerik:RadButton>
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="PageView2">
            <table style="margin: 80px 0px 0px 10px;">
                <tr>
                    <td colspan="3">
                        <span style="font-size: x-large;">Güvenlik Ayarları</span>
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px;">
                        Güvenlik Sorusu
                    </td>
                    <td style="width: 400px;">
                        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadButton ID="RadButton6" runat="server" Text="Düzenle" Font-Size="10px"
                            ButtonType="LinkButton" Skin="Hay">
                        </telerik:RadButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        Aktif Oturumlar
                    </td>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadButton ID="RadButton7" runat="server" Text="Düzenle" Font-Size="10px"
                            ButtonType="LinkButton" Skin="Hay">
                        </telerik:RadButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        E-posta
                    </td>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadButton ID="RadButton8" runat="server" Text="Düzenle" Font-Size="10px"
                            ButtonType="LinkButton" Skin="Hay">
                        </telerik:RadButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        Şifre
                    </td>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadButton ID="RadButton9" runat="server" Text="Düzenle" Font-Size="10px"
                            ButtonType="LinkButton" Skin="Hay">
                        </telerik:RadButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        Dil
                    </td>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadButton ID="RadButton10" runat="server" Text="Düzenle" Font-Size="10px"
                            ButtonType="LinkButton" Skin="Hay">
                        </telerik:RadButton>
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="PageView3">
            <table style="margin: 80px 0px 0px 10px;">
                <tr>
                    <td colspan="3">
                        <span style="font-size: x-large;">Güvenlik Ayarları</span>
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px;">
                        Güvenlik Sorusu
                    </td>
                    <td style="width: 400px;">
                        <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadButton ID="RadButton11" runat="server" Text="Düzenle" Font-Size="10px"
                            ButtonType="LinkButton" Skin="Hay">
                        </telerik:RadButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        Aktif Oturumlar
                    </td>
                    <td>
                        <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadButton ID="RadButton12" runat="server" Text="Düzenle" Font-Size="10px"
                            ButtonType="LinkButton" Skin="Hay">
                        </telerik:RadButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        E-posta
                    </td>
                    <td>
                        <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadButton ID="RadButton13" runat="server" Text="Düzenle" Font-Size="10px"
                            ButtonType="LinkButton" Skin="Hay">
                        </telerik:RadButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        Şifre
                    </td>
                    <td>
                        <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadButton ID="RadButton14" runat="server" Text="Düzenle" Font-Size="10px"
                            ButtonType="LinkButton" Skin="Hay">
                        </telerik:RadButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        Dil
                    </td>
                    <td>
                        <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadButton ID="RadButton15" runat="server" Text="Düzenle" Font-Size="10px"
                            ButtonType="LinkButton" Skin="Hay">
                        </telerik:RadButton>
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="PageView4">
            ıoıoıoıo</telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="PageView5">
            mmömömömömöm</telerik:RadPageView>
    </telerik:RadMultiPage>
</div>
