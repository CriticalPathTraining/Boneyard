/// <rifeference path="knockout-2.3.0.js" />

var customerData = [
  { firstName: "Ted", lastName: "Pattison" },
  { firstName: "Scot", lastName: "Hillier" },
  { firstName: "Matt", lastName: "McDermott" },
  { firstName: "Andrew", lastName: "Connell" },
  { firstName: "Gary", lastName: "LaPointe" }
];

var veiwModelCustomers = function () {

  // create observable array
  var customers = ko.observableArray(customerData);

  return {
    customers: customers,
  };

}();

$(function () {
  ko.applyBindings(veiwModelCustomers);
});
