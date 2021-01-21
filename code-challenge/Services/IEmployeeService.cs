using challenge.Models;

namespace challenge.Services
{
    public interface IEmployeeService
    {
        Employee GetById(string id);
        Employee Create(Employee employee);
        Employee Replace(Employee originalEmployee, Employee newEmployee);

        /// <summary>
        /// Get a reporting structure by a given employee id.
        /// </summary>
        /// <param name="id">Id of the employee to use.</param>
        /// <returns>The data structure for the given employee id.</returns>
        ReportingStructure GetReportingStructureById(string id);
    }
}
