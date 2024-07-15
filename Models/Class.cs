using System.ComponentModel.DataAnnotations;

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
        [StringLength(15, ErrorMessage = "En fazla 15 karakter girebilirsiniz.")]
        public string ClassName { get; set; }
        public int ClassQuota { get; set; }
    }
}