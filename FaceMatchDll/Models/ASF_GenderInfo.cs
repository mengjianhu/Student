using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceMatchDll.Models
{
    /// <summary>
    /// 性别结构体
    /// </summary>
    public struct ASF_GenderInfo
    {
        /// <summary>
        /// 性别检测结果集合
        /// </summary>
        public IntPtr genderArray;
        /// <summary>
        /// 结果集大小
        /// </summary>
        public int num;
    }
}
