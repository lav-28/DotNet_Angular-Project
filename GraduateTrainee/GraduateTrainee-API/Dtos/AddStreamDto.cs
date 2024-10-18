using System.ComponentModel.DataAnnotations;

namespace GraduateTraineeEnrollmentApi.Dtos
{
    public class AddStreamDto
    {
        public int StreamId { get; set; }
        [Required]
        public string StreamName { get; set; }
        public string StreamDescription { get; set; }
        [Required]
        public int? DegreeId { get; set; }
    }
}
