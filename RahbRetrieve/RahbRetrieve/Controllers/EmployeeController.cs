using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeRepository _employeeRepository;
    private readonly IConfiguration _configuration;

    public EmployeeController(EmployeeRepository employeeRepository, IConfiguration configuration)
    {
        _employeeRepository = employeeRepository;
        _configuration = configuration;
    }

    [HttpGet]
    public IActionResult GetAllEmployees()
    {
        var employees = _employeeRepository.GetAllEmployees();
        return Ok(employees);
    }
}