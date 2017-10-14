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
    public class ClientProcess : ProcessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Client> SelectList()
        {
            var response = HttpGet<AllResponse<Client>>("rest/Client/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public Client SelectOne(int id)
        {
            var response = HttpGet<FindResponse<Client>>("rest/Client/Find", new List<object> { id }, MediaType.Json);
            return response.Result;
        }

        public void Delete(int id)
        {
            var response = HttpPost<int>("rest/Client/Delete", id, MediaType.Json);
        }

        public Client Add(Client client)
        {
            var response = HttpPost<Client>("rest/Client/Add", client);
            return response;
        }

        public void Edit(Client client)
        {
            var response = HttpPost<Client>("rest/Client/Edit", client);
        }

    }
}