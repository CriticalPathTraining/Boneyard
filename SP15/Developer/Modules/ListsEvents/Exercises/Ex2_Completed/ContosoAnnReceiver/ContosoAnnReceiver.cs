using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;

namespace AnnouncementListEventChecker.ContosoAnnReceiver {
    /// <summary>
    /// List Item Events
    /// </summary>
    public class ContosoAnnReceiver : SPItemEventReceiver {
        /// <summary>
        /// An item is being added.
        /// </summary>
        public override void ItemAdding(SPItemEventProperties properties) {
            CheckForError(properties);
        }

        /// <summary>
        /// An item is being updated.
        /// </summary>
        public override void ItemUpdating(SPItemEventProperties properties) {
            CheckForError(properties);
        }

        private void CheckForError(SPItemEventProperties properties) {
            string stringToValidate = properties.AfterProperties["Title"].ToString() + properties.AfterProperties["Body"];
            if (!IsValidString(stringToValidate)) {
                properties.Status = SPEventReceiverStatus.CancelWithError;
                properties.ErrorMessage = "Creating announcements with the previous company name is not permitted.";
            }
        }

        private bool IsValidString(string stringToValidate) {
            if (string.IsNullOrEmpty(stringToValidate))
                return true;

            // check if the string has "contoso" anywhere in the name
            return stringToValidate.ToLower().Contains("contoso") ? false : true;
        }

    }
}