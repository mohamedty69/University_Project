using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni.DAL.Entity
{
    public class Profile
    {
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public string? Image { get; set; }
        [ForeignKey("Student")]
        public string SId { get; set; }

        public virtual Student Student { get; set; }


    }
}
