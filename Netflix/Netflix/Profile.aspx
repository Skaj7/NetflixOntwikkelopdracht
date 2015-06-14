<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Netflix.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <link href="Style/profileStyle.css" rel="stylesheet" />
        <div id="loginpos">
            <div style="float:left">
            <asp:Label Text="e-mail adres" id="lbl1" runat="server" />
            <asp:TextBox ID="user" runat="server"></asp:TextBox>
                <asp:Button ID="profiel1" runat="server" Text="profiel" OnClick="profiel1_Click" />
                <img src="#" id="afbeelding1" alt="Alternate Text" runat="server" />
            </div><div style="float:right">
            <asp:Label Text="Wachtwoord" ID="lbl2" runat="server" />
            <asp:TextBox ID="password" runat="server"></asp:TextBox>
                <asp:Button ID="profiel2" runat="server" Text="profiel" OnClick="profiel2_Click"/>
                <img src="#" id="afbeelding2" alt="Alternate Text" runat="server" />
            </div>
        </div>    

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentDown" runat="server">
</asp:Content>
