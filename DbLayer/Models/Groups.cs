using System;
using System.Collections.Generic;

namespace DbLayer.Models
{
    public partial class Groups
    {
        public Groups()
        {
            Lessons = new HashSet<Lessons>();
            Students = new HashSet<Students>();
        }

        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string CourseName { get; set; }
        public string Specialization { get; set; }

        public ICollection<Lessons> Lessons { get; set; }
        public ICollection<Students> Students { get; set; }
    }
}
