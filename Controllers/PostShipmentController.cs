using Microsoft.AspNetCore.Mvc;
using backend.Services;
using backend.DTOs;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/post-shipment")]
    public class PostShipmentController : ControllerBase
    {
        private readonly PostShipmentService _service;

        public PostShipmentController(PostShipmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] string status = "all", [FromQuery] string search = "")
        {
            return Ok(_service.GetAll(status, search));
        }

        [HttpPost("draft")]
        public IActionResult SaveDraft([FromBody] CreatePostShipmentDto dto)
        {
            _service.SaveDraft(dto);
            return Ok(new { message = "Post-shipment draft saved" });
        }

        [HttpPost("submit")]
        public IActionResult Submit([FromBody] CreatePostShipmentDto dto)
        {
            _service.Submit(dto);
            return Ok(new { message = "Post-shipment submitted" });
        }
    }
}
