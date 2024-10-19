using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GraduateTraineeEnrollmentMVC.ViewModels
{
    public class AddDegreeViewModel
    {
        public int DegreeId { get; set; }
        [Required(ErrorMessage ="Degree name is required")]
        [DisplayName("Degree name")]
        public string DegreeName { get; set; }
        [Required(ErrorMessage = "Degree description is required")]
        [DisplayName("Degree description")]
        public string DegreeDescription { get; set; }
    }
}
