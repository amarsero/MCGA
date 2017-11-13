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
    public class OrderDetailProcess : ProcessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<OrderDetail> SelectList()
        {
            var response = HttpGet<AllResponse<OrderDetail>>("rest/OrderDetail/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public OrderDetail SelectOne(int id)
        {
            var response = HttpGet<FindResponse<OrderDetail>>("rest/OrderDetail/Find", new List<object> { id }, MediaType.Json);
            return response.Result;
        }

        public List<OrderDetail> SelectByOrderId(int id)
        {
            var response = HttpGet<AllResponse<OrderDetail>>("rest/OrderDetail/FindByOrderId", new List<object> { id }, MediaType.Json);
            return response.Result;
        }

        public void Delete(int id)
        {
            var response = HttpPost<int>("rest/OrderDetail/Delete", id, MediaType.Json);
        }

        public OrderDetail Add(OrderDetail orderDetail)
        {
            var response = HttpPost<OrderDetail>("rest/OrderDetail/Add", orderDetail);
            return response;
        }

        public void Edit(OrderDetail orderDetail)
        {
            var response = HttpPost<OrderDetail>("rest/OrderDetail/Edit", orderDetail);
        }

    }
}