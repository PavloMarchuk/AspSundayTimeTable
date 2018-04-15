using System;
using System.Collections.Generic;

namespace DbLayer.Models
{
    public partial class Lessons
    {
        public int LessonId { get; set; }
        public DateTime LessoDatetime { get; set; }
        public string Cabinet { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        public int GroupId { get; set; }

        public Groups Group { get; set; }
        public Subjects Subject { get; set; }
        public Teachers Teacher { get; set; }
    }
}
