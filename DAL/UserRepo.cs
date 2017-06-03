using Entity.DBContext;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserRepo
    {
        public static List<User> GetAll()
        {
            using (ApiDBContext db = new ApiDBContext())
            {
                return db.Users.ToList();
            }
        }

        public static void Add(User user)
        {
            using (ApiDBContext db = new ApiDBContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public static void Update(User user, int id)
        {
            using (ApiDBContext db = new ApiDBContext())
            {
                var result = db.Users.FirstOrDefault(u => u.Id == id);
                result.FirstName = user.FirstName;
                result.LastName = user.LastName;
                db.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (ApiDBContext db = new ApiDBContext())
            {
                var result = db.Users.FirstOrDefault(u => u.Id == id);
                db.Users.Remove(result);
                db.SaveChanges();
            }
        }
    }
}
