using GraduateTraineeEnrollmentApi.Data.Contract;
using GraduateTraineeEnrollmentApi.Dtos;
using GraduateTraineeEnrollmentApi.Models;
using GraduateTraineeEnrollmentApi.Services.Contract;

namespace GraduateTraineeEnrollmentApi.Services.Imlementation
{
    public class GraduateTraineeService : IGraduateTraineeService
    {
        private readonly IGraduateTraineeRepository _repository;
        public GraduateTraineeService(IGraduateTraineeRepository traineeRepository)
        {
            _repository = traineeRepository;
        }
        public ServiceResponse<IEnumerable<GraduateTraineeDto>> GetGraduateTrainee()
        {
            var response = new ServiceResponse<IEnumerable<GraduateTraineeDto>>();
            var graduates = _repository.GetAll();
            if (graduates != null && graduates.Any())
            {
                graduates.Where(c => c.Image == string.Empty).ToList();
                List<GraduateTraineeDto> graduateTraineeDtos = new List<GraduateTraineeDto>();
                foreach (var grads in graduates.ToList())
                {
                    graduateTraineeDtos.Add(
                        new GraduateTraineeDto()
                        {
                            GraduateTraineeId = grads.GraduateTraineeId,
                            DegreeId = (int)grads.DegreeId,
                            StreamId = (int)grads.StreamId,
                            TraineeName = grads.TraineeName,
                            TraineeEmail = grads.TraineeEmail,
                            UniversityName = grads.UniversityName,
                            IsLastSemesterPending = grads.IsLastSemesterPending,
                            Gender = grads.Gender,
                            DateOfApplication = grads.DateOfApplication,
                            Image = grads.Image,
                            Ai = grads.Ai,
                            Phyton = grads.Phyton,
                            BusinessAnalysis = grads.BusinessAnalysis,
                            MachineLearning = grads.MachineLearning,
                            Practical = grads.Practical,
                            TotalMarks = grads.TotalMarks,
                            Percentages = grads.Percentages,
                            IsAdmisisonConfirmed = grads.IsAdmisisonConfirmed,
                            Degree = new Degree()
                            {
                                DegreeId = grads.Degree.DegreeId,
                                DegreeName = grads.Degree.DegreeName,
                                DegreeDescription = grads.Degree.DegreeDescription,
                            },
                            Stream = new Streams()
                            {
                                StreamId = grads.Stream.StreamId,
                                StreamName =grads.Stream.StreamName,
                                StreamDescription = grads.Stream.StreamDescription,
                            },
                        });
                }
                response.Data = graduateTraineeDtos;

            }
            else
            {
                response.Success = false;
                response.Message = "No record found";
            }

            return response;
        }
        public ServiceResponse<IEnumerable<TraineeEnrollmentReportResult>> TraineeReport()
        {
            var response = new ServiceResponse<IEnumerable<TraineeEnrollmentReportResult>>();
            var report = _repository.TraineeEnrollmentReport();
            if (report != null && report.Any())
            {
                List<TraineeEnrollmentReportResult> reports = new List<TraineeEnrollmentReportResult>();
                foreach (var rep in report)
                {
                    reports.Add(new TraineeEnrollmentReportResult()
                    {
                        DegreeName = rep.DegreeName,
                        StreamName = rep.StreamName,
                        TotalTraineeCount = rep.TotalTraineeCount,
                    });
                }
                response.Data = reports;
            }
            else
            {
                response.Success = false;
                response.Message = "No record found";
            }
            return response;
        }
        public ServiceResponse<GraduateTraineeDto> GetGraduateTrainee(int id)
        {
            var response = new ServiceResponse<GraduateTraineeDto>();
            var existingTrainee = _repository.GetGraduateTraineeById(id);

            if (existingTrainee != null)
            {
                var Trainee = new GraduateTraineeDto()
                {
                    GraduateTraineeId = existingTrainee.GraduateTraineeId,
                    DegreeId = (int)existingTrainee.DegreeId,
                    StreamId = (int)existingTrainee.StreamId,
                    TraineeName = existingTrainee.TraineeName,
                    TraineeEmail = existingTrainee.TraineeEmail,
                    UniversityName = existingTrainee.UniversityName,
                    IsLastSemesterPending = existingTrainee.IsLastSemesterPending,
                    Gender = existingTrainee.Gender,
                    DateOfApplication = existingTrainee.DateOfApplication,
                    Image = existingTrainee.Image,
                    Ai = existingTrainee.Ai,
                    Phyton = existingTrainee.Phyton,
                    BusinessAnalysis = existingTrainee.BusinessAnalysis,
                    MachineLearning = existingTrainee.MachineLearning,
                    Practical = existingTrainee.Practical,
                    TotalMarks = existingTrainee.TotalMarks,
                    Percentages = existingTrainee.Percentages,
                    IsAdmisisonConfirmed = existingTrainee.IsAdmisisonConfirmed,
                    Degree = new Degree()
                    {
                        DegreeId = existingTrainee.Degree.DegreeId,
                        DegreeName = existingTrainee.Degree.DegreeName,
                        DegreeDescription = existingTrainee.Degree.DegreeDescription,
                    },
                    Stream = new Streams()
                    {
                        StreamId = existingTrainee.Stream.StreamId,
                        StreamName = existingTrainee.Stream.StreamName,
                        StreamDescription = existingTrainee.Stream.StreamDescription,
                    },
                };
                response.Data = Trainee;
            }

            else
            {
                response.Success = false;
                response.Message = "No records found";
            }

            return response;
        }
        public ServiceResponse<string> AddGraduateTrainee(GraduateTrainees trainee)
        {
            var response = new ServiceResponse<string>();
            if (_repository.GraduateTraineeExists(trainee.TraineeEmail))
            {
                response.Success = false;
                response.Message = "Graduate traainee already exists.";
                return response;
            }
            if(_repository.IsDateValid(trainee.DateOfApplication))
            {
                response.Success = false;
                response.Message = "Date of application cannot be of future.";
                return response;
            }

            if (!trainee.IsLastSemesterPending)
            {
                if (trainee.Ai == null || trainee.Phyton == null || trainee.BusinessAnalysis == null || trainee.MachineLearning == null || trainee.Practical == null)
                {
                    response.Success = false;
                    response.Message = "Marks are required.";
                    return response;
                }
            }

            if (trainee.IsLastSemesterPending)
            {
                trainee.Ai = null;
                trainee.Phyton = null;
                trainee.BusinessAnalysis = null;
                trainee.MachineLearning = null;
                trainee.Practical = null;
            }

            trainee.TotalMarks = trainee.Ai + trainee.Phyton + trainee.BusinessAnalysis + trainee.MachineLearning + trainee.Practical;
            trainee.Percentages = (trainee.TotalMarks * 100) / 500;

            if (!trainee.IsLastSemesterPending)
            {
                if (trainee.Percentages >= 60)
                {
                    trainee.IsAdmisisonConfirmed = true;
                }
                else
                {
                    trainee.IsAdmisisonConfirmed = false;
                }
            }
            
            var fileName = string.Empty;
            //trainee.FileName = fileName;
            var result = _repository.InsertGraduateTrainee(trainee);
            if (result)
            {
                //response.Success = true;
                response.Message = "Graduate trainee saved successfully.";
            }
            else
            {
                response.Success = false;
                response.Message = "Something went wrong, please try after sometime.";
            }
            return response;
        }
        public ServiceResponse<string> ModifyTrainee(GraduateTrainees trainee)
        {
            var response = new ServiceResponse<string>();

            if (_repository.GraduateTraineeExists(trainee.GraduateTraineeId, trainee.TraineeEmail))
            {
                response.Success = false;
                response.Message = "Graduate trainee already exists.";
                return response;
            }
            if (!trainee.IsLastSemesterPending)
            {
                if (trainee.Ai == null || trainee.Phyton == null || trainee.BusinessAnalysis == null || trainee.MachineLearning == null || trainee.Practical == null)
                {
                    response.Success = false;
                    response.Message = "Marks are required.";
                    return response;
                }
            }
            if (_repository.IsDateValid(trainee.DateOfApplication))
            {
                response.Success = false;
                response.Message = "Date of application cannot be of future.";
                return response;
            }
            if (trainee.IsLastSemesterPending)
            {
                trainee.Ai = null;
                trainee.Phyton = null;
                trainee.BusinessAnalysis = null;
                trainee.MachineLearning = null;
                trainee.Practical = null;
            }
            trainee.TotalMarks = trainee.Ai + trainee.Phyton + trainee.BusinessAnalysis + trainee.MachineLearning + trainee.Practical;
            trainee.Percentages = (trainee.TotalMarks * 100) / 500;
            if (!trainee.IsLastSemesterPending)
            {
                if (trainee.Percentages >= 60)
                {
                    trainee.IsAdmisisonConfirmed = true;
                }
                else
                {
                    trainee.IsAdmisisonConfirmed = false;
                }
            }
            var existingtrainee = _repository.GetGraduateTraineeById(trainee.GraduateTraineeId);
            var result = false;
            if (existingtrainee != null)
            {
                existingtrainee.DegreeId = trainee.DegreeId;
                existingtrainee.StreamId = trainee.StreamId;
                existingtrainee.TraineeName = trainee.TraineeName;
                existingtrainee.TraineeEmail = trainee.TraineeEmail;
                existingtrainee.UniversityName = trainee.UniversityName;
                existingtrainee.IsLastSemesterPending = trainee.IsLastSemesterPending;
                existingtrainee.Gender = trainee.Gender;
                existingtrainee.DateOfApplication = trainee.DateOfApplication;
                existingtrainee.Image = trainee.Image;
                existingtrainee.Ai = trainee.Ai;
                existingtrainee.Phyton = trainee.Phyton;
                existingtrainee.BusinessAnalysis = trainee.BusinessAnalysis;
                existingtrainee.MachineLearning = trainee.MachineLearning;
                existingtrainee.Practical = trainee.Practical;
                existingtrainee.TotalMarks = trainee.TotalMarks;
                existingtrainee.Percentages = trainee.Percentages;
                existingtrainee.IsAdmisisonConfirmed = trainee.IsAdmisisonConfirmed;
                result = _repository.UpdateGraduateTrainee(existingtrainee);
            }
            if (result)
            {

                response.Message = "Graduate trainee updated successfully.";
            }
            else
            {
                response.Success = false;
                response.Message = "Something went wrong, please try after sometime.";
            }

            return response;
        }
        public ServiceResponse<string> RemoveTrainee(int id)
        {
            var response = new ServiceResponse<string>();
            var result = _repository.DeleteGraduateTrainee(id);
            if (result)
            {

                response.Message = "Graduate trainee deleted successfully.";
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
