using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.Process;
using ASF.Entities;
using ASF.UI.WbSite.Services.Cache;

namespace ASF.UI.WbSite.Controllers
{
    public class CountryController : Controller
    {
        // GET: Country
        public ActionResult Index()
        {
            CountryProcess countryProcess = new CountryProcess();

            return View(countryProcess.SelectList());
        }

        // GET: Country/Details/5
        public ActionResult Details(int id)
        {
            CountryProcess countryProcess = new CountryProcess();

            return View(countryProcess.SelectOne(id));
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CountryProcess countryProcess = new CountryProcess();
                Country country = new Country()
                {
                    Name = collection["Name"]
                };
                countryProcess.Add(country);            

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Country/Edit/5
        public ActionResult Edit(int id)
        {
            CountryProcess countryProcess = new CountryProcess();

            return View(countryProcess.SelectOne(id));
        }

        // POST: Country/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                CountryProcess countryProcess = new CountryProcess();
                Country country = new Country()
                {
                    Name = collection["Name"],
                    Id = id
                };
                countryProcess.Edit(country);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Country/Delete/5
        public ActionResult Delete(int id)
        {
            CountryProcess countryProcess = new CountryProcess();

            return View(countryProcess.SelectOne(id));
        }

        // POST: Country/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                CountryProcess countryProcess = new CountryProcess();
                countryProcess.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
