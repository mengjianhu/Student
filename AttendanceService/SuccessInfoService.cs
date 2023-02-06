using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceEntity;
namespace AttendanceService
{
    public class SuccessInfoService
    {
        private AttendanceContext db = AttendanceContext.Instance;
        public async Task<int> add(SuccessInfo successInfo)
        {
            try
            {
                db.SuccessInfos.Add(successInfo);
                return await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }
        public List<SuccessInfo> findall()
        {
            try
            {
                return db.SuccessInfos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
