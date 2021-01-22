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
        /// The employee id for this compensation used as a key.
        /// </summary>
        [Key]
        public int EmployeeId { get; set; }

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
