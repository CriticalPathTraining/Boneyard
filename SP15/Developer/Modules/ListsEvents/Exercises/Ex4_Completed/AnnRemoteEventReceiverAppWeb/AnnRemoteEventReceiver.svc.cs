using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.EventReceivers;

namespace AnnRemoteEventReceiverAppWeb {
    public class AnnRemoteEventReceiver : IRemoteEventService {
        public SPRemoteEventResult ProcessEvent(SPRemoteEventProperties properties) {
            SPRemoteEventResult result = new SPRemoteEventResult();

            if (properties.EventType == SPRemoteEventType.ItemAdding) {
                string bodyValue = properties.ItemEventProperties.AfterProperties["Body"].ToString();
                bodyValue += "\n\n\n *** CONFIDENTIAL *** \n";

                result.ChangedItemProperties.Add("Body", bodyValue);
            }

            return result;
        }

        public void ProcessOneWayEvent(SPRemoteEventProperties properties) {
            string x = "123";
        }
    }
}
