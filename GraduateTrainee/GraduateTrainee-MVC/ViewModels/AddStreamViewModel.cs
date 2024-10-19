using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GraduateTraineeEnrollmentMVC.ViewModels
{
    public class AddStreamViewModel
    {
        public int StreamId { get; set; }
        [Required(ErrorMessage ="Stream name is required")]
        [DisplayName("Stream name")]
        public string StreamName { get; set; }
        [Required(ErrorMessage = "Stream description is required")]
        [DisplayName("Stream description")]
        public string StreamDescription { get; set; }
        [Required]
        public int? DegreeId { get; set; }
        public List<DegreeViewModel>? DegreeList { get; set; }
    }
}
