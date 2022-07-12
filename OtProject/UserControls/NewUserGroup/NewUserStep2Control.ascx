<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewUserStep2Control.ascx.cs"
    Inherits="OtProject.UserControls.NewUserStep2" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.2, Version=11.2.11.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css"></style>
<div>
    <table>
        <tr>
            <td>
                <a id="mainlink2" href="javascript:void(0);"></a>
                <br />
                <a href="Default.aspx">
                    <img src="../../Develops/images/member-logo.jpg" />
                </a>
                <br />
                 <br />
                Yalnız kalmamak için en az 5 ilgi alanı seçiniz...
                <%--<telerik:RadToolTip runat="server" ID="ToolTip2" Skin="Default" TargetControlID="mainlink2"
                    IsClientID="true" ShowEvent="OnClick" Width="230px" Height="10px" VisibleOnPageLoad="true"
                    Position="TopRight" RelativeTo="Element" Animation="Fade" AnimationDuration="1000"
                    HideDelay="5000">
                    Yalnız kalmamak için en az 5 ilgi alanı seçiniz.</telerik:RadToolTip>--%>
                    <br />
                <div style="margin-top: 15px; float: right;">
                    <dx:ASPxProgressBar ID="progress" runat="server" CssFilePath="~/App_Themes/Youthful/{0}/styles.css"
                        CssPostfix="Youthful" DisplayMode="Position" ShowPosition="true"
    EnableClientSideAPI="True" EnableTheming="True" Height="25px"
                        Maximum="5" Position="0" Width="200px">
                    </dx:ASPxProgressBar>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadTagCloud ID="RadTagCloud1" runat="server" DataSourceID="CloudData" DataTextField="IlgiAlanTanim"
                    DataToolTipField="IlgiAlanTanim" DataValueField="ID" DataWeightField="Izlenme" Skin="Hay"
                    Width="500px" Height="150px" WordsToExclude="a,about,after,all,also,an,and,are,as,at,be,been,but,by,can,could,did,do,does,each,for,from,get,had,has,have,he,her,him,his,how,i,if,in,into,is,it,its,just,me,more,most,my,not,of,on,or,our,said,see,shall,she,should,so,some,than,that,the,their,there,they,this,those,to,up,used,was,we,were,what,when,which,while,who,why,will,with,would,you,your"
                    Font-Size="Large" MaxFontSize="36px" MinFontSize="16px" AutoPostBack="True" OnItemClick="RadTagCloud1_ItemClick"
                    Font-Names=" 'benchnine' , sans-serif">
                </telerik:RadTagCloud>
                <asp:SqlDataSource ID="CloudData" runat="server" ConnectionString="<%$ ConnectionStrings:OtaPokaDBConnectionString %>"
                    SelectCommand="SELECT top 20 * FROM [IlgiAlan] order by newid()"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>
                <div style="float: left">
                    <telerik:RadButton ID="btnMore1" runat="server" Text="Daha fazla ilgi alanı" OnClick="btnMore1_Click"
                        Skin="Hay">
                    </telerik:RadButton>
                </div>
                <div style="float: right">
                    <telerik:RadButton ID="btnLevel2Forward" runat="server" Text="Devam et" Enabled="false"
                        Skin="Hay">
                    </telerik:RadButton>
                </div>
            </td>
        </tr>
    </table>
</div>
