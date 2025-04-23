using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni.DAL.Entity
{
    public class Takes
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Student")]
        public string SId { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey("Course")]
        public string CourseCode { get; set; }
        [Key, Column(Order = 2)]

        public string Semester { get; set; }
        [Key, Column(Order = 3)]

        public string Year { get; set; }
        public string Grade { get; set; }

        public virtual Student Student { get; set; }
        public ICollection<Course> Course { get; set; }


    }
}
