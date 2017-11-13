using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.Process;
using ASF.Entities;

namespace ASF.UI.WbSite.Controllers
{
    public class ProductViewModel
    {
        public string dealer;
        public Product product;
    }
    public class ProductFullViewModel
    {
        public Product product;
        public List<SelectListItem> dealers;
    }
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int page = 1)
        {
            ProductProcess pp = new ProductProcess();                
            DealerProcess dp = new DealerProcess();

            List<ProductViewModel> vm = new List<ProductViewModel>();
            List<Dealer> dealers = dp.SelectList();

            vm = pp.SelectList(page, 100).ConvertAll(x => new ProductViewModel() { product = x });
            for (int i = 0; i < vm.Count; i++)
            {
                for (int j = 0; j < dealers.Count; j++)
                {
                    if (dealers[j].Id == vm[i].product.DealerId)
                    {
                        vm[i].dealer = dealers[j].FirstName + " " + dealers[j].LastName;
                    }
                }
            }
                return View(vm);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            ProductProcess pp = new ProductProcess();
            DealerProcess dp = new DealerProcess();

            ProductViewModel vm = new ProductViewModel();
            vm.product = pp.SelectOne(id);

            Dealer dealer = dp.SelectOne(vm.product.DealerId);

            vm.dealer = dealer.FirstName + " " + dealer.LastName;
            
            return View(vm);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ProductProcess pp = new ProductProcess();
            DealerProcess dp = new DealerProcess();

            ProductFullViewModel vm = new ProductFullViewModel();
            vm.dealers = dp.SelectList().Select(x => new SelectListItem() { Text = x.FirstName + " " + x.LastName, Value = x.Id.ToString() }).ToList();

            return View(vm);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ProductProcess pp = new ProductProcess();
                Product product = new Product()
                {
                    DealerId = int.Parse(collection["product.DealerId"]),
                    Description = collection["product.Description"],
                    Image = collection["product.Image"],
                    Price = double.Parse(collection["product.Price"]),
                    Title = collection["product.Title"]
                };
                pp.Add(product);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            ProductProcess pp = new ProductProcess();
            DealerProcess dp = new DealerProcess();

            ProductFullViewModel vm = new ProductFullViewModel();
            vm.product = pp.SelectOne(id);
            vm.dealers = dp.SelectList().Select(x => new SelectListItem() { Text = x.FirstName + " " + x.LastName, Value = x.Id.ToString() }).ToList();

            return View(vm);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {

                ProductProcess pp = new ProductProcess(); Product product = new Product()
                {
                    DealerId = int.Parse(collection["product.DealerId"]),
                    Description = collection["product.Description"],
                    Id = id,
                    Image = collection["product.Image"],
                    Price = double.Parse(collection["product.Price"]),
                    Title = collection["product.Title"],
                    ChangedBy = 1,
                    ChangedOn = DateTime.Now
                };

                pp.Edit(product);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            ProductProcess pp = new ProductProcess();
            DealerProcess dp = new DealerProcess();

            ProductViewModel vm = new ProductViewModel();
            vm.product = pp.SelectOne(id);

            Dealer dealer = dp.SelectOne(vm.product.DealerId);

            vm.dealer = dealer.FirstName + " " + dealer.LastName;

            return View(vm);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                ProductProcess pp = new ProductProcess();
                pp.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
