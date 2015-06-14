<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Netflix.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <link href="Style/loginStyle.css" rel="stylesheet" runat="server" />
        <div id="loginpos"> <%--positie van de login label en textbox--%>
            <%--Field validator voor je email en password--%>
            <asp:RequiredFieldValidator runat="server" id="reqEmail" controltovalidate="user" errormessage="Please enter your email!" enableclientscript="false" />
            <asp:RequiredFieldValidator runat="server" id="reqpassword" controltovalidate="password" errormessage="Please enter your password!" enableclientscript="false" />
            <div>
            <asp:Label Text="e-mail adres" runat="server" />
            <asp:TextBox ID="user" runat="server"></asp:TextBox>
            </div><div>
            <asp:Label Text="Wachtwoord" runat="server" />
            <asp:TextBox ID="password" runat="server"></asp:TextBox>
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="Login_Click" />
            </div>
        </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentDown" runat="server">
        
</asp:Content>
