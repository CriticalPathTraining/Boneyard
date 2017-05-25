window.EmployeeDirectory = window.EmployeeDirectory || {}
window.EmployeeDirectory.ViewModels = window.EmployeeDirectory.ViewModels || {}

window.EmployeeDirectory.Contact = function (ln, fn, ti, pa, em, ph) {

    //private members
    var lname = 'undefined',
        fname = 'undefined',
        title = 'undefined',
        path = 'undefined',
        email = 'undefined',
        phone = 'undefined',
        set_lname = function (v) { lname = v; },
        get_lname = function () { return lname; },
        set_fname = function (v) { fname = v; },
        get_fname = function () { return fname; },
        set_title = function (v) { title = v; },
        get_title = function () { return title; },
        set_path = function (v) { path = v; },
        get_path = function () { return path; },
        set_email = function (v) { email = v; },
        get_email = function () { return email; },
        set_phone = function (v) { phone = v; },
        get_phone = function () { return phone; };


    //Constructor
    lname = ln;
    fname = fn;
    title = ti;
    path = pa;
    email = em;
    phone = ph;

    //public interface
    return {
        set_lname: set_lname,
        get_lname: get_lname,
        set_fname: set_fname,
        get_fname: get_fname,
        set_title: set_title,
        get_title: get_title,
        set_path: set_path,
        get_path: get_path,
        set_email: set_email,
        get_email: get_email,
        set_phone: set_phone,
        get_phone: get_phone
    };
}

window.EmployeeDirectory.ViewModels.Contact = function () {

    //private members
    var query,
        contacts = ko.observableArray(),
        set_query = function (v) { query = v; },
        get_contacts = function () { return contacts; },

        load = function () {
            $.ajax(
                    {
                        url: _spPageContextInfo.webAbsoluteUrl + "/_api/search/query?querytext='LastName:"
                            + query
                            + "*'&selectproperties='LastName,FirstName,JobTitle,WorkEmail,WorkPhone'&sourceid='B09A7990-05EA-4AF9-81EF-EDFAB16C4E31'&sortlist='LastName:ascending,FirstName:ascending'",
                        method: "GET",
                        headers: {
                            "accept": "application/xml",
                        },
                        success: onSuccess,
                        error: onError
                    }
                );
        },

        onSuccess = function (data) {
            contacts.removeAll();

            $(data).find("d\\:Rows").children("d\\:element").each(function () {
                $(this).find("d\\:Cells").each(function () {

                    var contact = new EmployeeDirectory.Contact;

                    $(this).find("d\\:element").each(function () {

                        if ($(this).children("d\\:Key").first().text() == "LastName")
                            contact.set_lname($(this).children("d\\:Value").first().text());
                        if ($(this).children("d\\:Key").first().text() == "FirstName")
                            contact.set_fname($(this).children("d\\:Value").first().text());
                        if ($(this).children("d\\:Key").first().text() == "JobTitle")
                            contact.set_title($(this).children("d\\:Value").first().text());
                        if ($(this).children("d\\:Key").first().text() == "Path")
                            contact.set_path($(this).children("d\\:Value").first().text());
                        if ($(this).children("d\\:Key").first().text() == "WorkEmail")
                            contact.set_email($(this).children("d\\:Value").first().text());
                        if ($(this).children("d\\:Key").first().text() == "WorkPhone")
                            contact.set_phone($(this).children("d\\:Value").first().text());
                    });

                    contacts.push(contact);

                });
            });
        },

        getPropertyIndex = function (r, p) {
            for (var i = 0; i < r.length; i++) {
                if (r[i].Key == p)
                    return i;
            }
        },

        onError = function (err) {
            alert(JSON.stringify(err));
        };


    //public interface
    return {
        load: load,
        set_query: set_query,
        get_contacts: get_contacts
    };

}();
