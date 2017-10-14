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
    public class OrderNumberProcess : ProcessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<OrderNumber> SelectList()
        {
            var response = HttpGet<AllResponse<OrderNumber>>("rest/OrderNumber/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public OrderNumber SelectOne(int id)
        {
            var response = HttpGet<FindResponse<OrderNumber>>("rest/OrderNumber/Find", new List<object> { id }, MediaType.Json);
            return response.Result;
        }

        public void Delete(int id)
        {
            var response = HttpPost<int>("rest/OrderNumber/Delete", id, MediaType.Json);
        }

        public OrderNumber Add(OrderNumber orderNumber)
        {
            var response = HttpPost<OrderNumber>("rest/OrderNumber/Add", orderNumber);
            return response;
        }

        public void Edit(OrderNumber orderNumber)
        {
            var response = HttpPost<OrderNumber>("rest/OrderNumber/Edit", orderNumber);
        }

    }
}