using GraduateTraineeEnrollmentApi.Dtos;
using GraduateTraineeEnrollmentApi.Models;
using System.Collections.Generic;

namespace GraduateTraineeEnrollmentApi.Services.Contract
{
    public interface IStreamService
    {
        ServiceResponse<int> TotalStreams();
        ServiceResponse<IEnumerable<StreamDto>> GetPaginatedStreams(int page, int pageSize);
        ServiceResponse<int> TotalNoOfStream();
        ServiceResponse<IEnumerable<StreamDto>> GetStreamsByDegreeId(int id);
        ServiceResponse<IEnumerable<StreamDto>> GetAllStreams();
        ServiceResponse<StreamDto> GetStreamById(int id);
        ServiceResponse<string> AddStream(Streams stream);
        ServiceResponse<string> ModifyStream(Streams streams);
        ServiceResponse<string> RemoveStream(int id);
    }
}
