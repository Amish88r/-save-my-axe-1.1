using CourseManagementSystem.Models;
using CourseManagementSystem.Services;

namespace CourseManagementSystem;

class Program
{
    static void Main()
    {
        var system = new CourseManagementService();

        // Создание преподавателей
        var teacher1 = new Teacher("T001", "Кучебеев Алексей Викторович", "C# для чайников");
        var teacher2 = new Teacher("T002", "Слюсаренко Сергей Владимирович", "GO для начинающих");
        
        system.AddTeacher(teacher1);
        system.AddTeacher(teacher2);

        // Создание курсов
        var onlineCourse = new OnlineCourse("CS101", "C# для чайников", "Основы программирования на C# для начинающих", "Microsoft Teams", "teams.link/csharp");
        var offlineCourse = new OfflineCourse("GO201", "GO для начинающих", "Изучение языка программирования GO", "Аудитория 301", "Ср 14:00");
        
        system.AddCourse(onlineCourse);
        system.AddCourse(offlineCourse);

        // Назначение преподавателей
        system.AssignTeacherToCourse("CS101", teacher1);
        system.AssignTeacherToCourse("GO201", teacher2);

        // Добавление студентов
        var student1 = new Student("S001", "Мария Иванова", "maria@email.com");
        var student2 = new Student("S002", "Алексей Петров", "alex@email.com");
        var student3 = new Student("S003", "Екатерина Сидорова", "katya@email.com");
        
        system.EnrollStudentInCourse("CS101", student1);
        system.EnrollStudentInCourse("CS101", student2);
        system.EnrollStudentInCourse("GO201", student1);
        system.EnrollStudentInCourse("GO201", student3);

        // Вывод информации
        Console.WriteLine("Все курсы:");
        foreach (var course in system.GetAllCourses())
        {
            Console.WriteLine($"- {course}");
            Console.WriteLine($"  Преподаватель: {course.Teacher?.Name ?? "Не назначен"}");
            Console.WriteLine($"  Студентов: {course.Students.Count}");
            if (course.Students.Count > 0)
            {
                Console.WriteLine("  Список студентов:");
                foreach (var student in course.Students)
                {
                    Console.WriteLine($"    - {student}");
                }
            }
        }

        Console.WriteLine("\nКурсы преподавателя Кучебеева А.В.:");
        var kucheneevCourses = system.GetCoursesByTeacher("T001");
        foreach (var course in kucheneevCourses)
        {
            Console.WriteLine($"- {course.Name}");
        }

        Console.WriteLine("\nСтуденты курса 'C# для чайников':");
        var cs101Students = system.GetStudentsInCourse("CS101");
        foreach (var student in cs101Students)
        {
            Console.WriteLine($"- {student}");
        }
    }
}
