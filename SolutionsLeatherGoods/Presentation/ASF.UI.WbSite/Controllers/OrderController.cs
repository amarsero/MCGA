using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
namespace ASF.UI.WbSite.Controllers
{
    public enum OrderStates : int
    {
        Sending,
        Sent
    }
    [Authorize]
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            Process.OrderProcess op = new Process.OrderProcess();
            Process.ClientProcess cp = new Process.ClientProcess();

            return View(op.SelectByClientId(cp.SelectByAspNetId(User.Identity.GetUserId<string>()).Id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            Process.CartProcess cartp = new Process.CartProcess();
            if (Request.Cookies["cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Entities.Cart cart = cartp.SelectOne(Request.Cookies["cart"].Value.ToString());

            if (cart.ItemCount == 0) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public ActionResult Create(object payInfo)
        {
            Process.OrderProcess op = new Process.OrderProcess();
            Process.OrderNumberProcess onp = new Process.OrderNumberProcess();
            Process.OrderDetailProcess odp = new Process.OrderDetailProcess();
            Process.ClientProcess clientp = new Process.ClientProcess();
            Process.CartProcess cartp = new Process.CartProcess();
            Process.CartItemProcess cip = new Process.CartItemProcess();

           

            if (Request.Cookies["cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Entities.Cart cart = cartp.SelectOne(Request.Cookies["cart"].Value.ToString());

            if (cart.ItemCount == 0) return RedirectToAction("Index", "Home");

            Entities.Order order = op.Add(new Entities.Order()
            {
                ChangedOn = DateTime.Now,
                ClientId = clientp.SelectByAspNetId(User.Identity.GetUserId<string>()).Id,
                CreatedOn = DateTime.Now,
                ItemCount = 0,
                OrderDate = DateTime.Now,
                OrderNumber = onp.Add(new Entities.OrderNumber()
                {
                    ChangedOn = DateTime.Now,
                    CreatedOn = DateTime.Now,
                    Number = cart.Id
                }).Number,
                State = (int)OrderStates.Sending,
                TotalPrice = 0
            });

            foreach (Entities.CartItem cartItem in cip.SelectByCard(cart.Id))
            {
                odp.Add(new Entities.OrderDetail()
                {
                    ChangedOn = DateTime.Now,
                    CreatedOn = DateTime.Now,
                    OrderId = order.Id,
                    Price = cartItem.Price,
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity
                });
            }

            Response.Cookies["cart"].Expires = DateTime.Now.AddDays(-4);

            return RedirectToAction("Index", "Order");
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            Process.OrderDetailProcess odp = new Process.OrderDetailProcess();
            Process.ProductProcess pp = new Process.ProductProcess();
            List<Entities.OrderDetail> orders = odp.SelectByOrderId(id);
            List<CartItemViewModel> lista = new List<CartItemViewModel>();

            foreach(Entities.OrderDetail item in orders)
            {
                lista.Add(new CartItemViewModel()
                {
                   Price = item.Price,
                   ProductName = pp.SelectOne(item.ProductId).Title,
                   Quantity = item.Quantity
                   
                });
            }

            return View();
        }
    }
}