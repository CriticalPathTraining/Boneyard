//Namespace
window.AppLevelECT = window.AppLevelECT || {};

//Constructor
AppLevelECT.Grid = function (hostElement, surlWeb) {
    this.hostElement = hostElement;
    if (surlWeb.length > 0 &&
        surlWeb.substring(surlWeb.length - 1, surlWeb.length) !== "/")
        surlWeb += "/";
    this.surlWeb = surlWeb;
};

//Prototype
AppLevelECT.Grid.prototype = {

    init: function () {

        $.ajax({
            url: this.surlWeb + "_api/lists/getbytitle('People')/items?" +
                                "$select=BdcIdentity,FirstName,LastName",
            headers: {
                "accept": "application/json;odata=verbose",
                "X-RequestDigest": $("#__REQUESTDIGEST").val()
            },
            context: this,
            success: this.showItems
        });
    },

    showItems: function (data) {
        var items = [];

        items.push("<table>");
        items.push("<tr>" +
                   "<td>First Name</td><td>Last Name</td></tr>");

        $.each(data.d.results, function (key, val) {
            items.push('<tr id="' + val.BdcIdentity + '"><td>' +
                val.FirstName + '</td><td>' +
                val.LastName + '</td></tr>');
        });

        items.push("</table>");

        this.hostElement.html(items.join(''));
    }
};

function getProducts() {
    var grid = new AppLevelECT.Grid($("#displayDiv"),
                  _spPageContextInfo.webServerRelativeUrl);
    grid.init();
}

// This code runs when the DOM is ready and creates a context object which is needed to use the SharePoint object model
$(document).ready(function () {
    getProducts();
});