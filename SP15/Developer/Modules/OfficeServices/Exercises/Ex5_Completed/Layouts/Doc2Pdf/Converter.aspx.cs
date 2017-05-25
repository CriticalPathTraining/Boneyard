using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Text;
using Microsoft.SharePoint.Security;
using Microsoft.Office.Word.Server.Conversions;

namespace Doc2Pdf.Layouts.Doc2Pdf
{
    public partial class Converter : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string siteUrl = Request.QueryString["SiteUrl"];
                string listId = Request.QueryString["ListId"];
                string itemId = Request.QueryString["ItemId"];

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite site = new SPSite(siteUrl))
                    {
                        using (SPWeb web = site.OpenWeb())
                        {
                            SPDocumentLibrary library = (SPDocumentLibrary)web.Lists[new Guid(listId)];
                            SPListItem item = library.GetItemById(int.Parse(itemId));
                            SPFile file = item.File;

                            if (file.Name.EndsWith(".doc",
                                StringComparison.CurrentCultureIgnoreCase) ||
                                file.Name.EndsWith(".docx",
                                StringComparison.CurrentCultureIgnoreCase))
                            {
                                //Set up the job
                                ConversionJobSettings jobSettings = new ConversionJobSettings();
                                jobSettings.OutputFormat = SaveFormat.PDF;
                                ConversionJob job = new ConversionJob("Word Automation Services", jobSettings);
                                job.UserToken = web.CurrentUser.UserToken;

                                //File names
                                string wordFile = web.Url + "/" + item.Url;
                                string pdfFile = string.Empty;
                                if (file.Name.EndsWith(".doc",
                                    StringComparison.CurrentCultureIgnoreCase))
                                    pdfFile = wordFile.Replace(".doc", ".pdf");
                                if (file.Name.EndsWith(".docx",
                                    StringComparison.CurrentCultureIgnoreCase))
                                    pdfFile = wordFile.Replace(".docx", ".pdf");

                                //Start Job
                                job.AddFile(wordFile, pdfFile);
                                job.Start();

                                StringBuilder message = new StringBuilder();
                                message.Append("<p>The conversion job has been submitted</p>");
                                message.Append("<p>Word File: ");
                                message.Append(wordFile);
                                message.Append("</p><p>PDF File: ");
                                message.Append(pdfFile);
                                message.Append("</p>");
                                Messages.Text = message.ToString();
                            }
                        }
                    }
                });
            }
            catch (Exception x)
            {
                Messages.Text = "<p>" + x.Message + "</p>";
            }
        }
    }
}
