using System.ComponentModel.DataAnnotations;

namespace challenge.Models
{
    /// <summary>
    /// Model for a reporting structure object.
    /// </summary>
    public class ReportingStructure
    {
        /// <summary>
        /// The id for this reporting structure used as a key.
        /// Currently, not set as it is not needed for the task.
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
