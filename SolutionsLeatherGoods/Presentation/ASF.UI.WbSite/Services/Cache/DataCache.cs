using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;
using ASF.UI.Process;

namespace ASF.UI.WbSite.Services.Cache
{
    public class DataCache
    {
        #region Singleton
        private static DataCache _instance;
        private static readonly object InstanceLock = new object();
        public static DataCache Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (InstanceLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DataCache();
                        }
                    }
                }
                return _instance;
            }
        }
        #endregion

        private readonly ICacheService _cacheService;
        private DataCache()
        {
            _cacheService = DependencyResolver.Current.GetService<ICacheService>();
        }

        public List<Category> CategoryAll()
        {
            List<Category> lista = _cacheService.GetOrAdd(
                ASF.UI.WbSite.Constants.CacheSetting.Category.Key,
                () =>
                {
                    CategoryProcess cp = new CategoryProcess();
                    return cp.SelectList();
                },
                ASF.UI.WbSite.Constants.CacheSetting.Category.SlidingExpiration
                );
            return lista;
        }

        public Category CategoryPorId(int id)
        {
            Category resultado = CategoryAll().Where(x => x.Id == id).FirstOrDefault();
            if (resultado == null)
            {
                _cacheService.Remove(ASF.UI.WbSite.Constants.CacheSetting.Category.Key);
                resultado = CategoryAll().Where(x => x.Id == id).FirstOrDefault();
            }
            return resultado;
        }

        public void CategoryAñadirAlCache(Category cat)
        {
            List<Category> lista = CategoryAll();
            lista.Add(cat);

            _cacheService.AddOrUpdate(
                ASF.UI.WbSite.Constants.CacheSetting.Category.Key,
                lista);
        }
    }
}