using GraduateTraineeEnrollmentApi.Dtos;
using GraduateTraineeEnrollmentApi.Models;
using GraduateTraineeEnrollmentApi.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduateTraineeEnrollmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DegreeController : ControllerBase
    {
        private readonly IDegreeService _degreeService;
        public DegreeController(IDegreeService degreeService)
        {
            _degreeService = degreeService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllDegrees()
        {
            var response = _degreeService.GetDegrees();
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("GetDegreeById/{id}")]
        public IActionResult GetDegreeById(int id)
        {
            var response = _degreeService.GetDegree(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost("Create")]
        public IActionResult AddDegree(AddDegreeDto degreeDto)
        {
            if (ModelState.IsValid)
            {
                var degree = new Degree()
                {
                    DegreeName = degreeDto.DegreeName,
                    DegreeDescription = degreeDto.DegreeDescription,
                };
                var result = _degreeService.AddDegree(degree);
                return !result.Success ? BadRequest(result) : Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        //[Authorize]
        [HttpPut("ModifyDegree")]
        public IActionResult UpdateDegree(UpdateDegreeDto degreeDto)
        {
            var degree = new Degree()
            {
                DegreeId = degreeDto.DegreeId,
                DegreeName = degreeDto.DegreeName,
                DegreeDescription = degreeDto.DegreeDescription,
            };
            var response = _degreeService.ModifyDegree(degree);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpDelete("Remove/{id}")]
        public IActionResult RemoveCategory(int id)
        {
            if (id > 0)
            {
                var response = _degreeService.RemoveDegree(id);
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
