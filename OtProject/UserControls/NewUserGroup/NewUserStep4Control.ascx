<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewUserStep4Control.ascx.cs"
    Inherits="OtProject.UserControls.NewUserStep4" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<script type="text/javascript" src="../../Develops/files/jquery-1.8.3.js"></script>
<script type="text/javascript">

    function OnClientFileSelected(sender, args) {
        var thumbnail = document.getElementById("thumbnail");
        thumbnail.innerHTML = "";  
        if ($telerik.isIE) {
            var input = args.get_fileInputField();
            var img = document.createElement("img");
            
            thumbnail.innerHTML = "";                        
            thumbnail.appendChild(img);
            if (img) {

                img.style.visibility = "";
                img.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = input.value;
            }
        }
        else {
            var file = args.get_fileInputField().files.item(args.get_rowIndex());
            
            showThumbnail(file);
            $("#thumbnail").css("backgroundImage", "none");
        }
    }

    function showThumbnail(file) {
        var image = document.createElement("img");
        var thumbnail = document.getElementById("thumbnail");
        image.file = file;
        thumbnail.appendChild(image);
        var reader = new FileReader()
        reader.onload = (function (aImg) {
            return function (e) {
                aImg.src = e.target.result;
            };
        } (image))
        var ret = reader.readAsDataURL(file);
        var canvas = document.createElement("canvas");
        ctx = canvas.getContext("2d");
        image.onload = function () {
            ctx.drawImage(image, 100, 100);
        }
    }
</script>
<style type="text/css">
    #thumbnail img
    {
        filter: progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale);
    }
    #thumbnail img
    {
        width: 75px !important;
        height: 75px !important;
    }
     div.RadUpload .ruFakeInput
    {
        visibility: hidden;
        width: 0;
        padding: 0;
    }
    div.RadUpload .ruFileInput
    {
        width: 1;
    }
</style>
<div>
    <table>
        <tr>
            <td colspan="2" style="text-align: center;">
                <a id="mainlink4" href="javascript:void(0);"></a>
                <br />
                 <a href="Default.aspx" style="float:left;">
                    <img src="../../Develops/images/member-logo.jpg" />
                </a>
                <br />
                 <br />
                Otapoka'ya üye olmaya son bir adım kaldı. Lütfen az sabır :)
                <%--<telerik:RadToolTip runat="server" ID="ToolTip4" Skin="Default" TargetControlID="mainlink4"
                    IsClientID="true" ShowEvent="OnClick" Width="230px" Height="10px" VisibleOnPageLoad="true"
                    Position="TopCenter" RelativeTo="Element" Animation="Fade" AnimationDuration="1000"
                    HideDelay="5000">
                    Otapoka'ya üye olmaya son bir adım kaldı. Lütfen az sabır :)</telerik:RadToolTip>--%>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td rowspan="2">
                <div id="thumbnail" style="background-image: url(/Develops/images/boy.jpg); width: 75px;
                    height: 75px;">                    
                </div>
            </td>
            <td>
                <br />
                <telerik:RadUpload ID="imgFileUpload" runat="server" 
                    MultipleFileSelection="Disabled" Height="0"
                    InitialFileInputsCount="1" InputSize="3" MaxFileInputsCount="1" TemporaryFileExpiration="01:00:00"
                    OnClientFileSelected="OnClientFileSelected" controlobjectsvisibility="None" 
                    AllowedFileExtensions="jpg;jpeg;bmp;gif" OverwriteExistingFiles="True" 
                    Width="70px" MaxFileSize="2048">
                </telerik:RadUpload>
                <br />
                <br />
                <span style="font-size: 11px; text-align: left;">Adınızın yanında<br />
                    resminiz de olsun.<br />
                    (Lütfen 2mb dan küçük<br />
                bir fotoğraf yükleyiniz)
                    </span>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                Kısaca Sen<br />
                <telerik:RadTextBox ID="txtDescription" runat="server" Height="90px" Width="260px"
                    TextMode="MultiLine" Skin="Forest" MaxLength="160" DisplayText="Lütfen kendinizi kısaca tanıtınız...">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                Konum<br />
                <telerik:RadTextBox ID="txtLocation" runat="server" Width="260px" Skin="Forest" MaxLength="160"
                    DisplayText="Nerede yaşıyorsun?">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                Web Sitesi<br />
                <telerik:RadTextBox ID="txtWebSite" Text="http://" runat="server" Width="260px" Skin="Forest"
                    MaxLength="160">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
                <div style="float: right;">
                    <telerik:RadButton ID="btnLevel4Forward" runat="server" Text="Devam et" Skin="Hay">
                    </telerik:RadButton>
                    &nbsp;&nbsp;
                </div>
            </td>
        </tr>
    </table>
</div>
