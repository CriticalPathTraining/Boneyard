


var customerViewModel = function () {

  // private details
  var customer = { 
    firstName: "Mary", lastName: "Jones", company: "Acme Corp, Inc.",
    workPhone: "123-456-7890", homePhone: "987-123-4567", email: "maryj@acmecorp.com"
  };

  // return object with public interface
  return {
    firstName: ko.observable(customer.firstName),
    lastName: ko.observable(customer.lastName),
    company: ko.observable(customer.company),
    workPhone: ko.observable(customer.workPhone),
    homePhone: ko.observable(customer.homePhone),
    email: ko.observable(customer.email)
  };

}();

// apply bindings in document ready event handler
$(function () {
  ko.applyBindings(customerViewModel);
});

