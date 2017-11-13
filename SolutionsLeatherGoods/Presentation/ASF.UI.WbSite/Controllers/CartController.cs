using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;

namespace ASF.UI.WbSite.Controllers
{
    public class CartItemViewModel: Entities.CartItem
    {
        [Display(Name = "Product")]
        public string ProductName { get; set; }
    }
    [Authorize]
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            Entities.Cart cart;

            Process.ProductProcess pp = new Process.ProductProcess();
            Process.CartItemProcess cip = new Process.CartItemProcess();
            Process.CartProcess cp = new Process.CartProcess();
            if (Request.Cookies["cart"] == null)
            {
                cart = cp.Add(new Entities.Cart()
                {
                    CartDate = DateTime.Now,
                    ChangedOn = DateTime.Now,
                    Cookie = Guid.NewGuid().ToString(),
                    CreatedOn = DateTime.Now,
                    ItemCount = 0
                });
                Response.Cookies["cart"].Value = cart.Cookie;
                Response.Cookies["cart"].Expires = DateTime.Now.AddDays(2);
            }
            else
            {
                cart = cp.SelectOne(Request.Cookies["cart"].Value.ToString());
            }

            List<CartItemViewModel> lista = new List<CartItemViewModel>();

            foreach (Entities.CartItem item in cip.SelectByCard(cart.Id))
            {
                CartItemViewModel vm = new CartItemViewModel();
                vm.CartId = item.CartId;
                vm.Price = item.Price;
                vm.ProductName = pp.SelectOne(item.ProductId).Title;
                vm.ProductId = item.ProductId;
                vm.Quantity = item.Quantity;
                vm.Id = item.Id;

                lista.Add(vm);
            }

            return View(lista);
        }

        public ActionResult Add(int id, int cantidad = 1)
        {
            //Lógica mágica de agregar cositas
            Process.CartItemProcess cip = new Process.CartItemProcess();
            Process.CartProcess cp = new Process.CartProcess();
            Process.ProductProcess pp = new Process.ProductProcess();
            Entities.Product prod = pp.SelectOne(id);

            Entities.Cart cart;
            if (Request.Cookies["cart"] == null)
            {
                cart = cp.Add(new Entities.Cart()
                {
                    CartDate = DateTime.Now,
                    ChangedOn = DateTime.Now,
                    Cookie = Guid.NewGuid().ToString(),
                    CreatedOn = DateTime.Now,
                    ItemCount = 0
                });
                Response.Cookies["cart"].Value = cart.Cookie;
                Response.Cookies["cart"].Expires = DateTime.Now.AddDays(2);
            }
            else
            {
                cart = cp.SelectOne(Request.Cookies["cart"].Value.ToString());
            }


            cip.Add(new Entities.CartItem()
            {
                ChangedOn = DateTime.Now,
                CreatedOn = DateTime.Now,
                Price = prod.Price,
                Quantity = cantidad,
                ProductId = id,
                CartId = cart.Id
            });

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Process.CartItemProcess cip = new Process.CartItemProcess();
            cip.Delete(id);
            return RedirectToAction("Index");
        }
    }
}