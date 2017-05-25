﻿using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using SystemIO = System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using System.Collections.Specialized;

namespace SharePointGenerateCustomers {
  class Program {

    #region "static fields"
    static string siteUrl = ConfigurationManager.AppSettings["targetSiteUrl"];

    static ClientContext clientContext = new ClientContext(siteUrl);
    static Site siteCollection = clientContext.Site;
    static Web site = clientContext.Web;

    static List listCustomers;

    #endregion

    #region "Helper methods"
    static Field CreateSiteColumn(string fieldName, string fieldDisplayName, string fieldType) {

      Console.WriteLine("Creating " + fieldName + " site column...");

      // delete existing field if it exists
      try {
        Field fld = site.Fields.GetByInternalNameOrTitle(fieldName);
        fld.DeleteObject();
        clientContext.ExecuteQuery();
      }
      catch { }

      string fieldXML = @"<Field Name='" + fieldName + "' " +
                                "DisplayName='" + fieldDisplayName + "' " +
                                "Type='" + fieldType + "' " +
                                "Group='Wingtip' > " +
                         "</Field>";

      Field field = site.Fields.AddFieldAsXml(fieldXML, true, AddFieldOptions.DefaultValue);
      clientContext.Load(field);
      clientContext.ExecuteQuery();
      return field;
    }

    static void DeleteContentType(string contentTypeName) {
      try {
        foreach (var ct in site.ContentTypes) {
          if (ct.Name.Equals(contentTypeName)) {
            ct.DeleteObject();
            Console.WriteLine("Deleting existing " + ct.Name + " content type...");
            clientContext.ExecuteQuery();
            break;
          }
        }
      }
      catch { }

    }

    static ContentType CreateContentType(string contentTypeName, string baseContentType) {

      DeleteContentType(contentTypeName);

      ContentTypeCreationInformation contentTypeCreateInfo = new ContentTypeCreationInformation();
      contentTypeCreateInfo.Name = contentTypeName;
      contentTypeCreateInfo.ParentContentType = site.ContentTypes.GetById(baseContentType); ;
      contentTypeCreateInfo.Group = "Wingtip";
      ContentType ctype = site.ContentTypes.Add(contentTypeCreateInfo);
      clientContext.ExecuteQuery();
      return ctype;

    }

    static void DeleteList(string listTitle) {
      try {
        List list = site.Lists.GetByTitle(listTitle);
        list.DeleteObject();
        Console.WriteLine("Deleting existing " + listTitle + " list...");
        clientContext.ExecuteQuery();
      }
      catch { }
    }


    #endregion


    static void CreateListInitialization() {

      XNamespace ns = "http://schemas.microsoft.com/sharepoint/";

      var rows = new XElement(ns + "Rows");

      foreach (var customer in CustomerFactory.GetCustomerList(42)) {
        rows.Add(new  XElement(ns + "Row",
                      new XElement(ns + "Field", new XAttribute("Name", "FirstName"), customer.FirstName),
                      new XElement(ns + "Field", new XAttribute("Name","Title"), customer.LastName),
                      new XElement(ns + "Field", new XAttribute("Name","Company"), customer.Company),
                      new XElement(ns + "Field", new XAttribute("Name", "Email"), customer.EmailAddress),
                      new XElement(ns + "Field", new XAttribute("Name", "WorkPhone"), customer.WorkPhone),
                      new XElement(ns + "Field", new XAttribute("Name", "HomePhone"), customer.HomePhone)));
                                

      }


      var xml = new XDocument(new XDeclaration("1.0", "utf-8", "no"),
          new XElement(ns + "Elements", new XAttribute("xmlns", "http://schemas.microsoft.com/sharepoint/"),
            new XElement(ns + "ListInstance",
                          new XAttribute("Title", "Customers"),
                          new XAttribute("OnQuickLaunch", "TRUE"),
                          new XAttribute("TemplateType", "105"),
                          new XAttribute("FeatureId", "00bfea71-7e6d-4186-9ba8-c047ac750105"),
                          new XAttribute("Url", "Lists/Customers"),
                          new XAttribute("Description", "A test list to demo paging"),
                          new XElement(ns + "Data", rows))));

      xml.Save(@"C:\SPC2014\RESTDemos\HtmlSlingingSmackdown\HtmlSlingingSmackdown\Lists\Customers\elements.xml");

      

      Console.WriteLine("hi");
        

    }
    static void Main(string[] args) {
      CreateListInitialization();
      return;
      Console.WriteLine();
      Console.WriteLine("----------------------------------------------------");
      Console.WriteLine("---- Creating and Populating Customers list ----");
      Console.WriteLine("----------------------------------------------------");
      Console.WriteLine();

      try {
        clientContext.Load(siteCollection);
        clientContext.Load(site);
        clientContext.Load(site.Fields);
        clientContext.Load(site.ContentTypes);
        clientContext.ExecuteQuery();

        DeleteAllWingtipTypes();
        CreateCustomersList();
        PopulateCustomersList(178);

        Console.WriteLine("The Products list and its dependant types have been created.");
        Console.WriteLine();
      }
      catch (Exception ex) {
        Console.WriteLine();
        Console.WriteLine("----------------------------------------------------------------");
        Console.WriteLine("----  Error occured when attempting to create Products list ----");
        Console.WriteLine("----------------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("Error type:");
        Console.WriteLine(ex.GetType().ToString());
        Console.WriteLine();
        Console.WriteLine("Error message:");
        Console.WriteLine(ex.Message);
        Console.WriteLine();
        Console.WriteLine("You must find and correct the problem ou are experiencing in order to successfully use this utility.");
      }

      Console.WriteLine();
      Console.WriteLine("Press the ENTER key to continue...");
      Console.ReadLine();

    }

    static void DeleteAllWingtipTypes() {
      DeleteList("Customers");
    }

    static void CreateCustomersList() {

      Console.WriteLine("Creating Customers list...");

      ListCreationInformation listInformationCustomers = new ListCreationInformation();
      listInformationCustomers.Title = "Customers";
      listInformationCustomers.Url = "Lists/Customers";
      listInformationCustomers.QuickLaunchOption = QuickLaunchOptions.On;
      listInformationCustomers.TemplateType = (int)ListTemplateType.Contacts;
      listCustomers = site.Lists.Add(listInformationCustomers);
      listCustomers.OnQuickLaunch = true;
      listCustomers.Update();

      clientContext.Load(listCustomers);
      clientContext.ExecuteQuery();

    }

    static void PopulateCustomersList(int NumberOfCustomers) {

      Console.WriteLine();
      Console.WriteLine("Adding sample items to Customers list");
      Console.WriteLine("------------------------------------");
      Console.WriteLine();

      int batchSizeMax = 100;
      int batchSize = 0;
  
      foreach(var customer in CustomerFactory.GetCustomerList(NumberOfCustomers)){
        ListItem newCustomer = listCustomers.AddItem(new ListItemCreationInformation());
        newCustomer["FirstName"] = customer.FirstName;
        newCustomer["Title"] = customer.LastName;
        newCustomer["Company"] = customer.Company;
        newCustomer["WorkPhone"] = customer.WorkPhone;
        newCustomer["HomePhone"] = customer.HomePhone;
        newCustomer["Email"] = customer.EmailAddress;
        newCustomer.Update();
        if (batchSize >= batchSizeMax) {
          clientContext.ExecuteQuery();
          batchSize = 0;
        }
        batchSize += 1;
      }
      clientContext.ExecuteQuery();

      
      Console.WriteLine("  Adding New Customer...");
      clientContext.ExecuteQuery();

      Console.WriteLine();
      Console.WriteLine("  Loading of customer items has completed");
      Console.WriteLine();
    }


  }
}
