using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model1.EF;

namespace Model1.Dao
{
    public class SubMenuDao
    {
        OnlineShopDbContext db = null;
        public SubMenuDao()
        {
            db = new OnlineShopDbContext();
        }
        public List<SubMenu> getSubMenuByType(string type)
        {
            return db.SubMenus.Where(x => x.Type == type).OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}
