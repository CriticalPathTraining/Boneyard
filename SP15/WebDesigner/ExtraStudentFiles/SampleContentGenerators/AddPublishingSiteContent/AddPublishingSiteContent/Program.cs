using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using SystemIO = System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Publishing;
using Microsoft.SharePoint.Client.Publishing.Navigation;
using Microsoft.SharePoint.Client.Taxonomy;
using Microsoft.SharePoint.Client.WebParts;

namespace AddPublishingSiteContent {
  class Program {

    static string siteUrl = ConfigurationManager.AppSettings["targetSiteUrl"];
    static ClientContext clientContext;
    static Web TopSite;
    static PublishingWeb TopPublishingSite;
    static List MasterPageGallery;
    static List TopSitePagesLibrary;
    static ListItemCollection TopSitePublishingPages;
    static ListItem BankWebPartPageLayout;
    static ListItem ArticleLeftLayout;
    static ListItem ArticleRightLayout;
    static ListItem ArticleLinksLayout;

    static TaxonomySession CurrentTaxonomySession;
    static TermStore CurrentTermStore;
    static Guid TermStoreID;
    static TermGroup LocalTermGroup;
    static TermSet SiteTermSet;
    static NavigationTermSet SiteNavigationTermSet;

    static void Main() {

      Console.WriteLine("Creating Sample Content in Publishing Site");
      Console.WriteLine();

      clientContext = new ClientContext(siteUrl);

      TopSite = clientContext.Web;
      clientContext.Load(TopSite);
      clientContext.ExecuteQuery();

      TopPublishingSite = PublishingWeb.GetPublishingWeb(clientContext, TopSite);

      WebNavigationSettings navsettings = new WebNavigationSettings(clientContext, TopSite);
      navsettings.GlobalNavigation.Source = StandardNavigationSource.TaxonomyProvider;
      navsettings.CurrentNavigation.Source = StandardNavigationSource.PortalProvider;
      navsettings.Update(CurrentTaxonomySession);

      TopSite.AllProperties["__CurrentNavigationIncludeTypes"] = "3";
      TopSite.Update();
      clientContext.ExecuteQuery();

      TopSitePagesLibrary = TopSite.Lists.GetByTitle("Pages");
      TopSitePublishingPages = TopSitePagesLibrary.GetItems(CamlQuery.CreateAllItemsQuery());

      MasterPageGallery = TopSite.Lists.GetByTitle("Master Page Gallery");

      InitializePageLayouts();

      InitializeLocalTermset();

      UpdatePublishingPage("default.aspx", "Wingtip Toys", Properties.Resources.Home, true);
      CreateFriendlyURL("Home", "", "/Pages/default.aspx");

      PublishingWeb ProductsSite = CreatePublishingSite("Products", "Products");
      NavigationTerm ProductsNavTerm = CreateFriendlyURL("Wingtip Products", "wingtip-products", "/Products/Pages/default.aspx");
      UpdatePublishingPage(ProductsSite, "default.aspx", "Wingtip Product Catalog", Properties.Resources.Products, true);
      CreatePublishingPage(ProductsSite, "actionfigures.aspx", "Action Figures", "Action Figures", ArticleLeftLayout, Properties.Resources.GenericPageFull, false);
      CreateFriendlyURL(ProductsNavTerm, "Action Figures", "action-figures", "/Products/Pages/actionfigures.aspx");
      CreatePublishingPage(ProductsSite, "artsandcrafts.aspx", "Arts and Crafts", "Arts and Crafts", ArticleLeftLayout, Properties.Resources.GenericPageFull, false);
      CreateFriendlyURL(ProductsNavTerm, "Arts and Crafts", "arts-and-crafts", "/Products/Pages/artsandcrafts.aspx");
      CreatePublishingPage(ProductsSite, "vehicles.aspx", "Vehicles and RC", "Vehicles and RC", ArticleLeftLayout, Properties.Resources.GenericPageFull, false);
      CreateFriendlyURL(ProductsNavTerm, "Vehicles and RC", "vehicles-and-rc", "/Products/Pages/Vehicles.aspx");   

      PublishingWeb LocationsSite = CreatePublishingSite("Locations", "Locations");
      NavigationTerm LocationsNavTerm = CreateFriendlyURL("Store Locations", "store-locations", "/Locations/Pages/default.aspx");
      UpdatePublishingPage(LocationsSite, "default.aspx", "Wingtip Store Locations", Properties.Resources.Locations, true);
      CreatePublishingPage(LocationsSite, "tampa.aspx", "Tampa, FL", "Tampa, FL", ArticleLeftLayout, Properties.Resources.GenericPageFull, false);
      CreateFriendlyURL(LocationsNavTerm, "Tampa, FL", "tampa", "/Locations/Pages/tampa.aspx");   
      CreatePublishingPage(LocationsSite, "orlando.aspx", "Orlando, FL", "Orlando, FL", ArticleLeftLayout, Properties.Resources.GenericPageFull, false);
      CreateFriendlyURL(LocationsNavTerm, "Orlando, FL", "orlando", "/Locations/Pages/orlando.aspx");
      CreatePublishingPage(LocationsSite, "austin.aspx", "Austin, TX", "Austin, TX", ArticleLeftLayout, Properties.Resources.GenericPageFull, false);
      CreateFriendlyURL(LocationsNavTerm, "Austin, FL", "austin", "/Locations/Pages/Austin.aspx");   
      


    //  CreatePublishingPage("company.aspx", "Company", "Company Background", ArticleLeftLayout, Properties.Resources.Company);
      CreatePublishingPage("contact.aspx", "Contact", "Contact Information", ArticleLeftLayout, Properties.Resources.Contact);
      CreatePublishingPage("about.aspx", "About", "About Wingtip Toys", ArticleLeftLayout, Properties.Resources.About);
    

      // Create a publishing page

    }

    static void InitializePageLayouts() {

      var PageLayouts = MasterPageGallery.GetItems(CamlQuery.CreateAllItemsQuery());
      clientContext.Load(PageLayouts, layouts => layouts.Where(layout => layout.ContentType.Name == "Page Layout")
                                                        .Include(layout => layout.DisplayName));
      clientContext.ExecuteQuery();

      foreach (var layout in PageLayouts) {

        if (layout.DisplayName.Equals("BankWebPartPage")) {
          BankWebPartPageLayout = layout;
          clientContext.Load(BankWebPartPageLayout);
        };

        if (layout.DisplayName.Equals("ArticleLeft")) {
          ArticleLeftLayout = layout;
          clientContext.Load(ArticleLeftLayout);
        };

        if (layout.DisplayName.Equals("ArticleRight")) {
          ArticleRightLayout = layout;
          clientContext.Load(ArticleRightLayout);
        };

        if (layout.DisplayName.Equals("ArticleLinks")) {
          ArticleLinksLayout = layout;
          clientContext.Load(ArticleLinksLayout);
        };

      }
      clientContext.ExecuteQuery();

    }

    static void InitializeLocalTermset() {

      CurrentTaxonomySession = TaxonomySession.GetTaxonomySession(clientContext);
      CurrentTaxonomySession.UpdateCache();

      clientContext.Load(CurrentTaxonomySession, ts => ts.TermStores);
      clientContext.ExecuteQuery();

      CurrentTermStore = CurrentTaxonomySession.TermStores.FirstOrDefault<TermStore>();
      clientContext.ExecuteQuery();

      TermStoreID = CurrentTermStore.Id;
      LocalTermGroup = CurrentTermStore.GetSiteCollectionGroup(clientContext.Site, true);
      clientContext.Load(LocalTermGroup);
      TermSetCollection LocalTermSets = LocalTermGroup.TermSets;
      clientContext.Load(LocalTermSets);
      clientContext.ExecuteQuery();

      foreach (var ts in LocalTermSets) {
        if (ts.Name == "Site Navigation") {
          SiteTermSet = ts;
          clientContext.Load(SiteTermSet);
          clientContext.Load(SiteTermSet.Terms);
          clientContext.ExecuteQuery();
        }
      }

      if (SiteTermSet == null) {
        throw new ApplicationException("aint no nav term set");
      }

      DeleteAllTerms();

      //clientContext.Load(SiteTermSet);
      //clientContext.Load(SiteTermSet.Terms);
      //clientContext.ExecuteQuery();


      SiteNavigationTermSet = NavigationTermSet.GetAsResolvedByWeb(clientContext, SiteTermSet, TopSite, "GlobalNavigationTaxonomyProvider");
      SiteNavigationTermSet.IsNavigationTermSet = true;
      SiteNavigationTermSet.TargetUrlForChildTerms.Value = "~site/Pages/default.aspx";
      TopSite.Update();
      CurrentTermStore.CommitAll();
      clientContext.Load(SiteNavigationTermSet);
      clientContext.ExecuteQuery();


    }

    static void DeleteAllTerms() {
      foreach (var term in SiteTermSet.Terms) {
        term.DeleteObject();
      }
      CurrentTermStore.CommitAll();
      clientContext.ExecuteQuery();

    }

    static void CreateSimpleLink(string TermName, string TargetURL) {
      NavigationTerm navterm = SiteNavigationTermSet.CreateTerm(TermName, NavigationLinkType.SimpleLink, Guid.NewGuid());
      navterm.SimpleLinkUrl = TargetURL;
      navterm.ExcludeFromCurrentNavigation = true;
      CurrentTermStore.CommitAll();
      clientContext.ExecuteQuery();
    }

    static NavigationTerm CreateFriendlyURL(string TermName, string FriendlyURL, string TargetURL) {
      return CreateFriendlyURL(SiteNavigationTermSet, TermName, FriendlyURL, TargetURL);
    }

    static NavigationTerm CreateFriendlyURL(NavigationTermSetItem ParentTerm, string TermName, string FriendlyURL, string TargetURL) {
      NavigationTerm navterm = ParentTerm.CreateTerm(TermName, NavigationLinkType.FriendlyUrl, Guid.NewGuid());
      navterm.FriendlyUrlSegment.Value = FriendlyURL;
      navterm.TargetUrl.Value = TargetURL;
      navterm.ExcludeFromCurrentNavigation = true;
      CurrentTermStore.CommitAll();
      clientContext.ExecuteQuery();
      return navterm;
    }

    static void UpdatePublishingPage(string PageName, string PageTitle, string PageContent, bool DeleteWebParts) {
      UpdatePublishingPage(TopPublishingSite, PageName, PageTitle, PageContent, DeleteWebParts);
    }
    static void UpdatePublishingPage(PublishingWeb TargetPublishingWeb, string PageName, string PageTitle, string PageContent, bool DeleteWebParts) {

      PublishingWeb LocalPublishingWeb = TargetPublishingWeb;
      Web LocalWeb = LocalPublishingWeb.Web;
      List LocalPagesLibrary = LocalWeb.Lists.GetByTitle("Pages");
      ListItemCollection LocalPublishingPages = LocalPagesLibrary.GetItems(CamlQuery.CreateAllItemsQuery());

      File targetPage = LocalPagesLibrary.RootFolder.Files.GetByUrl(PageName);
      ListItem publishingPage = targetPage.ListItemAllFields;
      clientContext.Load(publishingPage.File, file => file.CheckOutType);
      clientContext.ExecuteQuery();
      if (publishingPage.File.CheckOutType != CheckOutType.None) {
        publishingPage.File.UndoCheckOut();
      }
      publishingPage.File.CheckOut();
      publishingPage["Title"] = PageTitle;
      publishingPage["PublishingPageContent"] = PageContent;
      publishingPage.Update();

      if (DeleteWebParts) {
        var wpManager = publishingPage.File.GetLimitedWebPartManager(PersonalizationScope.Shared);
        clientContext.Load(wpManager);
        clientContext.Load(wpManager.WebParts);
        clientContext.ExecuteQuery();
        foreach (WebPartDefinition wp in wpManager.WebParts) {
          wp.DeleteWebPart();
        }
        publishingPage.Update();
      }

      publishingPage.File.CheckIn("", CheckinType.MajorCheckIn);
      clientContext.Load(publishingPage);
      clientContext.ExecuteQuery();

    }

    static void CreatePublishingPage(string PageName, string FriendlyUrl, string PageTitle, ListItem PageLayout, string PageContent) {
      CreatePublishingPage(TopPublishingSite, PageName, FriendlyUrl, PageTitle, PageLayout, PageContent, true);
    }

    static void CreatePublishingPage(PublishingWeb TargetPublishingWeb, string PageName, string FriendlyUrl, string PageTitle, ListItem PageLayout, string PageContent, bool CreateFriendlyURL) {

      PublishingWeb LocalPublishingWeb = TargetPublishingWeb;
      Web LocalWeb = LocalPublishingWeb.Web;
      List LocalPagesLibrary = LocalWeb.Lists.GetByTitle("Pages");
      ListItemCollection LocalPublishingPages = LocalPagesLibrary.GetItems(CamlQuery.CreateAllItemsQuery());
    
      // delete file if it already exists
      ExceptionHandlingScope scope = new ExceptionHandlingScope(clientContext);
      using (scope.StartScope()) {
        using (scope.StartTry()) {
          //TargetWeb.Web.Lists
          File currentPage = LocalPagesLibrary.RootFolder.Files.GetByUrl(PageName);
          currentPage.DeleteObject();
        }
        using (scope.StartCatch()) { }
      }

      clientContext.ExecuteQuery();

      PublishingPageInformation publishingPageInfo = new PublishingPageInformation();
      publishingPageInfo.Name = PageName;
      publishingPageInfo.PageLayoutListItem = PageLayout;
      PublishingPage publishingPage = LocalPublishingWeb.AddPublishingPage(publishingPageInfo);
      clientContext.ExecuteQuery();
      if (CreateFriendlyURL) {
        publishingPage.AddFriendlyUrl(FriendlyUrl, SiteNavigationTermSet, true);
      }
      publishingPage.ListItem["Title"] = PageTitle;
      publishingPage.ListItem["PublishingPageContent"] = PageContent;
      publishingPage.ListItem.Update();
      publishingPage.ListItem.File.CheckIn("", CheckinType.MajorCheckIn);
      clientContext.ExecuteQuery();

    }

    static PublishingWeb CreatePublishingSite(string SiteTitle, string SiteUrl) {

      // delete TopSite if it already exists
      ExceptionHandlingScope scope = new ExceptionHandlingScope(clientContext);
      using (scope.StartScope()) {
        using (scope.StartTry()) {
          Web currentSite = clientContext.Site.OpenWeb(SiteUrl);
          currentSite.DeleteObject();
        }
        using (scope.StartCatch()) { }
      }

      clientContext.ExecuteQuery();

      var webCI = new WebCreationInformation();
      webCI.Title = SiteTitle;
      webCI.Description = "";
      webCI.Url = SiteUrl;
      webCI.WebTemplate = "BLANKINTERNET#0";
      webCI.Language = 1033;
      Web newSite = TopSite.Webs.Add(webCI);
      newSite.ResetRoleInheritance();
      clientContext.Load(newSite, s => s.RootFolder.WelcomePage);
      clientContext.ExecuteQuery();

      File homePage = newSite.GetFileByServerRelativeUrl("/" + SiteUrl + "/" + newSite.RootFolder.WelcomePage);
      homePage.Publish("");
      clientContext.ExecuteQuery();

      PublishingWeb newPubSite = PublishingWeb.GetPublishingWeb(clientContext, newSite);

      WebNavigationSettings navsettings = new WebNavigationSettings(clientContext, newSite);
      navsettings.GlobalNavigation.Source = StandardNavigationSource.InheritFromParentWeb;
      navsettings.CurrentNavigation.Source = StandardNavigationSource.PortalProvider;
      navsettings.Update(CurrentTaxonomySession);

      newSite.AllProperties["__CurrentNavigationIncludeTypes"] = "3";
      newSite.AllProperties["__CurrentDynamicChildLimit"] = "24";
      //newSite.AllProperties["__InheritsMasterUrl"] = "True";
      //newSite.AllProperties["__InheritsCustomMasterUrl"] = "True";
      //newSite.AllProperties["__InheritsAlternateCssUrl"] = "True";
      //newSite.AllProperties["__NavigationShowSiblings"] = "False";
      newSite.Update();
      clientContext.ExecuteQuery();

      return newPubSite;
    }
  }
}
