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
    public class ProductProcess : ProcessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Product> SelectList(int pageNumber, int pageSize = 9)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("pageNumber", pageNumber);
            dic.Add("pageSize", pageSize);
            var response = HttpGet<AllResponse<Product>>("rest/Product/All", , MediaType.Json);
            return response.Result;
        }

        public Product SelectOne(int id)
        {
            var response = HttpGet<FindResponse<Product>>("rest/Product/Find", new List<object> { id }, MediaType.Json);
            return response.Result;
        }

        public void Delete(int id)
        {
            var response = HttpPost<int>("rest/Product/Delete", id, MediaType.Json);
        }

        public Product Add(Product product)
        {
            var response = HttpPost<Product>("rest/Product/Add", product);
            return response;
        }

        public void Edit(Product product)
        {
            var response = HttpPost<Product>("rest/Product/Edit", product);
        }

    }
}