using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using ASF.Data;
using System.Transactions;

namespace ASF.Business
{
    public class ProductBusiness
    {

        /// <summary>
        /// Add method. 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public Product Add(Product product)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var productDac = new ProductDac();
                DealerDac dd = new DealerDac();

                Dealer dealer = dd.SelectById(product.DealerId);
                dealer.TotalProducts++;
                dd.UpdateById(dealer);

                var pro = productDac.Create(product);

                ts.Complete();

                return pro;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var productDac = new ProductDac();
                DealerDac dd = new DealerDac();
                var product = productDac.SelectById(id);
                Dealer dealer = dd.SelectById(product.DealerId);

                dealer.TotalProducts--;
                dd.UpdateById(dealer);

                var ratingDac = new RatingDac();
                ratingDac.DeleteByProductId(id);
                
                productDac.DeleteById(id);
                ts.Complete();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Product> All(int pageNumber, int pageSize)
        {
            var productDac = new ProductDac();
            var result = productDac.SelectOrderByTitle(pageNumber, pageSize);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product Find(int id)
        {
            var productDac = new ProductDac();
            var result = productDac.SelectById(id);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        public void Edit(Product product)
        {
            var productDac = new ProductDac();
            productDac.UpdateById(product);
        }
    }
}
