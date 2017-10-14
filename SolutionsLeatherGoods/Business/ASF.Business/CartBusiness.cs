﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class CartBusiness
    {

        /// <summary>
        /// Add method. 
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public Cart Add(Cart cart)
        {
            var cartDac = new CartDac();
            return cartDac.Create(cart);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            var cartDac = new CartDac();
            cartDac.DeleteById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Cart> All()
        {
            var cartDac = new CartDac();
            var result = cartDac.Select();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Cart Find(int id)
        {
            var cartDac = new CartDac();
            var result = cartDac.SelectById(id);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cart"></param>
        public void Edit(Cart cart)
        {
            var cartDac = new CartDac();
            cartDac.UpdateById(cart);
        }
    }
}
