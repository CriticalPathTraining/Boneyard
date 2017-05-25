"use strict";

var Wingtip = window.Wingtip || {};
Wingtip.Customers = Wingtip.Customers || {};
Wingtip.Customers.Model = Wingtip.Customers.Model || {};

Wingtip.Customers.Model.create = function (Id, FirstName, LastName, Phone, etag) {

  var newCustomer = {
    Id: Id,
    FirstName: FirstName,
    LastName: LastName,
    Phone: Phone,
    etag: etag
  }

  // add simple getter methods
  newCustomer.getId = function () { return Id; }
  newCustomer.getFirstName = function () { return FirstName; }
  newCustomer.getLastName = function () { return LastName; }
  newCustomer.getPhone = function () { return Phone; }
  newCustomer.getETag = function () { return etag; }

  // add computation functions
  newCustomer.getFullName = function () {
    return FirstName + " " + LastName;
  }

  return newCustomer;

};
