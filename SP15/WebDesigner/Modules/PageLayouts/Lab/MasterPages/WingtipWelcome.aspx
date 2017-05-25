<%@ Page language="C#"   Inherits="Microsoft.SharePoint.Publishing.PublishingLayoutPage,Microsoft.SharePoint.Publishing,Version=15.0.0.0,Culture=neutral,PublicKeyToken=71e9bce111e9429c" meta:webpartpageexpansion="full" meta:progid="SharePoint.WebPartPage.Document" %>

<%@ Register Tagprefix="SharePointWebControls" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="PublishingWebControls" Namespace="Microsoft.SharePoint.Publishing.WebControls" Assembly="Microsoft.SharePoint.Publishing, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="PublishingNavigation" Namespace="Microsoft.SharePoint.Publishing.Navigation" Assembly="Microsoft.SharePoint.Publishing, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<asp:content contentplaceholderid="PlaceHolderAdditionalPageHead" runat="server">
  
  <SharePointWebControls:CssRegistration name="&lt;% $SPUrl:~sitecollection/Style Library/~language/Themable/Core Styles/pagelayouts15.css %&gt;" runat="server" />

  <PublishingWebControls:EditModePanel runat="server">

    <SharePointWebControls:CssRegistration 
      name="&lt;% $SPUrl:~sitecollection/Style Library/~language/Themable/Core Styles/editmode15.css %&gt; "
			After="&lt;% $SPUrl:~sitecollection/Style Library/~language/Themable/Core Styles/pagelayouts15.css %&gt;" 
      runat="server"/>

  </PublishingWebControls:EditModePanel>

</asp:content>

<asp:content contentplaceholderid="PlaceHolderPageTitle" runat="server">
  <SharePointWebControls:FieldValue FieldName="Title" runat="server"/>
</asp:content>

<asp:Content ContentPlaceholderID="PlaceHolderPageTitleInTitleArea" runat="server" >
		<SharePointWebControls:FieldValue FieldName="Title" runat="server"/>
</asp:Content>

<asp:Content ContentPlaceholderID="PlaceHolderMain" runat="server">

 <PublishingWebControls:EditModePanel runat="server" CssClass="edit-mode-panel title-edit">
    <SharePointWebControls:TextField runat="server" FieldName="Title"/>
  </PublishingWebControls:EditModePanel>

  <div class="welcome-content">

    <PublishingWebControls:RichHtmlField 
      FieldName="PublishingPageContent" 
      HasInitialFocus="True"
      MinimumEditHeight="120px" 
      runat="server"/>

  </div>
  
    
  <div class="ms-table ms-fullWidth">
    <div class="tableCol-50">
      <WebPartPages:WebPartZone runat="server" ID="Left" Title="Left Zone"  >
      </WebPartPages:WebPartZone>
    </div>
    <div class="tableCol-50">
      <WebPartPages:WebPartZone runat="server" ID="Right" Title="Right Zone" >
      </WebPartPages:WebPartZone>
    </div>
  </div>

</asp:Content>