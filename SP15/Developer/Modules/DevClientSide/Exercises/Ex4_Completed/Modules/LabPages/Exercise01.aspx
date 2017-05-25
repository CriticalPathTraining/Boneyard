<%@ Page MasterPageFile="~masterurl/default.master" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
    
<asp:Content ContentPlaceHolderId="PlaceHolderAdditionalPageHead" runat="server">
  
    <SharePoint:CssRegistration After="corev4.css" runat="server"
    name="<% $SPUrl:~SiteCollection/css/smoothness/jquery-ui.css%>" />	  
 
    <SharePoint:CssRegistration After="corev4.css" runat="server"
    name="<% $SPUrl:~SiteCollection/css/lab_styles.css%>" />	  
 
  <link href="styles.css" rel="stylesheet" type="text/css" />   
    
  <SharePoint:ScriptLink Name="~sitecollection/js/jquery.js" Defer="false" runat="server" />  
  <SharePoint:ScriptLink Name="~sitecollection/js/jquery-ui.js" Defer="false" runat="server" />  
  
  <script src="Exercise01.js" type="text/javascript" ></script>

</asp:Content>    

<asp:Content ContentPlaceHolderId="PlaceHolderMain" runat="server">
   
  <div id="toolbar" class="ui-widget-header" >
    <input id="cmdGetSiteInfo" type="button" value="Get Site Info"  />
  </div>
  
  <div id="results" />
  
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
  REST Lab - Exercise 1
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageTitleInTitleArea" runat="server">
  REST Lab - Exercise 1
</asp:Content>