using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnyID.Models;
using AnyID.Class;

namespace AnyID.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [Permission]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Redirect()
        {
            return View();
        }

        public ActionResult TestView()
        {
            return View();
        }



        public void prod(RegisterModel Input)
        {
            OracleContext db = new OracleContext();
            var rs = db.B_P_GAM("030130027099");
            List<B_TABLE_ENTITIESVIEW_GAM> rsL = rs.ToList();
        }

    }
}
