using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingsController : ControllerBase
    {
        private IMeetingService _meetingService;

        public MeetingsController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _meetingService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getmeetingdetails")]
        public IActionResult GetMeetingDetails()
        {
            var result = _meetingService.GetMeetingDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _meetingService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        /* 
        [HttpGet("getdetailbyid")]
        public IActionResult GetDetailById(int wpId)
        {
            var result = _meetingService.GetWeddingPlaceDetail(wpId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        */
        [HttpPost("add")]
        public IActionResult Add(Meeting meeting)
        {
            var result = _meetingService.Add(meeting);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("update")]
        public IActionResult Update(Meeting meeting)
        {
            var result = _meetingService.Update(meeting);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Meeting meeting)
        {
            var result = _meetingService.Delete(meeting);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
