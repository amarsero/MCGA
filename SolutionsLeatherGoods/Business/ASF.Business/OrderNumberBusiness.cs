//====================================================================================================
// Base code generated with LeatherGoods - ASF.Business
// Architecture Solutions Foundation
//
// Generated by academic at LeatherGoods V 1.0 
//====================================================================================================

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASF.Entities;
using ASF.Data;


namespace ASF.Business
{
    /// <summary>
    /// OrderNumberBusiness business component.
    /// </summary>
    public class OrderNumberBusiness
    {
        /// <summary>
        /// Add method. 
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public OrderNumber Add(OrderNumber orderNumber)
        {
            var orderNumberDac = new OrderNumberDac();
            return orderNumberDac.Create(orderNumber);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            var orderNumberDac = new OrderNumberDac();
            orderNumberDac.DeleteById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<OrderNumber> All()
        {
            var orderNumberDac = new OrderNumberDac();
            var result = orderNumberDac.Select();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrderNumber Find(int id)
        {
            var orderNumberDac = new OrderNumberDac();
            var result = orderNumberDac.SelectById(id);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderNumber"></param>
        public void Edit(OrderNumber orderNumber)
        {
            var orderNumberDac = new OrderNumberDac();
            orderNumberDac.UpdateById(orderNumber);
        }
    }
}
