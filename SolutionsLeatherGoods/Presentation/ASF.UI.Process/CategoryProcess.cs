﻿using System;
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

        public Category Add(Category category)
        {
            var response = HttpPost<Category>("rest/Category/Add", category);
            return response;
        }

        public void Edit(Category category)
        {
            var response = HttpPost<Category>("rest/Category/Edit", category);
        }

    }
}