'use strict';

var globalX = 3; // declare and initialize global variable
// globalY = 7;     // causes undeclared variable error when in strict mode


function function1() { // declare function
  var localX = 3; // declare and initialize local variable
  // localY = 4;     // causes undeclared variable error when in strict mode
}


function getQueryStringParameter() {
  var querystring = document.URL.split("?")[1];
  if (querystring) {
    var params = querystring.split("&");
    for (var index = 0; (index < params.length) ; index++) {
      var current = params[index].split("=");
      if (param.toUpperCase() === current[0].toUpperCase()) {
        return decodeURIComponent(current[1]);
      }
    }
  }
}


// define closure as self-executing function
var closure1 = function () {

  var privateData = 714;
  var privateFunction = function(){
    return privateData;
  };

  return { 
    publicFunction: privateFunction
  };

}();


// client code
var result = closure1.publicFunction();

// ensure Wingtip object exists
var Wingtip = window.Wingtip || {};

// define variables in scope of Wingtip namespace

// variable with literal value
Wingtip.pi = 3.141592;

// variable with function reference
Wingtip.add = function (x, y) { return x + y };

// reference to function which returns object array
Wingtip.getCustomers = function () {
  return [
    { firstName: "Willie", lastName: "Mays" },
    { firstName: "Sandy", lastName: "Kofax" },
    { firstName: "Thai", lastName: "Cobb" },
    { firstName: "Box", lastName: "Fox" }
  ];
};


// client code using namespace-scoped variables

var pi = Wingtip.pi;

var result = Wingtip.add(2, 2);

var customers = Wingtip.getCustomers();

// supported syntax #1
var object1 = Object();
object1.firstName = "Bob";
object1.lastName = "Dylan";

// supported syntax #2
var object2 = {};
object2["firstName"] = "James";
object2["lastName"] = "Talor";

// supported syntax #3 - the one everyine uses!
var object3 = {
  firstName: "John",
  lastName: "Lennon"
}

// it is common to create an empty object
var object4 = {};


var json =

{ "name": "The Beatles",
  "homeTown": "Liverpool",
  "genre": "Rock and roll",
  "members": [{ "firstName": "John", "lastName": "Lennon" },
              { "firstName": "Paul", "lastName": "McCartney" },
              { "firstName": "George", "lastName": "Harrison" },
              { "firstName": "Pete", "lastName": "Best" }]
}



