using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;

namespace ClassicEvents.MovieEvents {

  public class MovieEvents : SPItemEventReceiver {
  
    public override void ItemAdding(SPItemEventProperties properties) {
      string input = properties.AfterProperties["Title"].ToString();
      if (input.Contains("&")) {
        properties.Status = SPEventReceiverStatus.;
        properties.ErrorMessage = "Don't use amptersand";
      }


    }

    public override void ItemUpdating(SPItemEventProperties properties) {
      string input = properties.AfterProperties["Title"].ToString();
      if (input.Contains("&")) {
        properties.Status = SPEventReceiverStatus.CancelWithError;
        properties.ErrorMessage = "Don't use amptersand";
      }
      
    }


    public override void ItemAdded(SPItemEventProperties properties) {
      string input = properties.ListItem["Title"].ToString();
      properties.ListItem["Title"] = input.ToUpper();
      properties.ListItem.UpdateOverwriteVersion();
    }

    /// <summary>
    /// An item was updated
    /// </summary>
    public override void ItemUpdated(SPItemEventProperties properties) {
      base.ItemUpdated(properties);
    }


  }
}