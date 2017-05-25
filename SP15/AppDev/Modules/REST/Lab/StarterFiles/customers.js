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
  // TODO
}

function onGetCustomersComplete(data) {
  // TODO

}

function onAddCustomerRequest(event) {
  // TODO
}

function onAddCustomer() {
  // TODO
}

function onDeleteCustomer(customerId) {
  // TODO
}

function onUpdateCustomerRequest(customerId) {
  // TODO
}

function onUpdateCustomerDialog(data) {
  // TODO
}

function onUpdateCustomer() {
  // TODO
}

function onSuccess(data, request) {
  getCustomers();
}

function onError(error) {
  $("#content_box").empty();
  $("#content_box").text("Error: " + JSON.stringify(error));
}