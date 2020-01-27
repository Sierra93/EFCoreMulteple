using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreMulteple {
    /// <summary>
    /// Класс связующей сущности позволяющий создавать более одной таблицы используя один контекст данных
    /// </summary>
    public class StudentCource {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Cource Course { get; set; }
    }
}
