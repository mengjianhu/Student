using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEntity
{
    [Table("t_studentbaseinfo")]
    public class StudentBaseInfo
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string sex { get; set; }
        public int age { get; set; }
        public string stuNum { get; set; }
        public string qqNum { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
     
    }
}
