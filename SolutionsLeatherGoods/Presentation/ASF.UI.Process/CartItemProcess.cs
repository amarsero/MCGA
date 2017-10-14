using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using ASF.Entities;
using ASF.Services.Contracts;

namespace ASF.UI.Process
{
    public class CartItemProcess : ProcessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CartItem> SelectList()
        {
            var response = HttpGet<AllResponse<CartItem>>("rest/CartItem/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public CartItem SelectOne(int id)
        {
            var response = HttpGet<FindResponse<CartItem>>("rest/CartItem/Find", new List<object> { id }, MediaType.Json);
            return response.Result;
        }

        public void Delete(int id)
        {
            var response = HttpPost<int>("rest/CartItem/Delete", id, MediaType.Json);
        }

        public CartItem Add(CartItem cartItem)
        {
            var response = HttpPost<CartItem>("rest/CartItem/Add", cartItem);
            return response;
        }

        public void Edit(CartItem cartItem)
        {
            var response = HttpPost<CartItem>("rest/CartItem/Edit", cartItem);
        }

    }
}