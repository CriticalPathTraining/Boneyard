using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Client;

namespace CSOM_ManageClient {
  class Program {
    static void Main() {

      ClientContext cc = new ClientContext("http://clientside.wingtip.com");
      cc.Credentials = CredentialCache.DefaultCredentials;
      Web site = cc.Web;
      ListCollection lists = site.Lists;

      // load site info
      cc.Load(site);
      cc.ExecuteQuery();
      Console.WriteLine("Site Title: " + site.Title);

      // create list
      ListCreationInformation newList = new ListCreationInformation();
      newList.Title = "Customers CSOM";
      newList.Url = "Lists/Customers_CSOM";
      newList.QuickLaunchOption = QuickLaunchOptions.On;
      newList.TemplateType = (int)ListTemplateType.Contacts;
      site.Lists.Add(newList);

      // refresh lists collection
      cc.Load(lists);

      // make round trip to Web server to do all the work
      cc.ExecuteQuery();

      foreach (List list in lists) {
        Console.WriteLine(list.Title);
      }

    }
  }
}
