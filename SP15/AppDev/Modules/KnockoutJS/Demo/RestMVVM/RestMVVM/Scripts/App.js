/// <reference path="wingtip.customers.viewmodel.js" />


var viewModel = Wingtip.Customers.ViewModel;


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

  // call view-model function which returns promise
  var promise = Wingtip.Customers.ViewModel.getCustomers()

  // use promise to implement what happens when OData result is ready
  promise.then(onGetCustomersComplete, onError);

}

function onGetCustomersComplete(data) {

  $("#results").empty();

  var odataResults = data.d.results;

  // set rendering template
  var tableHeader = "<thead>" +
                      "<td>First Name</td>" +
                      "<td>Last Name</td>" +
                      "<td>Work Phone</td>" +
                      "<td>&nbsp;</td>" +
                      "<td>&nbsp;</td>" +
                    "</thead>";

  var table = $("<table>", {id:"customersTable"}).append($(tableHeader));

  // create rendering template for table row using jsRender syntax
  var rowTemplateString = "<tr>" +
                            "<td>{{>FirstName}}</td>" +
                            "<td>{{>Title}}</td>" +
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

  viewModel.addCustomer(FirstName, LastName, WorkPhone).then(onSuccess, onError);  
}

function onDeleteCustomer(customerId) {
  viewModel.deleteCustomer(customerId).then(onSuccess, onError);
}

function onUpdateCustomerRequest(customerId) {
  viewModel.getCustomer(customerId).then(onUpdateCustomerDialog, onError);  
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

  viewModel.updateCustomer(Id, FirstName, LastName, WorkPhone, etag).then(onSuccess, OnError);


}

function onSuccess(data, request) {
  getCustomers();
}

function onError(error) {
  $("#results").empty();
  $("#results").text("Error: " + JSON.stringify(error));
}