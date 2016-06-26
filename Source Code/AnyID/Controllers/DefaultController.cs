using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnyID.Controllers
{
    public class DefaultController : Controller
    {
        //
        // GET: /Default/

        public ActionResult PermissionTimeOut()
        {
            return View("PermissionTimeOut");
        }

    }
}
