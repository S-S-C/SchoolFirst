using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolFirst.Models
{
    public class Instructor
    {
              
            public Instructor()
            {
                this.Courses = new HashSet<Course>();
            }

            public int Id { get; set; }

            public virtual ICollection<Course> Courses { get; set; }

            public virtual ApplicationUser ApplicationUser { get; set; }
        }
}