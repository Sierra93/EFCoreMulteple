using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreMulteple {
    public class Student {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StudentCource> StudentCources { get; set; } 
        public Student() {
            StudentCources = new List<StudentCource>();
        }
    }
}
