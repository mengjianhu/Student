using StudentEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace StudentService
{
    public class StudentBaseInfoService
    {
        private StudentDbContext db = StudentDbContext.Instance;
        public int add(StudentBaseInfo studentBaseInfo)
        {
            //using (var tray = db.Database.BeginTransaction())
            //{
            //    try
            //    {
            //        db.StudentBaseInfos.Add(studentBaseInfo);
            //        int i = db.SaveChanges();
            //        tray.Commit();
            //        return i; 
            //    }
            //    catch (Exception ex)
            //    {
            //        tray.Rollback();
            //        throw new Exception(ex.Message);
            //    }
            //}
            try
            {
                db.StudentBaseInfos.Add(studentBaseInfo);
                int i = db.SaveChanges();
                return i;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pagenNum">页数</param>
        /// <param name="pageSize">每页条数</param>
        /// <returns></returns>
        public List<StudentBaseInfo> findByPage(int pagenNum, int pageSize)
        {
            try
            {
                return db.StudentBaseInfos.ToList().Skip((pagenNum - 1) * pageSize).Take(pageSize).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("查询信息异常" + ex.Message);
            }

        }
        /// <summary>
        /// 查询总页数
        /// </summary>
        /// <param name="pageSize">每页条数</param>
        /// <returns></returns>
        public async Task<int> findAllPage(int pageSize)
        {
            try
            {
                string sqlstr = "SELECT count(*) from  t_studentbaseinfo";
                int num = await db.Database.SqlQuery<int>(sqlstr).SingleOrDefaultAsync();
                return num % pageSize == 0 ? num / pageSize : num / pageSize + 1;
            }
            catch (Exception ex)
            {
                throw new Exception("查询信息异常" + ex.Message);
            }

        }
        /// <summary>
        /// 根据姓名查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<List<StudentBaseInfo>> findByName(string name)
        {
            try
            {
                return await db.StudentBaseInfos.Where(a => a.name == name).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        /// <summary>
        /// 根据学号查询
        /// </summary>
        /// <param name="stuNum"></param>
        /// <returns></returns>
        public async Task< StudentBaseInfo> findByStuNum(string stuNum)
        {
            try
            {
                return await db.StudentBaseInfos.Where(a => a.stuNum == stuNum).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="studentBaseInfo"></param>
        /// <returns></returns>
        public async Task<int> update(StudentBaseInfo studentBaseInfo)
        {
            try
            {

                db.Entry<StudentBaseInfo>(studentBaseInfo).State = System.Data.Entity.EntityState.Modified;
                return await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 根据学号删除信息
        /// </summary>
        /// <param name="stuNum"></param>
        /// <returns></returns>
        public async Task<int> del(string stuNum)
        {
            try
            {
                StudentBaseInfo studentBaseInfo = findByStuNum(stuNum).Result;
                if (studentBaseInfo != null)
                {
                    db.StudentBaseInfos.Remove(studentBaseInfo);
                    return await db.SaveChangesAsync();
                }
                return -1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }
    }
}
