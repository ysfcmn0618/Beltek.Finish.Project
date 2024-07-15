using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Beltek.Finish.Project.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Öğrenci Adı gerekli bir alandır.")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Öğrenci Soyadı gerekli bir alandır.")]
        public string StudentSurname { get; set; }
        [Required(ErrorMessage = "Lütfen Öğrenci Numarasını Giriniz.")]
        public int StudentNumber { get; set; }
        public int ClassId { get; set; }
        [Required(ErrorMessage = "Her öğrenci bir sınıfa kayıt olmak zorundadır")]        
        public virtual Class Class { get; set; }

        public List<SelectListItem> classList = new List<SelectListItem>();

    }
}
