using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni.DAL.Entity
{
    public class Records
    {
        [Key]
        public int recordId { get; set; }
        [ForeignKey("Student")]
        public string SId { get; set; }
        public string CourseCode { get; set; }
        public string Grade { get; set; }
        public bool Improved { get; set; }
        public string Semester { get; set; }
        public string Year { get; set; }

        public virtual Student Student { get; set; }
    }
}
