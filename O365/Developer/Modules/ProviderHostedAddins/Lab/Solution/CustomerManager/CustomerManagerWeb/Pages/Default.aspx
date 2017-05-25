<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CustomerManagerWeb.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Manager</title>
    <link href="../Content/app.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="pageWidth">

      <nav id="topnav">
        <asp:HyperLink ID="lnkHostWeb" runat="server">Host Web</asp:HyperLink>
      </nav>

      <header id="topHeader">
        <h2>Customer Manager Start Page</h2>
      </header>
      
      <div id="contentBody">
        <asp:PlaceHolder ID="pageContent" runat="server"></asp:PlaceHolder>
      </div>

    </div>

    </form>
</body>
</html>
