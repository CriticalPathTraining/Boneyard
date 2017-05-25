using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace SandboxedWebPart.SandboxWebPart {
    [ToolboxItemAttribute(false)]
    public class SandboxWebPart : WebPart {
        protected override void CreateChildControls() {
            Label message = new Label();
            Controls.Add(message);

            Controls.Add(new WebControl(HtmlTextWriterTag.Br));

            Button button = new Button() { Text = "Click Me!" };
            button.Click += delegate {
                message.Text = String.Format("This site contains {0} lists", SPContext.Current.Web.Lists.Count);
            };
            Controls.Add(button);
        }
    }
}
