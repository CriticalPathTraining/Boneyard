
$(onPageLoad);

function onPageLoad() {

  // make buttons pretty
  $(":button", "#toolbar").button();

  // register event handler
  $("#cmdGetCustomersList").click(onGetCustomersList);
  $("#cmdGetCustomersTable").click(onGetCustomersTable);

}

function onGetCustomersList() {
    // clear resultsArea and add spinning gears icon
    $("#results").empty();
    $("<img>", { "src": "/_layouts/images/GEARS_AN.GIF" }).appendTo("#results");

    var requestUri = _spPageContextInfo.webAbsoluteUrl + "/_api/web/lists/GetByTitle('Customers')/Items?$select=Title,FirstName,WorkPhone";

    // execute AJAX request 
    var requestHeaders = { "accept": "application/json;odata=verbose" }
    $.ajax({
        url: requestUri,
        headers: requestHeaders,
        success: onListDataReturned,
        error: onError
    });
}

function onListDataReturned(data) {
    $("#results").empty();

    var odataResults = data.d.results;

    $("<h2>").html("Customers").appendTo("#results");

    // set rendering template
    var renderingTemplate = "<li>{{=Title}}, {{=FirstName}}</li>";
    $.template("tmplLists", renderingTemplate);
    $("#results").append($("<ul>").append($.render(odataResults, "tmplLists")));
}

function onError(err) {
    $("#results").text("ERROR: " + JSON.stringify(err));
}

function onGetCustomersTable() {
    // clear resultsArea and add spinning gears icon
    $("#results").empty();
    $("<img>", { "src": "/_layouts/images/GEARS_AN.GIF" }).appendTo("#results");

    var requestUri = _spPageContextInfo.webAbsoluteUrl + "/_api/web/lists/GetByTitle('Customers')/Items?$select=Title,FirstName,WorkPhone";

    // execute AJAX request 
    var requestHeaders = { "accept": "application/json;odata=verbose" }
    $.ajax({
        url: requestUri,
        headers: requestHeaders,
        success: onTableDataReturned,
        error: onError
    });
}

function onTableDataReturned(data) {
    $("#results").empty();

    var odataResults = data.d.results;

    $("<h2>").html("Customers").appendTo("#results");

    // set rendering template
    var tableHeader = "<thead>" +
                        "<td>Last Name</td>" +
                        "<td>First Name</td>" +
                        "<td>Work Phone</td>" +
                      "</thead>";

    var table = $("<table>").append($(tableHeader));

    var renderingTemplate = "<tr>" +
                              "<td>{{=Title}}</td>" +
                              "<td>{{=FirstName}}</td>" +
                              "<td>{{=WorkPhone}}</td>" +
                            "</tr>";

    $.template("tmplTable", renderingTemplate);
    table.append($.render(odataResults, "tmplTable"));
    $("#results").append(table);
}
