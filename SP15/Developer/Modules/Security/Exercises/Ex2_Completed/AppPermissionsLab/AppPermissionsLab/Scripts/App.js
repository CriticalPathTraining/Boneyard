$(onPageReady);

function onPageReady() {
  $("#cmdGetSiteInfo").click(onGetSiteInfo);
}

function onGetSiteInfo() {

  // create URL to make REST call into host web
  var urlHostSite = _spPageContextInfo.siteAbsoluteUrl;
  var urlRestCall = urlHostSite + "/_api/web?$select=Title, Url";

  // issue web service request against host web
  var ajaxOptions = {
    url: urlRestCall,
    type: "GET",
    headers: { "ACCEPT": "application/json;odata=verbose" },
    contentType: "application/json",
    success: onComplete,
    error: onError,
  };

  $.ajax(ajaxOptions);
}

function onComplete(data) {
  var siteTitle = data.d.Title;
  $("#results").html($("<p>").text("Title of top-level site: " + siteTitle));
};

function onError(error) {
  var errorNumber = error.status;
  var errorMessage = errorNumber + " - " + error.statusText;
  $("#results").html($("<p>").text("An error has occurred: " + errorMessage));
}