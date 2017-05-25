<%@ Page Inherits="Microsoft.SharePoint.WebPartPages.WebPartPage, Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" MasterPageFile="~masterurl/default.master" Language="C#" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<asp:Content ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <link rel="Stylesheet" type="text/css" href="../Content/App.css" />
    <script type="text/javascript" src="../Scripts/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/knockout-2.3.0.js"></script>
    <script type="text/javascript" src="/_layouts/15/sp.runtime.js"></script>
    <script type="text/javascript" src="/_layouts/15/sp.js"></script>
    <script type="text/javascript" src="/_layouts/15/sp.ui.dialog.js"></script>
    <script type="text/javascript" src="../Scripts/wingtip.contacts.data.js"></script>
    <script type="text/javascript" src="../Scripts/wingtip.contacts.model.js"></script>
    <script type="text/javascript" src="../Scripts/wingtip.contacts.viewmodel.js"></script>
    <script type="text/javascript" src="../Scripts/DefaultPageEvents.js"></script>
</asp:Content>

<asp:Content ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server">
    MVVM
</asp:Content>

<asp:Content ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <div id="toolbarWindow">
        <input type="button" id="newButton" value="New" />
    </div>
    <div id="resultsDiv" style="overflow: auto">
        <!-- Knockout binding code goes here -->
    </div>
</asp:Content>
