<%@ Page Inherits="Microsoft.SharePoint.WebPartPages.WebPartPage, Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" MasterPageFile="~masterurl/default.master" Language="C#" %>

<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<asp:Content ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

  <script type="text/javascript" src="../Scripts/jquery-2.0.3.js"></script>
  
  <link href="../Content/themes/redmond/jquery-ui.css" rel="stylesheet" />
  <script src="../Scripts/jquery-ui-1.10.3.js"></script>

  <script src="../Scripts/jsrender.js"></script>

  <link rel="Stylesheet" type="text/css" href="../Content/App.css" />
  <script type="text/javascript" src="../Scripts/App.js"></script>

</asp:Content>

<asp:Content ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
  REST API Demo
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server">
  SharePoint 2013 REST API Demo
</asp:Content>


<asp:Content ContentPlaceHolderID="PlaceHolderMain" runat="server">

  <div id="toolbar"  class="ui-widget-header" >
    <input type="button" id="cmdAddNewCustomer" value="Add New Customer" class="ui-button" />
  </div>

  <div id="results"></div>

  <div id="customer_dialog" style="display: none;" class="ui-widget-content">
    <table>
      <tr>
        <td>First Name:</td>
        <td>
          <input id="txtFirstName" /></td>
      </tr>
      <tr>
        <td>Last Name:</td>
        <td>
          <input id="txtLastName" /></td>
      </tr>
      <tr>
        <td>Phone:</td>
        <td>
          <input id="txtPhone" /></td>
      </tr>
    </table>

    <!-- hidden controls -->
    <div style="display: none">
      <input id="txtId" />
      <input id="txtETag" />
    </div>

  </div>

</asp:Content>
