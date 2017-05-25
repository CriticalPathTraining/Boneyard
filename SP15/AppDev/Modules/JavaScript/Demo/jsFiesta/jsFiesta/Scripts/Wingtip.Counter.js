'use strict';

// ensure Wingtip object exists
var Wingtip = window.Wingtip || {};


// define Wingtip.Counter Module
Wingtip.Counter = function () {

  // private implementation details
  var currentValue = 0;

  // public interface
  return {
    increment: function() { currentValue += 1; },
    getValue: function()  { return currentValue; }
  }

}();


