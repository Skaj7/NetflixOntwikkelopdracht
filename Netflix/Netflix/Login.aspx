<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Netflix.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <link href="Style/loginStyle.css" rel="stylesheet" />
        <div id="loginpos">
            <div>
            <asp:Label Text="e-mail adres" runat="server" />
            <asp:TextBox ID="user" runat="server"></asp:TextBox>
            </div><div>
            <asp:Label Text="Wachtwoord" runat="server" />
            <asp:TextBox ID="password" runat="server"></asp:TextBox>
                <asp:Button ID="Login" runat="server" Text="Login" OnClick="Login_Click" />
            </div>
        </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentDown" runat="server">
        
</asp:Content>
