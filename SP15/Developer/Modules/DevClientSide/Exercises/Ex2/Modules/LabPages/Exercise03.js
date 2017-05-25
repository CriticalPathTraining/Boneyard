
$(onPageLoad);

function onPageLoad() {
    // make buttons pretty
    $(":button", "#toolbar").button();
    // register event handler
    $("#cmdGetUserLists").click(onGetUserLists);
}

function onGetUserLists() {
    // TODO: write code for exercise 3
    $("#results").html("Exercise 3 Not Yet Complete...");
}

