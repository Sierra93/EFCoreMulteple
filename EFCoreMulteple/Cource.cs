using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreMulteple {
    public class Cource {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StudentCource> StudentCources { get; set; }

        public Cource() { 
            StudentCources = new List<StudentCource>();
        }
    }
}
