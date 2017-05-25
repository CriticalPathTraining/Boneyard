
// register onPageLoad function with jquery Document Ready event handler
$(onPageLoad);

function onPageLoad() {
    // use jquery-ui to format command button
    $(":button", "#toolbar").button();
    // register event handler for click event
    $("#cmdGetSiteInfo").click(onGetSiteInfo);
}

function onGetSiteInfo() {
    // clear resultsArea and add spinning gears icon
    $("#results").empty();
    $("<img>", { "src": "/_layouts/images/GEARS_AN.GIF" }).appendTo("#results");

    var requestUri = _spPageContextInfo.webAbsoluteUrl + "/_api/web";

    // execute AJAX request 
    var requestHeaders = { "accept": "application/json;odata=verbose" }
    $.ajax({
        url: requestUri,
        headers: requestHeaders,
        success: onDataReturned,
        error: onError
    });
}

function onDataReturned(data) {
    $("#results").empty();

    var odataResults = data.d;

    $("<h2>").html("Site Properties").appendTo("#results");
    $("<p>").html("<b>Id</b>: " + odataResults.Id).appendTo("#results");
    $("<p>").html("<b>Url</b>: " + odataResults.Url).appendTo("#results");
    $("<p>").html("<b>Title</b>: " + odataResults.Title).appendTo("#results");
    $("<p>").html("<b>MasterUrl</b>: " + odataResults.MasterUrl).appendTo("#results");
    $("<p>").html("<b>Language</b>: " + odataResults.Language).appendTo("#results");
}

function onError(err) {
    $("#results").text("ERROR: " + JSON.stringify(err));
}
