namespace CourseManagementSystem.Models;

public class OnlineCourse : Course
{
    public string Platform { get; set; }
    public string MeetingLink { get; set; }

    public OnlineCourse(string courseId, string name, string description, string platform, string meetingLink) 
        : base(courseId, name, description)
    {
        Platform = platform;
        MeetingLink = meetingLink;
    }

    public override string GetCourseType()
    {
        return $"Online Course on {Platform}";
    }

    public override string ToString()
    {
        return base.ToString() + $", Platform: {Platform}, Link: {MeetingLink}";
    }
}