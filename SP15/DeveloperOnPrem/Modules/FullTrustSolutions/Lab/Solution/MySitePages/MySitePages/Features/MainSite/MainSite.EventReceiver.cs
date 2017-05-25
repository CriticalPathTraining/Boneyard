using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Navigation;

namespace MySitePages.Features.MainSite {

  [Guid("0b32f860-e767-4b0b-95b4-f8d6645a36d4")]
  public class MainSiteEventReceiver : SPFeatureReceiver {
    public override void FeatureActivated(SPFeatureReceiverProperties properties) {

      SPSite siteCollection = properties.Feature.Parent as SPSite;
      if (siteCollection != null) {
        SPWeb site = siteCollection.RootWeb;
        // create menu items on top link bar for custom site pages
        SPNavigationNodeCollection topNav = site.Navigation.TopNavigationBar;
        topNav.AddAsLast(new SPNavigationNode("Page 1", "WingtipPages/Page1.aspx"));
        topNav.AddAsLast(new SPNavigationNode("Page 2", "WingtipPages/Page2.aspx"));
        topNav.AddAsLast(new SPNavigationNode("Page 3", "WingtipPages/Page3.aspx"));
      }
    }
    public override void FeatureDeactivating(SPFeatureReceiverProperties properties) {
      SPSite siteCollection = properties.Feature.Parent as SPSite;
      if (siteCollection != null) {
        SPWeb site = siteCollection.RootWeb;

        try {
          // delete folder of site pages provisioned during activation
          SPFolder sitePagesFolder = site.GetFolder("WingtipPages");
          sitePagesFolder.Delete();
        }
        catch { }

        SPNavigationNodeCollection topNav = site.Navigation.TopNavigationBar;
        for (int i = topNav.Count - 1; i >= 0; i--) {
          if (topNav[i].Url.Contains("WingtipPages")) {
            // delete node
            topNav[i].Delete();
          }
        }
      }
    }

  }
}
