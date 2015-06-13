<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Netflix.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <link href="Style/loginStyle.css" rel="stylesheet" />
        <div id="loginpos">
            <div>
            <asp:Label Text="gebruikersnaam" runat="server" />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </div><div>
            <asp:Label Text="Wachtwoord" runat="server" />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </div>
        </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentDown" runat="server">
        
</asp:Content>
