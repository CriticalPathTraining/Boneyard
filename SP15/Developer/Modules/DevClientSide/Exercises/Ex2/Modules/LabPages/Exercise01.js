
// register onPageLoad function with jquery Document Ready event handler
$(onPageLoad);

function onPageLoad() {
    // use jquery-ui to format command button
    $(":button", "#toolbar").button();
    // register event handler for click event
    $("#cmdGetSiteInfo").click(onGetSiteInfo);
}

function onGetSiteInfo() {
    // TODO: write code for exercise 1
    $("#results").html("Exercise 1 Not Yet Complete...");

}
