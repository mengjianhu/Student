using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentEntity;
namespace StudentService
{
    public class LoginService
    {
        private StudentDbContext db = StudentDbContext.Instance;
        /// <summary>
        /// 注册账号
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        public async Task<int> add(UserLogin userLogin)
        {
            try
            {
                db.UserLogins.Add(userLogin);
                return await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("注册信息异常：" + ex.Message);
            }

        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public async Task<UserLogin> fingByAccount(string account, string password)
        {
            try
            {
                
                IQueryable<UserLogin> ii = from a in db.UserLogins
                                           where (a.account == account)
                                           select a;

                UserLogin uu = await ii.FirstOrDefaultAsync();

                return uu;
                //return await db.UserLogins.Where(a => a.account == account && a.password == password).FirstOrDefaultAsync<UserLogin>();
            }
            catch (Exception ex)
            {
                throw new Exception("查询信息异常：" + ex.Message);
            }

        }
    }
}
