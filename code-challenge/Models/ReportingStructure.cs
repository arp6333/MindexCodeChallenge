using System.ComponentModel.DataAnnotations;

namespace challenge.Models
{
    /// <summary>
    /// Model for a reporting structure object.
    /// </summary>
    public class ReportingStructure
    {
        /// <summary>
        /// The id of the employee for this reporting structure used as a key.
        /// </summary>
        [Key]
        public string EmployeeId { get; set; }

        /// <summary>
        /// The employee requested.
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// The number of directReports the Employee has.
        /// </summary>
        public int NumberOfReports { get; set; }
    }
}
