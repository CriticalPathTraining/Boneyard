'use strict';



var appWebUrl_qs  = getQueryStringParameter("SPAppWebUrl");
var hostWebUrl_qs = getQueryStringParameter("SPHostUrl");

var appWebUrl_pc;
var topsite_pc;

$(function () {

  $("#cmdAJAXwithXMLHttpRequest").click(onAJAXwithXMLHttpRequest);
  $("#cmdAJAXwithjQuery").click(onAJAXwithjQuery);

  $("#cmdAppWeb1").click(onAppWeb1);
  $("#cmdAppWeb2").click(onAppWeb2);
  $("#cmdAppWeb3").click(onAppWeb3);
  
  $("#cmdHostWeb1").click(onHostWeb1);
  $("#cmdHostWeb2").click(onHostWeb2);
  $("#cmdHostWeb3").click(onHostWeb3);
  $("#cmdHostWeb4").click(onHostWeb4);
  $("#cmdHostWeb5").click(onHostWeb5);
  $("#cmdHostWeb6").click(onHostWeb6);
  $("#cmdHostWeb7").click(onHostWeb7);


  appWebUrl_pc = _spPageContextInfo.webAbsoluteUrl;
  topsite_pc = _spPageContextInfo.siteAbsoluteUrl



});

function onAJAXwithXMLHttpRequest() {

  // create XMLHttpRequest object
  var xmlhttp = new XMLHttpRequest();

  // define response behavior by creating a callback function    
  xmlhttp.onreadystatechange = function () {
    if (xmlhttp.readyState === 4 && xmlhttp.status === 200) {
      var web = JSON.parse(xmlhttp.responseText).d;
      $("#content_box").empty();
      $("#content_box").append($("<h2>").text("Rest call using XMLHttpRequest object"));
      $("#content_box").append($("<div>").text("ID: " + web.Id));
      $("#content_box").append($("<div>").text("Title: " + web.Title));
      $("#content_box").append($("<div>").text("Url: " + web.Url));
    }
  };

  // formulate URL and send request
  var url = "../_api/web/?$select=Id,Title,Url";
  xmlhttp.open("GET", url, false);
  xmlhttp.setRequestHeader("accept", "application/json;odata=verbose");
  xmlhttp.send();
}

function onAJAXwithjQuery() {

  var ajaxSettings = {
    type: "GET",
    url: "../_api/web/?$select=Id,Title,Url",
    headers: { "accept": "application/json;odata=verbose" }
  };

  $.ajax(ajaxSettings).then(function (data) {
    var web = data.d;
    $("#content_box").empty();
    $("#content_box").append($("<h2>").text("Rest call using jQuery $.ajax() function"));
    $("#content_box").append($("<div>").text("ID: " + web.Id));
    $("#content_box").append($("<div>").text("Title: " + web.Title));
    $("#content_box").append($("<div>").text("Url: " + web.Url));
  });

}

function onAppWeb1() {
  clear();

  var restURI = "../_api/" + "web/lists/getByTitle('Customers')/items/" + "?$select=FirstName,Title"

  $.ajax({
    url: restURI,
    type: "GET",
    headers: { "accept": "application/json;odata=verbose" }
  }).then(onWebDataRecieved, onError);


  $("#url_showcase").text("onAppWeb1 executed: " + restURI);

}

function onAppWeb2() {
  clear();

  var restURI = getQueryStringParameter("SPAppWebUrl") +
                "/_api/web/?$select=Id,Title,Url"

  $.ajax({
    url: restURI,
    type: "GET",
    headers: { "accept": "application/json;odata=verbose" }
  }).then(onWebDataRecieved, onError);

  $("#url_showcase").text("onAppWeb2 executed: " + restURI);
}

function onAppWeb3() {
  clear();

  var restURI = _spPageContextInfo.webAbsoluteUrl +
                "/_api/web/?$select=Id,Title,Url"

  $.ajax({
    url: restURI,
    type: "GET",
    headers: { "accept": "application/json;odata=verbose" }
  }).then(onWebDataRecieved, onError);

  $("#url_showcase").text("onAppWeb3 executed: " + restURI);

}

function onHostWeb1() {
  clear();

  var restURI = getQueryStringParameter("SPHostUrl") + 
                "/_api/web/?$select=Id,Title,Url";


  $.ajax({
    url: restURI,
    type: "GET",
    headers: { "accept": "application/json;odata=verbose" }
  }).then(onWebDataRecieved, onError);

  $("#url_showcase").text("onHostWeb1 executed: " + restURI);

}

function onHostWeb2() {
  clear();


  var restURI = "/_api/web/?$select=Id,Title,Url";

  $.ajax({
    url: restURI,
    type: "GET",
    headers: { "accept": "application/json;odata=verbose" }
  }).then(onWebDataRecieved, onError);

  $("#url_showcase").text("onHostWeb2 executed: " + restURI);

}

function onHostWeb3() {
  clear();


  var restURI = "../../_api/web/?$select=Id,Title,Url"

  $.ajax({
    url: restURI,
    type: "GET",
    headers: { "accept": "application/json;odata=verbose" }
  }).then(onWebDataRecieved, onError);

  $("#url_showcase").text("onHostWeb3 executed: " + restURI);

}

function onHostWeb4() {
  clear();

  var appWebUrl = getQueryStringParameter("SPAppWebUrl");
  var appWebUrlLength = appWebUrl.length;
  var appSuffix = "/AppsGoneWild";
  var appSuffixLength = appSuffix.length;
  var hostWebUrlTranslated = appWebUrl.substring(0, (appWebUrlLength - appSuffixLength));

  var restURI = hostWebUrlTranslated + "/_api/web/?$select=Id,Title,Url";

    $.ajax({
    url: restURI,
    type: "GET",
    headers: { "accept": "application/json;odata=verbose" }
  }).then(onWebDataRecieved, onError);


  $("#url_showcase").text("onHostWeb4 executed: " + restURI);

}

function onHostWeb5() {
  clear();

  var restURI = "/_api/SP.AppContextSite(@target)/web/" +
                "?$select=Id,Title,Url" +
                "&@target='" + getQueryStringParameter("SPHostUrl") + "'";


  $.ajax({
    url: restURI,
    type: "GET",
    headers: { "accept": "application/json;odata=verbose" }
  }).then(onWebDataRecieved, onError);

  $("#url_showcase").text("onHostWeb5 executed: " + restURI);
  
}

function onHostWeb6() {
  clear();

  var restURI = getQueryStringParameter("SPAppWebUrl") +
                "/_api/SP.AppContextSite(@target)/web/?$select=Id,Title,Url" +
                "&@target='" + getQueryStringParameter("SPHostUrl") + "'";


  $.ajax({
    url: restURI,
    type: "GET",
    headers: { "accept": "application/json;odata=verbose" }
  }).then(onWebDataRecieved, onError);

  $("#url_showcase").text("onHostWeb6 executed: " + restURI);

}

function onHostWeb7() {
  clear();


  var restURI = "../_api/SP.AppContextSite(@target)/web/" +
              "?$select=Id,Title,Url" +
              "&@target='" + getQueryStringParameter("SPHostUrl") + "'";


  $.ajax({
    url: restURI,
    type: "GET",
    headers: { "accept": "application/json;odata=verbose" }
  }).then(onWebDataRecieved, onError);

  $("#url_showcase").text("onHostWeb7 executed: " + restURI);

}


function onWebDataRecieved(data){
  var web = data.d;  
  $("#content_box").append($("<div>").text("Title: " + web.Title));
  $("#content_box").append($("<div>").text("ID: " + web.Id));
  $("#content_box").append($("<div>").text("Url: " + web.Url));
}

function clear() {
  $("#content_box").empty();
}



function onError(error) {
  alert(JSON.stringify(error));
}

function getQueryStringParameter(param) {
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