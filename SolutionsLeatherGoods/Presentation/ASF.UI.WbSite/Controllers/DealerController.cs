using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.Process;
using ASF.Entities;

namespace ASF.UI.WbSite.Controllers
{

    public class DealerViewModel
    {
        public Dealer dealer;
        public string category;
        public string country;        
    }
    public class DealerFullViewModel
    {
        public List<Dealer> dealer;
        public List<SelectListItem> countries;
        public List<SelectListItem> categories;
    }
    public class DealerController : Controller
    {
        // GET: Dealer
        public ActionResult Index()
        {
            DealerProcess dp = new DealerProcess();
            CountryProcess coup = new CountryProcess();
            CategoryProcess catp = new CategoryProcess();
            List<DealerViewModel> vm = new List<DealerViewModel>();
            List<Country> countries = coup.SelectList();
            List<Category> categories = catp.SelectList();
            vm = dp.SelectList().ConvertAll(x => new DealerViewModel() { dealer = x } );
            for (int i = 0; i < vm.Count; i++)
            {
                for (int j = 0; j < countries.Count; j++)
                {
                    if (countries[j].Id == vm[i].dealer.CountryId)
                    {
                        vm[i].country = countries[j].Name;
                    }
                }
                for (int j = 0; j < categories.Count; j++)
                {
                    if (categories[j].Id == vm[i].dealer.CategoryId)
                    {
                        vm[i].category = categories[j].Name;
                    }
                }
            }



            return View(vm);
        }

        // GET: Dealer/Details/5
        public ActionResult Details(int id)
        {
            DealerProcess dp = new DealerProcess();
            CountryProcess coup = new CountryProcess();
            CategoryProcess catp = new CategoryProcess();
            DealerViewModel vm = new DealerViewModel();
            vm.dealer = dp.SelectOne(id);
            vm.category = catp.SelectOne(vm.dealer.CategoryId).Name;
            vm.country = coup.SelectOne(vm.dealer.CountryId).Name;
            
            return View(vm);


        }

        // GET: Dealer/Create
        public ActionResult Create()
        {
            DealerProcess dp = new DealerProcess();
            CountryProcess coup = new CountryProcess();
            CategoryProcess catp = new CategoryProcess();
            DealerFullViewModel vm = new DealerFullViewModel();
            vm.countries = coup.SelectList().Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();
            vm.categories = catp.SelectList().Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();

            return View(vm);
        }

        // POST: Dealer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                DealerProcess dp = new DealerProcess();
                Dealer dealer = new Dealer();

                dealer.CountryId = int.Parse(collection["dealer[0].CountryId"]);
                dealer.CategoryId = int.Parse(collection["dealer[0].CategoryId"]);
                dealer.Description = collection["dealer[0].Description"];
                dealer.FirstName = collection["dealer[0].FirstName"];
                dealer.LastName = collection["dealer[0].LastName"];
                dealer.TotalProducts = int.Parse(collection["dealer[0].TotalProducts"]);

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
