using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public List<string> Courses { get; set; }
}

//class Program
//{
//    static void Main()
//    {
//        List<Student> students1 = new List<Student>
//        {
//            new Student { Name = "Alice", Age = 20, Courses = new List<string> { "Math", "Physics" } },
//            new Student { Name = "Bob", Age = 22, Courses = new List<string> { "Chemistry", "Biology" } },
//        };

//        List<Student> students2 = new List<Student>
//        {
//            new Student { Name = "Charlie", Age = 21, Courses = new List<string> { "Math", "Computer Science" } },
//            new Student { Name = "David", Age = 23, Courses = new List<string> { "Physics", "Computer Science" } }
//        };

//        // Concatenate two student lists
//        var concatenatedStudents = students1.Concat(students2);
//        Console.WriteLine("Concatenated Students:");
//        PrintStudents(concatenatedStudents);

//        // Distinct students by name
//        var distinctStudents = concatenatedStudents.DistinctBy(student => student.Name);
//        Console.WriteLine("\nDistinct Students:");
//        PrintStudents(distinctStudents);

//        // Skip the first student in the distinct list
//        var skippedStudent = distinctStudents.Skip(1).FirstOrDefault();
//        Console.WriteLine("\nSkipped Student:");
//        PrintStudent(skippedStudent);

//        // Take the next student from the skipped list
//        var takenStudent = distinctStudents.Skip(1).Take(1).FirstOrDefault();
//        Console.WriteLine("\nTaken Student:");
//        PrintStudent(takenStudent);
//    }

//    static void PrintStudents(IEnumerable<Student> students)
//    {
//        foreach (var student in students)
//        {
//            PrintStudent(student);
//        }
//    }

//    static void PrintStudent(Student student)
//    {
//        Console.WriteLine($"Name: {student?.Name}, Age: {student?.Age}, Courses: {string.Join(", ", student?.Courses)}");
//    }
//}

//static class Extensions
//{
//    public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
//    {
//        HashSet<TKey> seenKeys = new HashSet<TKey>();
//        foreach (T element in source)
//        {
//            if (seenKeys.Add(keySelector(element)))
//            {
//                yield return element;
//            }
//        }
//    }
//}



class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student { Name = "Alice", Age = 20, Courses = new List<string> { "Math", "Physics" } },
            new Student { Name = "Bob", Age = 22, Courses = new List<string> { "Chemistry", "Biology" } },
            new Student { Name = "Charlie", Age = 21, Courses = new List<string> { "Math", "Computer Science" } },
            new Student { Name = "David", Age = 23, Courses = new List<string> { "Physics", "Computer Science" } }
        };

        // LINQ queries
        var mathStudents = students.Where(student => student.Courses.Contains("Math"));
        var orderedByAge = students.OrderBy(student => student.Age);
        var groupedByAge = students.GroupBy(student => student.Age);
        var selectedNames = students.Select(student => student.Name);

        // Print results
        Console.WriteLine("Students taking Math:");
        PrintStudents(mathStudents);

        Console.WriteLine("\nStudents ordered by Age:");
        PrintStudents(orderedByAge);

        Console.WriteLine("\nStudents grouped by Age:");
        PrintGroupedStudents(groupedByAge);

        Console.WriteLine("\nStudent Names:");
        PrintList(selectedNames);
    }

    static void PrintStudents(IEnumerable<Student> students)
    {
        foreach (var student in students)
        {
            Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Courses: {string.Join(", ", student.Courses)}");
        }
    }

    static void PrintGroupedStudents(IEnumerable<IGrouping<int, Student>> groupedStudents)
    {
        foreach (var group in groupedStudents)
        {
            Console.WriteLine($"Age: {group.Key}");
            PrintStudents(group);
            Console.WriteLine();
        }
    }

    static void PrintList(IEnumerable<string> list)
    {
        foreach (var item in list)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();
    }
}
