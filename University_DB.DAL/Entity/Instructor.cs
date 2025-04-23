using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni.DAL.Entity
{
    public class Instructor
    {
        [Key]
        public string IId { get; set; }
        public string Name { get; set; }
        [ForeignKey("Department")]
        public string DeptName { get; set; }
        public double Salary { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<Teaches> Teaches { get; set; }
    }
}
