using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model1.EF;

namespace Model1.Dao
{
    public class ProductDao
    {
        OnlineShopDbContext db = null;
        public ProductDao()
        {
            db = new OnlineShopDbContext(); 
        }

        public List<Product> ListSameCategory(long cateID)
        {
            return db.Products.Where(x => x.CategoryID == cateID).ToList();
        }
        public List<Product> ListNewProduct(int top)
        {
            return db.Products.OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }

        public List<Product> ListRelatedProducts(long productID)
        {
            var product = db.Products.Find(productID);
            return db.Products.Where(x => x.Id != productID && x.CategoryID == product.CategoryID).ToList();
        }

        public Product ViewDetail(long productID)
        {
            return db.Products.Find(productID);
        }
    }
}
