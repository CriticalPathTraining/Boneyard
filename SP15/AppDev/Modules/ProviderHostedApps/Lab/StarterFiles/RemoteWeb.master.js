
$(function LoadChromeControl() {

  // determine URL back to host web
  var hostWebUrl = decodeURIComponent(getQueryStringParameter("SPHostUrl"));

  // create setting object for Chrome control
  var options = {
    siteUrl: hostWebUrl,
    siteTitle: "Back to Host Web",
    appHelpPageUrl: "help.aspx?SPHostUrl=" + hostWebUrl,
    appIconUrl: "/Content/img/AppIcon.png",
    appTitle: "Customer Manager App",
    settingsLinks: [
      { linkUrl: "start.aspx?SPHostUrl=" + hostWebUrl, displayName: "Home" },
      { linkUrl: "about.aspx?SPHostUrl=" + hostWebUrl, displayName: "About" },
      { linkUrl: "contact.aspx?SPHostUrl=" + hostWebUrl, displayName: "Contact" }
    ]
  };

  // create Chrome control instance
  var nav = new SP.UI.Controls.Navigation("chrome_ctrl_container", options);
  nav.setVisible(true);

  // fix RTM bug with help link
  var helpIconUrl = hostWebUrl + "/_layouts/15/1033/images/spintl.png";
  var helpLink = $("#chromeControl_topheader_helplink")
  helpLink.css({ "background-image": "url('" + helpIconUrl + "')" });

});

function getQueryStringParameter(paramToRetrieve) {
  var params = document.URL.split("?")[1].split("&");
  var strParams = "";
  for (var i = 0; i < params.length; i = i + 1) {
    var singleParam = params[i].split("=");
    if (singleParam[0] == paramToRetrieve)
      return singleParam[1];
  }
}