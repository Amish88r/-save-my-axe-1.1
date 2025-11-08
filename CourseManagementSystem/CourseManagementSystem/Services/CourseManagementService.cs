using CourseManagementSystem.Models;

namespace CourseManagementSystem.Services;

public class CourseManagementService
{
    private List<Course> _courses;
    private List<Teacher> _teachers;

    public CourseManagementService()
    {
        _courses = new List<Course>();
        _teachers = new List<Teacher>();
    }

    // Методы для работы с преподавателями
    public void AddTeacher(Teacher teacher)
    {
        if (!_teachers.Contains(teacher))
        {
            _teachers.Add(teacher);
        }
    }

    public void RemoveTeacher(Teacher teacher)
    {
        _teachers.Remove(teacher);
    }

    public List<Teacher> GetAllTeachers()
    {
        return new List<Teacher>(_teachers);
    }

    // Методы для работы с курсами
    public void AddCourse(Course course)
    {
        if (!_courses.Contains(course))
        {
            _courses.Add(course);
        }
    }

    public void RemoveCourse(Course course)
    {
        _courses.Remove(course);
    }

    public List<Course> GetAllCourses()
    {
        return new List<Course>(_courses);
    }

    // Назначение преподавателя на курс
    public void AssignTeacherToCourse(string courseId, Teacher teacher)
    {
        var course = _courses.FirstOrDefault(c => c.CourseId == courseId);
        if (course != null)
        {
            course.Teacher = teacher;
        }
    }

    // Получение курсов преподавателя
    public List<Course> GetCoursesByTeacher(string teacherId)
    {
        return _courses.Where(c => c.Teacher?.Id == teacherId).ToList();
    }

    // Добавление студента на курс
    public void EnrollStudentInCourse(string courseId, Student student)
    {
        var course = _courses.FirstOrDefault(c => c.CourseId == courseId);
        course?.AddStudent(student);
    }

    // Получение студентов курса
    public List<Student> GetStudentsInCourse(string courseId)
    {
        var course = _courses.FirstOrDefault(c => c.CourseId == courseId);
        return course?.Students ?? new List<Student>();
    }
}