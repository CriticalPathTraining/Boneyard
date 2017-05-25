using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using SystemIO = System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using System.Collections.Specialized;

namespace CreateWingtipCatalogContent {
  class Program {

    static string siteUrl = ConfigurationManager.AppSettings["targetSiteUrl"];

    static void Main() {

      string siteUrl = "http://intranet.wingtip.com";
      ClientContext clientContext = new ClientContext(siteUrl);
      WingtipContentGenerator.CreateProductCategoriesTermset();
      WingtipContentGenerator.CreateProductsLists();
    }
  }
}
