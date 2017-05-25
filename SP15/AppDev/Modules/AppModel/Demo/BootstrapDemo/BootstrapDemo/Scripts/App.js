'use strict';

$(document).ready(onPageLoad);

function onPageLoad() {
  // get URL back to host web
  var urlHostWeb = getQueryStringParameter("SPHostUrl");
  // configure URL for link back to host web
  $("#lnkHostWeb").attr("href", urlHostWeb);
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