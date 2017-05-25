<%@ Page MasterPageFile="~/Pages/app.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PlaceholderAdditionalPageHead" runat="server">
  <script src="../Scripts/demo4.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolderMain" runat="server">

  <h2>Demo 4: Displaying Items in an Observable Array</h2>

  <div>
      
    <h3>Binding to an unorder list </h3>
    <ul data-bind="foreach: customers()">
      <li>
        <span data-bind="text: firstName"></span>
        <span></span>
        <span data-bind="text: lastName"></span>
      </li>
    </ul>

    <h3>Binding to an HTML table</h3>
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

    <h3>Binding to a simple div</h3>
    <div data-bind="foreach: customers()">
      <div class="customersDiv">
        <span data-bind="text: firstName"></span>
        <br />
        <span data-bind="text: lastName"></span>
      </div>
    </div>

  </div>

</asp:Content>
