using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEntity
{
    /// <summary>
    /// 用户登录类
    /// </summary>
    [Table("t_login")]
    public class UserLogin
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int id { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }

    }
}
