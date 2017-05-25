using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.Office.TranslationServices;
using System.Globalization;
using System.IO;
using System.Text;
using Microsoft.SharePoint.Utilities;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Doc2Esmx.Layouts.Doc2Esmx
{
    public partial class Converter : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string fileIn = string.Empty;
            string fileOut = string.Empty;

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
                            //web.AllowUnsafeUpdates = true;
                            SPDocumentLibrary library = (SPDocumentLibrary)web.Lists[new Guid(listId)];
                            SPListItem item = library.GetItemById(int.Parse(itemId));
                            SPFile file = item.File;

                            //Get file names
                            string extension = file.Name.Substring(file.Name.LastIndexOf('.') + 1);
                            string libUrl = library.DefaultViewUrl.Substring(0, library.DefaultViewUrl.LastIndexOf("Forms"));
                            fileIn = site.Url + libUrl + item.File.Name;
                            string fileName = item.File.Name.Replace(extension, "_esmx." + extension);
                            fileOut = site.Url + libUrl + fileName;

                            //Set up Job
                            SPServiceContext sc = SPServiceContext.GetContext(site);
                            byte[] inputByte = file.OpenBinary();
                            byte[] outputByte;

                            //Execute job synchronously
                            SyncTranslator job = new SyncTranslator(sc, CultureInfo.GetCultureInfo(2058));
                            //TranslationItemInfo itemInfo = job.Translate(fileIn, fileOut);
                            TranslationItemInfo itemInfo = job.Translate(inputByte, out outputByte, extension);

                            //Upload translated file
                            web.AllowUnsafeUpdates = true;
                            web.Files.Add(fileOut, outputByte, true);
                            web.AllowUnsafeUpdates = false;

                            //Go back to library
                            SPUtility.Redirect(library.DefaultViewUrl, SPRedirectFlags.Default, HttpContext.Current);

                        }
                    }
                });
            }
            catch (Exception x)
            {
                StringBuilder message = new StringBuilder();
                message.Append("<p>" + x.Message + "</p>");
                message.Append("<p>Input File: ");
                message.Append(fileIn);
                message.Append("</p><p>Output File: ");
                message.Append(fileOut);
                message.Append("</p>");
                Messages.Text = message.ToString();
            }
        }
    }
}

