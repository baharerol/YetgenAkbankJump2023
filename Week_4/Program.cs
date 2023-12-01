using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Week_4.Contexts;
using Week_4.Entities;

class Program
{
    static void Main()
    {
        using (var context = new AppDbContext())
        {
            // Bulk Insert
            var newStudents = new List<Student>
            {
                new Student { Name = "John", Age = 22, Courses = new List<Course> { new Course { Title = "Math" }, new Course { Title = "Physics" } } },
                new Student { Name = "Jane", Age = 21, Courses = new List<Course> { new Course { Title = "Chemistry" }, new Course { Title = "Biology" } } },
                new Student { Name = "Bob", Age = 23, Courses = new List<Course> { new Course { Title = "Computer Science" } } }
            };
            context.Students.AddRange(newStudents);
            context.SaveChanges();

            // Update
            var studentToUpdate = context.Students.FirstOrDefault(s => s.Name == "John");
            if (studentToUpdate != null)
            {
                studentToUpdate.Age = 23;
                context.SaveChanges();
            }

            // Delete
            var studentToDelete = context.Students.FirstOrDefault(s => s.Name == "Bob");
            if (studentToDelete != null)
            {
                context.Students.Remove(studentToDelete);
                context.SaveChanges();
            }

            // Retrieve All Students and Their Courses
            var allStudents = context.Students.Include(s => s.Courses).ToList();
            Console.WriteLine("All Students:");
            foreach (var student in allStudents)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}");
                Console.WriteLine("Courses:");
                foreach (var course in student.Courses)
                {
                    Console.WriteLine($"  Id: {course.Id}, Title: {course.Title}");
                }
            }
        }

        Console.WriteLine("Operations completed successfully.");
    }
}