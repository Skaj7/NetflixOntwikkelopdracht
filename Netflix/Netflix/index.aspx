<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Netflix.Test" %>

<%@ Register Src="~/video.ascx" TagPrefix="uc1" TagName="video" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <link href="Style/indexStyle.css" rel="stylesheet" />
    <div id="billboard">
        <video id="billboardvid" autoplay="autoplay"><%--autoplay video--%>
             <source src="http://so1.akam.nflximg.com/soa7/433/2085437433.mp4?v=1&amp;e=1433182153&amp;t=1XIATIRc25-vXrlxyDSeqj5yLGw" type="video/mp4" />
        </video>
    </div>
    <%--search opties--%>
    <asp:Label ID="Label1" runat="server" Text="Search titel"></asp:Label>
    <asp:TextBox ID="SearchTitle" runat="server" OnTextChanged="SearchTitle_TextChanged" AutoPostBack="True"></asp:TextBox>  
    <asp:Label ID="Label2" runat="server" Text="Search genre"></asp:Label>
    <asp:TextBox ID="SearchGenre" runat="server" OnTextChanged="SearchGenre_TextChanged" AutoPostBack="True"></asp:TextBox>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentDown" runat="server">
    <div id="innerContent" clientidmode="Static" runat="server"> <%--uc--%> 

    </div>
</asp:Content>

