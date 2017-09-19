﻿
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASF.Entities;
using ASF.Data;


namespace ASF.Business
{
    /// <summary>
    /// CountryBusiness business component.
    /// </summary>
    public class CountryBusiness
    {
        /// <summary>
        /// Add method. 
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public Country Add(Country country)
        {
            var countryDac = new CountryDac();
            return countryDac.Create(country);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            var countryDac = new CountryDac();
            countryDac.DeleteById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Country> All()
        {
            var countryDac = new CountryDac();
            var result = countryDac.Select();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Country Find(int id)
        {
            var countryDac = new CountryDac();
            var result = countryDac.SelectById(id);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="country"></param>
        public void Edit(Country country)
        {
            var countryDac = new CountryDac();
            countryDac.UpdateById(country);
        }
    }
}
