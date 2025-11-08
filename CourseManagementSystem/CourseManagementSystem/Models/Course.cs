namespace CourseManagementSystem.Models;

public abstract class Course
{
    public string CourseId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Teacher Teacher { get; set; }
    public List<Student> Students { get; set; }

    protected Course(string courseId, string name, string description)
    {
        CourseId = courseId;
        Name = name;
        Description = description;
        Students = new List<Student>();
    }

    public virtual void AddStudent(Student student)
    {
        if (!Students.Contains(student))
        {
            Students.Add(student);
        }
    }

    public virtual void RemoveStudent(Student student)
    {
        Students.Remove(student);
    }

    public abstract string GetCourseType();

    public override string ToString()
    {
        return $"{CourseId}: {Name} - {GetCourseType()}";
    }
}