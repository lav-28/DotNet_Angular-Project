using GraduateTraineeEnrollmentApi.Models;
using System.ComponentModel.DataAnnotations;

namespace GraduateTraineeEnrollmentApi.Dtos
{
    public class StreamDto
    {
        [Key]
        public int StreamId { get; set; }
        [Required]
        public string StreamName { get; set; }
        public string StreamDescription { get; set; }
        [Required]
        public int? DegreeId { get; set; }

        public virtual Degree Degree { get; set; }
        public virtual ICollection<GraduateTrainees> GraduateTrainees { get; set; }
    }
}
