using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.Process;
using ASF.Entities;

namespace ASF.UI.WbSite.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            CategoryProcess pc = new CategoryProcess();
            
            return View(pc.SelectList());
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            CategoryProcess pc = new CategoryProcess();
            return View(pc.SelectOne(id));
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CategoryProcess pc = new CategoryProcess();
                Category cat = new Category();
                cat.Name = collection["Name"];
                pc.Add(cat);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            CategoryProcess pc = new CategoryProcess();
            return View(pc.SelectOne(id));
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                CategoryProcess pc = new CategoryProcess();
                Category cat = new Category();
                cat.Name = collection["Name"];
                cat.Id = id;

                pc.Edit(cat);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            CategoryProcess pc = new CategoryProcess();



            return View(pc.SelectOne(id));
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                CategoryProcess pc = new CategoryProcess();
                pc.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
