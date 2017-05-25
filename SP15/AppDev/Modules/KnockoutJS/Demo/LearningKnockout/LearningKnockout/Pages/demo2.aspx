<%@ Page MasterPageFile="~/Pages/app.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PlaceholderAdditionalPageHead" runat="server">
  <script src="../Scripts/demo2.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolderMain" runat="server">
 
  <h2>Demo 2: Creating the ViewModel</h2>

  <div>
    <div style="float: left; width: 48%">

      <fieldset>
        <legend>Edit Customer Information:</legend>
        <label for="firstName">First Name: </label>
        <input data-bind="value: firstName"><br>
        <label for="lastName">Last Name: </label>
        <input data-bind="value: lastName"><br>
        <label for="workPhone">Work Phone: </label>
        <input data-bind="value: workPhone"><br>
        <label for="homePhone">Home Phone: </label>
        <input data-bind="value: homePhone"><br>
        <label for="email">EMail: </label>
        <input data-bind="value: email"><br>
        <label for="company">Company: </label>
        <input data-bind="value: company"><br>
      </fieldset>

    </div>
  </div>

  <div>
    <div style="float: right; width: 48%">

      <fieldset>
        <legend>View Customer Information:</legend>
        <label for="firstName">First Name: </label>
        <input data-bind="value: firstName" readonly="true"><br>
        <label for="lastName">Last Name: </label>
        <input data-bind="value: lastName" readonly="true"><br>
        <label for="workPhone">Work Phone: </label>
        <input data-bind="value: workPhone" readonly="true"><br>
        <label for="homePhone">Home Phone: </label>
        <input data-bind="value: homePhone" readonly="true"><br>
        <label for="email">EMail: </label>
        <input data-bind="value: email" readonly="true"><br>
        <label for="company">Company: </label>
        <input data-bind="value: company" readonly="true"><br>
      </fieldset>
    </div>
  </div>

</asp:Content>
