using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.DocumentSet;
using System.Collections.Specialized;
using System.Xml;

namespace CreateResearchLibraries {

  class Program {

    #region "static fields"
    static string siteUrl = ConfigurationManager.AppSettings["targetSiteUrl"];

    static ClientContext clientContext = new ClientContext(siteUrl);
    static Site siteCollection = clientContext.Site;
    static Web site = clientContext.Web;

    static ContentType ctypeProductProposal;
    static List libraryProductProposals;

    static ContentType ctypeProductPlanStatusReport;

    const string ctypeIdDocumentSet = "0x0120D520";
    static ContentType ctypeProductPlanDocucmentSet;
    
    static List libraryProductPlans;


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

    static void Main() {

      Console.WriteLine();
      Console.WriteLine("------------------------------------------------------");
      Console.WriteLine("---- Applying solution for Document Libraries lab ----");
      Console.WriteLine("------------------------------------------------------");
      Console.WriteLine();

      try {
        clientContext.Load(siteCollection);
        clientContext.Load(site);
        clientContext.Load(site.Fields);
        clientContext.Load(site.ContentTypes);
        clientContext.ExecuteQuery();

        DeleteAllResearchTypes();
        CreateResearchContentTypes();
        CreateProductProposalsLibrary();
        CreateProductPlansLibrary();

        Console.WriteLine("The solution to the Document Library lab has been applied successfully");
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

    static void DeleteAllResearchTypes() {
      DeleteList("Product Proposals");
      DeleteList("Product Plans");
      DeleteContentType("Product Proposal");
      DeleteContentType("Product Plan Document Set");
      DeleteContentType("Product Plan Status Report");
      Console.WriteLine();
    }

    static void CreateResearchContentTypes() {

      Console.WriteLine("Creating Product Proposal content type...");
      ctypeProductProposal = CreateContentType("Product Proposal", "0x0101");

      ListItemCreationInformation folder = new ListItemCreationInformation();
      site.RootFolder.Folders.Add("_cts/Product Proposal");
      clientContext.ExecuteQuery();

      FileCreationInformation newFile = new FileCreationInformation();
      newFile.Content = Properties.Resources.WingtipProductProposal_dotx;
      newFile.Url = @"_cts/Product Proposal/WingtipProductProposal.dotx";
      newFile.Overwrite = true;
      Microsoft.SharePoint.Client.File uploadFile = site.RootFolder.Files.Add(newFile);
      clientContext.Load(uploadFile);
      clientContext.ExecuteQuery();

      ctypeProductProposal.DocumentTemplate = siteUrl + @"/_cts/Product Proposal/WingtipProductProposal.dotx";
      ctypeProductProposal.Update(true);
      clientContext.ExecuteQuery();


      Console.WriteLine("Creating Product Plan Status Report content type...");
      ctypeProductPlanStatusReport = CreateContentType("Product Plan Status Report", "0x0101");

      folder = new ListItemCreationInformation();
      site.RootFolder.Folders.Add("_cts/Product Plan Status Report");
      clientContext.ExecuteQuery();

      newFile = new FileCreationInformation();
      newFile.Content = Properties.Resources.WingtipProductPlanStatusReport_dotx;
      newFile.Url = @"_cts/Product Plan Status Report/WingtipProductPlanStatusReport.dotx";
      newFile.Overwrite = true;
      uploadFile = site.RootFolder.Files.Add(newFile);
      clientContext.Load(uploadFile);
      clientContext.ExecuteQuery();

      ctypeProductPlanStatusReport.DocumentTemplate = siteUrl + @"/_cts/Product Plan Status Report/WingtipProductPlanStatusReport.dotx";
      ctypeProductPlanStatusReport.Update(true);
      clientContext.ExecuteQuery();

      Console.WriteLine("Creating Product Plan Document Set content type...");
      ctypeProductPlanDocucmentSet = CreateContentType("Product Plan Document Set", ctypeIdDocumentSet);
      clientContext.ExecuteQuery();
      
      //// copy files
      FileCreationInformation infoDefaultFile1 = new FileCreationInformation();
      infoDefaultFile1.Content = Properties.Resources.Product_Design_Specification_docx;
      infoDefaultFile1.Url = siteUrl + @"_cts/Product Plan Document Set/Product Design Specification.docx";
      infoDefaultFile1.Overwrite = true;
      uploadFile = site.RootFolder.Files.Add(infoDefaultFile1);
      clientContext.ExecuteQuery();

      FileCreationInformation infoDefaultFile2 = new FileCreationInformation();
      infoDefaultFile2.Content = Properties.Resources.Product_Plan_Schedule_xlsx;
      infoDefaultFile2.Url = siteUrl + @"_cts/Product Plan Document Set/Product Plan Schedule.xlsx";
      infoDefaultFile2.Overwrite = true;
      Microsoft.SharePoint.Client.File uploadFile2 = site.RootFolder.Files.Add(infoDefaultFile2);
      clientContext.ExecuteQuery();

      clientContext.Load(ctypeProductPlanDocucmentSet, ctype => ctype.SchemaXmlWithResourceTokens);
      clientContext.ExecuteQuery();

      XElement elementCTypeSchema = XElement.Parse(ctypeProductPlanDocucmentSet.SchemaXmlWithResourceTokens);

      // add default documents
      XElement elementDefaultDocuments = elementCTypeSchema.Descendants().Single(node => (node.Name == "XmlDocument") &&  (node.FirstAttribute.ToString() == @"NamespaceURI=""http://schemas.microsoft.com/office/documentsets/defaultdocuments"""));
      string xmlDefaultDocuments = @"<dd:DefaultDocuments xmlns:dd='http://schemas.microsoft.com/office/documentsets/defaultdocuments' AddSetName='True' LastModified='01/01/0001'><DefaultDocument name='/Product Design Specification.docx' idContentType='0x0101' /><DefaultDocument name='/Product Plan Schedule.xlsx' idContentType='0x0101' /></dd:DefaultDocuments>";
      elementDefaultDocuments.Value = ConvertToBase64EncodedString(xmlDefaultDocuments);

      // add allowed content types
      XElement elementAllowedContentTypes = elementCTypeSchema.Descendants().Single(node => (node.Name == "XmlDocument") && (node.FirstAttribute.ToString() == @"NamespaceURI=""http://schemas.microsoft.com/office/documentsets/allowedcontenttypes"""));
      string xmlAllowedContentTypes = @"<act:AllowedContentTypes xmlns:act='http://schemas.microsoft.com/office/documentsets/allowedcontenttypes' LastModified='01/01/0001'><AllowedContentType id='0x0101'/><AllowedContentType id='@ctypeTypeIdProductPlanStatusReport'/></act:AllowedContentTypes>";
      clientContext.Load(ctypeProductPlanStatusReport, ct => ct.Id);
      clientContext.ExecuteQuery();
      xmlAllowedContentTypes = xmlAllowedContentTypes.Replace("@ctypeTypeIdProductPlanStatusReport", ctypeProductPlanStatusReport.Id.StringValue);
      elementAllowedContentTypes.Value = ConvertToBase64EncodedString(xmlAllowedContentTypes);



      string xmlSharedFields = @"<sf:SharedFields xmlns:sf='http://schemas.microsoft.com/office/documentsets/sharedfields' LastModified='01/01/0001'><SharedField id='@idProposedProductCode' /></sf:SharedFields>";

      string xmlWelcomePageFields = @"<wpf:WelcomePageFields xmlns:wpf='http://schemas.microsoft.com/office/documentsets/welcomepagefields' LastModified='01/01/0001'><WelcomePageField id='idProposedProductCode' /><WelcomePageField id='idEstimatedCompletionDate' /></wpf:WelcomePageFields>";


      // save the edited schema back into the site
      ctypeProductPlanDocucmentSet.SchemaXmlWithResourceTokens = elementCTypeSchema.ToString(SaveOptions.DisableFormatting);
      ctypeProductPlanDocucmentSet.Update(true);
      clientContext.ExecuteQuery();

    }

    static void CreateProductProposalsLibrary() {

      Console.WriteLine("Creating Product Proposals document library...");

      ListCreationInformation infoProductProposals = new ListCreationInformation();
      infoProductProposals.Title = "Product Proposals";
      infoProductProposals.Url = "ProductProposals";
      infoProductProposals.QuickLaunchOption = QuickLaunchOptions.On;
      infoProductProposals.TemplateType = (int)ListTemplateType.DocumentLibrary;
      libraryProductProposals = site.Lists.Add(infoProductProposals);
      libraryProductProposals.OnQuickLaunch = true;
      libraryProductProposals.EnableVersioning = true;
      libraryProductProposals.Update();

      clientContext.Load(libraryProductProposals);
      clientContext.Load(libraryProductProposals.ContentTypes);
      clientContext.ExecuteQuery();

      libraryProductProposals.ContentTypesEnabled = true;
      libraryProductProposals.ContentTypes.AddExistingContentType(ctypeProductProposal);
      ContentType existing = libraryProductProposals.ContentTypes[0]; ;
      existing.DeleteObject();
      libraryProductProposals.Update();
      clientContext.ExecuteQuery();

      clientContext.ExecuteQuery();

    }

    static void CreateProductPlansLibrary() {
      Console.WriteLine("Creating Product Plans document library...");

      ListCreationInformation infoProductPlans = new ListCreationInformation();
      infoProductPlans.Title = "Product Plans";
      infoProductPlans.Url = "ProductPlans";
      infoProductPlans.QuickLaunchOption = QuickLaunchOptions.On;
      infoProductPlans.TemplateType = (int)ListTemplateType.DocumentLibrary;
      libraryProductPlans = site.Lists.Add(infoProductPlans);
      libraryProductPlans.OnQuickLaunch = true;
      libraryProductPlans.EnableVersioning = true;
      libraryProductPlans.Update();

      clientContext.Load(libraryProductPlans);
      clientContext.Load(libraryProductPlans.ContentTypes);
      clientContext.ExecuteQuery();

      libraryProductPlans.ContentTypesEnabled = true;
      ContentType listTypeDocumentSet = libraryProductPlans.ContentTypes.AddExistingContentType(ctypeProductPlanDocucmentSet);
      ContentType existing = libraryProductPlans.ContentTypes[0]; ;
      existing.DeleteObject();
      libraryProductPlans.Update();
      clientContext.Load(listTypeDocumentSet);
      clientContext.ExecuteQuery();

      Console.WriteLine();

      clientContext.Load(ctypeProductPlanDocucmentSet, ctype => ctype.Id);
      clientContext.ExecuteQuery();

      CreateDocumentSetInstance("Mitt Ronmey Action Figure");
      CreateDocumentSetInstance("Newt Ginrage Action Figure");
      CreateDocumentSetInstance("George Bush Action Figure");
      CreateDocumentSetInstance("Billy Clinton Action Figure");
      CreateDocumentSetInstance("Barack Obama Action Figure");

    }

    static void CreateDocumentSetInstance(string DocumentSetInstanceName) {
      DocumentSet.Create(clientContext, libraryProductPlans.RootFolder, DocumentSetInstanceName, ctypeProductPlanDocucmentSet.Id);
      clientContext.ExecuteQuery();
    }

    public static string ConvertFromBase64EncodedString(string input) {
      Byte[] byteData = Convert.FromBase64String(input);
      return Encoding.ASCII.GetString(byteData);
    }

    public static string ConvertToBase64EncodedString(string input) {
      Byte[] byteData = Encoding.ASCII.GetBytes(input);
      return Convert.ToBase64String(byteData);
    }

  }

}
