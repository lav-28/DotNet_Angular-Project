using GraduateTraineeEnrollmentApi.Models;

namespace GraduateTraineeEnrollmentApi.Data.Contract
{
    public interface IDegreeRepository
    {
        IEnumerable<Degree> GetAll();
        bool InsertDegree(Degree degree);
        bool UpdateDegree(Degree degree);
        bool DeleteDegree(int id);
        bool DegreeExists(string name);
        bool DegreeExists(int degreeId, string name);
        Degree? GetDegree(int id);
    }
}
