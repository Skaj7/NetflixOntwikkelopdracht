﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NetflixHome.aspx.cs" Inherits="Netflix.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Style/NetflixHome.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="topbar">
            <a href="http://www2.netflix.com/WiHome"></a>
        dadasdadasdancjnascnasnckaslcnklasnckasncnakslnckanscnlkanclknas
        </div>

        <div id="billboard">
            
            <video id="billboardvid" autoplay>
                <source src="http://so1.akam.nflximg.com/soa7/433/2085437433.mp4?v=1&amp;e=1433182153&amp;t=1XIATIRc25-vXrlxyDSeqj5yLGw" type="video/mp4" />
            </video>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            <%--<img id="billboardpic" src="extra/Sense8-2.jpg" alt="Alternate Text" />--%>
            
        </div>
    </form>
</body>
</html>