using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prodavalnik.Web.Areas.Admin.Controllers
{
    using Attributes;

    [RouteArea("Admin")]
    [CustomAuthorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}