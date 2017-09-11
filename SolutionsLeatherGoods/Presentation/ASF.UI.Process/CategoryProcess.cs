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
using ASF.UI.Process;

namespace ASF.UI.Process
{
    public class CategoryProcess : ProcessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Category> SelectList()
        {
            var response = HttpGet<AllResponse<Category>>("rest/Category/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public Category SelectOne(int id)
        {
            var response = HttpGet<FindResponse<Category>>("rest/Category/Find", new List<object> { id }, MediaType.Json);
            return response.Result;
        }

        public void Delete(int id)
        {
            var response = HttpPost<int>("rest/Category/Delete", id, MediaType.Json);
        }

        public Category Add(Category categoria)
        {
            var response = HttpPost<Category>("rest/Category/Add", categoria);
            return response;
        }

        public void Edit(Category categoria)
        {
            var response = HttpPut<Category>("rest/Category/Edit", categoria);
        }

    }
}