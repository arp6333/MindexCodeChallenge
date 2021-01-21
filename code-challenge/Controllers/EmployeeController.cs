using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using challenge.Services;
using challenge.Models;

namespace challenge.Controllers
{
    [Route("api/employee")]
    public class EmployeeController : Controller
    {
        private readonly ILogger _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            // Make sure employee first and last name are given
            if (string.IsNullOrEmpty(employee.FirstName))
            {
                string errorText = "Missing required employee first name for the employee create request";

                _logger.LogDebug(errorText);

                return BadRequest(errorText);
            }
            else if (string.IsNullOrEmpty(employee.LastName))
            {
                string errorText = "Missing required employee last name for the employee create request";

                _logger.LogDebug(errorText);

                return BadRequest(employee);
            }
            else
            {
                _logger.LogDebug($"Received employee create request for '{employee.FirstName} {employee.LastName}'");

                _employeeService.Create(employee);

                return CreatedAtRoute("getEmployeeById", new { id = employee.EmployeeId }, employee);
            }
        }

        [HttpGet("{id}", Name = "getEmployeeById")]
        public IActionResult GetEmployeeById(string id)
        {
            _logger.LogDebug($"Received employee get request for '{id}'");

            var employee = _employeeService.GetById(id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPut("{id}")]
        public IActionResult ReplaceEmployee(string id, [FromBody]Employee newEmployee)
        {
            _logger.LogDebug($"Recieved employee update request for '{id}'");

            var existingEmployee = _employeeService.GetById(id);
            if (existingEmployee == null)
                return NotFound();

            _employeeService.Replace(existingEmployee, newEmployee);

            return Ok(newEmployee);
        }
    }
}
