﻿	<%@ Register TagPrefix="GroupBoardMobile"   Namespace="Microsoft.SharePoint.Applications.GroupBoard.MobileControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#"   EnableViewState="false" inherits="Microsoft.SharePoint.MobileControls.SPMobilePage, Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c"%> <%@ Assembly Name="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" %> <%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Register TagPrefix="SPMobile" Namespace="Microsoft.SharePoint.MobileControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <mobile:StyleSheet RunAt="Server" ID="SharePointMobileStyleSheet" />
<SPMobile:SPMobileForm RunAt="Server">
	<SPMobile:SPMobileUrlRedirection Runat="Server" />
</SPMobile:SPMobileForm>
