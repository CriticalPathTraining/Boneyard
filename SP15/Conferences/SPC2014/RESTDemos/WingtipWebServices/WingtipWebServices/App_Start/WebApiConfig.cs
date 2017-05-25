﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using Microsoft.Data.Edm;
using WingtipWebServices.Models;

namespace WingtipWebServices {
  public static class WebApiConfig {
    public static void Register(HttpConfiguration config) {

      // Web API configuration and services
      ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
      builder.EntitySet<Customer>("Customers");
      builder.EntitySet<Customer>("Contacts");
      config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
       
      // Web API routes
      config.MapHttpAttributeRoutes();

      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{id}",
          defaults: new { id = RouteParameter.Optional }
      );
    }



  }
}
