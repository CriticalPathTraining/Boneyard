using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerManagerWeb {
  public partial class Default : System.Web.UI.Page {
    protected void Page_PreInit(object sender, EventArgs e) {

    }

    protected void Page_Load(object sender, EventArgs e) {
      // configure link back to host web
      lnkHostWeb.NavigateUrl = Request.QueryString["SPHostUrl"];

      // add content to page
      pageContent.Controls.Add(new LiteralControl("Hello from server-side C# code"));

    }
  }
}