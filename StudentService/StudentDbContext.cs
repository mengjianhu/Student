using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SQLite.EF6;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentEntity;
namespace StudentService
{
    public class StudentDbContext:DbContext
    {
        static string dbPath = @"Data Source=.\db\studentdb.db";
        public static StudentDbContext Instance
        {
            get
            {
                DbConnection sqliteCon = SQLiteProviderFactory.Instance.CreateConnection();
                sqliteCon.ConnectionString = dbPath;
                return new StudentDbContext(sqliteCon);
            }
        }
        private StudentDbContext(DbConnection con) : base(con, true)
        {

        }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<StudentBaseInfo> StudentBaseInfos { get; set; }
    }
    
}
