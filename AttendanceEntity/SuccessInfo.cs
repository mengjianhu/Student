using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceEntity
{
    [Table("t_score")]
    public class SuccessInfo
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string jobNum { get; set; }
        public float score { get; set; }
        public string datetime { get; set; }
    }
}
