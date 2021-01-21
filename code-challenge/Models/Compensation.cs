using System;
using System.ComponentModel.DataAnnotations;

namespace challenge.Models
{
    /// <summary>
    /// Model for a compensation object.
    /// </summary>
    public class Compensation
    {
        /// <summary>
        /// The id for this compensation used as a key.
        /// Currently, not set as it is not needed for the task.
        /// </summary>
        [Key]
        public int CompensationId { get; set; }

        /// <summary>
        /// The employee requested.
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// The salary of the compensation.
        /// </summary>
        public double Salary { get; set; }

        /// <summary>
        /// The effective date of the compensation.
        /// </summary>
        public DateTime EffectiveDate { get; set; }
    }
}
