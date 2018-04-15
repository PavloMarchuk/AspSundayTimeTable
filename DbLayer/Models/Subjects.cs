using System;
using System.Collections.Generic;

namespace DbLayer.Models
{
    public partial class Subjects
    {
        public Subjects()
        {
            Lessons = new HashSet<Lessons>();
            TeachersInSubjects = new HashSet<TeachersInSubjects>();
        }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public ICollection<Lessons> Lessons { get; set; }
        public ICollection<TeachersInSubjects> TeachersInSubjects { get; set; }
    }
}
