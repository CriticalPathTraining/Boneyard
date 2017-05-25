/// <reference path="knockout-2.3.0.js" />

var customerViewModel = function () {
  // private details
  var customer = { firstName: "Mary", lastName: "Jones" };

  // add standard observables
  this.firstName = ko.observable(customer.firstName);
  this.lastName = ko.observable(customer.lastName);

  // add computed observable
  this.fullName = ko.computed(function () {
    return this.firstName() + " " + this.lastName();
  }, customerViewModel);

  // return object with public interface
  return {
    firstName: firstName,
    lastName: lastName,
    fullName: fullName
  };

}();

$(function () {
  ko.applyBindings(customerViewModel);
});