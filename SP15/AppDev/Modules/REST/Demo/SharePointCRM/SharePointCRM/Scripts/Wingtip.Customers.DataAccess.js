"use strict"

var Wingtip = window.Wingtip || {};

Wingtip.Customers = Wingtip.Customers || {};

Wingtip.Customers.DataAccess = function () {

  var getCustomers = function () {

    // parse target URI for customer list in app web
    var requestUri = _spPageContextInfo.webAbsoluteUrl + "/_api/web/lists/getByTitle('Customers')/items" +
                     "?$select=ID,FirstName,Title,Company,WorkPhone,HomePhone,Email" +
                     "&$orderby=Title,FirstName";

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
    var requestUri = _spPageContextInfo.webAbsoluteUrl + "/_api/web/lists/getByTitle('Customers')/items(" + Id + ")";

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

    var requestUri = _spPageContextInfo.webAbsoluteUrl + "/_api/web/lists/getByTitle('Customers')/items";

    var requestHeaders = {
      "accept": "application/json;odata=verbose",
      "X-RequestDigest": $("#__REQUESTDIGEST").val()
    }

    var customerData = {
      __metadata: { "type": "SP.Data.CustomersListItem" },
      Title: LastName,
      FirstName: FirstName,
      Company: Company,
      WorkPhone: WorkPhone,
      HomePhone: HomePhone,
      Email: Email
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

  var updateCustomer = function (Id, FirstName, LastName, Company, WorkPhone, HomePhone, Email, ETag) {

    var requestUri = _spPageContextInfo.webAbsoluteUrl +
                    "/_api/web/lists/getByTitle('Customers')/items(" + Id + ")";

    var requestHeaders = {
      "accept": "application/json;odata=verbose",
      "X-HTTP-Method": "MERGE",
      "X-RequestDigest": $("#__REQUESTDIGEST").val(),
      "If-Match": ETag
    }

    var customerData = {
      __metadata: { "type": "SP.Data.CustomersListItem" },
      Title: LastName,
      FirstName: FirstName,
      Company: Company,
      WorkPhone: WorkPhone,
      HomePhone: HomePhone,
      Email: Email
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

    var requestUri = _spPageContextInfo.webAbsoluteUrl +
                     "/_api/web/lists/getByTitle('Customers')/items(" + Id + ")";

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

    return deferred.promise();
  };

  // public interface
  return {
    getCustomers: getCustomers,
    addCustomer: addCustomer,
    getCustomer: getCustomer,
    updateCustomer: updateCustomer,
    deleteCustomer: deleteCustomer
  };

}();
