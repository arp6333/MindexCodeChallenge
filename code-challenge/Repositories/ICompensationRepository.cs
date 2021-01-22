using challenge.Models;
using System.Threading.Tasks;

namespace challenge.Repositories
{
    /// <summary>
    /// Interface for the compensation repository.
    /// </summary>
    public interface ICompensationRepository
    {
        /// <summary>
        /// Get a compensation object by employee id.
        /// </summary>
        /// <param name="id">Employee id to use.</param>
        /// <returns>Compensation for the given employee id.</returns>
        Compensation GetById(string id);

        /// <summary>
        /// Create a new compensation object.
        /// </summary>
        /// <param name="compensation">Compensation object to create.</param>
        /// <returns>Created compensation object.</returns>
        Compensation Add(Compensation compensation);

        /// <summary>
        /// Saves changes asynchronously.
        /// </summary>
        /// <returns>Save task.</returns>
        Task SaveAsync();
    }
}