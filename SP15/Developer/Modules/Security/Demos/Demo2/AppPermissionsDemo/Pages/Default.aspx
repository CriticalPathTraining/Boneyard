<%@ Page Inherits="Microsoft.SharePoint.WebPartPages.WebPartPage, Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" MasterPageFile="~masterurl/default.master" Language="C#" %>

<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<asp:Content ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
  <script type="text/javascript" src="../Scripts/jquery-1.6.2.min.js"></script>
  <link rel="Stylesheet" type="text/css" href="../Content/App.css" />
  <script type="text/javascript" src="../Scripts/App.js"></script>
</asp:Content>

<asp:Content ContentPlaceHolderID="PlaceHolderMain" runat="server">

  <div id="toolbar">
    <input type="button" id="cmdGetSiteInfo" value="Get Site Info" />
  </div>

  <div id="results" />

</asp:Content>
