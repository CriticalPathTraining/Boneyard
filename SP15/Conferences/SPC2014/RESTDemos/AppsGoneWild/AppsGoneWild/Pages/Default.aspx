<%@ Page Inherits="Microsoft.SharePoint.WebPartPages.WebPartPage, Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<!DOCTYPE html>

<html>

<head id="Head1" runat="server">

    <meta http-equiv="Content-type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=10" />
    <meta http-equiv="Expires" content="0" />
    <meta name="WebPartPageExpansion" content="full" />

    <title>Apps Gone Wild</title>

    <SharePoint:StartScript runat="server" />
    <SharePoint:CacheManifestLink runat="server" />
    <SharePoint:ScriptLink Language="javascript" Name="core.js" OnDemand="true" runat="server" Localizable="false" />
    <SharePoint:ScriptLink Language="javascript" Name="menu.js" OnDemand="true" runat="server" Localizable="false" />
    <SharePoint:ScriptLink Language="javascript" Name="callout.js" OnDemand="true" runat="server" Localizable="false" />
    <SharePoint:ScriptLink Language="javascript" Name="sharing.js" OnDemand="true" runat="server" Localizable="false" />
    <SharePoint:ScriptLink Language="javascript" Name="suitelinks.js" OnDemand="true" runat="server" Localizable="false" />

    <script type="text/javascript" src="/_layouts/15/sp.runtime.js"></script>
    <script type="text/javascript" src="/_layouts/15/sp.js"></script>


    <script src="../Scripts/jquery-2.1.0.js"></script>

    <script src="../Scripts/App.js" type="text/javascript"></script>
    <link href="../Content/App.css" rel="Stylesheet" type="text/css" />

</head>
<body>
    <form runat="server">
        <WebPartPages:SPWebPartManager ID="SPWebPartManager1" runat="Server" />
        <asp:ScriptManager id="ScriptManager" runat="server" 
                           EnablePageMethods="false" 
                           EnablePartialRendering="true" 
                           EnableScriptGlobalization="false" 
                           EnableScriptLocalization="true" />

        <div id="page_width">

            <div id="top_row">
                <SharePoint:ReturnToParentLink
                    ID="BackToParentLink"
                    runat="server"
                    Icon="../Content/img/backarrow.png" />
            </div>

            <div id="banner">
                <div id="site_logo">&nbsp;</div>
                <div id="site_title">Apps Gone Wild - the Good, the Bad and the Ugly</div>
            </div>

            <div id="toolbar">

                <input id="cmdAJAXwithXMLHttpRequest" type="button" value="XMLHttpRequest" />
                <input id="cmdAJAXwithjQuery" type="button" value="jQuery.ajax()" />

                <input id="cmdAppWeb1" type="button" value="AppWeb1" />
                <input id="cmdAppWeb2" type="button" value="AppWeb2" />
                <input id="cmdAppWeb3" type="button" value="AppWeb3" />

                <input id="cmdHostWeb1" type="button" value="HostWeb1" />
                <input id="cmdHostWeb2" type="button" value="HostWeb2" />
                <input id="cmdHostWeb3" type="button" value="HostWeb3" />
                <input id="cmdHostWeb4" type="button" value="HostWeb4" />
                <input id="cmdHostWeb5" type="button" value="HostWeb5" />
                <input id="cmdHostWeb6" type="button" value="HostWeb6" />
                <input id="cmdHostWeb7" type="button" value="HostWeb7" />
                
            </div>

            <div id="url_showcase"></div>

            <div id="content_box"></div>
                        
        </div>

    </form>
</body>
</html>
