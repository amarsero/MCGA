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
    public class CartProcess : ProcessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Cart> SelectList()
        {
            var response = HttpGet<AllResponse<Cart>>("rest/Cart/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public Cart SelectOne(int id)
        {
            var response = HttpGet<FindResponse<Cart>>("rest/Cart/Find", new List<object> { id }, MediaType.Json);
            return response.Result;
        }

        public void Delete(int id)
        {
            var response = HttpPost<int>("rest/Cart/Delete", id, MediaType.Json);
        }

        public Cart Add(Cart cart)
        {
            var response = HttpPost<Cart>("rest/Cart/Add", cart);
            return response;
        }

        public void Edit(Cart cart)
        {
            var response = HttpPost<Cart>("rest/Cart/Edit", cart);
        }

    }
}