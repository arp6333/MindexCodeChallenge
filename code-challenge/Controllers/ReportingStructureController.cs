using challenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace challenge.Controllers
{
    [Route("api/reportingstructure")]
    public class ReportingStructureController : Controller
    {
        private readonly ILogger _logger;
        private readonly IEmployeeService _employeeService;

        /// <summary>
        /// Create a new reporting structure controller.
        /// </summary>
        /// <param name="logger">Allow logging messages.</param>
        /// <param name="employeeService">Employee service to use.</param>
        public ReportingStructureController(ILogger<ReportingStructureController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        /// <summary>
        /// Handle a GetReportingStructureById request.
        /// </summary>
        /// <param name="id">Employee id to use.</param>
        /// <returns>Result of the get request.</returns>
        [HttpGet("{id}", Name = "getReportingStructureById")]
        public IActionResult GetReportingStructureById(string id)
        {
            _logger.LogDebug($"Received reporting structure get request for employee '{id}'");

            var reportingStructure = _employeeService.GetReportingStructureById(id);

            if (reportingStructure == null)
                return NotFound();

            return Ok(reportingStructure);
        }
    }
}
