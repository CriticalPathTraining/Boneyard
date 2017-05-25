
$(onPageLoad);

function onPageLoad() {

  // make buttons pretty
  $(":button", "#toolbar").button();

  // register event handler
  $("#cmdGetLists").click(onGetLists);
}

function onGetLists() {
  // clear resultsArea and add spinning gears icon
  $("#results").empty();
  $("<img>", { "src": "/_layouts/images/GEARS_AN.GIF" }).appendTo("#results");

  // begin work to call across network
  var requestUri = _spPageContextInfo.webAbsoluteUrl + "/_api/Web/Lists";

    // execute AJAX request 
  var requestHeaders = {
      "accept": "application/json;odata=verbose"
  }
  $.ajax({
      url: requestUri,
      headers: requestHeaders,
      success: onDataReturned,
      error: onError
  });
}

function onDataReturned(data) {
  $("#results").empty();

  var odataResults = data.d.results;

  $("<h2>").html("Lists in this site").appendTo("#results");

  var ul = $("<ul>");

  for (var i = 0; i < odataResults.length; i++) {
    $("<li>").html(odataResults[i].Title).appendTo(ul);
  }

  ul.appendTo("#results");
}

function onError(err) {
  $("#results").text("ERROR: " + JSON.stringify(err));
}
