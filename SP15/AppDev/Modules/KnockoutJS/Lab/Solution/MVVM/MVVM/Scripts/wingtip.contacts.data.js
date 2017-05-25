"use strict";

var Wingtip = window.Wingtip || {};
Wingtip.Contacts = Wingtip.Contacts || {};

Wingtip.Contacts.Data = function () {

  //This module contains all of the functionality
  //for performing CRUD operations on the list

  //private members
  var create = function (lname, fname, wphone) {
      var deferred = $.ajax({
          url: "../_api/web/lists/getByTitle('Contacts')/items",
          type: "POST",
          contentType: "application/json;odata=verbose",
          data: JSON.stringify(
              {
                '__metadata': {
                  'type': 'SP.Data.ContactsListItem'
                },
                'Title': lname,
                'FirstName': fname,
                'WorkPhone': wphone
              }),
          headers: {
            "accept": "application/json;odata=verbose",
            "X-RequestDigest": $("#__REQUESTDIGEST").val()
          }
      });
  return deferred.promise();

},

       readList = function () {

         var deferred = $.ajax(
             {
               url: "../_api/web/lists/getByTitle('Contacts')/items/" +
                   "?$select=Id,FirstName,Title,WorkPhone" +
                   "&$orderby=Title,FirstName",
               type: "GET",
               headers: {
                 "accept": "application/json;odata=verbose",
               }
             }
         );
         return deferred.promise();


       },

        readItem = function (id) {

          var deferred = $.ajax(
              {
                url: "../_api/web/lists/getByTitle('Contacts')/getItemByStringId('" +
                     id + "')/?$select=Id,FirstName,Title,WorkPhone",
                type: "GET",
                headers: {
                  "accept": "application/json;odata=verbose",
                }
              }
          );
          return deferred.promise();

        },

        update = function (id, lname, fname, wphone) {
          
          var deferred = $.ajax(
              {
                url: "../_api/web/lists/getByTitle('Contacts')/getItemByStringId('" + id + "')",
                type: "POST",
                contentType: "application/json;odata=verbose",
                data: JSON.stringify(
                {
                  '__metadata': {
                    'type': 'SP.Data.ContactsListItem'
                  },
                  'Title': lname,
                  'FirstName': fname,
                  'WorkPhone': wphone
                }),
                headers: {
                  "accept": "application/json;odata=verbose",
                  "X-RequestDigest": $("#__REQUESTDIGEST").val(),
                  "IF-MATCH": "*",
                  "X-Http-Method": "PATCH"
                }
              }
          );
          return deferred.promise();

        },

        remove = function (id) {

          var deferred = $.ajax(
              {
                url: "../_api/web/lists/getByTitle('Contacts')/getItemByStringId('" + id + "')",
                type: "DELETE",
                headers: {
                  "accept": "application/json;odata=verbose",
                  "X-RequestDigest": $("#__REQUESTDIGEST").val(),
                  "IF-MATCH": "*"
                }
              }
          );
          return deferred.promise();

        };


    //public interface
    return {
        create: create,
        readList: readList,
        readItem: readItem,
        update: update,
        remove: remove
    };

}();