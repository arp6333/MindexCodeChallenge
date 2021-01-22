using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using challenge.Services;
using challenge.Models;

namespace challenge.Controllers
{
    /// <summary>
    /// Controller for compensation.
    /// </summary>
    [Route("api/compensation")]
    public class CompensationController : Controller
    {
        private readonly ILogger _logger;
        private readonly ICompensationService _compensationService;

        /// <summary>
        /// Create a new compensation controller.
        /// </summary>
        /// <param name="logger">Logging object.</param>
        /// <param name="compensationService">Compensation service to use.</param>
        public CompensationController(ILogger<CompensationController> logger, ICompensationService compensationService)
        {
            _logger = logger;
            _compensationService = compensationService;
        }

        /// <summary>
        /// Handle a CreateCompensation request.
        /// </summary>
        /// <param name="id">Compensation object to create.</param>
        /// <returns>Result of the post request.</returns>
        [HttpPost]
        public IActionResult CreateCompensation([FromBody] Compensation compensation)
        {
            // Make sure required compensation fields are provided
            if (string.IsNullOrEmpty(compensation.Employee.EmployeeId))
            {
                string errorText = "Missing required employee id for the compensation create request";
                _logger.LogDebug(errorText);
                return BadRequest(errorText);
            }
            else
            {
                _logger.LogDebug($"Received compensation create request for '{compensation.Employee.EmployeeId}'");

                _compensationService.Create(compensation);

                return CreatedAtRoute("getCompensationById", new { id = compensation.Employee.EmployeeId }, compensation);
            }
        }

        /// <summary>
        /// Handle a GetCompensationById request.
        /// </summary>
        /// <param name="id">Employee id to use.</param>
        /// <returns>Result of the get request.</returns>
        [HttpGet("{id}", Name = "getCompensationById")]
        public IActionResult GetCompensationById(string id)
        {
            _logger.LogDebug($"Received compensation get request for '{id}'");
            
            Compensation compensation = _compensationService.GetById(id);

            if (compensation == null)
                return NotFound();

            return Ok(compensation);
        }
    }
}
