"use strict"

var Wingtip = window.Wingtip || {};

Wingtip.Customers = Wingtip.Customers || {};

Wingtip.Customers.DataAccess = function () {

  var getCustomers = function () {
    // parse target URI for customer list in app web
    var requestUri = "/crm.svc/Customers/" +
                     "?$select=ID,FirstName,LastName,Company,WorkPhone,HomePhone,EmailAddress" +
                     "&$orderby=LastName,FirstName";

    // create object for request headers
    var requestHeaders = {
      "accept": "application/json;odata=verbose"
    }

    // send call across network
    var deferred = $.ajax({
      url: requestUri,
      headers: requestHeaders,
    });

    return deferred.promise();
  };

  var getCustomer = function (Id) {
    // begin work to call across network
    var requestUri = "/crm.svc/Customers(" + Id + ")";

    // execute AJAX request 
    var requestHeaders = {
      "accept": "application/json;odata=verbose"
    }

    var deferred = $.ajax({
      url: requestUri,
      contentType: "application/json;odata=verbose",
      headers: requestHeaders,
    });

    return deferred.promise();
  }

  var addCustomer = function (FirstName, LastName, Company, WorkPhone, HomePhone, Email) {

    var requestUri = "/crm.svc/Customers/";

    var requestHeaders = {
      "accept": "application/json;odata=verbose",
    }

    var customerData = {
      LastName: LastName,
      FirstName: FirstName,
      Company: Company,
      WorkPhone: WorkPhone,
      HomePhone: HomePhone,
      EmailAddress: Email
    };

    var requestBody = JSON.stringify(customerData);

    var deferred = $.ajax({
      url: requestUri,
      type: "POST",
      contentType: "application/json;odata=verbose",
      headers: requestHeaders,
      data: requestBody,
    });

    return deferred.promise();
  };

  var deleteCustomer = function (Id) {

    var requestUri = "/crm.svc/Customers(" + Id + ")";

    var requestHeaders = {
      "accept": "application/json;odata=verbose",
    }

    var deferred = $.ajax({
      url: requestUri,
      type: "DELETE",
      headers: requestHeaders,
      success: onSuccess,
      error: onError
    });

    return deferred.promise();
  };

  var updateCustomer = function (Id, FirstName, LastName, Company, WorkPhone, HomePhone, Email) {

    var requestUri = "/crm.svc/Customers(" + Id + ")";

    var requestHeaders = {
      "accept": "application/json;odata=verbose",
      "X-HTTP-Method": "MERGE",
    }

    var customerData = {
      LastName: LastName,
      FirstName: FirstName,
      Company: Company,
      WorkPhone: WorkPhone,
      HomePhone: HomePhone,
      EmailAddress: Email
    };

    var requestBody = JSON.stringify(customerData);

    var deferred = $.ajax({
      url: requestUri,
      type: "POST",
      contentType: "application/json;odata=verbose",
      headers: requestHeaders,
      data: requestBody,
    });

    return deferred.promise();

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
