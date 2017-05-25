/// <reference path="wingtip.customers.viewmodel.js" />
/// <reference path="knockout-2.3.0.js" />


var viewModel = Wingtip.Customers.ViewModel;

$(function () {

  $("#cmdAddNewCustomer").click(onAddCustomerRequest);
  $("#cmdAddNewCustomer").button();

  viewModel.loadCustomers();
  ko.applyBindings(viewModel);

});

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

  viewModel.addCustomer(FirstName, LastName, WorkPhone);
}

function onDeleteCustomer(customerId) {
  viewModel.deleteCustomer(customerId);
}

function onUpdateCustomerRequest(customerId) {
  viewModel.getCustomer(customerId).then(onUpdateCustomerDialog);
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

  viewModel.updateCustomer(Id, FirstName, LastName, WorkPhone, etag);

}

