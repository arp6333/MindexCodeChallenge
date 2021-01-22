using System.ComponentModel.DataAnnotations;

namespace challenge.Models
{
    /// <summary>
    /// Model for a reporting structure object.
    /// </summary>
    public class ReportingStructure
    {
        /// <summary>
        /// The employee id for this reporting structure used as a key.
        /// </summary>
        [Key]
        public int EmployeeId { get; set; }

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
