using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace CamlQueryWebPart.CamlQueryWebPart {
    [ToolboxItemAttribute(false)]
    public class CamlQueryWebPart : WebPart {
        protected override void CreateChildControls() {
            SPList list = SPContext.Current.Web.Lists.TryGetList("Projects");
            if (list != null) {
                SPQuery query = new SPQuery() {
                    ViewFields = "<FieldRef Name='Title' /><FieldRef Name='Description' />",
                    Query = @"<OrderBy>
                <FieldRef Name='Title' />
              </OrderBy>"
                };
                SPListItemCollection listItems = list.GetItems(query);

                foreach (SPListItem item in listItems) {
                    string html = string.Format("<div><b>Project:</b>{0}<br /><em>{1}</em></div>", item["Title"].ToString(), item["Description"].ToString());
                    this.Controls.Add(new LiteralControl(html));
                }
            }
        }
    }
}