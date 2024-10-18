using GraduateTraineeEnrollmentApi.Models;

namespace GraduateTraineeEnrollmentApi.Data.Contract
{
    public interface IGraduateTraineeRepository
    {
        GraduateTrainees? GetGraduateTraineeById(int id);
        bool InsertGraduateTrainee(GraduateTrainees trainee);
        bool UpdateGraduateTrainee(GraduateTrainees trainee);
        bool GraduateTraineeExists(string name);
        bool GraduateTraineeExists(int graduateTraineeId, string name);
        IEnumerable<GraduateTrainees> GetAll();
        bool IsDateValid(DateTime dateTime);
        bool IsLastSemsterPending(bool res);
        IEnumerable<TraineeEnrollmentReportResult> TraineeEnrollmentReport();
        bool DeleteGraduateTrainee(int id);
    }
}
