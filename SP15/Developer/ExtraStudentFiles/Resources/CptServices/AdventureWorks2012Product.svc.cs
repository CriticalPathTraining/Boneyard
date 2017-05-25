//------------------------------------------------------------------------------
// <copyright file="WebDataService.svc.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;

namespace CptServices
{
  [System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults = true)]
  [DataServicesJSONP.JSONPSupportBehavior]
  public class AdventureWorks2012Product : DataService<AdventureWorks2012ProductModelEntities>
  {
    public static void InitializeService(DataServiceConfiguration config)
    {
      config.SetEntitySetAccessRule("*", EntitySetRights.All);
      config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
      config.UseVerboseErrors = true;
    }
  }
}
