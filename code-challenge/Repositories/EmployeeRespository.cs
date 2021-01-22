using System;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;
using Microsoft.Extensions.Logging;
using challenge.Data;

namespace challenge.Repositories
{
    public class EmployeeRespository : IEmployeeRepository
    {
        private readonly EmployeeContext _employeeContext;
        private readonly ILogger<IEmployeeRepository> _logger;

        public EmployeeRespository(ILogger<IEmployeeRepository> logger, EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
            _logger = logger;
        }

        public Employee Add(Employee employee)
        {
            employee.EmployeeId = Guid.NewGuid().ToString();
            _employeeContext.Employees.Add(employee);
            return employee;
        }

        public Employee GetById(string id)
        {
            // Make sure the direct reports are being retrieved as well - otherwise they are returning as null
            return _employeeContext.Employees.AsEnumerable().Where(employee => employee.EmployeeId.Equals(id)).SingleOrDefault();
        }

        public Task SaveAsync()
        {
            return _employeeContext.SaveChangesAsync();
        }

        public Employee Remove(Employee employee)
        {
            return _employeeContext.Remove(employee).Entity;
        }

        /// <summary>
        /// Get a reporting structure by a given employee id.
        /// </summary>
        /// <param name="id">Id of the employee to use.</param>
        /// <returns>The data structure for the given employee id.</returns>
        public ReportingStructure GetReportingStructureById(string id)
        {
            // Make sure the requested employee is valid
            Employee employee = GetById(id);
            if (employee != null)
            {
                // Get the number of reports for this employee
                int numberOfReports = GetNumberOfReportsByEmployee(employee);
                return new ReportingStructure
                {
                    EmployeeId = id,
                    Employee = employee,
                    NumberOfReports = numberOfReports
                };
            }

            return null;
        }

        /// <summary>
        /// Recursively calculates the number of reports for a given employee.
        /// </summary>
        /// <param name="employee">The employee to use.</param>
        /// <returns>Number of reports for the given employee.</returns>
        private int GetNumberOfReportsByEmployee(Employee employee)
        {
            int numberOfReports = 0;

            // Check if this employee has any direct reports
            if (employee.DirectReports != null)
            {
                numberOfReports += employee.DirectReports.Count;
                foreach (Employee directReport in employee.DirectReports)
                {
                    // Call this function recursively to get the number of reports for each direct report
                    // Runs until we reach an employee with no direct reports
                    numberOfReports += GetNumberOfReportsByEmployee(directReport);
                }
            }

            return numberOfReports;
        }
    }
}
