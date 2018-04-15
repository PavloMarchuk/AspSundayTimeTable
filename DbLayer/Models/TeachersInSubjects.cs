using System;
using System.Collections.Generic;

namespace DbLayer.Models
{
    public partial class TeachersInSubjects
    {
        public int TeachersInSubjectsId { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }

        public Subjects Subject { get; set; }
        public Teachers Teacher { get; set; }
    }
}
