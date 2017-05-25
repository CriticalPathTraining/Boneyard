using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;

namespace AnnouncementListEventChecker.Features.Feature1 {
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("766b7185-b896-456d-aef7-0e0ac68d709e")]
    public class Feature1EventReceiver : SPFeatureReceiver {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties) {
            SPWeb site = properties.Feature.Parent as SPWeb;
            if (site == null) { return; }
            SPList list = site.Lists.TryGetList("Company Announcements");
            if (list == null) { return; }

            // attach event to ItemAdding
            var itemAddingEvent = list.EventReceivers.Add();
            itemAddingEvent.Type = SPEventReceiverType.ItemAdding;
            itemAddingEvent.Synchronization = SPEventReceiverSynchronization.Synchronous;
            itemAddingEvent.Assembly = System.Reflection.Assembly.GetExecutingAssembly().FullName;
            itemAddingEvent.Class = "AnnouncementListEventChecker.ContosoAnnReceiver.ContosoAnnReceiver";
            itemAddingEvent.Update();

            // attach event to ItemUpdatinging
            var itemUpdatingEvent = list.EventReceivers.Add();
            itemUpdatingEvent.Type = SPEventReceiverType.ItemUpdating;
            itemUpdatingEvent.Synchronization = SPEventReceiverSynchronization.Synchronous;
            itemUpdatingEvent.Assembly = System.Reflection.Assembly.GetExecutingAssembly().FullName;
            itemUpdatingEvent.Class = "AnnouncementListEventChecker.ContosoAnnReceiver.ContosoAnnReceiver";
            itemUpdatingEvent.Update();
        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        //public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}
