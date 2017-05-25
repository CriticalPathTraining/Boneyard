<%@ Page MasterPageFile="~/Pages/app.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PlaceholderAdditionalPageHead" runat="server">
  <script src="../Scripts/demo5.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolderMain" runat="server">

  <h2>Demo 5: Adding Elements to an Observable Array</h2>


  <div style="width: 48%;">

    <fieldset>
      <legend>Add New Customer:</legend>

      <label for="firstName">First Name: </label>
      <input data-bind="value: newCustomer.firstName, valueUpdate: 'keyup'" /><br />

      <label for="lastName">Last Name: </label>
      <input data-bind="value: newCustomer.lastName, valueUpdate: 'keyup'" /><br />

      <input type="button" value="Add Customer" 
             data-bind="click: addCustomer, enable: newCustomer.isValid()" />

    </fieldset>

  </div>


  <h3>Customer List</h3>

  <table id="customersTable">
    <thead>
      <tr>
        <td>First Name</td>
        <td>Last Name</td>
      </tr>
    </thead>
    <tbody id="resultsTable" data-bind="foreach: customers()">
      <tr>
        <td data-bind="text: firstName"></td>
        <td data-bind="text: lastName"></td>
      </tr>
    </tbody>
  </table>


</asp:Content>
