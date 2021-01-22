using System.Linq;
using System.Threading.Tasks;
using challenge.Models;
using Microsoft.Extensions.Logging;
using challenge.Data;

namespace challenge.Repositories
{
    /// <summary>
    /// The repository for compensation.
    /// </summary>
    public class CompensationRepository : ICompensationRepository
    {
        private readonly CompensationContext _compensationContext;
        private readonly EmployeeContext _employeeContext;
        private readonly ILogger<ICompensationRepository> _logger;

        /// <summary>
        /// Create a new compensation repository.
        /// </summary>
        /// <param name="logger">Logger object.</param>
        /// <param name="compensationContext">Compensation context.</param>
        /// <param name="employeeContext">Employee context.</param>
        public CompensationRepository(ILogger<ICompensationRepository> logger, CompensationContext compensationContext, EmployeeContext employeeContext)
        {
            _compensationContext = compensationContext;
            _employeeContext = employeeContext;
            _logger = logger;
        }

        /// <summary>
        /// Add a new compensation.
        /// </summary>
        /// <param name="id">Compensation object to create.</param>
        /// <returns>Result of the post request.</returns>
        public Compensation Add(Compensation compensation)
        {
            // Make sure the employee is set
            compensation.Employee = _employeeContext.Employees.FirstOrDefault(employee => employee.EmployeeId.Equals(compensation.Employee.EmployeeId));
            _compensationContext.Compensations.Add(compensation);
            return compensation;
        }

        /// <summary>
        /// Get a compensation by id.
        /// </summary>
        /// <param name="id">Employee id to use.</param>
        /// <returns>Compensation retrieved.</returns>
        public Compensation GetById(string id)
        {
            return _compensationContext.Compensations.AsEnumerable().Where(compensation => compensation.EmployeeId.Equals(id)).SingleOrDefault();
        }

        /// <summary>
        /// Saves changes asynchronously.
        /// </summary>
        /// <returns>Save task.</returns>
        public Task SaveAsync()
        {
            return _compensationContext.SaveChangesAsync();
        }
    }
}
