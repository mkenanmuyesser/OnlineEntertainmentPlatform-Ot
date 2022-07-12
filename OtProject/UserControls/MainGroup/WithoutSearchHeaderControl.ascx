<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WithoutSearchHeaderControl.ascx.cs"
    Inherits="OtProject.UserControls.WithoutSearchHeaderControl" %>
<style type="text/css">
    @font-face
    {
        font-family: "BenchNine";
        src: url(Develops/fonts/BenchNine-Regular.ttf);
    }
    #headertop
    {
        background-color: #279e33;
        height: 30px;
    }
    #logodiv
    {
        background-image: url('../Develops/images/otapoka_top_logo.png');
        background-repeat: no-repeat;
        height: 30px;
        width: 70px;
        float: left;
    }
    #logodiv:hover
    {
        background-image: url('../Develops/images/otapoka_top_logo2.png');
        background-repeat: no-repeat;
        height: 30px;
        width: 70px;
    }
    #motto
    {
        font-family: 'BenchNine' , sans-serif;
        font-size: 20px;
        margin-top: -2px;
        color: #279e33;
    }
</style>
<div id="headertop">
    <div style="width: 1024px; margin: 0px auto; position: relative;">
        <div id="logodiv">
            <a href="Default.aspx" style=" font-size:26px ;text-decoration: none;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a>
        </div>
        <span style="float: left; margin-top: 6px; font-family: 'BenchNine' , sans-serif;
            margin-left: -15px; font-size: 12px; color: White;">Benim Babam Senin Babanı Döver
            !</span>
    </div>
</div>
