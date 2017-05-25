'use strict';

var urlAdventureWorksOData = "http://services.odata.org/V2/(S(cpt))/OData/OData.svc/Products";

var proxyResponse;

$(function () {

  var context = new SP.ClientContext.get_current();
  var request = new SP.WebRequestInfo();
  request.set_url(urlAdventureWorksOData);
  request.set_method("GET");
  request.set_headers({ "Accept": "application/json;odata=verbose" });
  var response = SP.WebProxy.invoke(context, request);
  proxyResponse = response;
  context.executeQueryAsync(OnSuccess, OnFail);



  //on On Successful app Request  
  
  /// Request Fails

});

function OnSuccess(p1, p2) {

  if (proxyResponse.get_statusCode() == 200) {

    var odataResult = JSON.parse(proxyResponse.get_body());
    var Products = odataResult.d;

    $("#results").append( $("<h3>").text("Northwind Products") );

    var listProducts = $("<ol>");

    for (var index = 0; index < Products.length; index++) {
      var product = Products[index];
      listProducts.append($("<li>").text( product.Name  ));
    }

    $("#results").append(listProducts);
    
  } else {
    // on Error 
    var errordesc;

    errordesc = "<P>Status code: " + proxyResponse.get_statusCode() + "<br/>";
    errordesc += proxyResponse.get_body();
    $("#results").text(errordesc);
  }

}


function OnFail() {

  document.getElementById("message").innerHTML =
         response.get_body();

}