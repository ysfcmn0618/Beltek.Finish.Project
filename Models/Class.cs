namespace Beltek.Finish.Project.Models
{
    public class Class
    {
        public Class()
        {
            Students = new List<Student>();
        }

        public virtual ICollection<Student> Students { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int ClassQuota { get; set; }
    }
}