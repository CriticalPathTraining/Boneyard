
$(onPageLoad);

function onPageLoad() {

  // make buttons pretty
  $(":button", "#toolbar").button();

  // register event handler
  $("#cmdGetLists").click(onGetLists);
}

function onGetLists() {
    // TODO: write code for exercise 2
    $("#results").html("Exercise 2 Not Yet Complete...");
}
