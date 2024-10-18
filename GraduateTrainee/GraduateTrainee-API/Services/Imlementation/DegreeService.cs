using GraduateTraineeEnrollmentApi.Data.Contract;
using GraduateTraineeEnrollmentApi.Dtos;
using GraduateTraineeEnrollmentApi.Models;
using GraduateTraineeEnrollmentApi.Services.Contract;

namespace GraduateTraineeEnrollmentApi.Services.Imlementation
{
    public class DegreeService : IDegreeService
    {
        private readonly IDegreeRepository _degreeRepository;
        public DegreeService(IDegreeRepository degreeRepository)
        {
            _degreeRepository = degreeRepository;
        }
        public ServiceResponse<IEnumerable<DegreeDto>> GetDegrees()
        {
            var response = new ServiceResponse<IEnumerable<DegreeDto>>();
            var degrees = _degreeRepository.GetAll();

            if (degrees == null)
            {
                response.Success = false;
                response.Data = new List<DegreeDto>();
                response.Message = "No record found.";
                return response;
            }

            List<DegreeDto> degreeDtos = new List<DegreeDto>();
            foreach (var degree in degrees.ToList())
            {
                degreeDtos.Add(
                    new DegreeDto()
                    {
                        DegreeId = degree.DegreeId,
                        DegreeName = degree.DegreeName,
                        DegreeDescription = degree.DegreeDescription,
                    });

            }
            response.Data = degreeDtos;
            return response;
        }
        public ServiceResponse<DegreeDto> GetDegree(int degreeId)
        {
            var response = new ServiceResponse<DegreeDto>();
            var existingDegree = _degreeRepository.GetDegree(degreeId);
            if (existingDegree != null)
            {
                var degree = new DegreeDto()
                {
                    DegreeId = degreeId,
                    DegreeName = existingDegree.DegreeName,
                    DegreeDescription = existingDegree.DegreeDescription,
                    //GraduateTrainees = existingDegree.GraduateTrainees,
                    //Streams = existingDegree.Streams
                };
                response.Data = degree;
            }
            else
            {
                response.Success = false;
                response.Message = "No record found!";
            }
            return response;
        }
        public ServiceResponse<string> AddDegree(Degree degree)
        {
            var response = new ServiceResponse<string>();
            if (_degreeRepository.DegreeExists(degree.DegreeName))
            {
                response.Success = false;
                response.Message = "Degree already exists.";
                return response;
            }
            var result = _degreeRepository.InsertDegree(degree);
            if (result)
            {
                //response.Success = true;
                response.Message = "Degree saved successfully.";
            }

            else
            {
                response.Success = false;
                response.Message = "Something went wrong, please try after sometime.";
            }
            return response;
        }
        public ServiceResponse<string> ModifyDegree(Degree degree)
        {
            var response = new ServiceResponse<string>();

            if (_degreeRepository.DegreeExists(degree.DegreeId, degree.DegreeName))
            {
                response.Success = false;
                response.Message = "Degree already exists.";
                return response;
            }
            var existingDegree = _degreeRepository.GetDegree(degree.DegreeId);
            var result = false;
            if (existingDegree != null)
            {
                existingDegree.DegreeName = degree.DegreeName;
                existingDegree.DegreeDescription = degree.DegreeDescription;
                result = _degreeRepository.UpdateDegree(existingDegree);
            }
            if (result)
            {
                response.Message = "Degree updated successfully.";
            }
            else
            {
                response.Success = false;
                response.Message = "Something went wrong, please try after sometime.";
            }
            return response;
        }
        public ServiceResponse<string> RemoveDegree(int id)
        {
            var response = new ServiceResponse<string>();
            var result = _degreeRepository.DeleteDegree(id);
            if (result)
            {

                response.Message = "Degree deleted successfully.";
            }
            else
            {
                response.Success = false;
                response.Message = "Something went wrong, please try after sometimes.";
            }
            return response;
        }
    }
}
