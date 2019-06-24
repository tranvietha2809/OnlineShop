using System;
using Model1.EF;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.Dao
{
    public class MenuDao
    {
        OnlineShopDbContext db = null;
        public MenuDao()
        {
            db = new OnlineShopDbContext();
        }

        public List<Menu> ListByType(string Type)
        {
            return db.Menus.Where(x => x.Type == Type && x.Status == 1).OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}
