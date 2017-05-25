'use strict';

$(function () {
  $("#cmdHelloDOM").click(onHelloDOM);
  $("#cmdHellojQuery").click(onHellojQuery);
  $("#cmdCreateList").click(onCreateList);
  $("#cmdLinkHostWeb").click(onLinkHostWeb);
  $("#cmdAjax").click(onAjax);
  $("#cmdPromises").click(onPromises);
});

function onHelloDOM() {
  var resultsDiv = document.getElementById("results");
  resultsDiv.innerHTML = "Hello DOM";

}

function onHellojQuery() {
  $("#results")
      .text("Hello jQuery")
      .css({ "color": "blue", "font-size": "48px" });
  ;
}

function onCreateList() {
  // declare JavaScript array of strings
  var people = ["Betty", "Frank", "Sandra", "Ricco"];

  // create <ol> element
  var list = $("<ol>");

  // add li child elements
  for (var index = 0; (index < people.length) ; index++) {
    list.append($("<li>").text(people[index]));
  }

  // add list element to page
  $("#results").empty();
  $("#results").append(list);

}

function onLinkHostWeb() {
  // get URL back to host web
  var urlHostWeb = Wingtip.Utilities.getQueryStringParameter("SPHostUrl");

  // create <a> elements and link it to host web
  var linkHostWeb =
    $("<a>")
    .attr("href", urlHostWeb)
    .css({ "color": "white", "text-decoration": "none" })
    .text("Back to Host Web");

  // append link into nav_bar div
  $("#nav_bar").append(linkHostWeb);

}

function onAjax() {
  // use ajax() function to execute an HTTP request
  $.ajax({
    url: "FreshContent.htm",
    type: "GET",
    dataType: "html",
    success: onAjaxComplete,
    error: onAjaxError
  });

}
function onAjaxComplete(responseData) {
  $("#results").html(responseData);
}

function onAjaxError(error) {
  $("#results").text("ERROR: " + error);
}


function onPromises() {
  var promise = Wingtip.Utilities.executeGetRequest("FreshContent.htm");

  promise.then(

    // implement success function
    function (responseData) {
      $("#results").html(responseData);
    },

    // implement error function
    function (error) {
      $("#results").text("ERROR: " + error);
    });

}

