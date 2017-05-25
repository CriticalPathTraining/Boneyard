window.Wingtip = window.Wingtip || {};

Wingtip.WelcomeViewModel = function () {

    var displayName = ko.observable(""),
        pictureUrl = ko.observable(""),

    get_displayName = function () { return displayName; },
    get_pictureUrl = function () { return pictureUrl; },

    init = function () {
        //Code goes here
    };

    return {
        init: init,
        get_displayName: get_displayName,
        get_pictureUrl: get_pictureUrl
    }

}();

Wingtip.Utilities = function () {

    var getQueryStringParameter = function (p) {
        try {
            var params =
                document.URL.split("?")[1].split("&");
            var strParams = "";
            for (var i = 0; i < params.length; i = i + 1) {
                var singleParam = params[i].split("=");
                if (singleParam[0] == p)
                    return decodeURIComponent(singleParam[1]);
            }
        }
        catch (err)
        { return null; }
    };

    return {
        getQueryStringParameter: getQueryStringParameter
    }

}();
