/// <reference path="jquery-2.0.3.js" />
/// <reference path="jquery-ui-1.10.3.js" />
/// <reference path="jsrender.js" />
/// <reference path="Wingtip.Customers.DataAccess.js" />

$(function () {

  $("#cmdAddNewCustomer").click(onAddCustomerRequest);
  $("#cmdAddNewCustomer").button();

  // retrieve customer items
  getCustomers();

});


function getCustomers() {

  // clear results and add spinning gears icon
  $("#content_box").empty();
  $("<img>", { "src": "../Content/img/GEARS.gif" }).css({"padding": "16px"}).appendTo("#content_box");

  // call view-model function which returns promise
  var promise = Wingtip.Customers.DataAccess.getCustomers()

  // use promise to implement what happens when OData result is ready
  promise.then(onGetCustomersComplete, onError);

}

function onGetCustomersComplete(data) {
  
  $("#content_box").empty();

  var odataResults = data.d.results;

  // set rendering template
  var tableHeader = "<thead>" +
                      "<td>&nbsp;</td>" +
                      "<td>&nbsp;</td>" +
                      "<td>First Name</td>" +
                      "<td>Last Name</td>" +
                      "<td>Company</td>" +
                      "<td>Work Phone</td>" +
                      "<td>Home Phone</td>" +
                      "<td>Email</td>" +
                    "</thead>";

  var table = $("<table>", { ID: "customersTable" }).append($(tableHeader));

  // create rendering template for table row using jsRender syntax
  var rowTemplateString = "<tr>" +
                            "<td><a href='javascript: onUpdateCustomerRequest({{>ID}});'><img src='../Content/img/EDITITEM.gif' alt='Edit' /></a></td>" +
                            "<td><a href='javascript: onDeleteCustomer({{>ID}});'><img src='../Content/img/DELITEM.gif' alt='Delete' /></a></td>" +
                            "<td>{{>FirstName}}</td>" +
                            "<td>{{>LastName}}</td>" +
                            "<td>{{>Company}}</td>" +
                            "<td>{{>WorkPhone}}</td>" +
                            "<td>{{>HomePhone}}</td>" +
                            "<td>{{>EmailAddress}}</td>" +
                          "</tr>";

  // load row template and give it a name of "rowTemplate"
  $.templates({ "rowTemplate": rowTemplateString });

  var renderedTable = $.render.rowTemplate(odataResults);
  // render table rows using row template and OData data result
  table.append(renderedTable);

  // append table to div in DOM
  $("#content_box").append(table);


}

function onAddCustomerRequest(event) {

  $("#firstName").val("");
  $("#lastName").val("");
  $("#company").val("");
  $("#workPhone").val("");
  $("#homePhone").val("");
  $("#email").val("");

  var customer_dialog = $("#customer_dialog");

  customer_dialog.dialog({
    autoOpen: true,
    title: "Add Customer",
    width: 640,
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
  var LastName = $("#lastName").val();
  var FirstName = $("#firstName").val();
  var Company = $("#company").val();
  var WorkPhone = $("#workPhone").val();
  var HomePhone = $("#homePhone").val();
  var Email = $("#email").val();

  // add new customer 
  var promise = Wingtip.Customers.DataAccess.addCustomer(FirstName, LastName, Company, WorkPhone, HomePhone, Email);
  promise.then(onSuccess, onError);

}

function onDeleteCustomer(customerId) {
  var promise = Wingtip.Customers.DataAccess.deleteCustomer(customerId);
  promise.then(onSuccess, onError);
}

function onUpdateCustomerRequest(customerId) {
  var promise = Wingtip.Customers.DataAccess.getCustomer(customerId);
  promise.then(onUpdateCustomerDialog, onError);
}

function onUpdateCustomerDialog(data) {
  // update customer dialog with current customer data
  $("#firstName").val(data.d.FirstName);
  $("#lastName").val(data.d.LastName);
  $("#company").val(data.d.Company);
  $("#workPhone").val(data.d.WorkPhone);
  $("#homePhone").val(data.d.HomePhone);
  $("#email").val(data.d.EmailAddress);

  // store value for item id
  $("#customer_id").val(data.d.ID);

  var customer_dialog = $("#customer_dialog");

  customer_dialog.dialog({
    autoOpen: true,
    title: "Edit Customer",
    width: 640,
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

  // scrape input values from dialog
  var Id = $("#customer_id").val();
  var FirstName = $("#firstName").val();
  var LastName = $("#lastName").val();
  var Company = $("#company").val();
  var WorkPhone = $("#workPhone").val();
  var HomePhone = $("#homePhone").val();
  var Email = $("#email").val();

  // update customer
  var promise = Wingtip.Customers.DataAccess.updateCustomer(Id, FirstName, LastName, Company, WorkPhone, HomePhone, Email);
  promise.then(onSuccess, onError);
}

function onSuccess(data, request) {
  getCustomers();
}

function onError(error) {
  $("#content_box").empty();
  $("#content_box").text("Error: " + JSON.stringify(error));
}