using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using System.Collections.Specialized;

namespace CreateIntranetTypes {
  class Program {

    static string siteUrl = ConfigurationManager.AppSettings["targetSiteUrl"];
    static string studentFolder = ConfigurationManager.AppSettings["studentFolder"];

    static ClientContext clientContext = new ClientContext(siteUrl);
    static Site siteCollection = clientContext.Site;
    static Web site = clientContext.Web;
    static Field fieldProductCode;
    static FieldCurrency fieldProductListPrice;
    static FieldChoice fieldProductCategory;
    static FieldChoice fieldProductColor;
    static FieldNumber fieldMinimumAge;
    static FieldNumber fieldMaximumAge;
    static ContentType ctypeProduct;
    static ContentType ctypeProductProposal;

    static void Main() {

      Console.WriteLine("Adding types and content to site at " + siteUrl);


      clientContext.Load(siteCollection);
      clientContext.Load(site);
      clientContext.Load(site.Fields);
      clientContext.Load(site.ContentTypes);
      clientContext.ExecuteQuery();

      DeleteAllWingtipTypes();
      CreateWingtipSiteColumns();
      CreateWingtipContentTypes();
      CreateWingtipLists();  

    }
   
    #region "Helper methods"
    static Field CreateSiteColumn(string fieldName, string fieldDisplayName, string fieldType) {

      // delete existing field if it exists
      try {
        Field fld = site.Fields.GetByInternalNameOrTitle(fieldName);
        fld.DeleteObject();
        clientContext.ExecuteQuery();
      }
      catch{}

      string fieldXML = @"<Field Name='" + fieldName + "' " +
                                "DisplayName='" + fieldDisplayName + "' " +
                                "Type='" + fieldType + "' " +
                                "Group='Wingtip' > " +
                         "</Field>";

      Console.WriteLine("Creating site column: " + fieldName);
      Field field = site.Fields.AddFieldAsXml(fieldXML, true, AddFieldOptions.DefaultValue);
      clientContext.Load(field);
      clientContext.ExecuteQuery();
      return field;
    }

    static void DeleteContentType(string contentTypeName) {
      try
      {
        foreach (var ct in site.ContentTypes)
        {
          if (ct.Name.Equals(contentTypeName))
          {
            ct.DeleteObject();
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
      try
      {
        List list = site.Lists.GetByTitle(listTitle);
        list.DeleteObject();
        clientContext.ExecuteQuery();
      }
      catch { }
    }
    #endregion

    static void DeleteAllWingtipTypes() {

      // delete existing content types
      Console.WriteLine();
      Console.WriteLine("Deleting existing lists");
      DeleteList("Products");
      DeleteList("Product Proposals");
      DeleteList("Product Plans");


      // delete existing content types
      Console.WriteLine();
      Console.WriteLine("Deleting existing content types");
      DeleteContentType("Product");
      DeleteContentType("Product Proposal");


      clientContext.ExecuteQuery();

      Console.WriteLine();
      Console.WriteLine("Creating content types");
    }

    static void CreateWingtipSiteColumns() {
      Console.WriteLine();
      Console.WriteLine("Creating site columns");

      fieldProductCode = CreateSiteColumn("ProductCode", "Product Code", "Text");
      fieldProductCode.EnforceUniqueValues = true;
      fieldProductCode.Indexed = true;
      fieldProductCode.Required = true;
      fieldProductCode.Update();
      clientContext.ExecuteQuery();
      clientContext.Load(fieldProductCode);
      clientContext.ExecuteQuery();

      fieldProductListPrice = clientContext.CastTo<FieldCurrency>(CreateSiteColumn("ProductListPrice", "List Price", "Currency"));

      fieldProductCategory = clientContext.CastTo<FieldChoice>(CreateSiteColumn("ProductCategory", "Product Category", "Choice"));
      string[] choicesProductCategory = { "Action Figures", "Arts and Crafts", "Vehicles and Remote Control" };
      fieldProductCategory.Choices = choicesProductCategory;
      fieldProductCategory.Update();
      clientContext.ExecuteQuery();

      fieldProductColor = clientContext.CastTo<FieldChoice>(CreateSiteColumn("ProductColor", "Product Color", "Choice"));
      string[] choicesProductColor = { "White", "Black", "Grey", "Blue", "Red", "Green", "Yellow" };
      fieldProductColor.Choices = choicesProductColor;
      fieldProductColor.Update();
      clientContext.ExecuteQuery();

      fieldMinimumAge = clientContext.CastTo<FieldNumber>(CreateSiteColumn("MinimumAge", "Minimum Age", "Number"));

      fieldMaximumAge = clientContext.CastTo<FieldNumber>(CreateSiteColumn("MaximumAge", "Maximum Age", "Number"));

    }

    static void CreateWingtipContentTypes() {
      
      ctypeProduct = CreateContentType("Product", "0x01");

      // add site columns
      FieldLinkCreationInformation fieldLinkProductCode = new FieldLinkCreationInformation();
      fieldLinkProductCode.Field = fieldProductCode;
      ctypeProduct.FieldLinks.Add(fieldLinkProductCode);
      ctypeProduct.Update(true);

      FieldLinkCreationInformation fieldLinkProductListPrice = new FieldLinkCreationInformation();
      fieldLinkProductListPrice.Field = fieldProductListPrice;
      ctypeProduct.FieldLinks.Add(fieldLinkProductListPrice);
      ctypeProduct.Update(true);

      FieldLinkCreationInformation fieldLinkProductCategory = new FieldLinkCreationInformation();
      fieldLinkProductCategory.Field = fieldProductCategory;
      ctypeProduct.FieldLinks.Add(fieldLinkProductCategory);
      ctypeProduct.Update(true);

      FieldLinkCreationInformation fieldLinkProductColor = new FieldLinkCreationInformation();
      fieldLinkProductColor.Field = fieldProductColor;
      ctypeProduct.FieldLinks.Add(fieldLinkProductColor);
      ctypeProduct.Update(true);

      FieldLinkCreationInformation fieldLinkMinimumAge = new FieldLinkCreationInformation();
      fieldLinkMinimumAge.Field = fieldMinimumAge;
      ctypeProduct.FieldLinks.Add(fieldLinkMinimumAge);
      ctypeProduct.Update(true);

      FieldLinkCreationInformation fieldLinkMaximumAge = new FieldLinkCreationInformation();
      fieldLinkMaximumAge.Field = fieldMaximumAge;
      ctypeProduct.FieldLinks.Add(fieldLinkMaximumAge);
      ctypeProduct.Update(true);
      clientContext.ExecuteQuery();


      Console.WriteLine("Create Product Proposal content type");
      ctypeProductProposal = CreateContentType("Product Proposal", "0x0101");
      clientContext.Load(ctypeProductProposal);
      clientContext.ExecuteQuery();

      Console.WriteLine("Create Product Proposal folder in _cts folder");
      ListItemCreationInformation folder = new ListItemCreationInformation();
      site.RootFolder.Folders.Add("_cts/Product Proposal");
      clientContext.ExecuteQuery();

      Console.WriteLine("Update doc template file for content type");
      FileCreationInformation newFile = new FileCreationInformation();
      newFile.Content = System.IO.File.ReadAllBytes(studentFolder + @"Modules\DocumentLibraries\Lab\DocumentTemplates\WingtipProductProposal.dotx");
      newFile.Url = @"_cts/Product Proposal/WingtipProductProposal.dotx";
      newFile.Overwrite = true;
      Microsoft.SharePoint.Client.File uploadFile = site.RootFolder.Files.Add(newFile);
      clientContext.Load(uploadFile);
      clientContext.ExecuteQuery();


      Console.WriteLine("Assign doc template url to content type");
      ctypeProductProposal.DocumentTemplate =  siteUrl +  @"/_cts/Product Proposal/WingtipProductProposal.dotx";
      ctypeProductProposal.Update(true);
      clientContext.ExecuteQuery();

    }

    static void CreateWingtipLists() {



      ListCreationInformation listInformationProducts = new ListCreationInformation();
      listInformationProducts.Title = "Products";
      listInformationProducts.Url = "Lists/Products";
      listInformationProducts.QuickLaunchOption = QuickLaunchOptions.On;
      listInformationProducts.TemplateType = (int)ListTemplateType.GenericList;
      List listProducts = site.Lists.Add(listInformationProducts);

      clientContext.Load(listProducts);
      clientContext.Load(listProducts.ContentTypes);
      clientContext.ExecuteQuery();

      listProducts.ContentTypesEnabled = true;
      listProducts.ContentTypes.AddExistingContentType(ctypeProduct);
      ContentType existing = listProducts.ContentTypes[0]; ;
      existing.DeleteObject();
      listProducts.Update();
      clientContext.ExecuteQuery();


      View viewProducts = listProducts.DefaultView;
      viewProducts.ViewFields.Add("ProductCode");
      viewProducts.ViewFields.Add("ProductListPrice");
       viewProducts.ViewFields.Add("ProductColor");
      //viewProducts.ViewFields.Add("MinimumAge");
      //viewProducts.ViewFields.Add("MaximumAge");
      viewProducts.Update();

      clientContext.ExecuteQuery();


      string fieldXML = @"<Field 
                            Type=""Calculated""
                            Name=""AgeRange""
                            DisplayName=""Age Range"" 
                            EnforceUniqueValues=""FALSE"" 
                            Indexed=""FALSE"" 
                            ResultType=""Text"" > 
                            <Formula>=IF(AND(ISBLANK([Minimum Age]),ISBLANK([Maximum Age])),&quot;All ages&quot;,IF(ISBLANK([Maximum Age]),&quot;Ages &quot;&amp;[Minimum Age]&amp;&quot; and older&quot;,IF(ISBLANK([Minimum Age]),&quot;Ages &quot;&amp;[Maximum Age]&amp;&quot; and younger&quot;,&quot;Ages &quot;&amp;[Minimum Age]&amp;&quot; to &quot;&amp;[Maximum Age])))</Formula>
                            <FieldRefs>
                              <FieldRef Name=""MinimumAge""/>
                              <FieldRef Name=""MaximumAge""/>
                            </FieldRefs>
                          </Field>";

      listProducts.Fields.AddFieldAsXml(fieldXML, true, AddFieldOptions.DefaultValue);
      clientContext.ExecuteQuery();

      viewProducts.ViewFields.Add("ProductCategory");
      viewProducts.Update();
      clientContext.ExecuteQuery();

      Console.WriteLine();
      Console.WriteLine("Wingtip types have been created");

      // add a few sample products
      ListItem product1 = listProducts.AddItem(new ListItemCreationInformation());
      product1["Title"] = "Batman Action Figure";
      product1["ProductCode"] = "WP0001";
      product1["ProductListPrice"] = 14.95;
      product1["ProductCategory"] = "Action Figures";
      product1["ProductColor"] = "Black";
      product1["MinimumAge"] = 7;
      product1["MaximumAge"] = 12;
      product1.Update();
      clientContext.ExecuteQuery();


      ListItem product2 = listProducts.AddItem(new ListItemCreationInformation());
      product2["Title"] = "Captain America Action Figure";
      product2["ProductCode"] = "WP0002";
      product2["ProductListPrice"] = 12.95;
      product2["ProductCategory"] = "Action Figures";
      product2["ProductColor"] = "Blue";
      product2["MinimumAge"] = 7;
      product2["MaximumAge"] = 12;
      product2.Update();
      clientContext.ExecuteQuery();

      ListItem product3 = listProducts.AddItem(new ListItemCreationInformation());
      product3["Title"] = "GI Joe Action Figure";
      product3["ProductCode"] = "WP0003";
      product3["ProductListPrice"] = 14.95;
      product3["ProductCategory"] = "Action Figures";
      product3["ProductColor"] = "Green";
      product3["MinimumAge"] = 7;
      product3["MaximumAge"] = null;
      product3.Update();
      clientContext.ExecuteQuery();

      ListItem product4 = listProducts.AddItem(new ListItemCreationInformation());
      product4["Title"] = "Green Hulk Action Figure";
      product4["ProductCode"] = "WP0004";
      product4["ProductListPrice"] = 9.99;
      product4["ProductCategory"] = "Action Figures";
      product4["ProductColor"] = "Green";
      product4["MinimumAge"] = 7;
      product4["MaximumAge"] = 12;
      product4.Update();
      clientContext.ExecuteQuery();

      ListItem product5 = listProducts.AddItem(new ListItemCreationInformation());
      product5["Title"] = "Red Hulk Alter Ego Action Figure";
      product5["ProductCode"] = "WP0005";
      product5["ProductListPrice"] = 9.99;
      product5["ProductCategory"] = "Action Figures";
      product5["ProductColor"] = "Red";
      product5["MinimumAge"] = 7;
      product5["MaximumAge"] = 12;
      product5.Update();
      clientContext.ExecuteQuery();

      ListItem product6 = listProducts.AddItem(new ListItemCreationInformation());
      product6["Title"] = "Godzilla Action Figure";
      product6["ProductCode"] = "WP0006";
      product6["ProductListPrice"] = 19.95;
      product6["ProductCategory"] = "Action Figures";
      product6["ProductColor"] = "Green";
      product6["MinimumAge"] = 10;
      product6["MaximumAge"] = null;
      product6.Update();
      clientContext.ExecuteQuery();

      ListItem product7 = listProducts.AddItem(new ListItemCreationInformation());
      product7["Title"] = "Perry the Platypus Action Figure";
      product7["ProductCode"] = "WP0007";
      product7["ProductListPrice"] = 21.95;
      product7["ProductCategory"] = "Action Figures";
      product7["ProductColor"] = "Green";
      product7["MinimumAge"] = 10;
      product7["MaximumAge"] = null;
      product7.Update();
      clientContext.ExecuteQuery();

      ListItem product8 = listProducts.AddItem(new ListItemCreationInformation());
      product8["Title"] = "Green Angry Bird Action Figure";
      product8["ProductCode"] = "WP0008";
      product8["ProductListPrice"] = 4.95;
      product8["ProductCategory"] = "Action Figures";
      product8["ProductColor"] = "Green";
      product8["MinimumAge"] = 5;
      product8["MaximumAge"] = 10;
      product8.Update();
      clientContext.ExecuteQuery();

      ListItem product9 = listProducts.AddItem(new ListItemCreationInformation());
      product9["Title"] = "Red Angry Bird Action Figure";
      product9["ProductCode"] = "WP0009";
      product9["ProductListPrice"] = 14.95;
      product9["ProductCategory"] = "Action Figures";
      product9["ProductColor"] = "Red";
      product9["MinimumAge"] = 5;
      product9["MaximumAge"] = 10;
      product9.Update();
      clientContext.ExecuteQuery();

      ListItem product10 = listProducts.AddItem(new ListItemCreationInformation());
      product10["Title"] = "Phineas and Ferb Action Figure Set";
      product10["ProductCode"] = "WP0010";
      product10["ProductListPrice"] = 19.95;
      product10["ProductCategory"] = "Action Figures";
      product10["ProductColor"] = "Black";
      product10["MinimumAge"] = 5;
      product10["MaximumAge"] = 51;
      product10.Update();
      clientContext.ExecuteQuery();

      ListItem product11 = listProducts.AddItem(new ListItemCreationInformation());
      product11["Title"] = "Black Power Ranger Action Figure";
      product11["ProductCode"] = "WP0011";
      product11["ProductListPrice"] = 7.50;
      product11["ProductCategory"] = "Action Figures";
      product11["ProductColor"] = "Black";
      product11["MinimumAge"] = 8;
      product11["MaximumAge"] = 12;
      product11.Update();
      clientContext.ExecuteQuery();

      ListItem product12 = listProducts.AddItem(new ListItemCreationInformation());
      product12["Title"] = "Woody Action Figure";
      product12["ProductCode"] = "WP0012";
      product12["ProductListPrice"] = 9.95;
      product12["ProductCategory"] = "Action Figures";
      product12["ProductColor"] = "Blue";
      product12["MinimumAge"] = 8;
      product12["MaximumAge"] = 12;
      product12.Update();
      clientContext.ExecuteQuery();

      ListItem product13 = listProducts.AddItem(new ListItemCreationInformation());
      product13["Title"] = "Spiderman Action Figure";
      product13["ProductCode"] = "WP0013";
      product13["ProductListPrice"] = 12.95;
      product13["ProductCategory"] = "Action Figures";
      product13["ProductColor"] = "Red";
      product13["MinimumAge"] = 8;
      product13["MaximumAge"] = 12;
      product13.Update();
      clientContext.ExecuteQuery();

      ListItem product14 = listProducts.AddItem(new ListItemCreationInformation());
      product14["Title"] = "Twitter Follower Action Figure";
      product14["ProductCode"] = "WP0014";
      product14["ProductListPrice"] = 1.00;
      product14["ProductCategory"] = "Action Figures";
      product14["ProductColor"] = "Yellow";
      product14["MinimumAge"] = 12;
      product14["MaximumAge"] = null;
      product14.Update();
      clientContext.ExecuteQuery();

      ListItem product15 = listProducts.AddItem(new ListItemCreationInformation());
      product15["Title"] = "Crayloa Crayon Set";
      product15["ProductCode"] = "WT0015";
      product15["ProductListPrice"] = 2.49;
      product15["ProductCategory"] = "Arts and Crafts";
      product15["ProductColor"] = "Yellow";
      product15["MinimumAge"] = 10;
      product15["MaximumAge"] = null;
      product15.Update();
      clientContext.ExecuteQuery();

      ListItem product16 = listProducts.AddItem(new ListItemCreationInformation());
      product16["Title"] = "Sponge Bob Coloring Book";
      product16["ProductCode"] = "WP0016";
      product16["ProductListPrice"] = 2.95;
      product16["ProductCategory"] = "Arts and Crafts";
      product16["ProductColor"] = "Yellow";
      product16["MinimumAge"] = 7;
      product16["MaximumAge"] = 12;
      product16.Update();
      clientContext.ExecuteQuery();

      ListItem product17 = listProducts.AddItem(new ListItemCreationInformation());
      product17["Title"] = "Easel with Supply Trays";
      product17["ProductCode"] = "WP0017";
      product17["ProductListPrice"] = 49.95;
      product17["ProductCategory"] = "Arts and Crafts";
      product17["ProductColor"] = "White";
      product17["MinimumAge"] = 12;
      product17["MaximumAge"] = null;
      product17.Update();
      clientContext.ExecuteQuery();

      ListItem product18 = listProducts.AddItem(new ListItemCreationInformation());
      product18["Title"] = "Crate o' Crayons";
      product18["ProductCode"] = "WP0018";
      product18["ProductListPrice"] = 14.95;
      product18["ProductCategory"] = "Arts and Crafts";
      product18["ProductColor"] = "White";
      product18["MinimumAge"] = 7;
      product18["MaximumAge"] = 12;
      product18.Update();
      clientContext.ExecuteQuery();

      ListItem product19 = listProducts.AddItem(new ListItemCreationInformation());
      product19["Title"] = "Etch A Sketch";
      product19["ProductCode"] = "WP0019";
      product19["ProductListPrice"] = 12.95;
      product19["ProductCategory"] = "Arts and Crafts";
      product19["ProductColor"] = "Red";
      product19["MinimumAge"] = 7;
      product19["MaximumAge"] = null;
      product19.Update();
      clientContext.ExecuteQuery();

      ListItem product20 = listProducts.AddItem(new ListItemCreationInformation());
      product20["Title"] = "Green Hornet";
      product20["ProductCode"] = "WP0020";
      product20["ProductListPrice"] = 24.95;
      product20["ProductCategory"] = "Vehicles and Remote Control";
      product20["ProductColor"] = "Green";
      product20["MinimumAge"] = 10;
      product20["MaximumAge"] = null;
      product20.Update();
      clientContext.ExecuteQuery();

      ListItem product21 = listProducts.AddItem(new ListItemCreationInformation());
      product21["Title"] = "Red Wacky Stud Bumper";
      product21["ProductCode"] = "WP0021";
      product21["ProductListPrice"] = 24.95;
      product21["ProductCategory"] = "Vehicles and Remote Control";
      product21["ProductColor"] = "Red";
      product21["MinimumAge"] = 10;
      product21["MaximumAge"] = null;
      product21.Update();
      clientContext.ExecuteQuery();

      ListItem product22 = listProducts.AddItem(new ListItemCreationInformation());
      product22["Title"] = "Red Stomper Bully";
      product22["ProductCode"] = "WP0022";
      product22["ProductListPrice"] = 29.95;
      product22["ProductCategory"] = "Vehicles and Remote Control";
      product22["ProductColor"] = "Red";
      product22["MinimumAge"] = 10;
      product22["MaximumAge"] = null;
      product22.Update();
      clientContext.ExecuteQuery();

      ListItem product23 = listProducts.AddItem(new ListItemCreationInformation());
      product23["Title"] = "Green Stomper Bully";
      product23["ProductCode"] = "WP0023";
      product23["ProductListPrice"] = 24.95;
      product23["ProductCategory"] = "Vehicles and Remote Control";
      product23["ProductColor"] = "Green";
      product23["MinimumAge"] = 10;
      product23["MaximumAge"] = null;
      product23.Update();
      clientContext.ExecuteQuery();

      ListItem product24 = listProducts.AddItem(new ListItemCreationInformation());
      product24["Title"] = "Indy Race Car";
      product24["ProductCode"] = "WP0024";
      product24["ProductListPrice"] = 19.95;
      product24["ProductCategory"] = "Vehicles and Remote Control";
      product24["ProductColor"] = "Black";
      product24["MinimumAge"] = 10;
      product24["MaximumAge"] = null;
      product24.Update();
      clientContext.ExecuteQuery();

      ListItem product25 = listProducts.AddItem(new ListItemCreationInformation());
      product25["Title"] = "Drug Kingpin Speedboat";
      product25["ProductCode"] = "WP0025";
      product25["ProductListPrice"] = 32.95;
      product25["ProductCategory"] = "Vehicles and Remote Control";
      product25["ProductColor"] = "Red";
      product25["MinimumAge"] = 21;
      product25["MaximumAge"] = null;
      product25.Update();
      clientContext.ExecuteQuery();

      ListItem product26 = listProducts.AddItem(new ListItemCreationInformation());
      product26["Title"] = "Sandpiper Prop Plane";
      product26["ProductCode"] = "WP0026";
      product26["ProductListPrice"] = 24.95;
      product26["ProductCategory"] = "Vehicles and Remote Control";
      product26["ProductColor"] = "White";
      product26["MinimumAge"] = 15;
      product26["MaximumAge"] = null;
      product26.Update();
      clientContext.ExecuteQuery();

      ListItem product27 = listProducts.AddItem(new ListItemCreationInformation());
      product27["Title"] = "Flying Badger";
      product27["ProductCode"] = "WP0027";
      product27["ProductListPrice"] = 27.95;
      product27["ProductCategory"] = "Vehicles and Remote Control";
      product27["ProductColor"] = "Blue";
      product27["MinimumAge"] = 15;
      product27["MaximumAge"] = null;
      product27.Update();
      clientContext.ExecuteQuery();

      ListItem product28 = listProducts.AddItem(new ListItemCreationInformation());
      product28["Title"] = "Red Barron von Richthofen";
      product28["ProductCode"] = "WP0028";
      product28["ProductListPrice"] = 32.95;
      product28["ProductCategory"] = "Vehicles and Remote Control";
      product28["ProductColor"] = "Red";
      product28["MinimumAge"] = 15;
      product28["MaximumAge"] = null;
      product28.Update();
      clientContext.ExecuteQuery();

      ListItem product29 = listProducts.AddItem(new ListItemCreationInformation());
      product29["Title"] = "Fly Squirrel";
      product29["ProductCode"] = "WP0029";
      product29["ProductListPrice"] = 69.95;
      product29["ProductCategory"] = "Vehicles and Remote Control";
      product29["ProductColor"] = "Grey";
      product29["MinimumAge"] = 18;
      product29["MaximumAge"] = null;
      product29.Update();
      clientContext.ExecuteQuery();

      ListItem product30 = listProducts.AddItem(new ListItemCreationInformation());
      product30["Title"] = "FOX News Chopper";
      product30["ProductCode"] = "WP0030";
      product30["ProductListPrice"] = 29.95;
      product30["ProductCategory"] = "Vehicles and Remote Control";
      product30["ProductColor"] = "Blue";
      product30["MinimumAge"] = 18;
      product30["MaximumAge"] = null;
      product30.Update();
      clientContext.ExecuteQuery();

      ListItem product31 = listProducts.AddItem(new ListItemCreationInformation());
      product31["Title"] = "Seal Team 6 Helicopter";
      product31["ProductCode"] = "WP0031";
      product31["ProductListPrice"] = 59.95;
      product31["ProductCategory"] = "Vehicles and Remote Control";
      product31["ProductColor"] = "Green";
      product31["MinimumAge"] = 18;
      product31["MaximumAge"] = null;
      product31.Update();
      clientContext.ExecuteQuery();

      ListItem product32 = listProducts.AddItem(new ListItemCreationInformation());
      product32["Title"] = "Personal Commuter Chopper";
      product32["ProductCode"] = "WP0032";
      product32["ProductListPrice"] = 99.95;
      product32["ProductCategory"] = "Vehicles and Remote Control";
      product32["ProductColor"] = "Red";
      product32["MinimumAge"] = 18;
      product32["MaximumAge"] = null;
      product32.Update();
      clientContext.ExecuteQuery(); 




      Console.WriteLine("Create doc lib to use content typecontent type");
      ListCreationInformation libraryInformationProductProposals = new ListCreationInformation();
      libraryInformationProductProposals.Title = "Product Proposals";
      libraryInformationProductProposals.Url = "ProductProposals";
      libraryInformationProductProposals.QuickLaunchOption = QuickLaunchOptions.On;
      libraryInformationProductProposals.TemplateType = (int)ListTemplateType.DocumentLibrary;
      List libraryProductProposals = site.Lists.Add(libraryInformationProductProposals);

      clientContext.Load(libraryProductProposals);
      clientContext.Load(libraryProductProposals.ContentTypes);
      clientContext.ExecuteQuery();

      libraryProductProposals.ContentTypesEnabled = true;
      libraryProductProposals.ContentTypes.AddExistingContentType(ctypeProductProposal);
      libraryProductProposals.ContentTypes[0].DeleteObject();
      libraryProductProposals.Update();
      clientContext.ExecuteQuery();

      ListCreationInformation libraryInformationProductPlans = new ListCreationInformation();
      libraryInformationProductPlans.Title = "Product Plans";
      libraryInformationProductPlans.Url = "ProductPlans";
      libraryInformationProductPlans.QuickLaunchOption = QuickLaunchOptions.On;
      libraryInformationProductPlans.TemplateType = (int)ListTemplateType.DocumentLibrary;
      List libraryProductPlans = site.Lists.Add(libraryInformationProductPlans);

      clientContext.Load(libraryProductPlans);
      clientContext.Load(libraryProductPlans.ContentTypes);
      clientContext.ExecuteQuery();

      libraryProductPlans.ContentTypesEnabled = true;
      ContentType ctypeDocumentSet = site.ContentTypes.GetById("0x0120D520");
      libraryProductPlans.ContentTypes.AddExistingContentType(ctypeDocumentSet);
      libraryProductPlans.ContentTypes[0].DeleteObject();
      libraryProductPlans.Update();
      clientContext.ExecuteQuery();

    }
  
  }
}
