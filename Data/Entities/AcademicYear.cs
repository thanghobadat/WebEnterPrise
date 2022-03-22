using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class AcademicYear
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Idea> Ideas { get; set; }
    }
}
