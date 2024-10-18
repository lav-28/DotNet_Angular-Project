using GraduateTraineeEnrollmentApi.Dtos;
using GraduateTraineeEnrollmentApi.Models;
using GraduateTraineeEnrollmentApi.Services.Contract;
using GraduateTraineeEnrollmentApi.Services.Imlementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduateTraineeEnrollmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraduateTraineeController : ControllerBase
    {
        private readonly IGraduateTraineeService _traineeService;
        public GraduateTraineeController(IGraduateTraineeService traineeService)
        {
            _traineeService = traineeService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var response = _traineeService.GetGraduateTrainee();
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetGraduateTraineeById(int id)
        {
            var response = _traineeService.GetGraduateTrainee(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpPost("AddTrainee")]
        public IActionResult AddGraduateTrainee(AddGraduateTraineeDto traineeDto)
        {
            if (ModelState.IsValid)
            {
                var trainee = new GraduateTrainees()
                {
                    DegreeId = traineeDto.DegreeId,
                    StreamId = traineeDto.StreamId,
                    TraineeName = traineeDto.TraineeName,
                    TraineeEmail = traineeDto.TraineeEmail,
                    UniversityName = traineeDto.UniversityName,
                    IsLastSemesterPending = traineeDto.IsLastSemesterPending,
                    Gender = traineeDto.Gender,
                    DateOfApplication = traineeDto.DateOfApplication,
                    Image = traineeDto.Image,
                    Ai = traineeDto.Ai,
                    Phyton = traineeDto.Phyton,
                    BusinessAnalysis = traineeDto.BusinessAnalysis,
                    MachineLearning = traineeDto.MachineLearning,
                    Practical = traineeDto.Practical,
                    TotalMarks = traineeDto.TotalMarks,
                    Percentages = traineeDto.Percentages,
                    IsAdmisisonConfirmed = traineeDto.IsAdmisisonConfirmed,
                };
               
                var result = _traineeService.AddGraduateTrainee(trainee);
                return !result.Success ? BadRequest(result) : Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
        //[Authorize]
        [HttpPut("UpdateTrainee")]
        public IActionResult UpdateGraduatrainee(UpdateGraduateTraineeDto trineeDto)
        {
            var traine = new GraduateTrainees()
            {
                GraduateTraineeId = trineeDto.GraduateTraineeId,
                DegreeId = trineeDto.DegreeId,
                StreamId = trineeDto.StreamId,
                TraineeName = trineeDto.TraineeName,
                TraineeEmail = trineeDto.TraineeEmail,
                UniversityName = trineeDto.UniversityName,
                IsLastSemesterPending = trineeDto.IsLastSemesterPending,
                Gender = trineeDto.Gender,
                DateOfApplication = trineeDto.DateOfApplication,
                Image = trineeDto.Image,
                Ai = trineeDto.Ai,
                Phyton = trineeDto.Phyton,
                BusinessAnalysis = trineeDto.BusinessAnalysis,
                MachineLearning = trineeDto.MachineLearning,
                Practical = trineeDto.Practical,
                TotalMarks = trineeDto.TotalMarks,
                Percentages = trineeDto.Percentages,
                IsAdmisisonConfirmed = trineeDto.IsAdmisisonConfirmed,
            };
            
            var response = _traineeService.ModifyTrainee(traine);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            else
            {
                return Ok(response);
            }
        }
        [HttpGet("GetTraineeEnrollmentReport")]
        public IActionResult TraineeReport()
        {
            var response = _traineeService.TraineeReport();
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpDelete("Remove/{id}")]
        public IActionResult RemoveGraduateTrainee(int id)
        {
            if (id > 0)
            {
                var response = _traineeService.RemoveTrainee(id);
                if (!response.Success)
                {
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            else
            {
                return BadRequest("Please enter proper data.");
            }
        }
    }
}
