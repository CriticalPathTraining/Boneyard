using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace RestForToughGuys {
  class Program {
    static void Main() {
      GetSiteProperties();
      GetRequestDigest();

    }

    static string GetRequestDigest() {
      
      string restURI = "http://intranet.wingtip.com/_api/contextinfo";
      HttpWebRequest request = HttpWebRequest.CreateHttp(restURI);
      request.Method = "POST";
      request.ContentLength = 0;
      request.Credentials = CredentialCache.DefaultCredentials;
      request.Accept = "application/atom+xml";

      // send request and wait synchronously for response
      HttpWebResponse response = request.GetResponse() as HttpWebResponse;

      // use LINQ to XML to get data
      XDocument doc = XDocument.Load(response.GetResponseStream());
      XNamespace nsDataService = "http://schemas.microsoft.com/ado/2007/08/dataservices";
      string FormDigestValue = doc.Descendants(nsDataService + "FormDigestValue").First().Value;

      Console.WriteLine(FormDigestValue);

      return FormDigestValue;
    }

    static void GetSiteProperties() {

      string restURI = "http://intranet.wingtip.com/_api/web/?$select=Id,Title";
      HttpWebRequest request = HttpWebRequest.CreateHttp(restURI);
      request.Credentials = CredentialCache.DefaultCredentials;
      request.Accept = "application/atom+xml";

      // send request and wait synchronously for response
      HttpWebResponse response = request.GetResponse() as HttpWebResponse;

      // use LINQ to XML to get data
      XDocument doc = XDocument.Load(response.GetResponseStream());
      XNamespace nsDataService = "http://schemas.microsoft.com/ado/2007/08/dataservices";
      string title = doc.Descendants(nsDataService + "Title").First().Value;
      string Id = doc.Descendants(nsDataService + "Id").First().Value;

      Console.WriteLine(title);
      Console.WriteLine(Id);

    }
  }
}
