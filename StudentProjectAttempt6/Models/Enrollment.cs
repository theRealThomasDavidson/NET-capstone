using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;


namespace StudentProjectAttempt6.Models
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public float Grade { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }

    }
}
