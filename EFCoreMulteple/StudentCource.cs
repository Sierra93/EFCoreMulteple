using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreMulteple {
    public class StudentCource {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Cource Course { get; set; }
    }
}
