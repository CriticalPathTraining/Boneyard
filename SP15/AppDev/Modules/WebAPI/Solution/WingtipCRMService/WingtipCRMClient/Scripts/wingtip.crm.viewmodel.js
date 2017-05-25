/// <reference path="breeze.min.js" />
/// <reference path="q.min.js" />
/// <reference path="knockout-2.3.0.js" />
/// <reference path="wingtip.customers.model.js" />

"use strict";

var Wingtip = window.Wingtip || {};
Wingtip.Crm = Wingtip.Crm || {};

Wingtip.Crm.ViewModel = function () {

    //TO DO: Update the service root
    var serviceRoot = "http://localhost:26059/"

    var customers = ko.observableArray();

    var getCustomers = function () { return customers };

    //create a cache of data
    var cache = null;;

    var refreshCache = function () {
      //TO DO: Edit refreshCache function
      if (cache !== null) cache.clear();
      cache = datajs.createDataCache({
        name: "contacts",
        source: serviceRoot + "odata/Customers?$orderby=LastName,FirstName&$top=100",
        prefetchSize: 100,
        pageSize: 100
      });
      loadCustomers();

    };

    var loadCustomers = function () {
      //TO DO: Edit loadCustomers function
      return cache.readRange(0, 100).then(
         function (data) {
            onLoadCustomersComplete(data);
         },
         function (err) {
            onError(err);
         }
      );
    };

    var onLoadCustomersComplete = function (data) {

        customers.destroyAll();

        for (var i = 0; i < data.length; i++) {
            var d = data[i];
            var customer = Wingtip.Crm.Model.create(
                                d.ID,
                                d.FirstName,
                                d.LastName,
                                d.Company,
                                d.EmailAddress,
                                d.WorkPhone,
                                d.HomePhone);
            customers.push(customer);
        }

    }

    var getCustomer = function (Id) {
      //TO DO: Edit getCustomer function
      var deferred = jQuery.Deferred();
      cache.readRange(0, 100).always(function (data) {
        deferred.resolve(
            _.chain(data)
            .filter(function (contact) { return (contact.ID === Id); })
            .rest(0)
            .first()
            .value()
        );
      });
      return deferred.promise();

    }

    var addCustomer = function (FirstName, LastName, Company, EmailAddress, WorkPhone, HomePhone) {
      //TO DO: Edit addCustomer function
      OData.request(
      {
        requestUri: serviceRoot + "odata/Customers",
        method: "POST",
        contentType: "application/json",
        data: {
          'LastName': LastName,
          'FirstName': FirstName,
          'Company': Company,
          'EmailAddress': EmailAddress,
          'WorkPhone': WorkPhone,
          'HomePhone': HomePhone
        },
        headers: {
               "accept": "application/json"
        }
      }, function (data) {
        refreshCache();
      }, function (err) {
        refreshCache();
      }
     );

    };

    var updateCustomer = function (Id, FirstName, LastName, Company, EmailAddress, WorkPhone, HomePhone) {
      //TO DO: Edit updateCustomer function
      OData.request(
     {
       requestUri: serviceRoot + "odata/Customers(" + Id + ")",
       method: "PUT",
       contentType: "application/json",
       data: {
         'ID': Id,
         'LastName': LastName,
         'FirstName': FirstName,
         'Company': Company,
         'EmailAddress': EmailAddress,
         'WorkPhone': WorkPhone,
         'HomePhone': HomePhone
       },
       headers: {
         "accept": "application/json"
       }
     }, function (data) {
       refreshCache();
     }, function (err) {
       refreshCache();
     }
     );

    };

    var deleteCustomer = function (Id) {
      //TO DO: Edit deleteCustomer function
      OData.request(
      {
        requestUri: serviceRoot + "odata/Customers(" + Id + ")",
        method: "DELETE",
        headers: {
          "accept": "application/json"
        }
      }, function (data) {
        refreshCache();
      }, function (err) {
        refreshCache();
      }
     );
    };

    function onError(error) {
        alert("Error: " + JSON.stringify(error));
    }

    //public interface
    return {
        refreshCache: refreshCache,
        loadCustomers: loadCustomers,
        getCustomers: getCustomers,
        addCustomer: addCustomer,
        getCustomer: getCustomer,
        updateCustomer: updateCustomer,
        deleteCustomer: deleteCustomer
    };

}();