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
    //[Authorize]
    public class SteamController : ControllerBase
    {
        private readonly IStreamService _streamService;
        public SteamController(IStreamService streamService)
        {
            _streamService = streamService;
        }
        [HttpGet("GetAllStream")]
        public IActionResult GetAllStreams()
        {
            var response = _streamService.GetAllStreams();
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpGet("GetAllStreamByPagination")]
        public IActionResult GetAllStreamByPagination(int page = 1, int pageSize = 2)
        {
            var response = _streamService.GetPaginatedStreams(page, pageSize);
            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("StreamsCount")]
        public IActionResult GetTotalCountOfPositions()
        {
            var response = _streamService.TotalStreams();
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("GetStreamByDegreeId/{id}")]
        public IActionResult GetStreamByDegreeId(int id)
        {
            var response = _streamService.GetStreamsByDegreeId(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    /*    [HttpGet("GetTotalCountOfStreams")]
        public IActionResult GetTotalCountOfStreams()
        {
            var response = _streamService.TotalNoOfStream();
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }*/

        [HttpGet("GetStreamById/{id}")]
        public IActionResult GetStreamById(int id)
        {
            var response = _streamService.GetStreamById(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost("Create")]
        public IActionResult AddStream(AddStreamDto streamDto)
        {
            if (ModelState.IsValid)
            {
                var stream = new Streams()
                {
                    StreamName = streamDto.StreamName,
                    StreamDescription = streamDto.StreamDescription,
                    DegreeId = streamDto.DegreeId,
                };
                var result = _streamService.AddStream(stream);
                return !result.Success ? BadRequest(result) : Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("ModifyStream")]
        public IActionResult UpdateStream(UpdateStreamDto streamDto)
        {
            var stream = new Streams()
            {
                StreamId = streamDto.StreamId,
                StreamName = streamDto.StreamName,
                StreamDescription = streamDto.StreamDescription,
                DegreeId = streamDto.DegreeId,
            };
            var response = _streamService.ModifyStream(stream);
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
        public IActionResult RemoveStream(int id)
        {
            if (id > 0)
            {
                var response = _streamService.RemoveStream(id);
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
