using GraduateTraineeEnrollmentApi.Data.Contract;
using GraduateTraineeEnrollmentApi.Dtos;
using GraduateTraineeEnrollmentApi.Models;
using GraduateTraineeEnrollmentApi.Services.Contract;

namespace GraduateTraineeEnrollmentApi.Services.Imlementation
{
    public class StreamService : IStreamService
    {
        private readonly IStreamRepository _streamRepository;
        public StreamService(IStreamRepository streamRepository)
        {
            _streamRepository = streamRepository;   
        }
        public ServiceResponse<IEnumerable<StreamDto>> GetPaginatedStreams(int page, int pageSize)
        {
            var response = new ServiceResponse<IEnumerable<StreamDto>>();
            var positions = _streamRepository.GetPaginatedStream(page, pageSize);
            if (positions != null && positions.Any())
            {
                List<StreamDto> positionDtos = new List<StreamDto>();
                foreach (var position in positions.ToList())
                {
                    positionDtos.Add(new StreamDto()
                    {
                        StreamId = position.StreamId,
                        StreamName = position.StreamName,
                        StreamDescription = position.StreamDescription,
                        DegreeId = position.DegreeId,
                        Degree = new Models.Degree()
                        {
                            DegreeId = (int)position.DegreeId,
                            DegreeName = position.Degree.DegreeName,
                            DegreeDescription = position.Degree.DegreeDescription,
                        }
                    });
                }
                response.Data = positionDtos;
                response.Success = true;
                response.Message = "Success";
            }
            else
            {
                response.Success = false;
                response.Message = "No record found";
            }
            return response;
        }
        public ServiceResponse<int> TotalStreams()
        {
            var response = new ServiceResponse<int>();
            int totalPositions = _streamRepository.TotalNoOfStreams();
            response.Data = totalPositions;
            response.Success = true;
            response.Message = "Paginated";
            return response;
        }
        public ServiceResponse<int> TotalNoOfStream()
        {
            var response = new ServiceResponse<int>();
            int totalStreams = _streamRepository.TotalNoOfStreams();

            response.Data = totalStreams;
            response.Success = true;
            response.Message = "Success";

            return response;
        }
        public ServiceResponse<IEnumerable<StreamDto>> GetAllStreams()
        {
            var response = new ServiceResponse<IEnumerable<StreamDto>>();

            var streams = _streamRepository.GetAllStreams();

            if (streams == null)
            {
                response.Success = false;
                response.Data = new List<StreamDto>();
                response.Message = "No record found.";
                return response;
            }

            List<StreamDto> streamDtos = new List<StreamDto>();

            foreach (var stream in streams.ToList())
            {
                streamDtos.Add(new StreamDto()
                {
                    StreamId = stream.StreamId,
                    StreamName = stream.StreamName,
                    StreamDescription = stream.StreamDescription,
                    Degree = new Models.Degree()
                    {
                        DegreeId = stream.Degree.DegreeId,
                        DegreeName = stream.Degree.DegreeName,
                        DegreeDescription = stream.Degree.DegreeDescription,
                    }
                });
            }

            response.Data = streamDtos;
            return response;
        }
        public ServiceResponse<IEnumerable<StreamDto>> GetStreamsByDegreeId(int id)
        {
            var response = new ServiceResponse<IEnumerable<StreamDto>>();
            var streams = _streamRepository.GetStreamsByDegreeId(id);

            if (streams != null && streams.Any())
            {
                var streamDtos = new List<StreamDto>();
                foreach (var stream in streams)
                {
                    streamDtos.Add(new StreamDto()
                    {
                        StreamId = stream.StreamId,
                        StreamName = stream.StreamName,
                        StreamDescription = stream.StreamDescription,
                        DegreeId = stream.DegreeId
                    });
                }
                response.Data = streamDtos;
            }
            else
            {
                response.Success = false;
                response.Message = "No record found";
            }
            return response;
        }
        public ServiceResponse<StreamDto> GetStreamById(int id)
        {
            var response = new ServiceResponse<StreamDto>();

            var stream = _streamRepository.GetStreamById(id);

            var streamDto = new StreamDto()
            {
                StreamId = stream.StreamId,
                StreamName = stream.StreamName,
                StreamDescription = stream.StreamDescription,
                DegreeId = stream.DegreeId,
                Degree = new Degree()
                {
                    DegreeId = stream.Degree.DegreeId,
                    DegreeName = stream.Degree.DegreeName,
                    DegreeDescription = stream.Degree.DegreeDescription,
                },
            };

            response.Data = streamDto;
            return response;
        }
        public ServiceResponse<string> AddStream(Streams stream)
        {
            var response = new ServiceResponse<string>();
            if (_streamRepository.StreamExists(stream.StreamName, (int)stream.DegreeId))
            {
                response.Success = false;
                response.Message = "Stream already exists.";
                return response;
            }
            var result = _streamRepository.InsertStream(stream);
            if (result)
            {
                //response.Success = true;
                response.Message = "Stream saved successfully.";
            }

            else
            {
                response.Success = false;
                response.Message = "Something went wrong, please try after sometime.";
            }
            return response;
        }
        public ServiceResponse<string> ModifyStream(Streams streams)
        {
            var response = new ServiceResponse<string>();

            if (_streamRepository.StreamExists(streams.StreamId, streams.StreamName, (int)streams.DegreeId))
            {
                response.Success = false;
                response.Message = "Stream already exists.";
                return response;
            }
            var existingStream = _streamRepository.GetStreamById(streams.StreamId);
            var result = false;
            if (existingStream != null)
            {
                existingStream.DegreeId = streams.DegreeId;
                existingStream.StreamName = streams.StreamName;
                existingStream.StreamDescription = streams.StreamDescription;
                result = _streamRepository.UpdateStream(existingStream);
            }
            if (result)
            {
                response.Message = "Stream updated successfully.";
            }
            else
            {
                response.Success = false;
                response.Message = "Something went wrong, please try after sometime.";
            }
            return response;
        }
        public ServiceResponse<string> RemoveStream(int id)
        {
            var response = new ServiceResponse<string>();
            var result = _streamRepository.DeleteStream(id);
            if (result)
            {

                response.Message = "Stream deleted successfully.";
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
