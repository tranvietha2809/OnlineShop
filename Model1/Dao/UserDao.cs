using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model1.EF;
using PagedList;

namespace Model1.Dao
{
    //DAO layer to interact with User database
    public class UserDao
    {
        OnlineShopDbContext db = null;
        public UserDao()
        {
            db = new OnlineShopDbContext();
        }

        //Insert new user to the database
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        //Update data of existing user
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                user.Name = entity.Name;
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        //Get all users from the database record
        public IEnumerable<User> ListAll(int page, int pageSize)
        {
            return db.Users.OrderBy(user => user.ID).ToPagedList(page, pageSize);
        }

        // Get an user from a provided username
        public User GetUserByName(string userName)
        {
            return db.Users.SingleOrDefault(u => u.UserName == userName);
        }

        //Get an user from a provided ID
        public User GetUserByID(long id)
        {
            return db.Users.Find(id);
        }

        //Login an user to the database
        //Return: -2 if wrong password
        //      : -1 if user is deactivated/inactivated
        //      :  0 if username is not found in database
        //      :  1 if OK
        public int Login(string userName, string passWord)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName);
            if(result == null)
            {
                return 0;
            }
            else
            {
                if(result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if(result.Password == passWord)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }
    }
}
