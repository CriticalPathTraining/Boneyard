'use strict';

$(document).ready(onPageLoad);

function onPageLoad() {
  $("#cmdSayHello").click(onSayHello);
  // add call to addLinkBackToHostWeb
  addLinkBackToHostWeb();
}

function onSayHello() {
  $("#content_box")
    .text("Hello, I am your shiny new SharePoint app.")
    .css({ "font-size": "48px", "color": "red", "padding": "16px" })
}

function addLinkBackToHostWeb() {
  // get URL back to host web
  var urlHostWeb = getQueryStringParameter("SPHostUrl");
  // create <a> elements and link it to host web
  var linkHostWeb = $("<a>").attr("href", urlHostWeb)
                            .css({ "color": "white", "text-decoration": "none" })
                            .text("Back to Host Web");
  // append link into nav_bar div
  $("#nav_bar").append(linkHostWeb);
}

function getQueryStringParameter(param) {
  var querystring = document.URL.split("?")[1];
  if (querystring) {
    var params = querystring.split("&");
    for (var index = 0; (index < params.length) ; index++) {
      var current = params[index].split("=");
      if (param.toUpperCase() === current[0].toUpperCase()) {
        return decodeURIComponent(current[1]);
      }
    }
  }
}


