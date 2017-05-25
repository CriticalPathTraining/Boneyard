"use strict"

var Wingtip = window.Wingtip || {};

Wingtip.Customers = Wingtip.Customers || {};

Wingtip.Customers.DataAccess = function () {

  var getCustomers = function () {
    // TODO
  };

  var getCustomer = function (Id) {
    // TODO
  }

  var addCustomer = function (FirstName, LastName, Company, WorkPhone, HomePhone, Email) {
    // TODO
  };

  var deleteCustomer = function (Id) {
    // TODO
  };

  var updateCustomer = function (Id, FirstName, LastName, Company, WorkPhone, HomePhone, Email) {
    // TODO
  };

  // public interface
  return {
    getCustomers: getCustomers,
    addCustomer: addCustomer,
    getCustomer: getCustomer,
    deleteCustomer: deleteCustomer,
    updateCustomer: updateCustomer
  };

}();
