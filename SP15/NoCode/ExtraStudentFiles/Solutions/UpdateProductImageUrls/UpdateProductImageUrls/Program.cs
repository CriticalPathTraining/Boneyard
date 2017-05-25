using System;
using System.Configuration;
using System.Collections.Generic;
using SystemIO = System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using System.Collections.Specialized;

namespace UpdateProductImageUrls {

  class Program {
  
    static string siteUrl = ConfigurationManager.AppSettings["targetSiteUrl"];
    static ClientContext clientContext = new ClientContext(siteUrl);
    static Site siteCollection = clientContext.Site;
    static Web site = clientContext.Web;
    static List listProducts;
    static List listProductImages;

    static void Main() {

      clientContext.Load(siteCollection);
      clientContext.Load(site);
      clientContext.Load(site.Lists);
      clientContext.ExecuteQuery();

      listProducts = site.Lists.GetByTitle("Products");
      clientContext.Load(listProducts);

      listProductImages = site.Lists.GetByTitle("Product Images");
      clientContext.Load(listProductImages, lib => lib.RootFolder.ServerRelativeUrl);


      ListItemCollection products = listProducts.GetItems(new CamlQuery());
      clientContext.Load(products);
      clientContext.ExecuteQuery();

      Console.WriteLine();
      Console.WriteLine("Updating product image URL for all products");

      foreach (var product in products) {
        string title = product["Title"].ToString();
        string productCode = product["ProductCode"].ToString();
        string productImageUrl = site.Url + listProductImages.RootFolder.ServerRelativeUrl + "/" + productCode + ".jpg";
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
      Console.WriteLine("Update complete. Press the ENTER ke to continue.");
      Console.WriteLine();
      Console.WriteLine();
      Console.ReadLine();
    }
  }
}
