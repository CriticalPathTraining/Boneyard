'use strict';


$(function () {

  $("#tabs").tabs();

  $("input[type='button']").button();

  $("#cmdHelloDOM").click(onHelloDOM);
  $("#cmdGetQueryString").click(onGetQueryString);
  $("#cmdCreateElements").click(onCreateElements);
  $("#cmdRemoveElements").click(onRemoveElements);
  $("#cmdObjects").click(onObjects);
  $("#cmdClosures").click(onClosures);
  $("#cmdModules").click(onModules);


  $("#cmdHellojQuery").click(onHellojQuery);
  $("#cmdCreateElements2").click(onCreateElements2);
  $("#cmdSelectors").click(onSelectors);
  $("#cmdAjax").click(onAjax);
  $("#cmdPromises").click(onPromises);

  // jQuery UI init

  $("#themesToolbar").buttonset()
  $(":radio", "#themesToolbar").click(onChangeTheme);


  $("#autocomplete").autocomplete({
    source: ["Cindy Lauper", "Critical Path Training", "Carmen Electra", "Chinese Food"]
  });

  $("#startDate").datepicker({
    showOn: "button",
    minDate: -1,
    maxDate: "+1M +3D"
  });

  $("#cmdAddNewCustomer").button();
  $("#cmdAddNewCustomer").click(onAddNewCustomer);

  $("#red, #green, #blue").slider({
    orientation: "horizontal",
    range: "min",
    max: 255,
    value: 127,
    slide: refreshSwatch,
    change: refreshSwatch
  });

  $("#red").slider("value", 255);
  $("#green").slider("value", 140);
  $("#blue").slider("value", 60);

  $("#accordion").accordion();

});

  function onHelloDOM() {

    var html_output = "<h3>Div elements on page with non-blank id</h3>";

    // obtain reference to array of all div elements on page
    var all_divs = document.getElementsByTagName("div");

    // parse div element ids into ordered list
    html_output += "<ol>";
    for (var i = 0; i < all_divs.length; i++) {
      var currentDiv = all_divs[i];
      if (currentDiv.id) { html_output += "<li>" + currentDiv.id + "</li>"; }
    }
    html_output += "</ol>";

    // write HTML output into target element on page
    var results_div = document.getElementById("results");
    results_div.innerHTML = html_output;

  }

  function onGetQueryString() {
    var html_output = "<h4>Querystring Paramters<h4>";

    // get querystring from end of URL
    var querystring = document.URL.split("?")[1];

    // ensure questystring exists for this request
    if (querystring) {
      // get array of querystring parameters
      var params = querystring.split("&");
      html_output = "<ol>";
      for (var i = 0; i < params.length; i = i + 1) {
        var param = params[i].split("=");
        html_output += "<li>" + param[0] + ": " + param[1] + "</li>";
      }
      html_output += "</ol>";
    }
    else {
      html_output += "there were no querystring parameters";
    }
  
    var results_div = document.getElementById("results");
    results_div.innerHTML = html_output;
  }

  function getQuerystringNameValue(name) {
    // For example... passing a name parameter of "name1" will return a value of "100", etc.
    // page.htm?name1=100&name2=101&name3=102

    var winURL = window.location.href;
    var queryStringArray = winURL.split("?");
    var queryStringParamArray = queryStringArray[1].split("&");
    var nameValue = null;

    for (var i = 0; i < queryStringParamArray.length; i++) {
      queryStringNameValueArray = queryStringParamArray[i].split("=");

      if (name == queryStringNameValueArray[0]) {
        nameValue = queryStringNameValueArray[1];
      }
    }

    return nameValue;
  }

  function onCreateElements() {

    // clear results div
    var results_div = document.getElementById("results");
    results_div.innerHTML = "";

    // define sample data
    var beatles = Array("John", "Paul", "George", "Ringo");

    // create HTML <ul> element using DOM 
    var list1 = document.createElement("ul");
    for (var index = 0; index < beatles.length; index++) {
      var listItem = document.createElement("li");
      var textNode = document.createTextNode(beatles[index]);
      listItem.appendChild(textNode);
      list1.appendChild(listItem);
    }

    // append <ul> element to results div
    results_div.appendChild(list1);

  }

  function onRemoveElements() {
    // remove child nodes from results div
    var results_div = document.getElementById("results");
    while (results_div.childNodes.length > 0) {
      results_div.removeChild(results_div.childNodes[0]);
    }
  }

  function onObjects() {

    // initialize JavaScript object  
    var band = {
      name: "The Beatles",
      homeTown: "Liverpool",
      genre: "Rock and roll",
      members: [ { firstName: "John", lastName: "Lennon" },
                 { firstName: "Paul", lastName: "McCartney" },
                 { firstName: "George", lastName: "Harrison" },
                 { firstName: "Pete", lastName: "Best" }]
    }

    // convert JavaScript object into JSON string format
    var jsonBand = JSON.stringify(band);

    // rehydrate JavaScript object tree
    var rehydratedBand = JSON.parse(jsonBand);
    var name = rehydratedBand.name;
    var homeTown = rehydratedBand.homeTown;


    var results_div = document.getElementById("results");
    results_div.innerHTML = name + " are from " + homeTown;
  
  }

  function onClosures() {
    // client code can call public functions from closure
    var result = closure1.publicFunction();

    var results_div = document.getElementById("results");
    results_div.innerHTML = "Result: " + result;

  }

  function onModules() {

    // client code can only access Module's public members 

    // read counter value from Wingtip.Counter module
    var counterValue = Wingtip.Counter.getValue();
    document.getElementById("results").innerHTML = "Counter value: " + counterValue;

    // increment counter in Wingtip.Counter module
    Wingtip.Counter.increment();

  }

  function onHellojQuery() {

    // update div with an ID of resultContainer
    $("#resultContainer").text("Hello jQuery");

    // update CSS styles of div
    $("#resultContainer").css({"color": "red"});
    

    // same as above but more concise with cascading method calls
    $("#resultContainer")
      .text("Hello jQuery")
      .css({"color": "green"});

  }

  function onCreateElements2() {

    // clear target element container
    $("#resultContainer").empty();

    // create and initialize new element
    var h2 = $("<h2>").text("The Gettysburg Address");

    // add new element into DOM as child
    $("#resultContainer").append(h2);


    // add more content
    $("#resultContainer").append($("<p>").text("Four score and seven years ago our fathers brought forth on this continent, a new nation, conceived in Liberty, and dedicated to the proposition that all men are created equal."));
    $("#resultContainer").append($("<p>").text("Now we are engaged in a great civil war, testing whether that nation, or any nation so conceived and so dedicated, can long endure. We are met on a great battle-field of that war. We have come to dedicate a portion of that field, as a final resting place for those who here gave their lives that that nation might live. It is altogether fitting and proper that we should do this."));
    $("#resultContainer").append($("<p>").text("But, in a larger sense, we can not dedicate -- we can not consecrate -- we can not hallow -- this ground. The brave men, living and dead, who struggled here, have consecrated it, far above our poor power to add or detract. The world will little note, nor long remember what we say here, but it can never forget what they did here. It is for us the living, rather, to be dedicated here to the unfinished work which they who fought here have thus far so nobly advanced. It is rather for us to be here dedicated to the great task remaining before us -- that from these honored dead we take increased devotion to that cause for which they gave the last full measure of devotion -- that we here highly resolve that these dead shall not have died in vain -- that this nation, under God, shall have a new birth of freedom -- and that government of the people, by the people, for the people, shall not perish from the earth."));

  }

  function onSelectors() {
    // create css styles object
    var cssParagraphs = {
      "color": "#444",
      "margin": "8px"
    }

    // pass css styles object to css function
    $("#resultContainer p").css(cssParagraphs);

    // update css for all headers
    $("#resultContainer :header").css({ "color": "Green" });

    // update css for first paragraph
    $("#resultContainer p:first").css(
      {
        "font-size": "1.1em",
        "color": "black"
      });

    // getting crazy - create a pretty div and wrap it around all headers
    $("#resultContainer :header")
      .css({ "margin": "0px" })
      .wrap("<div/>").css(
            {
              "border": "1px solid green",
              "padding": "2px",
              "background-color": "#DDD",
              "left": "-20px"
      });

  }

  function onAjax() {
    // use ajax() function to start HTTP request
    var xhr = $.ajax({
      url: "ContentPage1.htm",
      type: "GET",
      dataType: "html",
      success: onAjaxComplete,
      error: onAjaxError
    });
  }

  function onAjaxComplete(responseData) {
    $("#resultContainer").html(responseData);
  }

  function onAjaxError(error) {
    alert(error);
  }

  function onPromises() {

    // begin AJAX request and capture xhr return value
    var xhr = $.ajax({
      url: "ContentPage1.htm",
      type: "GET",
      dataType: "html"
    });

    // register success handler #1
    xhr.promise().done(function (responseData) {
      $("#resultContainer").html(responseData);
    });

    // register success handler #2
    xhr.promise().done(function (responseData) {
      $("#resultContainer p").css({"color": "red"});
    });

    // register failure handler
    xhr.promise().fail(function (error) {
      alert(error);
    });

  }

// jQuery UI event handlers

  function onAddNewCustomer(event) {
    var customer_dialog = $("#customer_dialog");
    customer_dialog.dialog({
      autoOpen: true,
      title: "Add New Customer",
      width: 420,
      buttons: {
        "Save": onAddNewCustomerSave,
        "Cancel": function () { $(this).dialog("close"); },
      }
    });
  }

  function onAddNewCustomerSave(event) {
    $("#lblFirstName").html($("#txtFirstName").val());
    $("#lblLastName").html($("#txtLastName").val());
    $("#lblPhone").html($("#txtPhone").val());
    $(this).dialog("close");
  }

  function refreshSwatch() {
    var red = $("#red").slider("value");
    var green = $("#green").slider("value");
    var blue = $("#blue").slider("value");
    var hex = hexFromRGB(red, green, blue);

    $("#swatch").css("background-color", "#" + hex)
                .html("#" + hex);
  }

  function hexFromRGB(r, g, b) {
    var hex = [r.toString(16), g.toString(16), b.toString(16)];
    $.each(hex, function (nr, val) {
      if (val.length === 1) {
        hex[nr] = "0" + val;
      }
    });
    return hex.join("").toUpperCase();
  }

  function onChangeTheme() {
    // remove existing theme CSS file
    $("link[href*=jquery-ui]").remove();

    // calculate path to new theme CSS file
    var themeCssPath = "../Content/themes/" + this.id + "/jquery-ui.css";

    

    // add new theme CSS file
    if (document.createStyleSheet) {
      document.createStyleSheet(themeCssPath);
    }
    else {
      $('head')
        .append('<link rel="stylesheet" type="text/css" href="' + themeCssPath + '" />');
    }

  }

