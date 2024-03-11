using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingDocumentsController : ControllerBase
    {
        //IoC --> Inversion of Control
        private IMeetingDocumentService _meetingDocumentService;

        public MeetingDocumentsController(IMeetingDocumentService meetingDocumentService)
        {
            _meetingDocumentService = meetingDocumentService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _meetingDocumentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _meetingDocumentService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getdocumentsbymeetingid")]
        public IActionResult GetDocumentByUserId(int id)
        {
            var result = _meetingDocumentService.GetDocumentByMeetingId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile[] files, [FromForm] int meetingId)
        {
            var result = _meetingDocumentService.Add(files, new MeetingDocument { MeetingId = meetingId});
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("download")]
        public IActionResult Download(int id)
        {
            var result = _meetingDocumentService.GetDocumentByMeetingId(id);
            string zipPath;
            if (result.Success)
            {
                zipPath = result.Data.DocumentPath;
                if(result.Data.DocumentPath != null)
                {
                    return Ok(zipPath);

                }
                else
                {
                    return BadRequest(result);
                }
            }
            return BadRequest(result);
        }


        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("MeetingDocument"))] IFormFile[] files, [FromForm(Name = ("Id"))] int id)
        {
            var meetingDocument = _meetingDocumentService.GetById(id).Data;
            var result = _meetingDocumentService.Update(meetingDocument, files);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(MeetingDocument meetingDocument)
        {
            var result = _meetingDocumentService.Delete(meetingDocument);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
