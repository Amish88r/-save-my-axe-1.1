using CourseManagementSystem.Models;
using CourseManagementSystem.Services;

namespace CourseManagementSystem.Tests;

public class CourseManagementTests
{
    [Fact]
    public void AddCourse_ShouldAddCourseToSystem()
    {
        // Arrange
        var system = new CourseManagementService();
        var course = new OnlineCourse("CS101", "Programming", "Basic programming", "Zoom", "zoom.link");

        // Act
        system.AddCourse(course);

        // Assert
        var courses = system.GetAllCourses();
        Assert.Single(courses);
        Assert.Equal("CS101", courses[0].CourseId);
    }

    [Fact]
    public void RemoveCourse_ShouldRemoveCourseFromSystem()
    {
        // Arrange
        var system = new CourseManagementService();
        var course = new OnlineCourse("CS101", "Programming", "Basic programming", "Zoom", "zoom.link");
        system.AddCourse(course);

        // Act
        system.RemoveCourse(course);

        // Assert
        var courses = system.GetAllCourses();
        Assert.Empty(courses);
    }

    [Fact]
    public void AssignTeacherToCourse_ShouldSetCourseTeacher()
    {
        // Arrange
        var system = new CourseManagementService();
        var course = new OnlineCourse("CS101", "Programming", "Basic programming", "Zoom", "zoom.link");
        var teacher = new Teacher("T001", "John Doe", "Computer Science");
        
        system.AddCourse(course);
        system.AddTeacher(teacher);

        // Act
        system.AssignTeacherToCourse("CS101", teacher);

        // Assert
        Assert.Equal(teacher, course.Teacher);
    }

    [Fact]
    public void GetCoursesByTeacher_ShouldReturnCorrectCourses()
    {
        // Arrange
        var system = new CourseManagementService();
        var teacher = new Teacher("T001", "John Doe", "Computer Science");
        
        var course1 = new OnlineCourse("CS101", "Programming", "Basic programming", "Zoom", "zoom.link");
        var course2 = new OfflineCourse("CS102", "Algorithms", "Advanced algorithms", "Room 101", "Mon 10:00");
        
        system.AddTeacher(teacher);
        system.AddCourse(course1);
        system.AddCourse(course2);
        
        system.AssignTeacherToCourse("CS101", teacher);
        system.AssignTeacherToCourse("CS102", teacher);

        // Act
        var teacherCourses = system.GetCoursesByTeacher("T001");

        // Assert
        Assert.Equal(2, teacherCourses.Count);
    }

    [Fact]
    public void EnrollStudentInCourse_ShouldAddStudentToCourse()
    {
        // Arrange
        var system = new CourseManagementService();
        var course = new OnlineCourse("CS101", "Programming", "Basic programming", "Zoom", "zoom.link");
        var student = new Student("S001", "Alice", "alice@email.com");
        
        system.AddCourse(course);

        // Act
        system.EnrollStudentInCourse("CS101", student);

        // Assert
        var students = system.GetStudentsInCourse("CS101");
        Assert.Single(students);
        Assert.Equal("S001", students[0].Id);
    }

    [Fact]
    public void OnlineCourse_ShouldReturnCorrectCourseType()
    {
        // Arrange
        var course = new OnlineCourse("CS101", "Programming", "Basic programming", "Zoom", "zoom.link");

        // Act
        var courseType = course.GetCourseType();

        // Assert
        Assert.Equal("Online Course on Zoom", courseType);
    }

    [Fact]
    public void OfflineCourse_ShouldReturnCorrectCourseType()
    {
        // Arrange
        var course = new OfflineCourse("CS102", "Algorithms", "Advanced algorithms", "Room 101", "Mon 10:00");

        // Act
        var courseType = course.GetCourseType();

        // Assert
        Assert.Equal("Offline Course in Room 101", courseType);
    }
}