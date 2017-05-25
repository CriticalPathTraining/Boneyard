<%@ Page Language="C#" Inherits="Microsoft.SharePoint.Publishing.PublishingLayoutPage,Microsoft.SharePoint.Publishing,Version=15.0.0.0,Culture=neutral,PublicKeyToken=71e9bce111e9429c" meta:webpartpageexpansion="full" meta:progid="SharePoint.WebPartPage.Document" %>

<%@ Register TagPrefix="SharePointWebControls" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="PublishingWebControls" Namespace="Microsoft.SharePoint.Publishing.WebControls" Assembly="Microsoft.SharePoint.Publishing, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="PublishingNavigation" Namespace="Microsoft.SharePoint.Publishing.Navigation" Assembly="Microsoft.SharePoint.Publishing, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

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

<asp:content contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
		<SharePointWebControls:FieldValue FieldName="Title" runat="server"/>
</asp:content>

<asp:content contentplaceholderid="PlaceHolderMain" runat="server">

  <PublishingWebControls:EditModePanel runat="server" CssClass="edit-mode-panel title-edit">
    <SharePointWebControls:TextField runat="server" FieldName="Title"/>
  </PublishingWebControls:EditModePanel>

  <div id="store_location_right_column">
    
    <div id="store_location_driving_directions">
      <h3>Driving Directions</h3>
      <PublishingWebControls:RichHtmlField 
          FieldName="DrivingDirections"
          HasInitialFocus="True" 
          MinimumEditHeight="120px" runat="server" >
      </PublishingWebControls:RichHtmlField>
      </div>
  
      <div id="store_location_store_hours" >
        <h3>Store Hours</h3>
        <PublishingWebControls:RichHtmlField 
          FieldName="StoreHours" 
          HasInitialFocus="True" 
          MinimumEditHeight="120px" runat="server" >
        </PublishingWebControls:RichHtmlField>
      </div>
    
    </div>

	<div id="store_location_left_column">

      <div id="store_location_image" >
	    <PublishingWebControls:RichImageField FieldName="PublishingPageImage" runat="server" >
		</PublishingWebControls:RichImageField>
      </div>

      <div id="store_location_page_content" >
        <PublishingWebControls:RichHtmlField 
          FieldName="PublishingPageContent" 
          HasInitialFocus="True" 
          MinimumEditHeight="120px" runat="server" >
        </PublishingWebControls:RichHtmlField>
      </div>

    </div>

  <div style="clear: both;" />

</asp:content>
