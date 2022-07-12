<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewUserStep3Control.ascx.cs"
    Inherits="OtProject.UserControls.NewUserStep3" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.2, Version=11.2.11.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
    
</style>
<div>
    <table width="800">
        <tr>
            <td>
                <a id="mainlink3" href="javascript:void(0);"></a>
                <br />
                <a href="Default.aspx">
                    <img src="../../Develops/images/member-logo.jpg" />
                </a>
                <br />
                <br />
                Sizin ilgi alanlarınıza yakın kişileri takip edebilirsiniz...
                <%-- <telerik:RadToolTip runat="server" ID="ToolTip3" Skin="Default" TargetControlID="mainlink3"
                    IsClientID="true" ShowEvent="OnClick" Width="230px" Height="10px" VisibleOnPageLoad="true"
                    Position="TopRight" RelativeTo="Element" Animation="Fade" AnimationDuration="1000"
                    HideDelay="5000">
                    Seçtiğiniz ilgi alanlarına göre 5 üye takip ediniz.</telerik:RadToolTip>--%>
                <br />
                <div style="margin-left: 300px; font-size: large; float: left; margin-top: 10px">
                    <asp:Label ID="lblTag" runat="server" Font-Size="Large"></asp:Label>
                </div>
                <div style="margin-top: 15px; float: right;">
                    <dx:ASPxProgressBar ID="ProgressBar2" runat="server" CssFilePath="~/App_Themes/Youthful/{0}/styles.css"
                        CssPostfix="Youthful" DisplayMode="Position" EnableTheming="True" Height="25px"
                        Maximum="5" Position="0" Width="200px">
                    </dx:ASPxProgressBar>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DataList ID="DataList1" runat="server" DataKeyField="ID" DataSourceID="MemberData"
                    RepeatColumns="3" OnItemDataBound="DataList1_ItemDataBound" Width="500px" CellPadding="4"
                    ForeColor="#333333" RepeatDirection="Horizontal">
                    <AlternatingItemStyle BackColor="White" />
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <ItemTemplate>
                        <table style="width: 300px; height: 100px">
                            <tr>
                                <td>
                                    <telerik:RadBinaryImage ID="imgUser" runat="server" Width="75" Height="75" ImageUrl='<%# Eval("Resim") %>'
                                        ispng="False" />
                                </td>
                                <td>
                                    <table>
                                        <tr>
                                            <td style="font-size: 14px;">
                                                <b style="float: left; font-family: 'Source Sans Pro', sans-serif;">
                                                    <%# Eval("TakmaAd") %></b> <span style="margin-left: 5px; float: left; 
                                                        color: #C0C0C0;font-size:10px;">
                                                        <%# Eval("Sehir") %></span><span></span>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblDescription" runat="server" Text='<%#  Eval("Aciklama") %>' Height="60"
                                                    Font-Size="11px" ForeColor="DarkGray"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <p style="float: right;">
                                                    <telerik:RadButton ID="btnAdd" runat="server" Skin="Hay" Text="Takip Et" CommandArgument='<%# Eval("ID") %>'
                                                        OnClick="btnAdd_Click">
                                                    </telerik:RadButton>
                                                </p>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                </asp:DataList>
                <asp:SqlDataSource ID="MemberData" runat="server" ConnectionString="<%$ ConnectionStrings:OtaPokaDBConnectionString %>"
                    SelectCommand="SELECT top 6 * FROM [UyeDetay] order by newid()"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>
                <div style="float: left">
                    <telerik:RadButton ID="btnMore2" runat="server" Text="Daha fazla kişi" Skin="Hay"
                        OnClick="btnMore2_Click">
                    </telerik:RadButton>
                </div>
                <div style="float: right">
                    <telerik:RadButton ID="btnLevel3Forward" runat="server" Text="Devam et" Skin="Hay">
                    </telerik:RadButton>
                </div>
            </td>
        </tr>
    </table>
</div>
