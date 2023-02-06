using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite.EF6;
using AttendanceEntity;
using System.Data.Common;
using System.Data.Entity;
using System.Configuration;

namespace AttendanceService
{
    public class AttendanceContext: DbContext
    {
        static string dbPath = @"Data Source=.\db\kaoqin.db";
        public static AttendanceContext Instance
        {
            get
            {
                DbConnection sqliteCon = SQLiteProviderFactory.Instance.CreateConnection();
                sqliteCon.ConnectionString = dbPath;
                return new AttendanceContext(sqliteCon);
            }
        }
        private AttendanceContext(DbConnection con) : base(con, true)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Employeer> Employeers { get; set; }
        public DbSet<SuccessInfo> SuccessInfos { get; set; }

    }
}
