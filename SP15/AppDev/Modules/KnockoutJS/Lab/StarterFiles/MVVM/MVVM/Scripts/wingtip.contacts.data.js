"use strict";

var Wingtip = window.Wingtip || {};
Wingtip.Contacts = Wingtip.Contacts || {};

Wingtip.Contacts.Data = function () {

    //This module contains all of the functionality
    //for performing CRUD operations on the list

    //private members
    var create = function (lname, fname, wphone) {

            //CODE GOES HERE

       },

       readList = function () {

           //CODE GOES HERE

       },

        readItem = function (id) {

            //CODE GOES HERE

        },

        update = function (id, lname, fname, wphone) {

            //CODE GOES HERE

        },

        remove = function (id) {

            //CODE GOES HERE

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