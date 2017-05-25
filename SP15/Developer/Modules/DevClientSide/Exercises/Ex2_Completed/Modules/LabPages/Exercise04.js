
$(onPageLoad);

function onPageLoad() {

  // make buttons pretty
  $(":button", "#toolbar").button();

  // register event handler
  $("#cmdGetCustomersList").click(onGetCustomersList);
  $("#cmdGetCustomersTable").click(onGetCustomersTable);

}

function onGetCustomersList() {
    // TODO: write code for exercise 4 
    $("#results").html("Exercise 4 Part A Not Yet Complete...");
}

function onGetCustomersTable() {
    // TODO: write code for exercise 4
    $("#results").html("Exercise 4 Part B Not Yet Complete...");
}

