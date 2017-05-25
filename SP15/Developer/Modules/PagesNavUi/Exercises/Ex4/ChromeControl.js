function renderChromeControl() {
  var options = {
    siteUrl: hostWebUrl,
    siteTitle: "Host Web",
    appHelpPageUrl: "help.aspx?SPHostUrl=" + hostWebUrl,
    appIconUrl: "/Contents/AppIcon.png",
    appTitle: "Wingtip App",
    settingsLinks: [
      { linkUrl: "start.aspx?SPHostUrl=" + hostWebUrl, displayName: "Home" },
      { linkUrl: "about.aspx?SPHostUrl=" + hostWebUrl, displayName: "About" },
      { linkUrl: "contact.aspx?SPHostUrl=" + hostWebUrl, displayName: "Contact" }
    ]
  };

  var nav = new SP.UI.Controls.Navigation("chrome_ctrl_container", options);
  nav.setVisible(true);
} 
