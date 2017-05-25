New sharepoint hosted app
Add an Announcements list named Announcements to the site
Add this to the contents of default.aspx:

<WebPartPages:WebPartZone ID="Main" Title="Main Web Part Zone" FrameType="TitleBarOnly" runat="server">
  <ZoneTemplate>
    <WebPartPages:XsltListViewWebPart
            runat="server"
            ID="AnnouncementsWebPart"
            Title="Announcements"
            ListUrl="Lists/Announcements"
            ChromeType="None">
    </WebPartPages:XsltListViewWebPart>
  </ZoneTemplate>
</WebPartPages:WebPartZone>