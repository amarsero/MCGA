﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASF.Entities;
using ASF.Data;


namespace ASF.Business
{
    /// <summary>
    /// DealerBusiness business component.
    /// </summary>
    public class DealerBusiness
    {
        /// <summary>
        /// Add method. 
        /// </summary>
        /// <param name="dealer"></param>
        /// <returns></returns>
        public Dealer Add(Dealer dealer)
        {
            var dealerDac = new DealerDac();
            return dealerDac.Create(dealer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            var dealerDac = new DealerDac();
            dealerDac.DeleteById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Dealer> All()
        {
            var dealerDac = new DealerDac();
            var result = dealerDac.Select();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Dealer Find(int id)
        {
            var dealerDac = new DealerDac();
            var result = dealerDac.SelectById(id);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dealer"></param>
        public void Edit(Dealer dealer)
        {
            var dealerDac = new DealerDac();
            dealerDac.UpdateById(dealer);
        }
    }
}
