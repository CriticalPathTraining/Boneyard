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


namespace DocumentLibrariesSolution {
  class Program {

    #region "static fields"
    static string siteUrl = ConfigurationManager.AppSettings["targetSiteUrl"];
    static string username = ConfigurationManager.AppSettings["siteUser"];

    static ClientContext clientContext = new ClientContext(siteUrl);
    static Site siteCollection = clientContext.Site;
    static Web site = clientContext.Web;


    static FieldUrl fieldProductImageUrl;

    static ContentType ctypeProduct;
    static List listProducts;
    static List listProductImages;
    static string listProductImagesUrl;

    #endregion

    #region "Helper methods"
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

    static void Main() {

      Console.WriteLine();
      Console.WriteLine("-----------------------------------------------------");
      Console.WriteLine("---- Applying solution for Document Libaries lab ----");
      Console.WriteLine("-----------------------------------------------------");
      Console.WriteLine();

      SecureString password = GetPasswordFromConsoleInput();

      try {

          //Added for O365
        clientContext.Credentials = new SharePointOnlineCredentials(username, password);

        clientContext.Load(siteCollection);
        clientContext.Load(site);
        clientContext.Load(site.Fields);
        clientContext.Load(site.ContentTypes);
        clientContext.Load(site.Lists);
        clientContext.ExecuteQuery();

        listProducts = site.Lists.GetByTitle("Products");
  
        DeleteWingtipTypes();
        CreateProductImagesLibrary();
        UploadProductImages();
        CreateWingtipDocumentSiteColumns();
        ExtendProductContentType();
        UpdateProductsListWithImageUrls();
        CreateProductProposalContentType();
        CreateProductProposalsLibrary();
        CreateProductPlanDocumentSet();

        Console.WriteLine("The solution to the Document Libraries lab has been applied successfully");
        Console.WriteLine();
      }
      catch (Exception ex) {
        Console.WriteLine();
        Console.WriteLine("-------------------------------------------------------------");
        Console.WriteLine("----  Error occured when attempting to applying solution ----");
        Console.WriteLine("-------------------------------------------------------------");
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

    static void DeleteWingtipTypes(){
      DeleteList("Product Images");
    }

    static void CreateProductImagesLibrary(){
      Console.WriteLine();
      Console.WriteLine("Creating Product Images library...");


      ListCreationInformation listInformationProductImages = new ListCreationInformation();
      listInformationProductImages.Title = "Product Images";
      listInformationProductImages.Url = "ProductImages";
      listInformationProductImages.QuickLaunchOption = QuickLaunchOptions.On;
      listInformationProductImages.TemplateType = (int)ListTemplateType.PictureLibrary;
      listProductImages = site.Lists.Add(listInformationProductImages);
      listProductImages.OnQuickLaunch = true;
      listProductImages.Update();

      clientContext.Load(listProductImages);
      clientContext.Load(listProductImages.RootFolder);
      clientContext.ExecuteQuery();

      //listProductImagesUrl = listProductImages.RootFolder.ServerRelativeUrl;
      listProductImagesUrl = listProductImages.RootFolder.Name;

    }

    static void UploadProductImage(byte[] imageContent, string imageFileName){
     
      Console.WriteLine("  uploading " + imageFileName);
      

      FileCreationInformation fileInfo = new FileCreationInformation();
      fileInfo.Content = imageContent;
      fileInfo.Overwrite = true;            
      //fileInfo.Url = site.Url + listProductImages.RootFolder.ServerRelativeUrl + "/" + imageFileName;
      fileInfo.Url = site.Url + "/" + listProductImages.RootFolder.Name + "/" + imageFileName;
      File newFile = listProductImages.RootFolder.Files.Add(fileInfo);
      clientContext.ExecuteQuery();

    }

    static void UploadProductImages() {

      Console.WriteLine();
      Console.WriteLine("Uploading Product Images...");

      UploadProductImage(Properties.Resources.WP0001, "WP0001.jpg");
      UploadProductImage(Properties.Resources.WP0002, "WP0002.jpg");
      UploadProductImage(Properties.Resources.WP0003, "WP0003.jpg");
      UploadProductImage(Properties.Resources.WP0004, "WP0004.jpg");
      UploadProductImage(Properties.Resources.WP0005, "WP0005.jpg");
      UploadProductImage(Properties.Resources.WP0006, "WP0006.jpg");
      UploadProductImage(Properties.Resources.WP0007, "WP0007.jpg");
      UploadProductImage(Properties.Resources.WP0008, "WP0008.jpg");
      UploadProductImage(Properties.Resources.WP0009, "WP0009.jpg");
      UploadProductImage(Properties.Resources.WP0010, "WP0010.jpg");
      UploadProductImage(Properties.Resources.WP0011, "WP0011.jpg");
      UploadProductImage(Properties.Resources.WP0012, "WP0012.jpg");
      UploadProductImage(Properties.Resources.WP0013, "WP0013.jpg");
      UploadProductImage(Properties.Resources.WP0014, "WP0014.jpg");
      UploadProductImage(Properties.Resources.WP0015, "WP0015.jpg");
      UploadProductImage(Properties.Resources.WP0016, "WP0016.jpg");
      UploadProductImage(Properties.Resources.WP0017, "WP0017.jpg");
      UploadProductImage(Properties.Resources.WP0018, "WP0018.jpg");
      UploadProductImage(Properties.Resources.WP0019, "WP0019.jpg");
      UploadProductImage(Properties.Resources.WP0020, "WP0020.jpg");
      UploadProductImage(Properties.Resources.WP0021, "WP0021.jpg");
      UploadProductImage(Properties.Resources.WP0022, "WP0022.jpg");
      UploadProductImage(Properties.Resources.WP0023, "WP0023.jpg");
      UploadProductImage(Properties.Resources.WP0024, "WP0024.jpg");
      UploadProductImage(Properties.Resources.WP0025, "WP0025.jpg");
      UploadProductImage(Properties.Resources.WP0026, "WP0026.jpg");
      UploadProductImage(Properties.Resources.WP0027, "WP0027.jpg");
      UploadProductImage(Properties.Resources.WP0028, "WP0028.jpg");
      UploadProductImage(Properties.Resources.WP0029, "WP0029.jpg");
      UploadProductImage(Properties.Resources.WP0030, "WP0030.jpg");
      UploadProductImage(Properties.Resources.WP0031, "WP0031.jpg");
      UploadProductImage(Properties.Resources.WP0032, "WP0032.jpg");

    }

    static void CreateWingtipDocumentSiteColumns(){
      Console.WriteLine();
      Console.WriteLine("Executing CreateWingtipDocumentSiteColumns()...");

      try {
        fieldProductImageUrl = clientContext.CastTo<FieldUrl>(CreateSiteColumn("ProductImageUrl", "Product Image Url", "URL"));
        fieldProductImageUrl.DisplayFormat = UrlFieldFormatType.Image;
        fieldProductImageUrl.Update();
        clientContext.ExecuteQuery();
      }
      catch { }


    }

    static void ExtendProductContentType() {

      Console.WriteLine();
      Console.WriteLine("Extending Product content type with ProductImageUrl site column");

      clientContext.Load(site.ContentTypes);
      clientContext.ExecuteQuery();

      ContentType ctypeProduct = site.ContentTypes.Where(cType => cType.Name.Equals("Product")).First();


      clientContext.Load(ctypeProduct);
      clientContext.ExecuteQuery();

      try {
        FieldLinkCreationInformation fieldLinkProductImageUrl = new FieldLinkCreationInformation();
        fieldLinkProductImageUrl.Field = fieldProductImageUrl;
        ctypeProduct.FieldLinks.Add(fieldLinkProductImageUrl);
        ctypeProduct.Update(true);
        clientContext.ExecuteQuery();

      }
      catch { }

      clientContext.Load(listProducts.DefaultView);
      clientContext.Load(listProducts.DefaultView.ViewFields);
      clientContext.ExecuteQuery();

      listProducts.DefaultView.ViewFields.Add("ProductImageUrl");
      listProducts.DefaultView.Update();
      listProducts.Update();
      clientContext.ExecuteQuery();

    }

    static void CreateProductProposalContentType(){
      Console.WriteLine();
      Console.WriteLine("Executing CreateProductProposalContentType()...");
      Console.WriteLine();
    }

    static void UpdateProductsListWithImageUrls() {

      clientContext.Load(listProducts);
      ListItemCollection products = listProducts.GetItems(new CamlQuery());
      clientContext.Load(products);
      clientContext.ExecuteQuery();

      foreach (var product in products) {
        string title = product["Title"].ToString();
        string productCode = product["ProductCode"].ToString();
        string productImageUrl = site.Url + "/" + listProductImages.RootFolder.Name + "/" + productCode + ".jpg";
        FieldUrlValue urlValue = new FieldUrlValue();

        urlValue.Url = productImageUrl;
        urlValue.Description = title;
        product["ProductImageUrl"] = urlValue;
        product.Update();
        Console.WriteLine("  adding " + productImageUrl);
        clientContext.ExecuteQuery();
      }
    }
     
    static void CreateProductProposalsLibrary(){
      Console.WriteLine();
      Console.WriteLine("Executing CreateProductProposalsLibrary()...");
      Console.WriteLine();
    }

    static void CreateProductPlanDocumentSet(){
      Console.WriteLine();
      Console.WriteLine("Executing CreateProductPlanDocumentSet()...");
      Console.WriteLine();
    }

  }
}
