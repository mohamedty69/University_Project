using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni.DAL.Entity
{
    public class Teaches
    {
        [Key, Column(Order = 0)]
        public string IId { get; set; }
        [Key, Column(Order = 1)]
        public string CId { get; set; }
        [Key, Column(Order = 2)]
        public string Semester { get; set; }
        [Key, Column(Order = 3)]
        public int Year { get; set; }

        public virtual Instructor Instructor { get; set; }

    }
}
