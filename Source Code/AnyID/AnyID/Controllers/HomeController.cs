using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnyID.Models;

namespace AnyID.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private DataContext db = new DataContext();

        public ActionResult Index()
        {
            List<B_VIEW_GAM> rs = db.B_VIEW_GAM.Where(x => x.FORACID.Equals("001150436382")).ToList();
            
            return View();
        }

    }
}
