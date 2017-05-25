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
  public class Calculator : DataService<MathModel>
  {
    // This method is called only once to initialize service-wide policies.
    public static void InitializeService(DataServiceConfiguration config)
    {
      config.SetServiceOperationAccessRule("Add", ServiceOperationRights.All);
      config.SetServiceOperationAccessRule("Subtract", ServiceOperationRights.All);
      config.SetServiceOperationAccessRule("Multiply", ServiceOperationRights.All);
      config.SetServiceOperationAccessRule("Divide", ServiceOperationRights.All);
      config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
      config.UseVerboseErrors = true;
    }

    [WebGet]
    public MathModel Add(int subjectA, int subjectB)
    {
      return new MathModel()
      {
        SubjectA = subjectA,
        SubjectB = subjectB,
        Result = subjectA + subjectB
      };
    }

    [WebGet]
    public MathModel Subtract(int subjectA, int subjectB)
    {
      return new MathModel()
      {
        SubjectA = subjectA,
        SubjectB = subjectB,
        Result = subjectA - subjectB
      };
    }

    [WebGet]
    public MathModel Multiply(int subjectA, int subjectB)
    {
      return new MathModel()
      {
        SubjectA = subjectA,
        SubjectB = subjectB,
        Result = subjectA * subjectB
      };
    }


    [WebGet]
    public MathModel Divide(int subjectA, int subjectB)
    {
      return new MathModel()
      {
        SubjectA = subjectA,
        SubjectB = subjectB,
        Result = subjectA / subjectB
      };
    }
  }
}
