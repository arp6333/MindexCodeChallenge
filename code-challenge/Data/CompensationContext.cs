using challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace challenge.Data
{
    /// <summary>
    /// DbContext for compensation.
    /// </summary>
    public class CompensationContext : DbContext
    {
        /// <summary>
        /// Create a new compensation context.
        /// </summary>
        /// <param name="options">Context options.</param>
        public CompensationContext(DbContextOptions<CompensationContext> options) : base(options) { }

        /// <summary>
        /// Compensation database set.
        /// </summary>
        public DbSet<Compensation> Compensations { get; set; }
    }
}
