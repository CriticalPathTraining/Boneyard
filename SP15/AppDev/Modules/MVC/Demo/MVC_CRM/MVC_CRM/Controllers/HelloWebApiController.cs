using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC_CRM.Controllers {

  public class HelloWebApiController : ApiController {

    public string GetSomething() {
      return "Hello from the Web API";
    }

    public void PostSomething([FromBody] string bodyContent) {
      // POST operation implementation goes here
    }
  }

  }


