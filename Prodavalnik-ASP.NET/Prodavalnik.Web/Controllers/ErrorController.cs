using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prodavalnik.Web.Controllers
{
    [RoutePrefix("error")]
    public class ErrorController : Controller
    {
        [Route("notfound")]
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }

        [Route("servererror")]
        public ActionResult ServerError()
        {
            Response.StatusCode = 500;
            return View();
        }
        
        
    }
}
