using CourseManagementSystem.Models;
using CourseManagementSystem.Services;

namespace CourseManagementSystem;

class Program
{
    static void Main()
    {
        var system = new CourseManagementService();

        // Создание преподавателей
        var teacher1 = new Teacher("T001", "Dr. Smith", "Computer Science");
        var teacher2 = new Teacher("T002", "Prof. Johnson", "Mathematics");
        
        system.AddTeacher(teacher1);
        system.AddTeacher(teacher2);

        // Создание курсов
        var onlineCourse = new OnlineCourse("CS101", "C# Programming", "Learn C# programming", "Microsoft Teams", "teams.link");
        var offlineCourse = new OfflineCourse("MATH201", "Advanced Math", "University mathematics", "Room 301", "Wed 14:00");
        
        system.AddCourse(onlineCourse);
        system.AddCourse(offlineCourse);

        // Назначение преподавателей
        system.AssignTeacherToCourse("CS101", teacher1);
        system.AssignTeacherToCourse("MATH201", teacher2);

        // Добавление студентов
        var student1 = new Student("S001", "Alice", "alice@email.com");
        var student2 = new Student("S002", "Bob", "bob@email.com");
        
        system.EnrollStudentInCourse("CS101", student1);
        system.EnrollStudentInCourse("CS101", student2);
        system.EnrollStudentInCourse("MATH201", student1);

        // Вывод информации
        Console.WriteLine("All Courses:");
        foreach (var course in system.GetAllCourses())
        {
            Console.WriteLine($"- {course}");
            Console.WriteLine($"  Teacher: {course.Teacher?.Name ?? "Not assigned"}");
            Console.WriteLine($"  Students: {course.Students.Count}");
            if (course.Students.Count > 0)
            {
                Console.WriteLine("  Student List:");
                foreach (var student in course.Students)
                {
                    Console.WriteLine($"    - {student}");
                }
            }
        }

        Console.WriteLine("\nCourses taught by Dr. Smith:");
        var smithCourses = system.GetCoursesByTeacher("T001");
        foreach (var course in smithCourses)
        {
            Console.WriteLine($"- {course.Name}");
        }

        Console.WriteLine("\nStudents in CS101 course:");
        var cs101Students = system.GetStudentsInCourse("CS101");
        foreach (var student in cs101Students)
        {
            Console.WriteLine($"- {student}");
        }
    }
}