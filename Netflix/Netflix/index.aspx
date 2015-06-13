<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Netflix.Test" %>

<%@ Register Src="~/video.ascx" TagPrefix="uc1" TagName="video" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Style/Test.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    
        <video id="billboardvid" autoplay>
             <source src="http://so1.akam.nflximg.com/soa7/433/2085437433.mp4?v=1&amp;e=1433182153&amp;t=1XIATIRc25-vXrlxyDSeqj5yLGw" type="video/mp4" />
        </video>

    <div id="innerContent" clientidmode="Static" runat="server">

    </div>
    <a href="http://localhost:10187/video1.aspx">video1</a>

</asp:Content>
