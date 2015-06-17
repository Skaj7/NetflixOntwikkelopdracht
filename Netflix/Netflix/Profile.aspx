<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Netflix.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <link href="Style/profileStyle.css" rel="stylesheet" runat="server" />
        <div id="loginpos">
            <p>Kies je profiel</p> <%--maar 3 omdat een account maar die profielen mag hebben--%>
            <div style="float:left">
            <asp:Label Text="e" id="lbl1" runat="server" />
                <asp:Button ID="profile1" runat="server" Text="profiel" OnClick="profiel1_Click" />
                <img src="#" id="image1" alt="Alternate Text" runat="server" style="max-height: 150px; max-width: 150px;" />
            </div>
            <div style="float:left">
            <asp:Label Text="" ID="lbl2" runat="server" />
                <asp:Button ID="profile2" runat="server" Text="profiel" OnClick="profiel2_Click"/>
                <img src="#" id="image2" alt="Alternate Text" runat="server" style="max-height: 150px; max-width: 150px;" />
            </div>
            <div style="float:right">
            <asp:Label Text="" ID="lbl3" runat="server" />
                <asp:Button ID="profile3" runat="server" Text="profiel" OnClick="profile3_Click"/>
                <img src="#" id="image3" alt="Alternate Text" runat="server" style="max-height: 150px; max-width: 150px;"/>
            </div>
        </div>    
    

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentDown" runat="server">
            <p style="  text-align: center; text-decoration: underline;">Nieuw profiel aanmaken</p><%--profiel maken--%>
    <div style="float:left; margin-left:20%; font-family: Arial, Helvetica, sans-serif; font-weight: bold; padding: 5px;">   
        AFBEELDING <br />
        NAAM <br />
        LEEFTIJDSCATEGORIE <br />
        <br />
        TAAL <br />
    </div>
    <div id="NewProfile" style="width: 300px; margin-left: 50px; margin-bottom: 80px; float:left;">
        <asp:TextBox style="height: 14px;" ID="tbafbeelding" runat="server"></asp:TextBox> 
        <asp:TextBox style="height: 14px;" ID="tbnaam" runat="server"></asp:TextBox>
        <asp:TextBox style="height: 14px;" ID="tbleeftijd" runat="server"></asp:TextBox> Kleine kinderen, Oudere kinderen, Tieners, Volwassenen <%--mogelijke opties--%>
        <asp:TextBox style="height: 14px;" ID="tbtaal" runat="server"></asp:TextBox>
    </div>
    <div id="fieldV" style="width: 300px; margin-bottom: 80px; float:left;">
        <asp:RequiredFieldValidator runat="server" id="reqAfbeelding" controltovalidate="tbafbeelding" errormessage="Please enter a picture link" enableclientscript="false" /> <br />
        <asp:RequiredFieldValidator runat="server" id="reqNaamProfile" controltovalidate="tbnaam" errormessage="Please enter name" enableclientscript="false" /> <br />
        <asp:RequiredFieldValidator runat="server" id="reqLeeftijd" controltovalidate="tbleeftijd" errormessage="Please enter age group" enableclientscript="false" /> <br /> <br />
        <asp:RequiredFieldValidator runat="server" id="reqTaal" controltovalidate="tbtaal" errormessage="Please enter your language" enableclientscript="false" /> <br />
    </div>
    <asp:Button ID="newprofile" runat="server" Text="aanmaken" OnClick="newprofile_Click"/>
</asp:Content>
