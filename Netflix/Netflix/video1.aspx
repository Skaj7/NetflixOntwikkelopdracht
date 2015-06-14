<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="video1.aspx.cs" Inherits="Netflix.video1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Style/video1Style.css" rel="stylesheet" runat="server" />
    <div id="infodiv">
        <div id="photo">
            <img  src="#" id="imageVideo" alt="Alternate Text" runat="server"/>
        </div><%--Toont alle informatie--%>
        <div id="text">
            Maker <br />
            <br />
            <br />
            Cast <br />
            <br />
            <br />
            Genre <br />
            <br />
            Serie is <br />
            <br />
            Streaming details
        </div>
        <div id="info">
            <asp:Label id="maker" runat="server" Text="Label"></asp:Label><br />
            <br />
            <br />
            <asp:Label id="cast" runat="server" Text="Label"></asp:Label><br />
            <br />
            <br />
            <asp:Label id="genre" runat="server" Text="Label"></asp:Label><br />
            <br />
            <asp:Label id="serieIs" runat="server" Text="Label"></asp:Label><br />
            <br />
            <asp:Label id="details" runat="server" Text="Label"></asp:Label><br />
            
        </div>
        
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

</asp:Content>
