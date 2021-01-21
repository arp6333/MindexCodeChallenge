using challenge.Models;
using System.Threading.Tasks;

namespace challenge.Repositories
{
    public interface IEmployeeRepository
    {
        Employee GetById(string id);
        Employee Add(Employee employee);
        Employee Remove(Employee employee);
        Task SaveAsync();

        /// <summary>
        /// Get a reporting structure by a given employee id.
        /// </summary>
        /// <param name="id">Id of the employee to use.</param>
        /// <returns>The data structure for the given employee id.</returns>
        ReportingStructure GetReportingStructureById(string id);
    }
}