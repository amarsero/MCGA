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
    /// OrderDetailBusiness business component.
    /// </summary>
    public class OrderDetailBusiness
    {
        /// <summary>
        /// Add method. 
        /// </summary>
        /// <param name="orderDetail"></param>
        /// <returns></returns>
        public OrderDetail Add(OrderDetail orderDetail)
        {
            var orderDetailDac = new OrderDetailDac();
            var orderDac = new OrderDac();

            Order order = orderDac.SelectById(orderDetail.OrderId);

            order.TotalPrice += orderDetail.Price * orderDetail.Quantity;
            order.ItemCount += 1;

            orderDac.UpdateById(order);

            return orderDetailDac.Create(orderDetail);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            var orderDetailDac = new OrderDetailDac();
            orderDetailDac.DeleteById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<OrderDetail> All()
        {
            var orderDetailDac = new OrderDetailDac();
            var result = orderDetailDac.Select();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrderDetail Find(int id)
        {
            var orderDetailDac = new OrderDetailDac();
            var result = orderDetailDac.SelectById(id);
            return result;
        }

        public List<OrderDetail> FindByOrderId(int id)
        {
            var orderDetailDac = new OrderDetailDac();
            var result = orderDetailDac.SelectByOrderId(id);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderDetail"></param>
        public void Edit(OrderDetail orderDetail)
        {
            var orderDetailDac = new OrderDetailDac();
            orderDetailDac.UpdateById(orderDetail);
        }
    }
}
