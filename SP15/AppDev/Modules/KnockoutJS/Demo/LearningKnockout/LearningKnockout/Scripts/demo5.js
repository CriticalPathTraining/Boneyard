/// <rifeference path="knockout-2.3.0.js" />

var customerData = [
  { firstName: "Ted", lastName: "Pattison" },
  { firstName: "Scot", lastName: "Hillier" },
  { firstName: "Matt", lastName: "McDermott" },
  { firstName: "Andrew", lastName: "Connell" },
  { firstName: "Gary", lastName: "LaPointe" }
];

var veiwModelCustomers = function () {

  var customers = ko.observableArray(customerData);

  var newCustomer = {
    firstName: ko.observable(""),
    lastName: ko.observable(""),
    isValid: function () {
      return (this.firstName() != "") && (this.lastName() != "");
    }
  }

  var addCustomer = function () {
    customers.push({
      firstName: newCustomer.firstName(),
      lastName: newCustomer.lastName()
    });

    // reset input control in UI for next new customer
    newCustomer.firstName("");
    newCustomer.lastName("");
  }

  return {
    customers: customers,
    newCustomer: newCustomer,
    addCustomer: addCustomer
  };
}();

$(function () {
  ko.applyBindings(veiwModelCustomers);
});
