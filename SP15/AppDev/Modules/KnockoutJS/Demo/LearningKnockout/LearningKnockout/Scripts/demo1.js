

var customer = {
  firstName: "Mary",
  lastName: "Jones",
  workPhone: "123-456-7890"
};

var customerViewModel = {
  firstName: ko.observable(customer.firstName),
  lastName: ko.observable(customer.lastName),
  workPhone: ko.observable(customer.workPhone)
};


$(function(){

  ko.applyBindings(customerViewModel);

}); 