using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni.DAL.Entity
{
    public class Department
    {
        [Key]
        public string DeptName { get; set; }
        public string Building { get; set; }
        public string Head { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
        public virtual ICollection<AcademicStatus> AcademicStatus { get; set; }


    }
}
