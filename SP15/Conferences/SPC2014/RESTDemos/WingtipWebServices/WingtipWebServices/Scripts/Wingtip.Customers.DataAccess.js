"use strict"

var Wingtip = window.Wingtip || {};

Wingtip.Customers = Wingtip.Customers || {};

Wingtip.Customers.DataAccess = function () {

  var getCustomers = function () {

    var requestUri = "../odata/Customers/" +
                     "?$select=ID,FirstName,LastName,Company,WorkPhone,HomePhone,EmailAddress" +
                     "&$orderby=LastName,FirstName";

    return $.ajax({
      url: requestUri,
      type: "GET",
      headers: { "accept": "application/json;odata=verbose" }
    });

  };

  var getCustomersPage = function (RowCount, StartRow) {

    var requestUri = "../odata/Customers/" +
                     "?$select=ID,FirstName,LastName,Company,WorkPhone,HomePhone,EmailAddress" +
                     "&$orderby=LastName,FirstName";

    if (typeof RountCount !== 'undefined') {
      requestUri += "&$top=" + RountCount;
    }


    if (typeof StartRow !== 'undefined') {
      requestUri += "&$skip=" + StartRow;
    }

    return $.ajax({
      url: requestUri,
      type: "GET",
      headers: { "accept": "application/json;odata=verbose" }
    });

  };


  var getCustomer = function (Id) {

    var requestUri = "../odata/Customers(" + Id + ")";

    return $.ajax({
      url: requestUri,
      type: "GET",
      headers: { "accept": "application/json;odata=verbose" },
      contentType: "application/json;odata=verbose"
    });

  }

  var addCustomer = function (FirstName, LastName, Company, WorkPhone, HomePhone, Email) {

    var requestUri = "../odata/Customers/";

    var customerData = {
      LastName: LastName,
      FirstName: FirstName,
      Company: Company,
      WorkPhone: WorkPhone,
      HomePhone: HomePhone,
      EmailAddress: Email
    };

    var requestBody = JSON.stringify(customerData);

    return $.ajax({
      url: requestUri,
      type: "POST",
      headers: { "accept": "application/json;odata=verbose" },
      contentType: "application/json;odata=verbose",
      data: requestBody,
    });

  };

  var deleteCustomer = function (Id) {

    var requestUri = "../odata/Customers(" + Id + ")";

    return $.ajax({
      url: requestUri,
      type: "DELETE",
      headers: { "accept": "application/json;odata=verbose" }
    });

  };

  var updateCustomer = function (Id, FirstName, LastName, Company, WorkPhone, HomePhone, Email) {

    var requestUri = "../odata/Customers(" + Id + ")";
    

    var requestHeaders = {
      "accept": "application/json;odata=verbose"
      
    }

    //"X-HTTP-METHOD": "PUT"

    var customerData = {
      ID: Id,
      LastName: LastName,
      FirstName: FirstName,
      Company: Company,
      WorkPhone: WorkPhone,
      HomePhone: HomePhone,
      EmailAddress: Email
    };

    var requestBody = JSON.stringify(customerData);

    return $.ajax({
      url: requestUri,
      type: "PUT",
      headers: requestHeaders,
      contentType: "application/json;odata=verbose",
      data: requestBody,
    });

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


