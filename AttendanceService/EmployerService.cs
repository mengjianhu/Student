using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceEntity;
namespace AttendanceService
{
    public class EmployerService
    {
        private AttendanceContext db = AttendanceContext.Instance;
        /// <summary>
        /// 注册人脸
        /// </summary>
        /// <param name="employeer"></param>
        /// <returns></returns>
        public int add(Employeer employeer)
        {
            try
            {
                db.Employeers.Add(employeer);
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public Employeer findwithJobNum(string jobNum)
        {
            try
            {
                Employeer employeer = db.Employeers.Where(a => a.jobNum == jobNum).FirstOrDefault();
                return employeer;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public List<Employeer> findAll()
        {
            try
            {
                return db.Employeers.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
