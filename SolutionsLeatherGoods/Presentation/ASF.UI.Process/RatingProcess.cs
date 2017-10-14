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
    public class RatingProcess : ProcessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Rating> SelectList()
        {
            var response = HttpGet<AllResponse<Rating>>("rest/Rating/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public Rating SelectOne(int id)
        {
            var response = HttpGet<FindResponse<Rating>>("rest/Rating/Find", new List<object> { id }, MediaType.Json);
            return response.Result;
        }

        public void Delete(int id)
        {
            var response = HttpPost<int>("rest/Rating/Delete", id, MediaType.Json);
        }

        public Rating Add(Rating rating)
        {
            var response = HttpPost<Rating>("rest/Rating/Add", rating);
            return response;
        }

        public void Edit(Rating rating)
        {
            var response = HttpPost<Rating>("rest/Rating/Edit", rating);
        }

    }
}