using System;
using System.Collections.Generic;

namespace DbLayer.Models
{
    public partial class Teachers
    {
        public Teachers()
        {
            Lessons = new HashSet<Lessons>();
            TeachersInSubjects = new HashSet<TeachersInSubjects>();
        }

        public int TeacherId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public ICollection<Lessons> Lessons { get; set; }
        public ICollection<TeachersInSubjects> TeachersInSubjects { get; set; }
    }
}
