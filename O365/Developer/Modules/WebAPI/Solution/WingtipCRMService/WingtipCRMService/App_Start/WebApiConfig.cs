﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using WingtipCRMService.Models;

namespace WingtipCRMService {
  public static class WebApiConfig {
    public static void Register(HttpConfiguration config) {
      // Web API configuration and services
      ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
      builder.EntitySet<Customer>("Customers");
      builder.Namespace = "WingtipCRMService.Models";
      config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());

      // Web API routes
      config.MapHttpAttributeRoutes();

      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{id}",
          defaults: new { id = RouteParameter.Optional }
      );
      config.EnableCors();
    }
  }
}
