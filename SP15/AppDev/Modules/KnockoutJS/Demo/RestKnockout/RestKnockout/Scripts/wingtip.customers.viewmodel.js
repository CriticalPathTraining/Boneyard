/// <reference path="knockout-2.3.0.js" />
/// <reference path="wingtip.customers.model.js" />

"use strict";

var Wingtip = window.Wingtip || {};
Wingtip.Customers = Wingtip.Customers || {};

Wingtip.Customers.ViewModel = function () {

  var customers = ko.observableArray();

  var getCustomers = function () { return customers }

  var loadCustomers = function () {

    // parse target URI for customer list in app web
    var requestUri = _spPageContextInfo.webAbsoluteUrl +
                  "/_api/Web/Lists/getByTitle('Customers')/items/" +
                  "?$select=Id,FirstName,Title,WorkPhone" +
                  "&$orderby=Title,FirstName";


    // create object for request headers
    var requestHeaders = {
      "accept": "application/json;odata=verbose"
    }

    // send call across network
    var deferred = $.ajax({
      url: requestUri,
      headers: requestHeaders,
      success: onLoadCustomersComplete,
      error: onError
    });

  };

  var onLoadCustomersComplete = function (data) {

    customers.destroyAll();

    var odataCustomers = data.d.results;
   
    for (var index = 0; index < odataCustomers.length; index++) {
      var odataCustomer = odataCustomers[index];
      var id = odataCustomer.Id;
      var fn = odataCustomer.FirstName;
      var ln = odataCustomer.Title;
      var ph = odataCustomer.WorkPhone;
      var etag = odataCustomer.__metadata.etag;
      var customer = Wingtip.Customers.Model.create(id, fn, ln, ph, etag);      
      customers.push(customer);
    }

  }

  var getCustomer = function (Id) {

    // begin work to call across network
    var requestUri = _spPageContextInfo.webAbsoluteUrl +
                  "/_api/Web/Lists/getByTitle('Customers')/items(" + Id + ")";

    // execute AJAX request 
    var requestHeaders = {
      "accept": "application/json;odata=verbose"
    }

    var deferred = $.ajax({
      url: requestUri,
      contentType: "application/json;odata=verbose",
      headers: requestHeaders,
      error: onError
    });

    return deferred.promise();
  }

  var addCustomer = function (FirstName, LastName, WorkPhone) {

    var requestUri = _spPageContextInfo.webAbsoluteUrl +
                    "/_api/Web/Lists/getByTitle('Customers')/items/";

    var requestHeaders = {
      "accept": "application/json;odata=verbose",
      "X-RequestDigest": $("#__REQUESTDIGEST").val(),
    }

    var customerData = {
      __metadata: { "type": "SP.Data.CustomersListItem" },
      Title: LastName,
      FirstName: FirstName,
      WorkPhone: WorkPhone
    };

    var requestBody = JSON.stringify(customerData);

    var deferred = $.ajax({
      url: requestUri,
      type: "POST",
      contentType: "application/json;odata=verbose",
      headers: requestHeaders,
      data: requestBody,
      error: onError
    });

    deferred.promise().then(function () { loadCustomers(); });

    return deferred.promise();

  };
  
  var updateCustomer = function (Id, FirstName, LastName, WorkPhone, etag) {
    
    var requestUri = _spPageContextInfo.webAbsoluteUrl +
                     "/_api/Web/Lists/getByTitle('Customers')/items(" + Id + ")";

    var requestHeaders = {
      "accept": "application/json;odata=verbose",
      "X-RequestDigest": $("#__REQUESTDIGEST").val(),
      "X-HTTP-Method": "MERGE",
      "If-Match": etag
    }

    var customerData = {
      __metadata: { "type": "SP.Data.CustomersListItem" },
      Title: LastName,
      FirstName: FirstName,
      WorkPhone: WorkPhone
    };

    var requestBody = JSON.stringify(customerData);

    var deferred = $.ajax({
      url: requestUri,
      type: "POST",
      contentType: "application/json;odata=verbose",
      headers: requestHeaders,
      data: requestBody,
      error: onError
    });

    deferred.promise().then(function () { loadCustomers(); });

    return deferred.promise();

  };

  var deleteCustomer = function (Id) {

    var requestUri = _spPageContextInfo.webAbsoluteUrl +
                  "/_api/Web/Lists/getByTitle('Customers')/items(" + Id + ")";

    var requestHeaders = {
      "accept": "application/json;odata=verbose",
      "X-RequestDigest": $("#__REQUESTDIGEST").val(),
      "If-Match": "*"
    }

    var deferred = $.ajax({
      url: requestUri,
      type: "DELETE",
      headers: requestHeaders,
    });

    deferred.promise().then(function () { loadCustomers(); });

    return deferred.promise();

  };

  function onError(error) {
    alert("Error: " + JSON.stringify(error));
  }

  //public interface
  return {
    loadCustomers: loadCustomers,
    getCustomers: getCustomers,
    addCustomer: addCustomer,
    getCustomer: getCustomer,
    updateCustomer: updateCustomer,
    deleteCustomer: deleteCustomer
  };

}();