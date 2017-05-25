"use strict";

var Wingtip = window.Wingtip || {};
Wingtip.Contacts = Wingtip.Contacts || {};

Wingtip.Contacts.ViewModel = function () {

    //private members
    var contacts = ko.observableArray(),
        get_contacts = function () { return contacts; },
        get_contact = function (index) { return contacts()[index]; },

        loadItem = function (id) {

            //CODE GOES HERE

        },

        loadItems = function () {

            //CODE GOES HERE
        };

    //public interface
    return {
        loadItem: loadItem,
        loadItems: loadItems,
        get_contact: get_contact,
        get_contacts: get_contacts
    };

}();