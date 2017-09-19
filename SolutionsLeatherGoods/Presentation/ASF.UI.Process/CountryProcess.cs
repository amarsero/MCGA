using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ASF.Entities;
using ASF.Services.Contracts;

namespace ASF.UI.Process
{
    public class CountryProcess : ProcessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Country> SelectList()
        {
            var response = HttpGet<AllResponse<Country>>("rest/Country/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public Country SelectOne(int id)
        {
            var response = HttpGet<FindResponse<Country>>("rest/Country/Find", new List<object> { id }, MediaType.Json);
            return response.Result;
        }

        public void Delete(int id)
        {
            var response = HttpPost<int>("rest/Country/Delete", id, MediaType.Json);
        }

        public Country Add(Country country)
        {
            var response = HttpPost<Country>("rest/Country/Add", country);
            return response;
        }

        public void Edit(Country country)
        {
            var response = HttpPost<Country>("rest/Country/Edit", country);
        }

    }
}