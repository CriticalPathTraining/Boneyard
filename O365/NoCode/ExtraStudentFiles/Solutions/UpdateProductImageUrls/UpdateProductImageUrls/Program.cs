using System;
using System.Configuration;
using System.Collections.Generic;
using SystemIO = System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using System.Collections.Specialized;
using System.Security;
using System.Diagnostics;

namespace UpdateProductImageUrls {

  class Program {
  
    static string siteUrl = ConfigurationManager.AppSettings["targetSiteUrl"];
    static string username = ConfigurationManager.AppSettings["siteUser"];

    static ClientContext clientContext = new ClientContext(siteUrl);
    static Site siteCollection = clientContext.Site;
    static Web site = clientContext.Web;
    static List listProducts;
    static List listProductImages;

    static void Main() {

        //Added for O365
        SecureString password = GetPasswordFromConsoleInput();
        clientContext.Credentials = new SharePointOnlineCredentials(username, password);

      clientContext.Load(siteCollection);
      clientContext.Load(site);
      clientContext.Load(site.Lists);
      clientContext.ExecuteQuery();

      listProducts = site.Lists.GetByTitle("Products");
      clientContext.Load(listProducts);

      listProductImages = site.Lists.GetByTitle("Product Images");
      //clientContext.Load(listProductImages, lib => lib.RootFolder.ServerRelativeUrl);
      clientContext.Load(listProductImages, lib => lib.RootFolder.Name);

      ListItemCollection products = listProducts.GetItems(new CamlQuery());
      clientContext.Load(products);
      clientContext.ExecuteQuery();

      Console.WriteLine();
      Console.WriteLine("Updating product image URL for all products");

      foreach (var product in products) {
        string title = product["Title"].ToString();
        string productCode = product["ProductCode"].ToString();
        //string productImageUrl = site.Url + listProductImages.RootFolder.ServerRelativeUrl + "/" + productCode + ".jpg";
        string productImageUrl = site.Url + "/" + listProductImages.RootFolder.Name + "/" + productCode + ".jpg";
        //
        Debug.WriteLine("Updating: " + productImageUrl);
        FieldUrlValue urlValue = new FieldUrlValue();

        urlValue.Url = productImageUrl;
        urlValue.Description = title;
        product["ProductImageUrl"] = urlValue;
        product.Update();
        Console.Write(".");
        clientContext.ExecuteQuery();
      }

      Console.WriteLine();
      Console.WriteLine();
      Console.WriteLine("Update complete. Press the ENTER key to continue.");
      Console.WriteLine();
      Console.WriteLine();
      Console.ReadLine();
    }

    private static SecureString GetPasswordFromConsoleInput()
    {
        ConsoleKeyInfo info;

        //Get the user's password as a SecureString
        SecureString securePassword = new SecureString();
        Console.Write("Site Password: ");
        do
        {
            info = Console.ReadKey(true);
            if (info.Key != ConsoleKey.Enter)
            {
                securePassword.AppendChar(info.KeyChar);
            }
        }
        while (info.Key != ConsoleKey.Enter);
        return securePassword;
    }
  }
}
