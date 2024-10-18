using GraduateTraineeEnrollmentApi.Dtos;
using GraduateTraineeEnrollmentApi.Models;

namespace GraduateTraineeEnrollmentApi.Services.Contract
{
    public interface IDegreeService
    {
        ServiceResponse<IEnumerable<DegreeDto>> GetDegrees();
        ServiceResponse<DegreeDto> GetDegree(int degreeId);
        ServiceResponse<string> AddDegree(Degree degree);
        ServiceResponse<string> ModifyDegree(Degree degree);
        ServiceResponse<string> RemoveDegree(int id);
    }
}
