<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="video.ascx.cs" Inherits="Netflix.video" %>
    <div style="float:left; margin-right: 30px;"">
    <a href="#" id="videotoe" runat="server"><%--Link naar de film/serie--%>
    <img src="#" alt="Alternate Text" id="photo" runat="server"/><%--maakt een link van de afbeelding--%>
    </a>
   

    <a href="#" id="Toevideo" onClick="myFunction()" runat="server"><%--link naar de informatie pagina van de film/serie--%>
    <div class="videoid1" runat="server" id="videoname"></div> <%--maakt een link van de titel van de film/serie--%>
    </a>
    </div>