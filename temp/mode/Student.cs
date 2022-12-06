using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StudentProjectAttempt6.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("GPA")]
        [Range(0, 4, ErrorMessage = "GPA must be between 0.0 and 4.0")]
        public float Grade { get; set; }

    }
}
