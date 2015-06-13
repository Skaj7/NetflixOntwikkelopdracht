<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Netflix.Test" %>

<%@ Register Src="~/video.ascx" TagPrefix="uc1" TagName="video" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <link href="Style/indexStyle.css" rel="stylesheet" />
    <div id="billboard">
        <video id="billboardvid" autoplay>
             <source src="http://so1.akam.nflximg.com/soa7/433/2085437433.mp4?v=1&amp;e=1433182153&amp;t=1XIATIRc25-vXrlxyDSeqj5yLGw" type="video/mp4" />
        </video>
    </div>
    <asp:Label ID="Label1" runat="server" Text="Search"></asp:Label>
    <asp:TextBox ID="Search" runat="server" OnTextChanged="Search_TextChanged"></asp:TextBox>
    <%--<div style=" position: fixed; background-color: #CCCCCC; bottom: 0; width: 100%;">--%>
    <%--<div id="innerContent" clientidmode="Static" runat="server">--%>

    <%--</div>--%>
    <%--</div>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentDown" runat="server">
    <div id="innerContent" clientidmode="Static" runat="server">

    </div>
</asp:Content>

