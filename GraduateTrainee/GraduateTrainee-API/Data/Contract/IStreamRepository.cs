using GraduateTraineeEnrollmentApi.Models;
using Microsoft.Exchange.WebServices.Data;

namespace GraduateTraineeEnrollmentApi.Data.Contract
{
    public interface IStreamRepository
    {
        IEnumerable<Streams> GetPaginatedStream(int page, int pageSize);
        IEnumerable<Streams> GetStreamsByDegreeId(int id);
        int TotalNoOfStreams();
        IEnumerable<Streams> GetAllStreams();
        Streams GetStreamById(int id);
        bool InsertStream(Streams stream);
        bool UpdateStream(Streams stream);
        bool DeleteStream(int id);
        bool StreamExists(string name, int degreeId);
        bool StreamExists(int categoryId, string name, int degreeId);
    }
}
