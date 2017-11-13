using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;
using ASF.UI.Process;

namespace ASF.UI.WbSite.Controllers
{
    public class ShowroomController : Controller
    {
        // GET: Showroom
        public ActionResult Index()
        {
            Process.ProductProcess pp = new Process.ProductProcess();
            
            return View(pp.SelectList(1));
        }

        public ActionResult Detail(int id)
        {
            Process.ProductProcess pp = new Process.ProductProcess();

            return View(pp.SelectOne(id));
        }

        [HttpPost]
        public ActionResult Buy(int id)
        {
            return RedirectToAction("Add", "Cart", new { id = id });
        }

    }
}
