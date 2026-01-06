using Microsoft.AspNetCore.Mvc;
using backend.Services;
using backend.DTOs;

namespace backend.Controllers;

[ApiController]
[Route("api/pre-shipment")]
public class PreShipmentController : ControllerBase
{
    private readonly PreShipmentService _service;

    public PreShipmentController(PreShipmentService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll(
        [FromQuery] string? status,
        [FromQuery] string? search)
    {
        return Ok(_service.GetAll(status, search));
    }

    [HttpPost("draft")]
    public IActionResult SaveDraft([FromBody] CreatePreShipmentDto dto)
    {
        var refNo = _service.Create(dto, "Draft");
        return Ok(new { facilityRef = refNo });
    }

    [HttpPost("submit")]
    public IActionResult Submit([FromBody] CreatePreShipmentDto dto)
    {
        var refNo = _service.Create(dto, "Active");
        return Ok(new { facilityRef = refNo });
    }
}
