namespace Beltek.Finish.Project.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public int StudentNumber { get; set; }
        public int ClassId { get; set; }
        public virtual Class Class { get; set; }
    }
}
