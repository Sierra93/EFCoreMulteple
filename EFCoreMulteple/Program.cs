using EFCoreMulteple;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreMultiple {
    class Program {
        static void Main(string[] args) {
            using (ApplicationContext db = new ApplicationContext()) {
                Student s1 = new Student { Name = "Tom" };
                Student s2 = new Student { Name = "Alice" };
                Student s3 = new Student { Name = "Bob" };
                db.Students.AddRange(new List<Student> { s1, s2, s3 });

                Cource c1 = new Cource { Name = "Алгоритмы" };
                Cource c2 = new Cource { Name = "Основы программирования" };
                db.Cources.AddRange(new List<Cource> { c1, c2 });

                db.SaveChanges();

                // добавляем к студентам курсы
                s1.StudentCources.Add(new StudentCource { CourseId = c1.Id, StudentId = s1.Id });
                s2.StudentCources.Add(new StudentCource { CourseId = c1.Id, StudentId = s2.Id });
                s2.StudentCources.Add(new StudentCource { CourseId = c2.Id, StudentId = s2.Id });
                db.SaveChanges();

                var courses = db.Cources.Include(c => c.StudentCources).ThenInclude(sc => sc.Student).ToList();
                // выводим все курсы
                foreach (var c in courses) {
                    Console.WriteLine($"\n Course: {c.Name}");
                    // выводим всех студентов для данного кура
                    var students = c.StudentCources.Select(sc => sc.Student).ToList();
                    foreach (Student s in students)
                        Console.WriteLine($"{s.Name}");
                }
            }
            Console.ReadKey();
        }
    }
}
