using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model1.EF;

namespace Model1.Dao
{
    public class FooterDao
    {
        OnlineShopDbContext db = null;

        public FooterDao()
        {
            db = new OnlineShopDbContext();
        }

        public Footer GetFooter() 
        {
            return db.Footers.SingleOrDefault(x => x.Status == true);
        }
    }
}
