namespace CourseManagementSystem.Models;

public class OfflineCourse : Course
{
    public string Classroom { get; set; }
    public string Schedule { get; set; }

    public OfflineCourse(string courseId, string name, string description, string classroom, string schedule) 
        : base(courseId, name, description)
    {
        Classroom = classroom;
        Schedule = schedule;
    }

    public override string GetCourseType()
    {
        return $"Offline Course in {Classroom}";
    }

    public override string ToString()
    {
        return base.ToString() + $", Classroom: {Classroom}, Schedule: {Schedule}";
    }
}