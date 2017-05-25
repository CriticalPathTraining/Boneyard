using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.EventReceivers;

namespace AppLifecycleEventWeb {
    public class AppEventReceiver : IRemoteEventService {
        public SPRemoteEventResult ProcessEvent(SPRemoteEventProperties properties) {
            SPRemoteEventResult result = new SPRemoteEventResult();

            if (properties.EventType == SPRemoteEventType.AppInstalled) {
                string source = "Lifecycle SharePoint App Demo";
                // verify there's a category in the Event Log for our app
                if (!System.Diagnostics.EventLog.SourceExists(source)) {
                    System.Diagnostics.EventLog.CreateEventSource(source, "Application");
                }

                // write to the log
                System.Diagnostics.EventLog.WriteEntry(source, "App Installed");
            }
            result.Status = SPRemoteEventServiceStatus.Continue;
            return result;

        }

        public void ProcessOneWayEvent(SPRemoteEventProperties properties) {
            // This method is not used by app events
        }
    }
}
