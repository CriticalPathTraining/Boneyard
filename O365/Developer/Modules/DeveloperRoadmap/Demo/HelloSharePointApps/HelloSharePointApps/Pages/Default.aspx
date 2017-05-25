<%@ Page Inherits="Microsoft.SharePoint.WebPartPages.WebPartPage, Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" MasterPageFile="~masterurl/default.master" Language="C#" %>

<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<asp:Content ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

  <script type="text/javascript" src="../Scripts/jquery-1.9.1.min.js"></script>
  <script type="text/javascript" src="/_layouts/15/sp.runtime.js"></script>
  <script type="text/javascript" src="/_layouts/15/sp.js"></script>
  <meta name="WebPartPageExpansion" content="full" />

  <link rel="Stylesheet" type="text/css" href="../Content/App.css" />
  <script type="text/javascript" src="../Scripts/App.js"></script>
  <link href="../Content/App.css" rel="stylesheet" />

</asp:Content>

<asp:Content ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server">
  Hello SharePoint Apps
</asp:Content>

<asp:Content ContentPlaceHolderID="PlaceHolderMain" runat="server">

  <nav id="toolbar">
    <input type="button" id="cmdSayHello" value="Say Hello" />
  </nav>

  <div id="content_box"></div>

</asp:Content>


