using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni.DAL.Entity
{
    public class AcademicStatus
    {
        [Key]
        public int StatusId { get; set; }
        [ForeignKey("Department")]
        public string DeptName { get; set; }
        public int TotalCredit { get; set; }
        public int Improvement { get; set; } = 0;
        public int CurrentYear { get; set; } = 0;
        public int TotalYears { get; set; } = 1;
        public double CGPA { get; set; } = 0;
        public int Warnings { get; set; } = 0;
        [ForeignKey("Student")]
        public string SId { get; set; }
       
        public virtual Department Department { get; set; }

     
        public virtual Student Student { get; set; }


    }
}
