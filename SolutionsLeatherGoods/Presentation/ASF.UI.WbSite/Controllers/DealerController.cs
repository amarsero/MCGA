using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.Process;
using ASF.Entities;

namespace ASF.UI.WbSite.Controllers
{

    public class DealerListViewModel
    {
        public List<Dealer> dealers;
        public List<Category> categories;
        public List<Country> countries;
    }
    public class DealerController : Controller
    {
        // GET: Dealer
        public ActionResult Index()
        {
            DealerProcess dp = new DealerProcess();
            DealerListViewModel vm = new DealerListViewModel();
            vm.dealers = dp.SelectList();
            vm.countries = CountryController.SelectListCountry();
            return View(vm);
        }

        // GET: Dealer/Details/5
        public ActionResult Details(int id)
        {
            DealerProcess dp = new DealerProcess();
            return View(dp.SelectOne(id));
        }

        // GET: Dealer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dealer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                DealerProcess dp = new DealerProcess();
                Dealer dealer = new Dealer();

                dealer.CountryId = int.Parse(collection["CountryId"]);
                dealer.CategoryId = int.Parse(collection["CategoryId"]);
                dealer.Description = collection["Description"];
                dealer.FirstName = collection["FirstName"];
                dealer.LastName = collection["LastName"];
                dealer.TotalProducts = int.Parse(collection["TotalProducts"]);

                dp.Add(dealer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dealer/Edit/5
        public ActionResult Edit(int id)
        {
            DealerProcess dp = new DealerProcess();
            
            return View(dp.SelectOne(id));
        }

        // POST: Dealer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                DealerProcess dp = new DealerProcess();
                Dealer dealer = new Dealer();

                dealer.CountryId = int.Parse(collection["CountryId"]);
                dealer.CategoryId = int.Parse(collection["CategoryId"]);
                dealer.Description = collection["Description"];
                dealer.FirstName = collection["FirstName"];
                dealer.LastName = collection["LastName"];
                dealer.TotalProducts = int.Parse(collection["TotalProducts"]);
                dealer.Id = id;

                dp.Edit(dealer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dealer/Delete/5
        public ActionResult Delete(int id)
        {
            DealerProcess dp = new DealerProcess();

            return View(dp.SelectOne(id));
        }

        // POST: Dealer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                DealerProcess dp = new DealerProcess();
                dp.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
