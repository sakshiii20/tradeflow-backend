using Microsoft.AspNetCore.Mvc;
using backend.Services;
using backend.DTOs;

namespace backend.Controllers;

[ApiController]
[Route("api/bill-discounting")]
public class BillDiscountingController : ControllerBase
{
    private readonly BillDiscountingService _service;

    public BillDiscountingController(BillDiscountingService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get(
        [FromQuery] string status = "all",
        [FromQuery] string search = "")
    {
        return Ok(_service.GetAll(status, search));
    }

    [HttpPost("draft")]
    public IActionResult Draft(CreateBillDiscountingDto dto)
    {
        return Ok(_service.Create(dto, "Draft"));
    }

    [HttpPost("submit")]
    public IActionResult Submit(CreateBillDiscountingDto dto)
    {
        return Ok(_service.Create(dto, "Active"));
    }
}
