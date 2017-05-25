using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;

namespace ListCreator.Features.Feature1 {
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("a8e7f6dd-dadd-4a46-b0e7-303e8d50d139")]
    public class Feature1EventReceiver : SPFeatureReceiver {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties) {
            SPWeb spWeb = properties.Feature.Parent as SPWeb;

            //Projects List
            Guid pListGuid = spWeb.Lists.Add("Projects", "Company Projects", SPListTemplateType.GenericList);
            spWeb.Update();

            //Projects List columns
            SPList pList = spWeb.Lists[pListGuid];
            pList.OnQuickLaunch = true;
            SPField pTitleIDField = pList.Fields["Title"];
            FixupField(pList, pList.Fields.Add("Description", SPFieldType.Text, false));
            FixupField(pList, pList.Fields.Add("Due Date", SPFieldType.DateTime, false));
            SPFieldDateTime dueDateField = pList.Fields["Due Date"] as SPFieldDateTime;
            dueDateField.DisplayFormat = SPDateTimeFieldFormatType.DateOnly;

            dueDateField.Update();
            pList.Update();

            // Employees List
            Guid eListGuid = spWeb.Lists.Add("Employees", "Employees", SPListTemplateType.GenericList);
            spWeb.Update();

            // Employees List columns
            SPList eList = spWeb.Lists[eListGuid];
            eList.OnQuickLaunch = true;
            SPField titleIDField = eList.Fields["Title"];
            titleIDField.Title = "Fullname";
            titleIDField.Update();

            FixupField(eList, eList.Fields.Add("JobTitle", SPFieldType.Text, false));
            FixupField(eList, eList.Fields.Add("Team", SPFieldType.Text, false));
            FixupField(eList, eList.Fields.Add("Contribution (in Milestones)", SPFieldType.Number, false));

            string projectFieldInternalName = eList.Fields.AddLookup("Project", pListGuid, false);
            SPFieldLookup projectField = eList.Fields.GetFieldByInternalName(projectFieldInternalName) as SPFieldLookup;
            projectField.LookupField = pTitleIDField.InternalName;
            FixupField(projectField);
            eList.Update();

            // Project Manager field (Project to Employee lookup)
            string employeeFieldInternalName = pList.Fields.AddLookup("Primary Contact", eListGuid, false);
            SPFieldLookup managerField = pList.Fields.GetFieldByInternalName(employeeFieldInternalName) as SPFieldLookup;
            managerField.LookupField = titleIDField.InternalName;
            FixupField(managerField);
            pList.Update();
        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties) {
            SPWeb spWeb = properties.Feature.Parent as SPWeb;
            SPList empList = spWeb.Lists["Employees"];
            empList.Delete();
            spWeb.Update();

            SPList projList = spWeb.Lists["Projects"];
            projList.Delete();
            spWeb.Update();
        }


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

        private void FixupField(SPList spList, string fieldInternalName) {
            FixupField(spList.Fields.GetFieldByInternalName(fieldInternalName));
        }

        private void FixupField(SPField spField) {
            // This method takes an InternalName of a field in a spList 
            // and process a few things we want all fields to have by default
            // for example setting them to show into the default view
            spField.ShowInDisplayForm = true;
            spField.ShowInEditForm = true;
            spField.ShowInListSettings = true;
            spField.ShowInNewForm = true;
            spField.ShowInVersionHistory = true;
            spField.ShowInViewForms = true;

            // Add field to default view
            SPView defaultView = spField.ParentList.DefaultView;
            defaultView.ViewFields.Add(spField);
            defaultView.Update();

            spField.Update();
        }

    }
}
