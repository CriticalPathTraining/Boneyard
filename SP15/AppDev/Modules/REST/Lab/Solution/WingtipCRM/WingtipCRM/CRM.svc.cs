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
using WingtipCRM.Models;

namespace WingtipCRM {
  public class CRM : DataService<WingtipCRMEntities> {
    public static void InitializeService(DataServiceConfiguration config) {
      config.SetEntitySetAccessRule("Customers", EntitySetRights.All);
      config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
    }
  }
}
