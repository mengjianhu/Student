using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceEntity
{
    [Table("t_imagefaceRegist")]
    public class Employeer
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string jobNum { get; set; }
        public string imageFace { get; set; }
    }
}
