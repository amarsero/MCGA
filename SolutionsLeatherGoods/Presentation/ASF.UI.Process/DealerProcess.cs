using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using ASF.Services.Contracts;

namespace ASF.UI.Process
{
    public class DealerProcess : ProcessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Dealer> SelectList()
        {
            var response = HttpGet<AllResponse<Dealer>>("rest/Dealer/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public Dealer SelectOne(int id)
        {
            var response = HttpGet<FindResponse<Dealer>>("rest/Dealer/Find", new List<object> { id }, MediaType.Json);
            return response.Result;
        }

        public void Delete(int id)
        {
            var response = HttpPost<int>("rest/Dealer/Delete", id, MediaType.Json);
        }

        public Dealer Add(Dealer categoria)
        {
            var response = HttpPost<Dealer>("rest/Dealer/Add", categoria);
            return response;
        }

        public void Edit(Dealer categoria)
        {
            var response = HttpPost<Dealer>("rest/Dealer/Edit", categoria);
        }

    }
}
