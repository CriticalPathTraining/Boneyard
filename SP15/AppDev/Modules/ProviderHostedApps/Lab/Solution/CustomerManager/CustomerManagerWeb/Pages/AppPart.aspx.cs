using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerManagerWeb.Pages {
  public partial class AppPart : Page {
    protected void Page_Load(object sender, EventArgs e) {

    }

    protected void FormView1_ItemInserted(object sender, FormViewInsertedEventArgs e) {
      GridView1.DataBind();
    }
  }
}