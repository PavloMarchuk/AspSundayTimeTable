using System;
using System.Collections.Generic;

namespace DbLayer.Models
{
    public partial class Students
    {
        public int StudentId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int GroupId { get; set; }

        public Groups Group { get; set; }
    }
}
