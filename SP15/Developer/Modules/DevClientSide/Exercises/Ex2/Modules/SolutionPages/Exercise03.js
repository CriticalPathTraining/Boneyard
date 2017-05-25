
$(onPageLoad);

function onPageLoad() {
  // make buttons pretty
  $(":button", "#toolbar").button();
  // register event handler
  $("#cmdGetUserLists").click(onGetUserLists);
}

function onGetUserLists() {
    // clear resultsArea and add spinning gears icon
    $("#results").empty();
    $("<img>", { "src": "/_layouts/images/GEARS_AN.GIF" }).appendTo("#results");

    // begin work to call across network
    var requestUri = _spPageContextInfo.webAbsoluteUrl + "/_api/Web/Lists?$filter=Hidden eq false";

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

    // create a template using jsRender library
    renderingTemplate = "<li>{{=Title}}</li>";
    $.template("tmplLists", renderingTemplate);

    // generate output from array using template
    var ol = $("<ol>");
    ol.append($.render(odataResults, "tmplLists"));
    $("#results").append(ol);
}

function onError(err) {
  $("#results").text("ERROR: " + JSON.stringify(err));
}