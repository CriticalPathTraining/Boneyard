<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppPart.aspx.cs" Inherits="CustomerManagerWeb.Pages.AppPart" %>

<!DOCTYPE html>

<html>
<head>
    <title></title>
    <script type="text/javascript">
        // Set the style of the client web part page to be consistent with the host web.
        (function () {
            'use strict';

            var hostUrl = '';
            if (document.URL.indexOf('?') != -1) {
                var params = document.URL.split('?')[1].split('&');
                for (var i = 0; i < params.length; i++) {
                    var p = decodeURIComponent(params[i]);
                    if (/^SPHostUrl=/i.test(p)) {
                        hostUrl = p.split('=')[1];
                        document.write('<link rel="stylesheet" href="' + hostUrl + '/_layouts/15/defaultcss.ashx" />');
                        break;
                    }
                }
            }
            if (hostUrl == '') {
                document.write('<link rel="stylesheet" href="/_layouts/15/1033/styles/themable/corev15.css" />');
            }
        })();
    </script>
  <script src="../Scripts/jquery-2.1.0.js"></script>
</head>
<body>
  <form id="form1" runat="server">
  <h2>Customer List</h2>
    <div>
      <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" DataSourceID="EntityDataSource1" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
          <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
          <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
          <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
          <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
          <asp:BoundField DataField="Company" HeaderText="Company" SortExpression="Company" />
          <asp:BoundField DataField="WorkPhone" HeaderText="WorkPhone" SortExpression="WorkPhone" />
          <asp:BoundField DataField="HomePhone" HeaderText="HomePhone" SortExpression="HomePhone" />
          <asp:BoundField DataField="EmailAddress" HeaderText="EmailAddress" SortExpression="EmailAddress" />
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
      </asp:GridView>
      <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=WingtipCRMEntities" DefaultContainerName="WingtipCRMEntities" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="Customers">
      </asp:EntityDataSource>
    </div>
    <div>
      <asp:FormView ID="FormView1" runat="server" DataKeyNames="ID" DataSourceID="EntityDataSource1" DefaultMode="Insert" OnItemInserted="FormView1_ItemInserted" style="text-align: right">
        <EditItemTemplate>
          ID:
          <asp:Label ID="IDLabel1" runat="server" Text='<%# Eval("ID") %>' />
          <br />
          FirstName:
          <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' />
          <br />
          LastName:
          <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' />
          <br />
          Company:
          <asp:TextBox ID="CompanyTextBox" runat="server" Text='<%# Bind("Company") %>' />
          <br />
          WorkPhone:
          <asp:TextBox ID="WorkPhoneTextBox" runat="server" Text='<%# Bind("WorkPhone") %>' />
          <br />
          HomePhone:
          <asp:TextBox ID="HomePhoneTextBox" runat="server" Text='<%# Bind("HomePhone") %>' />
          <br />
          EmailAddress:
          <asp:TextBox ID="EmailAddressTextBox" runat="server" Text='<%# Bind("EmailAddress") %>' />
          <br />
          <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
          &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
        <InsertItemTemplate>
          FirstName:
          <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' />
          <br />
          LastName:
          <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' />
          <br />
          Company:
          <asp:TextBox ID="CompanyTextBox" runat="server" Text='<%# Bind("Company") %>' />
          <br />
          WorkPhone:
          <asp:TextBox ID="WorkPhoneTextBox" runat="server" Text='<%# Bind("WorkPhone") %>' />
          <br />
          HomePhone:
          <asp:TextBox ID="HomePhoneTextBox" runat="server" Text='<%# Bind("HomePhone") %>' />
          <br />
          EmailAddress:
          <asp:TextBox ID="EmailAddressTextBox" runat="server" Text='<%# Bind("EmailAddress") %>' />
          <br />
          <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
          &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
          ID:
          <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
          <br />
          FirstName:
          <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Bind("FirstName") %>' />
          <br />
          LastName:
          <asp:Label ID="LastNameLabel" runat="server" Text='<%# Bind("LastName") %>' />
          <br />
          Company:
          <asp:Label ID="CompanyLabel" runat="server" Text='<%# Bind("Company") %>' />
          <br />
          WorkPhone:
          <asp:Label ID="WorkPhoneLabel" runat="server" Text='<%# Bind("WorkPhone") %>' />
          <br />
          HomePhone:
          <asp:Label ID="HomePhoneLabel" runat="server" Text='<%# Bind("HomePhone") %>' />
          <br />
          EmailAddress:
          <asp:Label ID="EmailAddressLabel" runat="server" Text='<%# Bind("EmailAddress") %>' />
          <br />
          <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
          &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" />
          &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" />
        </ItemTemplate>
    </asp:FormView>
  </div>
  </form>
</body>
</html>
