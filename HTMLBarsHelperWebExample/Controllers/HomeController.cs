using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTMLBarsHelperWebExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Debug = false;
#if DEBUG
            ViewBag.Debug = true;
#endif
            return View();
        }
    }
}
