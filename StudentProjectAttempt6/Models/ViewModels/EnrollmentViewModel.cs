using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace StudentProjectAttempt6.Models.ViewModels
{
    public class EnrollmentViewModel
    {
        public Enrollment Enrollment { get; set; }

        public IEnumerable<SelectListItem> StudentsList;
    }
}
