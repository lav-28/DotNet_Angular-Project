using GraduateTraineeEnrollmentApi.Dtos;
using GraduateTraineeEnrollmentApi.Models;

namespace GraduateTraineeEnrollmentApi.Services.Contract
{
    public interface IGraduateTraineeService
    {
        ServiceResponse<IEnumerable<GraduateTraineeDto>> GetGraduateTrainee();
        ServiceResponse<GraduateTraineeDto> GetGraduateTrainee(int id);
        ServiceResponse<string> AddGraduateTrainee(GraduateTrainees trainee);
        ServiceResponse<string> ModifyTrainee(GraduateTrainees trainee);
        ServiceResponse<IEnumerable<TraineeEnrollmentReportResult>> TraineeReport();
        ServiceResponse<string> RemoveTrainee(int id);
    }
}
