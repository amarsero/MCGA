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
    public class OrderProcess : ProcessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Order> SelectList()
        {
            var response = HttpGet<AllResponse<Order>>("rest/Order/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public Order SelectOne(int id)
        {
            var response = HttpGet<FindResponse<Order>>("rest/Order/Find", new List<object> { id }, MediaType.Json);
            return response.Result;
        }

        public void Delete(int id)
        {
            var response = HttpPost<int>("rest/Order/Delete", id, MediaType.Json);
        }

        public Order Add(Order order)
        {
            var response = HttpPost<Order>("rest/Order/Add", order);
            return response;
        }

        public void Edit(Order order)
        {
            var response = HttpPost<Order>("rest/Order/Edit", order);
        }

    }
}