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
    public class SettingProcess : ProcessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Setting> SelectList()
        {
            var response = HttpGet<AllResponse<Setting>>("rest/Setting/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public Setting SelectOne(int id)
        {
            var response = HttpGet<FindResponse<Setting>>("rest/Setting/Find", new List<object> { id }, MediaType.Json);
            return response.Result;
        }

        public void Delete(int id)
        {
            var response = HttpPost<int>("rest/Setting/Delete", id, MediaType.Json);
        }

        public Setting Add(Setting setting)
        {
            var response = HttpPost<Setting>("rest/Setting/Add", setting);
            return response;
        }

        public void Edit(Setting setting)
        {
            var response = HttpPost<Setting>("rest/Setting/Edit", setting);
        }

    }
}