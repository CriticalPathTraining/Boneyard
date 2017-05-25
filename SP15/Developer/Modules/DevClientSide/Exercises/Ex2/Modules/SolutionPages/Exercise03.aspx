<%@ Page language="C#" MasterPageFile="~masterurl/default.master" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
    
<asp:Content ContentPlaceHolderId="PlaceHolderAdditionalPageHead" runat="server">
  
  <SharePoint:CssRegistration ID="CssRegistration1" After="corev4.css" runat="server"
    name="<% $SPUrl:~SiteCollection/css/smoothness/jquery-ui.css%>" />	  
 
  <SharePoint:CssRegistration ID="CssRegistration2" After="corev4.css" runat="server"
    name="<% $SPUrl:~SiteCollection/css/lab_styles.css%>" />	  
    
  <SharePoint:ScriptLink Name="~sitecollection/js/jquery.js" Defer="false" runat="server" />  
  <SharePoint:ScriptLink ID="ScriptLink1" Name="~sitecollection/js/jquery-ui.js" Defer="false" runat="server" />  
  <SharePoint:ScriptLink ID="ScriptLink2" Name="~sitecollection/js/jsrender.js" Defer="false" runat="server" />  
  
  <script src="Exercise03.js" type="text/javascript" ></script>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">
   
  <div id="toolbar" class="ui-widget-header" >
    <input id="cmdGetUserLists" type="button" value="Get User Lists"  />
  </div>
  
  <div id="results" />
  
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
  REST Lab - Solution to Exercise 3
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageTitleInTitleArea" runat="server">
  REST Lab - Solution to Exercise 3
</asp:Content>