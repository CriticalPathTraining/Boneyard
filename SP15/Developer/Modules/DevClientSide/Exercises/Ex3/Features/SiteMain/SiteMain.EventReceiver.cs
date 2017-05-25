using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Navigation;

namespace RestLab.Features.SiteMain {
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("4a141b8e-13ee-4fda-8f8d-105c7d915a3e")]
    public class SiteMainEventReceiver : SPFeatureReceiver {
        string[,] LabPages = {      
      { "Exercise 1","LabPages/Exercise01.aspx"},
      { "Exercise 2","LabPages/Exercise02.aspx"},
      { "Exercise 3","LabPages/Exercise03.aspx"},
      { "Exercise 4","LabPages/Exercise04.aspx"}
    };

        string[,] SolutionPages = {      
      { "Solution 1","SolutionPages/Exercise01.aspx"},
      { "Solution 2","SolutionPages/Exercise02.aspx"},
      { "Solution 3","SolutionPages/Exercise03.aspx"},
      { "Solution 4","SolutionPages/Exercise04.aspx"}
    };

        private void DeleteQuickLaunchNodes(SPNavigationNodeCollection quickLaunch) {
            for (int i = quickLaunch.Count - 1; i >= 0; i--) {
                quickLaunch[i].Delete();
            }
        }

        public override void FeatureActivated(SPFeatureReceiverProperties properties) {

            SPSite siteCollection = (SPSite)properties.Feature.Parent;
            SPWeb site = siteCollection.RootWeb;
            SPNavigationNodeCollection quickLaunch = site.Navigation.QuickLaunch;

            // delete existing nodes in QuickLaunch
            DeleteQuickLaunchNodes(quickLaunch);


            SPNavigationNode LabNode = quickLaunch.AddAsLast(new SPNavigationNode("Lab", ""));
            for (int i = LabPages.GetLowerBound(0); i <= LabPages.GetUpperBound(0); i++) {
                LabNode.Children.AddAsLast(new SPNavigationNode(LabPages[i, 0], LabPages[i, 1]));
            }

            SPNavigationNode SolutionNode = quickLaunch.AddAsLast(new SPNavigationNode("Lab Solution", ""));
            for (int i = SolutionPages.GetLowerBound(0); i <= SolutionPages.GetUpperBound(0); i++) {
                SolutionNode.Children.AddAsLast(new SPNavigationNode(SolutionPages[i, 0], SolutionPages[i, 1]));
            }

        }

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties) {
            SPSite siteCollection = (SPSite)properties.Feature.Parent;
            SPWeb site = siteCollection.RootWeb;
            SPNavigationNodeCollection quickLaunch = site.Navigation.QuickLaunch;

            // delete existing nodes in QuickLaunch
            DeleteQuickLaunchNodes(quickLaunch);

        }

    }
}
