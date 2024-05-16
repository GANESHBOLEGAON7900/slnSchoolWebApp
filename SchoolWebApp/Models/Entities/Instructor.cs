namespace SchoolWebApp.Models.Entities
{
    public class Instructor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Password { get; set; }
        public int? CourseID { get; set; }
        public virtual Course Course { get; set; }
    }
}
