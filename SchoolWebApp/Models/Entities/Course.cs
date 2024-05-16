namespace SchoolWebApp.Models.Entities
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? InstructorID { get; set; }
        public virtual Instructor Instructors { get; set; }

    }
}
