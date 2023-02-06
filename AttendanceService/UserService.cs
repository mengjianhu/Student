using AttendanceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceService
{
    public class UserService
    {
        private AttendanceContext db = AttendanceContext.Instance;
        public int add(User user)
        {
            try
            {
                db.Users.Add(user);
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int find(string account, string password)
        {
            var ii = from a in db.Users
                     where (a.account == account)
                     select a;
            User u = ii.FirstOrDefault();
            if (u != null)
            {
                if (u.password == password)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return 0;


            //User u = db.Users.Where(a => a.account == account).FirstOrDefault();
            //if (u != null)
            //{
            //    if (u.password == password)
            //    {
            //        return 1;
            //    }
            //    else
            //    {
            //        return 0;
            //    }
            //}
            //return 0;
        }
    }
}
