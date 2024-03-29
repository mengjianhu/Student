﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceMatchDll.Models
{
    public struct ASF_LivenessInfo
    {
        /// <summary>
        /// 是否是真人 
        /// 0：非真人；1：真人；-1：不确定；-2:传入人脸数>1；
        /// </summary>
        public IntPtr isLive;
        /// <summary>
        /// 结果集大小
        /// </summary>
        public int num;
    }
}
