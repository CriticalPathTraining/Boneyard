<%@ Page %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
  <meta charset="utf-8" />
  <meta http-equiv="X-UA-Compatible" content="IE=10"/>
  <title>Wingtip CRM</title>
  
  <!-- links to jQuery library and jQuery UI library -->
  <script src="Scripts/jquery-2.1.1.js"></script>
  <script src="Scripts/jquery-ui-1.11.1.js"></script>
  <link href="Content/themes/base/all.css" rel="stylesheet" />

  <script src="Scripts/jsrender.js"></script>
  <script src="Scripts/Wingtip.Customers.DataAccess.js"></script>
  <script src="Scripts/customers.js"></script>
  <link href="Content/app.css" rel="stylesheet" />
</head>

<body>
  <form runat="server">

    <div id="page_width">

      <header id="page_header">
        <div id="site_logo"><img src="Content/img/AppIcon.png" /></div>
        <h1 id="site_title">Customers List</h1>
      </header>

      <nav id="toolbar">
        <input type="button" id="cmdAddNewCustomer" value="Add New Customer" class="ui-button" />
      </nav>

      <div id="content_box"></div>

      <div id="customer_dialog" style="display: none;" >
        <table>
          <tr>
            <td>First Name:</td>
            <td><input id="firstName" /></td>
          </tr>
          <tr>
            <td>Last Name:</td>
            <td><input id="lastName" /></td>
          </tr>
          <tr>
            <td>Company:</td>
            <td><input id="company" /></td>
          </tr>
          <tr>
            <td>Work Phone:</td>
            <td><input id="workPhone" /></td>
          </tr>
          <tr>
            <td>Home Phone:</td>
            <td><input id="homePhone" /></td>
          </tr>
          <tr>
            <td>Email:</td>
            <td><input id="email" /></td>
          </tr>

        </table>

        <!-- hidden controls -->
        <div style="display: none">
          <input id="customer_id" />
        </div>

      </div>
  
    </div>

  </form>
</body>
</html>
