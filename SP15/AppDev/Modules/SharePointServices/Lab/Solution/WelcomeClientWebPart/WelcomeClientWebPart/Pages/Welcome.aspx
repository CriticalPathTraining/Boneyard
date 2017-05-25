<%@ Page language="C#" Inherits="Microsoft.SharePoint.WebPartPages.WebPartPage, Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<WebPartPages:AllowFraming ID="AllowFraming" runat="server" />

<html>
<head>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9" >
        <title></title>

    <script type="text/javascript" src="../Scripts/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="/_layouts/15/MicrosoftAjax.js"></script>
    <script type="text/javascript" src="/_layouts/15/sp.runtime.js"></script>
    <script type="text/javascript" src="/_layouts/15/sp.js"></script>

    <script type="text/javascript">
        'use strict';

        // Set the style of the client web part page to be consistent with the host web.
        (function () {
            var hostUrl = '';
            if (document.URL.indexOf('?') != -1) {
                var params = document.URL.split('?')[1].split('&');
                for (var i = 0; i < params.length; i++) {
                    var p = decodeURIComponent(params[i]);
                    if (/^SPHostUrl=/i.test(p)) {
                        hostUrl = p.split('=')[1];
                        document.write('<link rel="stylesheet" href="' + hostUrl + '/_layouts/15/defaultcss.ashx" />');
                        break;
                    }
                }
            }
            if (hostUrl == '') {
                document.write('<link rel="stylesheet" href="/_layouts/15/1033/styles/themable/corev15.css" />');
            }
        })();
    </script>
    <script type="text/javascript" src="../Scripts/knockout-2.1.0.js"></script>
    <script type="text/javascript" src="../Scripts/WelcomeViewModel.js"></script>
    <script type="text/javascript" src="../Scripts/App.js"></script>

</head>
<body>
<div>
    <article>
        <div id="portrait" style="text-align:center;">
            <figure>
                <img src="#" data-bind="attr: { src: get_pictureUrl() }" alt="photo" />
            </figure>
        </div>
        <div style="text-align:center;">
            <figcaption>
                Welcome <span data-bind="text: get_displayName()"></span>
            </figcaption>
        </div>
    </article>
</div>
</body>
</html>
