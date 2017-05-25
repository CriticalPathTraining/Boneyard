
$(function () {

  $("#cmdAddNewCustomer").click(onAddCustomerRequest);
  $("#cmdAddNewCustomer").button();

  $("#results").append($("<img>", { src: "_layouts/images/gears_anv4.gif" }));

  // retrieve customer items
  getCustomers();
});

function getCustomers() {

  // clear results and add spinning gears icon
  $("#results").empty();
  $("<img>", { "src": "/_layouts/images/GEARS_AN.GIF" }).appendTo("#results");

  // parse target URI for customer list in app web
  var requestUri = _spPageContextInfo.webAbsoluteUrl +
                "/_api/Web/Lists/getByTitle('Customers')/items/" +
                "?$select=Id,FirstName,Title,WorkPhone" +
                "&$orderby=Title,FirstName";


  // create object for request headers
  var requestHeaders = {
    "accept": "application/json;odata=verbose"
  }

  // send call across network
  $.ajax({
    url: requestUri,
    headers: requestHeaders,
    success: onGetCustomersComplete,
    error: onError
  });

}

function onGetCustomersComplete(data) {

  $("#results").empty();

  var odataResults = data.d.results;

  // set rendering template
  var tableHeader = "<thead>" +
                      "<td>Last Name</td>" +
                      "<td>First Name</td>" +
                      "<td>Work Phone</td>" +
                      "<td>&nbsp;</td>" +
                      "<td>&nbsp;</td>" +
                    "</thead>";

  var table = $("<table>", {id:"customersTable"}).append($(tableHeader));

  // create rendering template for table row using jsRender syntax
  var rowTemplateString = "<tr>" +
                            "<td>{{>Title}}</td>" +
                            "<td>{{>FirstName}}</td>" +
                            "<td>{{>WorkPhone}}</td>" +
                            "<td><a href='javascript: onDeleteCustomer({{>Id}});'><img src='_layouts/images/DELITEM.gif' alt='Delete' /></a></td>" +
                            "<td><a href='javascript: onUpdateCustomerRequest({{>Id}});'><img src='_layouts/images/EDITITEM.gif' alt='Edit' /></a></td>" +
                          "</tr>";

  // load row template and give it a name of "rowTemplate"
  $.templates({ "rowTemplate": rowTemplateString });

  // render table rows using row template and OData data result
  table.append($.render.rowTemplate(odataResults));

  // append table to div in DOM
  $("#results").append(table);

}

function onAddCustomerRequest(event) {

  $("#txtFirstName").val("");
  $("#txtLastName").val("");
  $("#txtPhone").val("");

  var customer_dialog = $("#customer_dialog");

  customer_dialog.dialog({
    autoOpen: true,
    title: "Add Customer",
    width: 320,
    buttons: {
      "Add": function () {
        onAddCustomer();
        $(this).dialog("close");
      },
      "Cancel": function () { $(this).dialog("close"); },
    }
  });

}

function onAddCustomer() {

  // get input data from add customer dialog
  var LastName = $("#txtLastName").val();
  var FirstName = $("#txtFirstName").val();
  var WorkPhone = $("#txtPhone").val();

  var requestUri = _spPageContextInfo.webAbsoluteUrl +
                  "/_api/Web/Lists/getByTitle('Customers')/items/";

  var requestHeaders = {
    "accept": "application/json;odata=verbose",
    "X-RequestDigest": $("#__REQUESTDIGEST").val(),
  }

  var customerData = {
    __metadata: { "type": "SP.Data.CustomersListItem" },
    Title: LastName,
    FirstName: FirstName,
    WorkPhone: WorkPhone
  };

  var requestBody = JSON.stringify(customerData);

  $.ajax({
    url: requestUri,
    type: "POST",
    contentType: "application/json;odata=verbose",
    headers: requestHeaders,
    data: requestBody,
    success: onSuccess,
    error: onError
  });

}

function onDeleteCustomer(customer) {

  var requestUri = _spPageContextInfo.webAbsoluteUrl +
                "/_api/Web/Lists/getByTitle('Customers')/items(" + customer + ")";

  var requestHeaders = {
    "accept": "application/json;odata=verbose",
    "X-RequestDigest": $("#__REQUESTDIGEST").val(),
    "If-Match": "*"
  }

  $.ajax({
    url: requestUri,
    type: "DELETE",
    headers: requestHeaders,
    success: onSuccess,
    error: onError
  });

}

function onUpdateCustomerRequest(customer) {

  // begin work to call across network
  var requestUri = _spPageContextInfo.webAbsoluteUrl +
                "/_api/Web/Lists/getByTitle('Customers')/items(" + customer + ")";

  // execute AJAX request 
  var requestHeaders = {
    "accept": "application/json;odata=verbose"
  }

  $.ajax({
    url: requestUri,
    contentType: "application/json;odata=verbose",
    headers: requestHeaders,
    success: onUpdateCustomerDialog,
    error: onError
  });
}

function onUpdateCustomerDialog(data) {

  // update customer dialog with current customer data
  $("#txtFirstName").val(data.d.FirstName);
  $("#txtLastName").val(data.d.Title);
  $("#txtPhone").val(data.d.WorkPhone);

  // store values for item id and etag
  $("#txtId").val(data.d.Id);
  $("#txtETag").val(data.d.__metadata.etag);

  var customer_dialog = $("#customer_dialog");

  customer_dialog.dialog({
    autoOpen: true,
    title: "Edit Customer",
    width: 320,
    buttons: {
      "Update": function () {
        onUpdateCustomer();
        $(this).dialog("close");
      },
      "Cancel": function () {
        $(this).dialog("close");
      },
    }
  });

}

function onUpdateCustomer() {

  var Id = $("#txtId").val();
  var FirstName = $("#txtFirstName").val();
  var LastName = $("#txtLastName").val();
  var WorkPhone = $("#txtPhone").val();
  var etag = $("#txtETag").val();

  var requestUri = _spPageContextInfo.webAbsoluteUrl +
                   "/_api/Web/Lists/getByTitle('Customers')/items(" + Id + ")";

  var requestHeaders = {
    "accept": "application/json;odata=verbose",
    "X-RequestDigest": $("#__REQUESTDIGEST").val(),
    "X-HTTP-Method": "MERGE",
    "If-Match": etag
  }

  var customerData = {
    __metadata: { "type": "SP.Data.CustomersListItem" },
    Title: LastName,
    FirstName: FirstName,
    WorkPhone: WorkPhone
  };

  var requestBody = JSON.stringify(customerData);

  $.ajax({
    url: requestUri,
    type: "POST",
    contentType: "application/json;odata=verbose",
    headers: requestHeaders,
    data: requestBody,
    success: onSuccess,
    error: onError
  });

}

function onSuccess(data, request) {
  getCustomers();
}

function onError(error) {
  $("#results").empty();
  $("#results").text("Error: " + JSON.stringify(error));
}