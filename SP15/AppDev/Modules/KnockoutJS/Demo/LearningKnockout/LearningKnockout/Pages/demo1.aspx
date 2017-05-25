<%@ Page MasterPageFile="~/Pages/app.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PlaceholderAdditionalPageHead" runat="server">
  <script src="../Scripts/demo1.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolderMain" runat="server">

  <h2>Demo 1: Observables</h2>

  <div>
    <div style="float: left; width: 48%">
      <fieldset>
        <legend>Edit Customer Information:</legend>

        <label for="firstName">First Name: </label>
        <input data-bind="value: firstName" /><br/>
        
        <label for="lastName">Last Name: </label>
        <input data-bind="value: lastName, valueUpdate: 'keyup'" /><br/>
        
        <label for="workPhone">Work Phone: </label>
        <input data-bind="value: workPhone, valueUpdate: 'afterkeydown'" /><br/>       
      
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
      </fieldset>
    </div>
  </div>

</asp:Content>
