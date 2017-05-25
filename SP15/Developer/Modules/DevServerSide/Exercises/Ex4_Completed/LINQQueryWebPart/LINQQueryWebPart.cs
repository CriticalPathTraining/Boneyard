using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Linq;

namespace LinqQueryWebPart.LinqQueryWebPart {
    [ToolboxItemAttribute(false)]
    public class LinqQueryWebPart : WebPart {
        protected override void CreateChildControls() {
            ServerSideEntitiesDataContext siteDataContext = new ServerSideEntitiesDataContext(SPContext.Current.Web.Url);
            var query = from project in siteDataContext.Projects
                        orderby project.Title
                        select new {
                            ProjectTitle = project.Title,
                            ProjectDescription = project.Description,
                            ProjectContactName = project.PrimaryContact.Title,
                            ProjectContactJobTitle = project.PrimaryContact.JobTitle
                        };
            foreach (var item in query) {
                string html = string.Format("<div><b>Project:</b> {0}<br /><em>{1}</em><br />&nbsp;&nbsp;<b>Primary Contact:</b> {2} ({3})</div>",
                                            item.ProjectTitle,
                                            item.ProjectDescription,
                                            item.ProjectContactName,
                                            item.ProjectContactJobTitle);
                this.Controls.Add(new LiteralControl(html));
            }
        }
    }
}
