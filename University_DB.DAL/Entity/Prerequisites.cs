using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni.DAL.Entity
{
    public class Prerequisites
    {
        [Key, Column(Order = 0)]
        public string CourseId { get; set; }
        [Key, Column(Order = 1)]
        public string PrerequisiteId { get; set; }
        //public virtual Course Course { get; set; }
        //public virtual Course Prerequisite { get; set; }
    }
}
